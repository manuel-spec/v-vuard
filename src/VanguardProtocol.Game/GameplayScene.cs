using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VanguardProtocol.AI;
using VanguardProtocol.Camera;
using VanguardProtocol.Combat;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Levels;
using VanguardProtocol.Physics;
using VanguardProtocol.Rendering;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace VanguardProtocol.Game;

public sealed class GameplayScene : IScene
{
    private readonly Texture2D _pixel;
    private readonly SpriteBatch _spriteBatch;
    private readonly SystemScheduler _scheduler = new();
    private readonly PhysicsSystem _physics = new();
    private readonly PlayerInputSystem _input = new();
    private readonly WeaponSystem _weapons = new();
    private readonly ProjectileSystem _projectiles = new();
    private readonly DamageSystem _damage = new();
    private readonly PickupSystem _pickups = new();
    private readonly AiSystem _ai = new();
    private readonly ParticleSystem _particles = new();
    private readonly ScrollingCamera _camera = new();
    private readonly ScreenShake _shake = new();
    private readonly LevelData _level;
    private Entity _player;

    public GameplayScene(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData([XnaColor.White]);
        _level = LevelData.CreateDemo();

        var collision = LevelLoader.LoadCollision(_level);
        _physics.SetTilemap(collision);
        _projectiles.SetTilemap(collision);
        _camera.ViewSize = new System.Numerics.Vector2(640, 360);
        _camera.LevelBounds = new System.Numerics.Vector2(
            _level.Width * _level.TileSize,
            _level.Height * _level.TileSize);
    }

    public string Name => _level.Name;

    public void Enter()
    {
    }

    public void Exit()
    {
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
        _scheduler.Add(_pickups);

        var spawn = _level.Spawns.Find(s => s.Type == "Player")
                    ?? new EntitySpawn { Type = "Player", X = 48, Y = 180 };

        _player = world.CreateEntity();
        var size = new System.Numerics.Vector2(14, 22);
        world.Add(_player, new Transform(new System.Numerics.Vector2(spawn.X, spawn.Y)));
        world.Add(_player, new Velocity(System.Numerics.Vector2.Zero));
        world.Add(_player, new RigidBody(size));
        world.Add(_player, new PlayerControlled(0));
        world.Add(_player, new DrawableRect(size.X, size.Y, 0xFFE8F0FF));
        world.Add(_player, new HealthComponent(3));
        world.Add(_player, new CameraFocus { Weight = 1f });
        world.Add(_player, new WeaponComponent
        {
            Definition = WeaponDefinition.PulseRifle,
            Facing = 1,
        });

        SpawnWalker(world, 240, 180, 200, 360);
        SpawnTargetDummy(world, 320, 100);
        SpawnWeaponPickup(world, 160, 170, "spread_cannon");
    }

    private static void SpawnWalker(World world, float x, float y, float left, float right)
    {
        var enemy = world.CreateEntity();
        var size = new System.Numerics.Vector2(18, 24);
        world.Add(enemy, new Transform(new System.Numerics.Vector2(x, y)));
        world.Add(enemy, new Velocity(System.Numerics.Vector2.Zero));
        world.Add(enemy, new RigidBody(size));
        world.Add(enemy, new DrawableRect(size.X, size.Y, 0xFFE06060));
        world.Add(enemy, new HealthComponent(3));
        world.Add(enemy, new AiControlled { Root = WalkerBehavior.Create(55f, left, right) });
    }

    private static void SpawnTargetDummy(World world, float x, float y)
    {
        var enemy = world.CreateEntity();
        var size = new System.Numerics.Vector2(18, 24);
        world.Add(enemy, new Transform(new System.Numerics.Vector2(x, y)));
        world.Add(enemy, new Velocity(System.Numerics.Vector2.Zero));
        world.Add(enemy, new RigidBody(size));
        world.Add(enemy, new DrawableRect(size.X, size.Y, 0xFFC05090));
        world.Add(enemy, new HealthComponent(3));
    }

