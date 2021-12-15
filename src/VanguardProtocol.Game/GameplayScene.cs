using System.Numerics;
using Microsoft.Xna.Framework.Graphics;
using VanguardProtocol.AI;
using VanguardProtocol.Audio;
using VanguardProtocol.Camera;
using VanguardProtocol.Combat;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Levels;
using VanguardProtocol.Levels.Campaign;
using VanguardProtocol.Physics;
using VanguardProtocol.Rendering;
using VanguardProtocol.SaveSystem;
using VanguardProtocol.UI.Hud;
using XnaColor = Microsoft.Xna.Framework.Color;
using XnaRectangle = Microsoft.Xna.Framework.Rectangle;

namespace VanguardProtocol.Game;

public enum RunState : byte
{
    Playing = 0,
    Paused = 1,
    Cleared = 2,
    GameOver = 3,
}

public sealed class GameplayScene : IScene
{
    private readonly Texture2D _pixel;
    private readonly SpriteBatch _spriteBatch;
    private readonly SfxManager _sfx;
    private readonly SaveSerializer _saves = new();
    private readonly ProgressTracker _progress;
    private readonly HighScoreTable _scores;
    private readonly SaveData _save;

    private readonly SystemScheduler _scheduler = new();
    private readonly PhysicsSystem _physics = new();
    private readonly PlayerInputSystem _input = new();
    private readonly WeaponSystem _weapons = new();
    private readonly ProjectileSystem _projectiles = new();
    private readonly ContactDamageSystem _contact = new();
    private readonly DamageSystem _damage = new();
    private readonly PickupSystem _pickups = new();
    private readonly AiSystem _ai = new();
    private readonly ParticleSystem _particles = new();
    private readonly ScrollingCamera _camera = new();
    private readonly ScreenShake _shake = new();
    private readonly HealthBar _healthBar = new() { Max = 3 };
    private readonly LivesCounter _livesHud = new() { Max = 5 };
    private readonly ScoreDisplay _scoreHud = new() { Max = 999999 };

    private LevelData _level = null!;
    private CollisionTilemap _collision = null!;
    private Entity _player;
    private Vector2 _checkpoint;
    private Vector2 _spawn;
    private int _lives = 3;
    private int _score;
    private float _clearTimer;
    private float _bannerPulse;
    private int _lastProjectileCount;
    private bool _wasOnGround = true;

    public GameplayScene(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SfxManager sfx, SaveData save)
    {
        _spriteBatch = spriteBatch;
        _sfx = sfx;
        _save = save;
        _progress = new ProgressTracker(save);
        _scores = new HighScoreTable(save);
        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData([XnaColor.White]);
        LoadLevel(Stage01ValeOutpost.Build());
    }

    public string Name => _level.Name;
    public RunState State { get; private set; } = RunState.Playing;
    public bool RequestTitle { get; private set; }

    public void Enter()
    {
        RequestTitle = false;
        State = RunState.Playing;
    }

    public void Exit()
    {
    }

    public void LoadLevel(LevelData level)
    {
        _level = level;
        _collision = LevelLoader.LoadCollision(level);
        _physics.SetTilemap(_collision);
        _projectiles.SetTilemap(_collision);
        _camera.ViewSize = new Vector2(640, 360);
        _camera.LevelBounds = new Vector2(level.Width * level.TileSize, level.Height * level.TileSize);
    }

    public void BuildWorld(World world)
    {
        world.Clear();
        _scheduler.Clear();
        _scheduler.Add(_input);
        _scheduler.Add(_ai);
        _scheduler.Add(_physics);
        _scheduler.Add(_weapons);
        _scheduler.Add(_projectiles);
        _scheduler.Add(_contact);
        _scheduler.Add(_pickups);

        State = RunState.Playing;
        _clearTimer = 0f;
        _score = 0;
        _lives = Math.Max(1, _save.LivesDefault);
        _healthBar.Max = 3;
        _livesHud.Max = 5;
        _livesHud.SetImmediate(_lives);
        _scoreHud.SetImmediate(0);
        _input.Reset();
        _wasOnGround = true;

        var spawn = _level.Spawns.Find(s => string.Equals(s.Type, "Player", StringComparison.OrdinalIgnoreCase))
                    ?? new EntitySpawn { Type = "Player", X = 48, Y = 200 };
        _spawn = new Vector2(spawn.X, spawn.Y);
        _checkpoint = _spawn;

        _player = CreatePlayer(world, _spawn);
        SpawnLevelEntities(world);

        _healthBar.SetImmediate(3);
        _lastProjectileCount = 0;
    }

