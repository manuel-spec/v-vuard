using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VanguardProtocol.Audio;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Levels;
using VanguardProtocol.SaveSystem;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace VanguardProtocol.Game;

public sealed class VanguardGame : Microsoft.Xna.Framework.Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameLoop _loop = new();
    private readonly World _world = new();

    private SpriteBatch _spriteBatch = null!;
    private Texture2D _pixel = null!;
    private BeepAudioPlayer _beeps = null!;
    private SfxManager _sfx = null!;
    private SaveData _save = null!;
    private ProgressTracker _progress = null!;
    private GameplayScene _gameplay = null!;

    private enum Mode : byte { Title, StageSelect, Playing }
    private Mode _mode = Mode.Title;
    private int _titleIndex;
    private int _stageSelectIndex;
    private int _stageSelectScroll;
    private float _titlePulse;

    public VanguardGame()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 640,
            PreferredBackBufferHeight = 360,
            SynchronizeWithVerticalRetrace = true,
        };
        IsMouseVisible = true;
        Window.Title = "Vanguard Protocol";
        Content.RootDirectory = "Content";
        IsFixedTimeStep = false;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData([XnaColor.White]);
        _beeps = new BeepAudioPlayer();
        _sfx = new SfxManager(_beeps);
        _save = LoadSave();
        _progress = new ProgressTracker(_save);
        _gameplay = new GameplayScene(GraphicsDevice, _spriteBatch, _sfx, _save);
        KeyboardInput.Reset();
    }

    protected override void Update(GameTime gameTime)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _titlePulse += dt;
        _sfx.Tick(dt);

        var frame = KeyboardInput.Poll();

        switch (_mode)
        {
            case Mode.Title:
                UpdateTitle(frame);
                break;
            case Mode.StageSelect:
                UpdateStageSelect(frame);
                break;
            default:
                _gameplay.SetInput(frame);
                if (_gameplay.RequestTitle)
                {
                    _mode = Mode.Title;
                    _titleIndex = 0;
                    KeyboardInput.Reset();
                }
                else if (_gameplay.RequestNextStage &&
                         CampaignRoster.TryGetNext(_gameplay.Name, out var next))
                {
                    StartStage(next.Index);
                }
                else
                {
                    _loop.Tick(dt, () => _gameplay.Update(_world, _loop.FixedDeltaSeconds));
                }

                break;
        }

        base.Update(gameTime);
    }

    private void UpdateTitle(InputFrame frame)
    {
        if (frame.WasPressed(InputButtons.Up) || frame.WasPressed(InputButtons.Left))
        {
            _titleIndex = Math.Max(0, _titleIndex - 1);
            _sfx.Play("ui");
        }

        if (frame.WasPressed(InputButtons.Down) || frame.WasPressed(InputButtons.Right))
        {
            _titleIndex = Math.Min(2, _titleIndex + 1);
            _sfx.Play("ui");
        }

        if (frame.WasPressed(InputButtons.Jump) || frame.WasPressed(InputButtons.Shoot))
        {
            if (_titleIndex == 0)
                StartStage(FirstUnlockedOrOne());
            else if (_titleIndex == 1)
            {
                _mode = Mode.StageSelect;
                _stageSelectIndex = Math.Max(0, FirstUnlockedOrOne() - 1);
                EnsureStageSelectVisible();
                _sfx.Play("ui");
                KeyboardInput.Reset();
            }
            else
                Exit();
        }

        if (frame.WasPressed(InputButtons.Pause))
            Exit();
    }

    private void UpdateStageSelect(InputFrame frame)
    {
        if (frame.WasPressed(InputButtons.Pause) || frame.WasPressed(InputButtons.Shoot))
        {
            _mode = Mode.Title;
            _sfx.Play("ui");
            KeyboardInput.Reset();
            return;
        }

        if (frame.WasPressed(InputButtons.Up))
        {
            _stageSelectIndex = Math.Max(0, _stageSelectIndex - 1);
            EnsureStageSelectVisible();
            _sfx.Play("ui");
        }

        if (frame.WasPressed(InputButtons.Down))
        {
            _stageSelectIndex = Math.Min(CampaignRoster.StageCount - 1, _stageSelectIndex + 1);
            EnsureStageSelectVisible();
            _sfx.Play("ui");
        }

        if (frame.WasPressed(InputButtons.Jump))
        {
            var stage = CampaignRoster.Get(_stageSelectIndex + 1);
            if (_progress.IsUnlocked(stage.Id))
                StartStage(stage.Index);
            else
                _sfx.Play("hurt", 0.4f);
        }
    }

    private void EnsureStageSelectVisible()
    {
        const int visible = 8;
        if (_stageSelectIndex < _stageSelectScroll)
            _stageSelectScroll = _stageSelectIndex;
        if (_stageSelectIndex >= _stageSelectScroll + visible)
            _stageSelectScroll = _stageSelectIndex - visible + 1;
    }

    private int FirstUnlockedOrOne()
    {
        for (var i = CampaignRoster.StageCount; i >= 1; i--)
        {
            if (_progress.IsUnlocked(CampaignRoster.Get(i).Id))
                return i;
        }

        return 1;
    }

    private void StartStage(int stageIndex)
    {
        _sfx.Play("ui");
        _world.Clear();
        _loop.Reset();
        _gameplay.LoadStage(stageIndex);
        _gameplay.BuildWorld(_world);
        _gameplay.Enter();
        _mode = Mode.Playing;
        KeyboardInput.Reset();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new XnaColor(12, 14, 20));

        if (_mode == Mode.Title)
            DrawTitle();
        else if (_mode == Mode.StageSelect)
            DrawStageSelect();
        else
            _gameplay.DrawWorld(_world);

        base.Draw(gameTime);
    }

    private void DrawTitle()
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_pixel, new Rectangle(0, 0, 640, 360), new XnaColor(10, 14, 22));
        _spriteBatch.Draw(_pixel, new Rectangle(0, 70, 640, 80), new XnaColor(18, 28, 40));

        TinyFont.Draw(_spriteBatch, _pixel, "VANGUARD PROTOCOL", 150, 90, new XnaColor(230, 240, 255), 3);
        TinyFont.Draw(_spriteBatch, _pixel, $"{CampaignRoster.StageCount} STAGES", 250, 140, new XnaColor(140, 180, 210), 2);

        var pulse = 0.65f + 0.35f * MathF.Sin(_titlePulse * 5f);
        DrawMenuLine(0, "CONTINUE", 200, pulse);
        DrawMenuLine(1, "STAGE SELECT", 230, pulse);
        DrawMenuLine(2, "QUIT", 260, pulse);

        TinyFont.Draw(_spriteBatch, _pixel, "ARROWS SELECT   SPACE CONFIRM", 170, 310, new XnaColor(120, 130, 140), 1);
        TinyFont.Draw(_spriteBatch, _pixel, "REACH THE GREEN EXIT TO CLEAR", 160, 330, new XnaColor(100, 140, 110), 1);
        _spriteBatch.End();
    }

    private void DrawMenuLine(int index, string label, int y, float pulse)
    {
        var selected = _titleIndex == index;
        var color = selected ? new XnaColor(120, 255, 160) * pulse : new XnaColor(160, 170, 180);
        TinyFont.Draw(_spriteBatch, _pixel, (selected ? "> " : "  ") + label, 230, y, color, 2);
    }

    private void DrawStageSelect()
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_pixel, new Rectangle(0, 0, 640, 360), new XnaColor(10, 14, 22));
        TinyFont.Draw(_spriteBatch, _pixel, "STAGE SELECT", 220, 24, new XnaColor(230, 240, 255), 3);

        const int visible = 8;
        for (var row = 0; row < visible; row++)
        {
            var idx = _stageSelectScroll + row;
            if (idx >= CampaignRoster.StageCount)
                break;

            var stage = CampaignRoster.Get(idx + 1);
            var unlocked = _progress.IsUnlocked(stage.Id);
            var selected = idx == _stageSelectIndex;
            var y = 70 + row * 28;
            var label = $"{stage.Index:00}  {stage.Title.ToUpperInvariant()}";
            if (!unlocked)
                label += "  LOCKED";

            var color = !unlocked
                ? new XnaColor(80, 80, 90)
                : selected
                    ? new XnaColor(120, 255, 160)
                    : new XnaColor(180, 190, 200);
            TinyFont.Draw(_spriteBatch, _pixel, (selected ? "> " : "  ") + label, 80, y, color, 2);
        }

        TinyFont.Draw(_spriteBatch, _pixel, "UP DOWN MOVE   SPACE PLAY   X BACK", 140, 330, new XnaColor(120, 130, 140), 1);
        _spriteBatch.End();
    }

    private static SaveData LoadSave()
    {
        try
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "VanguardProtocol",
                "save.json");
            return new SaveSerializer().LoadFromFile(path);
        }
        catch
        {
            return new SaveData();
        }
    }

    protected override void UnloadContent()
    {
        _beeps?.Dispose();
        _spriteBatch?.Dispose();
        _pixel?.Dispose();
        base.UnloadContent();
    }
}