    private static void SpawnWeaponPickup(World world, float x, float y, string weaponId)
    {
        var pickup = world.CreateEntity();
        world.Add(pickup, new Transform(new System.Numerics.Vector2(x, y)));
        world.Add(pickup, new DrawableRect(12, 12, 0xFFFFB060));
        world.Add(pickup, new PickupComponent
        {
            Kind = PickupKind.Weapon,
            WeaponId = weaponId,
            Amount = 1,
        });
    }

    public void SetInput(InputFrame frame)
    {
        _input.SetFrame(frame);
        _weapons.SetInput(frame);
    }

    public void Update(World world, float fixedDeltaSeconds)
    {
        _scheduler.Tick(world, fixedDeltaSeconds);
        UpdateFacing(world);

        if (_projectiles.DamageThisTick.Count > 0)
        {
            _damage.EnqueueRange(_projectiles.DamageThisTick);
            _damage.Update(world, fixedDeltaSeconds);
            _shake.AddTrauma(0.25f);
        }

        _camera.Follow(world, fixedDeltaSeconds);
        _particles.Update(fixedDeltaSeconds);
        PostEffects.Update(fixedDeltaSeconds);

        if (_damage.DiedThisTick.Count > 0)
            PostEffects.Flash(0.35f);
    }

    private void UpdateFacing(World world)
    {
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
            DrawRect(-scroll % 640, -cameraY * layer.ScrollFactorY, 640 + 64, 288, Rgba(layer.ColorRgba));
        }

        var tile = _level.TileSize;
        for (var y = 0; y < _level.Height; y++)
        for (var x = 0; x < _level.Width; x++)
        {
            var flags = _level.Tiles[y * _level.Width + x];
            if (flags == TileFlags.None)
                continue;

            var color = (flags & TileFlags.OneWay) != 0
                ? new XnaColor(80, 160, 220)
                : (flags & (TileFlags.SlopeUpLeft | TileFlags.SlopeUpRight)) != 0
                    ? new XnaColor(180, 140, 80)
                    : new XnaColor(70, 90, 110);

            DrawRect(x * tile - cameraX, y * tile - cameraY, tile, tile, color);
        }

        var drawables = world.GetStore<DrawableRect>();
        var transforms = world.GetStore<Transform>();
        foreach (var (entity, drawable) in drawables)
        {
            if (!transforms.TryGet(entity, out var transform))
                continue;
            DrawRect(
                transform.Position.X - cameraX,
                transform.Position.Y - cameraY,
                drawable.Width,
                drawable.Height,
                Rgba(drawable.ColorRgba));
        }

        foreach (var p in _particles.Active)
        {
            var alpha = Math.Clamp(p.Life / p.MaxLife, 0f, 1f);
            DrawRect(p.X - cameraX, p.Y - cameraY, p.Size, p.Size, Rgba(p.ColorRgba) * alpha);
        }

        if (PostEffects.ScreenFlash > 0f)
            DrawRect(0, 0, 640, 360, XnaColor.White * PostEffects.ScreenFlash);

        if (world.TryGet<HealthComponent>(_player, out var hp))
        {
            for (var i = 0; i < hp.Max; i++)
            {
                var filled = i < hp.Current;
                DrawRect(8 + i * 14, 8, 12, 8, filled ? new XnaColor(220, 70, 70) : new XnaColor(60, 30, 30));
            }
        }

        if (world.TryGet<WeaponComponent>(_player, out var weapon) && weapon.Definition is not null)
            DrawRect(8, 22, 40, 6, Rgba(weapon.Definition.ColorRgba));

        _spriteBatch.End();
    }

    private void DrawRect(float x, float y, float w, float h, XnaColor color) =>
        _spriteBatch.Draw(_pixel, new Rectangle((int)x, (int)y, Math.Max(1, (int)w), Math.Max(1, (int)h)), color);

    private static XnaColor Rgba(uint rgba)
    {
        var r = (byte)((rgba >> 16) & 0xFF);
        var g = (byte)((rgba >> 8) & 0xFF);
        var b = (byte)(rgba & 0xFF);
        var a = (byte)((rgba >> 24) & 0xFF);
        return new XnaColor(r, g, b, a == 0 ? (byte)255 : a);
    }
}