    private Entity CreatePlayer(World world, Vector2 position)
    {
        var entity = world.CreateEntity();
        var size = new Vector2(14, 22);
        world.Add(entity, new Transform(position));
        world.Add(entity, new Velocity(Vector2.Zero));
        world.Add(entity, new RigidBody(size));
        world.Add(entity, new PlayerControlled(0));
        world.Add(entity, new DrawableRect(size.X, size.Y, 0xFFE8F0FF));
        world.Add(entity, new HealthComponent(3));
        world.Add(entity, new CameraFocus { Weight = 1f });
        world.Add(entity, new WeaponComponent
        {
            Definition = WeaponDefinition.PulseRifle,
            Facing = 1,
        });
        return entity;
    }

    private void SpawnLevelEntities(World world)
    {
        foreach (var spawn in _level.Spawns)
        {
            var type = spawn.Type.ToLowerInvariant();
            if (type == "player")
                continue;

            if (type == "walker")
            {
                var hp = ParseInt(spawn, "hp", 1);
                var left = ParseFloat(spawn, "left", spawn.X - 40);
                var right = ParseFloat(spawn, "right", spawn.X + 40);
                SpawnWalker(world, spawn.X, spawn.Y, left, right, hp);
            }
            else if (type == "pickup_weapon")
            {
                SpawnWeaponPickup(world, spawn.X, spawn.Y, spawn.Properties?.GetValueOrDefault("weapon") ?? "spread_cannon");
            }
            else if (type == "pickup_health")
            {
                SpawnHealthPickup(world, spawn.X, spawn.Y, ParseInt(spawn, "amount", 1));
            }
        }
    }

    private static int ParseInt(EntitySpawn spawn, string key, int fallback) =>
        spawn.Properties is not null && spawn.Properties.TryGetValue(key, out var raw) && int.TryParse(raw, out var v) ? v : fallback;

    private static float ParseFloat(EntitySpawn spawn, string key, float fallback) =>
        spawn.Properties is not null && spawn.Properties.TryGetValue(key, out var raw) && float.TryParse(raw, out var v) ? v : fallback;

    private static void SpawnWalker(World world, float x, float y, float left, float right, int hp)
    {
        var enemy = world.CreateEntity();
        var size = new Vector2(16, 22);
        world.Add(enemy, new Transform(new Vector2(x, y)));
        world.Add(enemy, new Velocity(Vector2.Zero));
        world.Add(enemy, new RigidBody(size));
        world.Add(enemy, new DrawableRect(size.X, size.Y, 0xFFE06060));
        world.Add(enemy, new HealthComponent(Math.Max(1, hp)));
        world.Add(enemy, new EnemyTag { TouchDamage = 1 });
        world.Add(enemy, new AiControlled { Root = WalkerBehavior.Create(45f, left, right) });
    }

    private static void SpawnWeaponPickup(World world, float x, float y, string weaponId)
    {
        var pickup = world.CreateEntity();
        world.Add(pickup, new Transform(new Vector2(x, y)));
        world.Add(pickup, new DrawableRect(12, 12, 0xFFFFB060));
        world.Add(pickup, new PickupComponent { Kind = PickupKind.Weapon, WeaponId = weaponId, Amount = 1 });
    }

    private static void SpawnHealthPickup(World world, float x, float y, int amount)
    {
        var pickup = world.CreateEntity();
        world.Add(pickup, new Transform(new Vector2(x, y)));
        world.Add(pickup, new DrawableRect(12, 12, 0xFF80FF90));
        world.Add(pickup, new PickupComponent { Kind = PickupKind.Health, Amount = amount });
    }

    public void SetInput(InputFrame frame)
    {
        if (State == RunState.Paused)
        {
            if (frame.WasPressed(InputButtons.Pause) || frame.WasPressed(InputButtons.Jump))
            {
                State = RunState.Playing;
                _sfx.Play("ui");
            }
            else if (frame.WasPressed(InputButtons.Shoot))
            {
                RequestTitle = true;
                _sfx.Play("ui");
            }

            return;
        }

        if (State == RunState.Cleared)
        {
            if (frame.WasPressed(InputButtons.Jump) || frame.WasPressed(InputButtons.Shoot))
            {
                RequestTitle = true;
                _sfx.Play("ui");
            }

            return;
        }

        if (State == RunState.GameOver)
        {
            if (frame.WasPressed(InputButtons.Jump) || frame.WasPressed(InputButtons.Shoot))
            {
                RequestTitle = true;
                _sfx.Play("ui");
            }

            return;
        }

        if (frame.WasPressed(InputButtons.Pause))
        {
            State = RunState.Paused;
            _sfx.Play("ui");
            return;
        }

        _input.SetFrame(frame);
        _weapons.SetInput(frame);
    }

