# Brambly Hedge: The Game

A peaceful community sim set in the world of Brambly Hedge. Play a newcomer mouse finding their place in a hedgerow village — explore, gather, cook, and help your neighbours carry shared undertakings through the changing seasons, seen through a storybook camera that opens buildings like a picture-book cutaway.

> **"The first cozy sim where the community demonstrably runs, works, and celebrates with or without you — your reward is belonging, not credit."**
>
> *You don't build your empire. You build the community.*

## ⚠ IP Notice — read before doing anything public

This is a **private repository**. The Brambly Hedge IP is owned by Four Seasons Licensing and Merchandising Ltd and is **not yet licensed** to this project ([strategy: D1](docs/gdd/00-decisions.md)).

- The name **"Brambly Hedge" must never appear in any public material** pre-licence: no Steam page, devlog, trailer, social post, build metadata, shipped file or assembly name, screenshot caption, or store text.
- The public/external codename is **Project Hedgerow**. If a stranger could ever see it, it says *Project Hedgerow*.
- Inside this private repo and its docs, canon names may be used freely.
- Full naming rules and the rename-ready architecture: [01-working-title.md](docs/gdd/01-working-title.md).

## Status

**Pre-production.** The 2026-07-04 research sweep (13 documents + synthesis), the full sectioned GDD (00–21), and the production docs are complete. The next step is **Sprint 0** — engine migration, repo + LFS setup, package install — followed immediately by the **2-week camera greybox**, the first production task ([20-mvp.md](docs/gdd/20-mvp.md)). No production code or art exists yet; the Unity folder is a scaffold awaiting the sprint-0 rebuild.

## Repository Structure

```
brambly-hedge-the-game/
├── game/                     # Unity project (open THIS folder in Unity Hub, not the repo root)
│   └── Assets/_Project/      # All our content — scenes, scripts, art, data, dialogue
├── docs/
│   ├── gdd/                  # Game Design Document, sectioned 00–21; 00-decisions.md is binding
│   ├── production/           # Roadmap, backlog, risks, IP strategy, marketing, funding
│   ├── research/             # 2026-07-04 research sweep: canon, IP, comps, market, tech
│   └── development.md        # Setup, conventions, Git+LFS, workflow, MVP checklist
├── CLAUDE.md                 # Standing instructions for AI-assisted sessions
└── README.md                 # This file
```

## Documentation — Reading Order

1. **[docs/gdd/00-decisions.md](docs/gdd/00-decisions.md) — first, always.** The binding decisions brief: every number, name, and rule in every other document must agree with it. Where documents conflict, it wins.
2. [docs/gdd/INDEX.md](docs/gdd/INDEX.md) — the GDD index, with per-section status and the full reading path.
3. [docs/research/00-synthesis.md](docs/research/00-synthesis.md) — the research synthesis the decisions were distilled from; it resolves conflicts among research docs 01–13.
4. [docs/production/roadmap.md](docs/production/roadmap.md) — Plan A (12 months to demo), gates G1–G4, Plan B to 1.0.
5. [docs/gdd/20-mvp.md](docs/gdd/20-mvp.md) — the four gated steps to the first playable.

### Key documents

| Document | What it is |
|----------|------------|
| [Decisions Brief](docs/gdd/00-decisions.md) | **Binding.** Locked decisions D1–D17; overrides everything else |
| [GDD Index](docs/gdd/INDEX.md) | Full design document — vision, pillars, camera, systems, world, NPCs |
| [Research Synthesis](docs/research/00-synthesis.md) | Master synthesis of the 13-doc research sweep; risk register seed |
| [Roadmap](docs/production/roadmap.md) | Production plan: Plan A → gates G1–G4 → Plan B → Q3 2028 launch |
| [MVP](docs/gdd/20-mvp.md) | Sprint 0 → camera greybox → look-dev slice → vertical slice, with pass/fail gates |
| [Development Guide](docs/development.md) | Unity setup, folder + asmdef conventions, Git+LFS, MVP checklist |

## Tech Stack

| Area | Choice |
|------|--------|
| Engine | **Unity 6.3 LTS (6000.3.x) + URP** (Forward+, Render Graph, SRP Batcher + GPU Resident Drawer, linear colour). The current `game/` scaffold is still Unity 2022.3.50f1 / built-in RP — **migration is sprint-0 task 0.1** ([20-mvp.md](docs/gdd/20-mvp.md)); build nothing on the old scaffold |
| Camera | **Cinemachine 3.1.x** (never 2.x) — the Storybook Isometric Camera ([D3](docs/gdd/00-decisions.md)) |
| Dialogue | **Yarn Spinner 3** (Line Groups + saliency) integrated with Unity Localization 1.5.x from month one |
| Input | Input System — keyboard+mouse and controller, two action maps, full rebinding |
| Pathfinding | `com.unity.ai.navigation` (NavMesh); FSM NPC runtime, no utility AI |
| Saves | Newtonsoft JSON — versioned with sequential migrations, atomic writes, save-on-sleep only |
| Platform | PC/Steam + **Steam Deck Verified** at 1.0; consoles post-launch only |
| Performance gate | **60 fps @ 1080p on GTX 1060-class and on Steam Deck** — enforced from the greybox onward |

Full stack rationale: [19-technical-direction.md](docs/gdd/19-technical-direction.md) and the [systems architecture research](docs/research/12-tech-systems-architecture.md).

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- **Unity 6.3 LTS (6000.3.x)** once sprint 0 lands; `game/ProjectSettings/ProjectVersion.txt` is always the authority for the exact version. (Pre-sprint-0 the scaffold reads 2022.3.50f1 — do not develop against it.)
- [Git LFS](https://git-lfs.com/) installed **before cloning** once binary assets exist.

### Open the project

1. Clone this repository (with LFS).
2. Open Unity Hub → **Add** → select the `game/` folder (never the repo root).
3. Load `Assets/_Project/Scenes/Boot.unity` once it exists; greybox test scenes live under `Assets/_Project/Scenes/Greybox/`.

Setup order, folder conventions, asmdef layout, and the Git+LFS ritual: [docs/development.md](docs/development.md).

## Licence

Proprietary — all rights reserved. This repository, its documents, and its code are private. The Brambly Hedge name, characters, and artwork are the property of Four Seasons Licensing and Merchandising Ltd; nothing here grants or implies any right to them. See the IP notice above and [docs/production/ip-strategy.md](docs/production/ip-strategy.md).
