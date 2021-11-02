using System.Numerics;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Game;

public sealed class PlayerInputSystem : SystemBase
{
    public const float MoveSpeed = 160f;
    public const float JumpSpeed = 420f;

    private readonly InputBuffer _buffer = new();
    private InputFrame _frame;

    public override int Order => SystemOrders.Input;

    public void SetFrame(InputFrame frame)
    {
        _frame = frame;
        _buffer.Push(frame.Buttons);
    }

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var players = world.GetStore<PlayerControlled>();
        var velocities = world.GetStore<Velocity>();
        var bodies = world.GetStore<RigidBody>();

        foreach (var (entity, _) in players)
        {
            if (!velocities.Has(entity) || !bodies.Has(entity))
                continue;

            ref var velocity = ref velocities.Get(entity);
            ref var body = ref bodies.Get(entity);

            var axis = 0f;
            if (_frame.IsDown(InputButtons.Left))
                axis -= 1f;
            if (_frame.IsDown(InputButtons.Right))
                axis += 1f;

            velocity.Value.X = DeterministicMath.Quantize(axis * MoveSpeed);

            var wantsJump = _frame.WasPressed(InputButtons.Jump) ||
                            _buffer.ConsumedPress(InputButtons.Jump, lookbackFrames: 6);
            if (wantsJump && body.OnGround)
            {
                velocity.Value.Y = DeterministicMath.Quantize(-JumpSpeed);
                body.OnGround = false;
                bodies.Set(entity, body);
            }
        }
    }
}