    public void Update(World world, float fixedDeltaSeconds)
    {
        _bannerPulse += fixedDeltaSeconds;
        _sfx.Tick(fixedDeltaSeconds);
        _healthBar.Tick(fixedDeltaSeconds);
        _livesHud.Tick(fixedDeltaSeconds);
        _scoreHud.Tick(fixedDeltaSeconds);

        if (State is RunState.Paused or RunState.Cleared or RunState.GameOver)
        {
            if (State == RunState.Cleared)
                _clearTimer += fixedDeltaSeconds;
            return;
        }

        var projBefore = world.GetStore<ProjectileComponent>().Count;
        var pickupBefore = world.GetStore<PickupComponent>().Count;

        _scheduler.Tick(world, fixedDeltaSeconds);
        UpdateFacing(world);
        HandleFallDeath(world);

        if (_contact.HitsThisTick.Count > 0)
            _damage.EnqueueRange(_contact.HitsThisTick);
        if (_projectiles.DamageThisTick.Count > 0)
        {
            _damage.EnqueueRange(_projectiles.DamageThisTick);
            _shake.AddTrauma(0.22f);
            _sfx.Play("hit");
            foreach (var evt in _projectiles.DamageThisTick)
            {
                if (world.TryGet<Transform>(evt.Target, out var t))
                    _particles.Burst(t.Position.X + 8, t.Position.Y + 8, 8, 0xFFFF8060);
            }
        }

        var healthBefore = world.TryGet<HealthComponent>(_player, out var hpBefore) ? hpBefore.Current : 0;
        _damage.Update(world, fixedDeltaSeconds);

        if (world.TryGet<HealthComponent>(_player, out var hpAfter) && hpAfter.Current < healthBefore)
        {
            _sfx.Play("hurt");
            _shake.AddTrauma(0.45f);
            PostEffects.Flash(0.4f);
            _healthBar.SetTarget(hpAfter.Current);
        }

        var projAfter = world.GetStore<ProjectileComponent>().Count;
        if (projAfter > projBefore)
            _sfx.Play("shoot", 0.55f);

        if (world.GetStore<PickupComponent>().Count < pickupBefore)
            _sfx.Play("pickup");

        // Score for killed enemies
        foreach (var dead in _damage.DiedThisTick)
        {
            if (world.Has<PlayerControlled>(dead))
                continue;
            _score += 100;
            _scoreHud.SetTarget(_score);
            _sfx.Play("hit");
        }

        if (world.TryGet<RigidBody>(_player, out var body) &&
            world.TryGet<Velocity>(_player, out var vel))
        {
            if (_wasOnGround && !body.OnGround && vel.Value.Y < -50f)
                _sfx.Play("jump", 0.45f);
            _wasOnGround = body.OnGround;
        }

        CheckTriggers(world);
        HandlePlayerDeath(world);

        _camera.Follow(world, fixedDeltaSeconds);
        _particles.Update(fixedDeltaSeconds);
        PostEffects.Update(fixedDeltaSeconds);
        _lastProjectileCount = projAfter;
    }

    private void HandleFallDeath(World world)
    {
        if (!world.TryGet<Transform>(_player, out var t))
            return;
        if (t.Position.Y > _level.Height * _level.TileSize + 48)
        {
            if (world.TryGet<HealthComponent>(_player, out var hp))
            {
                hp.Current = 0;
                world.GetStore<HealthComponent>().Set(_player, hp);
            }
        }
    }

    private void HandlePlayerDeath(World world)
    {
        if (!world.TryGet<HealthComponent>(_player, out var hp) || hp.Current > 0)
            return;

        _lives--;
        _livesHud.SetTarget(Math.Max(0, _lives));
        _sfx.Play("hurt");

        if (_lives <= 0)
        {
            State = RunState.GameOver;
            return;
        }

        // Respawn at checkpoint with full health.
        if (world.TryGet<Transform>(_player, out var transform))
        {
            transform.Position = _checkpoint;
            world.GetStore<Transform>().Set(_player, transform);
        }

        if (world.TryGet<Velocity>(_player, out var velocity))
        {
            velocity.Value = Vector2.Zero;
            world.GetStore<Velocity>().Set(_player, velocity);
        }

        hp.Current = hp.Max;
        world.GetStore<HealthComponent>().Set(_player, hp);
        world.Add(_player, new InvulnFrames { Remaining = 1.5f });
        _healthBar.SetImmediate(hp.Max);
        PostEffects.Flash(0.25f);
    }

