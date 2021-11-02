using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Game;

public sealed class VanguardGame : Microsoft.Xna.Framework.Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly GameLoop _loop = new();
    private readonly World _world = new();
    private readonly SceneStack _scenes = new();

    private SpriteBatch _spriteBatch = null!;
    private GameplayScene _gameplay = null!;

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
        IsFixedTimeStep = false; // engine owns fixed timestep
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _gameplay = new GameplayScene(GraphicsDevice, _spriteBatch);
        _gameplay.BuildWorld(_world);
        _scenes.Replace(_gameplay);
    }

    protected override void Update(GameTime gameTime)
    {
        var frame = KeyboardInput.Poll();
        if (frame.WasPressed(InputButtons.Pause))
        {
            Exit();
            return;
        }

        _gameplay.SetInput(frame);
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _loop.Tick(dt, () => _scenes.Update(_world, _loop.FixedDeltaSeconds));
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(12, 14, 20));
        _gameplay.DrawWorld(_world);
        base.Draw(gameTime);
    }

    protected override void UnloadContent()
    {
        _spriteBatch?.Dispose();
        base.UnloadContent();
    }
}
