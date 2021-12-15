using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VanguardProtocol.Audio;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Ecs;
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
    private GameplayScene _gameplay = null!;

    private enum Mode : byte { Title, Playing }
    private Mode _mode = Mode.Title;
    private int _titleIndex;
    private float _titlePulse;
    private InputButtons _prevButtons;

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
        _gameplay = new GameplayScene(GraphicsDevice, _spriteBatch, _sfx, _save);
        KeyboardInput.Reset();
    }

    protected override void Update(GameTime gameTime)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _titlePulse += dt;
        _sfx.Tick(dt);

        var frame = KeyboardInput.Poll();

        if (_mode == Mode.Title)
        {
            UpdateTitle(frame);
        }
        else
        {
            _gameplay.SetInput(frame);
            if (_gameplay.RequestTitle)
            {
                _mode = Mode.Title;
                _titleIndex = 0;
                KeyboardInput.Reset();
            }
            else
            {
                _loop.Tick(dt, () => _gameplay.Update(_world, _loop.FixedDeltaSeconds));
            }
        }

        _prevButtons = frame.Buttons;
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
            _titleIndex = Math.Min(1, _titleIndex + 1);
            _sfx.Play("ui");
        }

        if (frame.WasPressed(InputButtons.Jump) || frame.WasPressed(InputButtons.Shoot))
        {
            if (_titleIndex == 0)
                StartGame();
            else
                Exit();
        }

        if (frame.WasPressed(InputButtons.Pause))
            Exit();
    }

    private void StartGame()
    {
        _sfx.Play("ui");
        _world.Clear();
        _loop.Reset();
        _gameplay.BuildWorld(_world);
        _mode = Mode.Playing;
        KeyboardInput.Reset();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new XnaColor(12, 14, 20));

        if (_mode == Mode.Title)
            DrawTitle();
        else
            _gameplay.DrawWorld(_world);

        base.Draw(gameTime);
    }

    private void DrawTitle()
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_pixel, new Rectangle(0, 0, 640, 360), new XnaColor(10, 14, 22));
        _spriteBatch.Draw(_pixel, new Rectangle(0, 80, 640, 90), new XnaColor(18, 28, 40));

        TinyFont.Draw(_spriteBatch, _pixel, "VANGUARD PROTOCOL", 150, 100, new XnaColor(230, 240, 255), 3);
        TinyFont.Draw(_spriteBatch, _pixel, "STAGE 1  VALE OUTPOST", 200, 150, new XnaColor(140, 180, 210), 2);

        var pulse = 0.65f + 0.35f * MathF.Sin(_titlePulse * 5f);
        var startColor = _titleIndex == 0 ? new XnaColor(120, 255, 160) * pulse : new XnaColor(160, 170, 180);
        var quitColor = _titleIndex == 1 ? new XnaColor(255, 140, 140) * pulse : new XnaColor(160, 170, 180);
        TinyFont.Draw(_spriteBatch, _pixel, (_titleIndex == 0 ? "> " : "  ") + "START STAGE 1", 220, 220, startColor, 2);
        TinyFont.Draw(_spriteBatch, _pixel, (_titleIndex == 1 ? "> " : "  ") + "QUIT", 270, 250, quitColor, 2);

        TinyFont.Draw(_spriteBatch, _pixel, "ARROWS SELECT   SPACE CONFIRM", 170, 310, new XnaColor(120, 130, 140), 1);
        TinyFont.Draw(_spriteBatch, _pixel, "REACH THE GREEN EXIT TO CLEAR", 160, 330, new XnaColor(100, 140, 110), 1);
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
