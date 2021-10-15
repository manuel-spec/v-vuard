using System.Numerics;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Physics;

public struct RigidBody : IComponent
{
    public Vector2 Size;
    public bool OnGround;
    public bool AffectedByGravity;
    public float GravityScale;

    public RigidBody(Vector2 size, bool affectedByGravity = true, float gravityScale = 1f)
    {
        Size = size;
        OnGround = false;
        AffectedByGravity = affectedByGravity;
        GravityScale = gravityScale;
    }
}

public sealed class PhysicsSystem : SystemBase
{
    public const float DefaultGravity = 1800f;

    private CollisionTilemap? _tilemap;

    public PhysicsSystem(float gravity = DefaultGravity)
    {
        Gravity = gravity;
    }

    public override int Order => SystemOrders.Physics;
    public float Gravity { get; set; }

    public void SetTilemap(CollisionTilemap? tilemap) => _tilemap = tilemap;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var bodies = world.GetStore<RigidBody>();
        var transforms = world.GetStore<Transform>();
        var velocities = world.GetStore<Velocity>();

        foreach (var (entity, body) in bodies)
        {
            if (!transforms.Has(entity) || !velocities.Has(entity))
                continue;

            ref var transform = ref transforms.Get(entity);
            ref var velocity = ref velocities.Get(entity);
            var bodyCopy = body;

            if (bodyCopy.AffectedByGravity)
            {
                velocity.Value.Y = DeterministicMath.Quantize(
                    velocity.Value.Y + Gravity * bodyCopy.GravityScale * fixedDeltaSeconds);
            }

            velocity.Value = DeterministicMath.Quantize(velocity.Value);
            var wasOnGround = bodyCopy.OnGround;
            var frameDelta = DeterministicMath.Scale(velocity.Value, fixedDeltaSeconds);

            if (_tilemap is not null)
            {
                var pos = transform.Position;
                TilemapCollision.Resolve(
                    _tilemap,
                    ref pos,
                    ref frameDelta,
                    bodyCopy.Size,
                    wasOnGround,
                    out var onGround);
                transform.Position = pos;
                bodyCopy.OnGround = onGround;

                // Rebuild velocity from remaining frame delta so blocked axes stop.
                if (fixedDeltaSeconds > 0f)
                {
                    velocity.Value = DeterministicMath.Quantize(new Vector2(
                        frameDelta.X / fixedDeltaSeconds,
                        frameDelta.Y / fixedDeltaSeconds));
                }
            }
            else
            {
                transform.Position = DeterministicMath.Add(transform.Position, frameDelta);
                bodyCopy.OnGround = false;
            }

            bodies.Set(entity, bodyCopy);
        }
    }
}
