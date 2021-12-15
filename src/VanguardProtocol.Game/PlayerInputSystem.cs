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
    public const float CoyoteSeconds = 0.1f;

    private readonly InputBuffer _buffer = new();
    private readonly Dictionary<uint, float> _coyote = new();
    private InputFrame _frame;

    public override int Order => SystemOrders.Input;

    public void SetFrame(InputFrame frame)
    {
        _frame = frame;
        _buffer.Push(frame.Buttons);
    }

    public void Reset()
    {
        _buffer.Clear();
        _coyote.Clear();
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

            if (body.OnGround)
                _coyote[entity.Index] = CoyoteSeconds;
            else if (_coyote.TryGetValue(entity.Index, out var remaining))
                _coyote[entity.Index] = Math.Max(0f, remaining - fixedDeltaSeconds);

            var coyoteOk = _coyote.TryGetValue(entity.Index, out var coyoteLeft) && coyoteLeft > 0f;
            var wantsJump = _frame.WasPressed(InputButtons.Jump) ||
                            _buffer.ConsumedPress(InputButtons.Jump, lookbackFrames: 6);
            if (wantsJump && (body.OnGround || coyoteOk))
            {
                velocity.Value.Y = DeterministicMath.Quantize(-JumpSpeed);
                body.OnGround = false;
                bodies.Set(entity, body);
                _coyote[entity.Index] = 0f;
            }
        }
    }
}
