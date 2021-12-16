# Vanguard Protocol

Original run-and-gun side-scroller built in **C#** on **MonoGame**, with a fully custom game engine on top: ECS, platformer physics, animation, enemy AI, weapons/pickups, tile-based levels + editor, and custom netcode for online 2-player co-op.

Genre-wise it plays in the Contra tradition — relentless side-scrolling action, multi-directional gun pickups, screen-filling bosses, tough difficulty, co-op — with original characters, story, levels, art, and branding. No Konami IP is used.

MonoGame covers window/input/audio/texture primitives. Everything that makes this *a game* (ECS, physics, AI, combat, levels, animation, co-op netcode) is custom.

Full design detail lives in a local architecture doc (gitignored — planning/agent use only).

---

## Run

```bash
dotnet test VanguardProtocol.sln
dotnet run --project src/VanguardProtocol.Game
```

**Controls:** A/D or arrows move · Space/Z jump · X / Ctrl shoot · Esc pause

Title → **Continue** / **Stage Select** (25 campaign stages) → reach the green **EXIT**. Clear unlocks the next stage and saves under `%LocalAppData%/VanguardProtocol/`. Stages 2–25 are playable adaptations of arenas 1–24.

---

## Architecture

```
MonoGame Host  →  Engine Core (fixed timestep, scenes)  →  ECS World
                                                              │
        ┌─────────────┬─────────────┬─────────────┬───────────┘
        ▼             ▼             ▼             ▼
   Physics       Animation         AI         Combat
        │             │             │             │
        └─────────────┴──────┬──────┴─────────────┘
                             ▼
              Levels / Camera / Rendering / UI / Save
                             │
                             ▼
                    Netcode (lockstep co-op)
```

Systems run every simulation tick in a fixed, deterministic order:

`Input → AI → Physics → Combat → Animation → Camera → Netcode sync → Render`

Determinism is a first-class constraint: co-op is **lockstep** (both peers simulate identical frames from identical inputs), so physics, AI, and combat must produce bit-identical results across machines. Movement/collision uses 16.16 fixed-point quantization via `DeterministicMath`.

---

## Project layout

```
VanguardProtocol.sln
src/
  VanguardProtocol.Core/         ECS, game loop, scenes, input buffer, assets
  VanguardProtocol.Physics/      AABB, tilemap collision, slopes, one-ways, fixed math
  VanguardProtocol.Animation/    Sprite sheets, clips, state machines, frame events
  VanguardProtocol.Combat/       Weapons, projectiles, damage, pickups
  VanguardProtocol.AI/           Behavior trees, walker/turret, boss phases
  VanguardProtocol.Levels/       Tilemaps, parallax, triggers, level JSON
  VanguardProtocol.Camera/       Scroll follow, boss lock, screen shake
  VanguardProtocol.Rendering/    Sprite layers, particles, post flash
  VanguardProtocol.Game/         MonoGame host + gameplay scene (composition root)
tests/                           Core, Physics, Animation, Combat
docs/architecture.md             Full design document
```

---

## Status

| Phase | Focus | State |
|------:|-------|-------|
| 0 | Core ECS + fixed timestep + MonoGame host | Done |
| 1 | Physics (AABB, tilemap, slopes, one-ways, determinism) | Done |
| 2 | Animation state machines / clips | Foundation |
| 3 | Levels (Stage 1 Vale Outpost + content packs) | Stage 1 playable |
| 4 | Combat (weapons, projectiles, damage, pickups) | Playable |
| 5 | AI (behavior tree + walker) | Wired in Stage 1 |
| 6 | Camera / HUD / audio / save / pause | Wired in Game host |
| 7–16 | Bosses, editor, full campaign, netcode in-session | In progress |

---

## License

TBD
