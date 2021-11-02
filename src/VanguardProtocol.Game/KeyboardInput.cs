using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using VanguardProtocol.Core;

namespace VanguardProtocol.Game;

public static class KeyboardInput
{
    private static InputButtons _previous;

    public static InputFrame Poll(PlayerIndex player = PlayerIndex.One)
    {
        var state = Keyboard.GetState();
        var pad = GamePad.GetState(player);
        var buttons = InputButtons.None;

        if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left) || pad.IsButtonDown(Buttons.DPadLeft) || pad.ThumbSticks.Left.X < -0.4f)
            buttons |= InputButtons.Left;
        if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right) || pad.IsButtonDown(Buttons.DPadRight) || pad.ThumbSticks.Left.X > 0.4f)
            buttons |= InputButtons.Right;
        if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up) || pad.IsButtonDown(Buttons.DPadUp) || pad.ThumbSticks.Left.Y > 0.4f)
            buttons |= InputButtons.Up;
        if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down) || pad.IsButtonDown(Buttons.DPadDown) || pad.ThumbSticks.Left.Y < -0.4f)
            buttons |= InputButtons.Down;
        if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.Z) || pad.IsButtonDown(Buttons.A))
            buttons |= InputButtons.Jump;
        if (state.IsKeyDown(Keys.X) || state.IsKeyDown(Keys.LeftControl) || pad.IsButtonDown(Buttons.X))
            buttons |= InputButtons.Shoot;
        if (state.IsKeyDown(Keys.Escape) || pad.IsButtonDown(Buttons.Start))
            buttons |= InputButtons.Pause;

        var frame = InputFrame.FromEdges(_previous, buttons);
        _previous = buttons;
        return frame;
    }

    public static void Reset() => _previous = InputButtons.None;
}