    private void CheckTriggers(World world)
    {
        if (State != RunState.Playing)
            return;
        if (!world.TryGet<HealthComponent>(_player, out var hp) || hp.Current <= 0)
            return;
        if (!world.TryGet<Transform>(_player, out var transform) || !world.TryGet<RigidBody>(_player, out var body))
            return;

        var box = new Aabb(transform.Position.X, transform.Position.Y, body.Size.X, body.Size.Y);
        foreach (var trigger in _level.Triggers)
        {
            var zone = new Aabb(trigger.X, trigger.Y, trigger.Width, trigger.Height);
            if (!box.Intersects(zone))
                continue;

            if (trigger.Kind == TriggerKind.Checkpoint)
                _checkpoint = new Vector2(trigger.X + 8f, _spawn.Y);

            if (trigger.Kind == TriggerKind.LevelExit)
                ClearLevel();
        }
    }

    private void ClearLevel()
    {
        if (State == RunState.Cleared)
            return;

        State = RunState.Cleared;
        _clearTimer = 0f;
        _sfx.Play("clear");
        _progress.Unlock(_level.Name);
        _progress.UnlockNext(_level.Name);
        _scores.TrySubmit(_level.Name, _score);
        try
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "VanguardProtocol",
                "save.json");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            _saves.SaveToFile(path, _save);
        }
        catch
        {
            // Save failures should never block clear.
        }
    }

    private void UpdateFacing(World world)
    {
        if (!world.IsAlive(_player))
            return;
        if (!world.TryGet<WeaponComponent>(_player, out var weapon))
            return;
        if (!world.TryGet<Velocity>(_player, out var velocity))
            return;

        if (velocity.Value.X > 1f)
            weapon.Facing = 1;
        else if (velocity.Value.X < -1f)
            weapon.Facing = -1;

        world.GetStore<WeaponComponent>().Set(_player, weapon);
    }

    public void Draw(float alpha)
    {
    }

    public void DrawWorld(World world)
    {
        var shake = _shake.Update(1f / 60f);
        var cameraX = _camera.Position.X + shake.X;
        var cameraY = _camera.Position.Y + shake.Y;

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (var layer in _level.Parallax)
        {
            var scroll = cameraX * layer.ScrollFactorX;
            DrawRect(-scroll % 640, 0, 640 + 64, 360, Rgba(layer.ColorRgba));
        }

        var tile = _level.TileSize;
        for (var y = 0; y < _level.Height; y++)
        for (var x = 0; x < _level.Width; x++)
        {
            var flags = _level.Tiles[y * _level.Width + x];
            if (flags == TileFlags.None)
                continue;

            var color = (flags & TileFlags.OneWay) != 0
                ? new XnaColor(70, 150, 210)
                : (flags & (TileFlags.SlopeUpLeft | TileFlags.SlopeUpRight)) != 0
                    ? new XnaColor(190, 150, 90)
                    : new XnaColor(78, 98, 118);

            DrawRect(x * tile - cameraX, y * tile - cameraY, tile, tile, color);
        }

        // Exit beacon
        foreach (var trigger in _level.Triggers)
        {
            if (trigger.Kind != TriggerKind.LevelExit)
                continue;
            var pulse = 0.55f + 0.45f * MathF.Sin(_bannerPulse * 6f);
            DrawRect(trigger.X - cameraX, trigger.Y - cameraY, trigger.Width, trigger.Height,
                new XnaColor(80, 255, 140) * pulse);
            TinyFont.Draw(_spriteBatch, _pixel, "EXIT", (int)(trigger.X - cameraX + 4), (int)(trigger.Y - cameraY - 12),
                new XnaColor(180, 255, 200), 2);
        }

        var drawables = world.GetStore<DrawableRect>();
        var transforms = world.GetStore<Transform>();
        foreach (var (entity, drawable) in drawables)
        {
            if (!transforms.TryGet(entity, out var transform))
                continue;

            var color = Rgba(drawable.ColorRgba);
            if (entity == _player && world.Has<InvulnFrames>(_player) && ((int)(_bannerPulse * 20) % 2 == 0))
                color *= 0.35f;

            DrawRect(
                transform.Position.X - cameraX,
                transform.Position.Y - cameraY,
                drawable.Width,
                drawable.Height,
                color);
        }

        foreach (var p in _particles.Active)
        {
            var a = Math.Clamp(p.Life / p.MaxLife, 0f, 1f);
            DrawRect(p.X - cameraX, p.Y - cameraY, p.Size, p.Size, Rgba(p.ColorRgba) * a);
        }

        if (PostEffects.ScreenFlash > 0f)
            DrawRect(0, 0, 640, 360, XnaColor.White * PostEffects.ScreenFlash);

        DrawHud(world);
        DrawOverlays();

        _spriteBatch.End();
    }

    private void DrawHud(World world)
    {
        DrawRect(0, 0, 640, 28, new XnaColor(8, 10, 14) * 0.75f);

        if (world.TryGet<HealthComponent>(_player, out var hp))
        {
            TinyFont.Draw(_spriteBatch, _pixel, "HP", 8, 8, new XnaColor(220, 220, 220), 2);
            for (var i = 0; i < hp.Max; i++)
            {
                var filled = i < hp.Current;
                DrawRect(36 + i * 14, 8, 12, 8, filled ? new XnaColor(220, 70, 70) : new XnaColor(50, 24, 24));
            }
        }

        TinyFont.Draw(_spriteBatch, _pixel, $"LIVES {_lives}", 100, 8, new XnaColor(220, 220, 220), 2);
        TinyFont.Draw(_spriteBatch, _pixel, $"SCORE {_score}", 220, 8, new XnaColor(220, 220, 180), 2);

        if (world.TryGet<WeaponComponent>(_player, out var weapon) && weapon.Definition is not null)
        {
            TinyFont.Draw(_spriteBatch, _pixel, weapon.Definition.Id.ToUpperInvariant().Replace('_', ' '), 400, 8,
                Rgba(weapon.Definition.ColorRgba), 2);
        }

        TinyFont.Draw(_spriteBatch, _pixel, "X SHOOT  SPACE JUMP  ESC PAUSE", 8, 340, new XnaColor(140, 150, 160), 1);
    }

    private void DrawOverlays()
    {
        if (State == RunState.Paused)
        {
            DrawRect(0, 0, 640, 360, new XnaColor(0, 0, 0) * 0.55f);
            TinyFont.Draw(_spriteBatch, _pixel, "PAUSED", 260, 140, XnaColor.White, 3);
            TinyFont.Draw(_spriteBatch, _pixel, "SPACE RESUME", 230, 190, new XnaColor(200, 200, 200), 2);
            TinyFont.Draw(_spriteBatch, _pixel, "X TITLE", 270, 220, new XnaColor(180, 180, 180), 2);
        }
        else if (State == RunState.Cleared)
        {
            DrawRect(0, 0, 640, 360, new XnaColor(0, 20, 0) * 0.45f);
            TinyFont.Draw(_spriteBatch, _pixel, "STAGE CLEAR", 210, 130, new XnaColor(120, 255, 160), 3);
            TinyFont.Draw(_spriteBatch, _pixel, $"SCORE {_score}", 250, 180, XnaColor.White, 2);
            TinyFont.Draw(_spriteBatch, _pixel, "PRESS SPACE", 240, 220, new XnaColor(220, 220, 220), 2);
        }
        else if (State == RunState.GameOver)
        {
            DrawRect(0, 0, 640, 360, new XnaColor(20, 0, 0) * 0.55f);
            TinyFont.Draw(_spriteBatch, _pixel, "GAME OVER", 230, 150, new XnaColor(255, 100, 100), 3);
            TinyFont.Draw(_spriteBatch, _pixel, "PRESS SPACE", 240, 210, new XnaColor(220, 220, 220), 2);
        }
    }

    private void DrawRect(float x, float y, float w, float h, XnaColor color) =>
        _spriteBatch.Draw(_pixel, new XnaRectangle((int)x, (int)y, Math.Max(1, (int)w), Math.Max(1, (int)h)), color);

    private static XnaColor Rgba(uint rgba)
    {
        var r = (byte)((rgba >> 16) & 0xFF);
        var g = (byte)((rgba >> 8) & 0xFF);
        var b = (byte)(rgba & 0xFF);
        var a = (byte)((rgba >> 24) & 0xFF);
        return new XnaColor(r, g, b, a == 0 ? (byte)255 : a);
    }
}
