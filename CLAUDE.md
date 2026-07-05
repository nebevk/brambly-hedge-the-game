# CLAUDE.md — standing instructions for AI-assisted sessions

**Project:** Brambly Hedge: The Game (public codename **Project Hedgerow**) — a cosy community-sim in Unity where a hedgerow village of mice demonstrably runs, works, and celebrates with or without the player. Pre-production: research + GDD complete, sprint 0 (engine migration) is next.

## Rule zero — the decisions brief is binding

**Always read [docs/gdd/00-decisions.md](docs/gdd/00-decisions.md) before any design or implementation work.** It locks decisions D1–D17 (IP, engine, camera, scope, time, NPCs, economy, production gates). If any document, comment, or suggestion conflicts with it, the brief wins and the other source is wrong. Never change a decided number or rule in code or docs — flag it for the owner instead. Items marked `⚠ DEFAULT — owner to confirm` are unresolved owner choices: never resolve them silently, and never add that marker anywhere the brief doesn't.

## Document map

| Directory | Role |
|---|---|
| `docs/gdd/` | **Design** — sectioned GDD, chain 00→21, [INDEX.md](docs/gdd/INDEX.md) links all |
| `docs/production/` | **Plans** — roadmap (gates G1–G4), backlog, risks, ip-strategy, marketing-release, funding |
| `docs/research/` | **Evidence** — 2026-07-04 sweep; [00-synthesis.md](docs/research/00-synthesis.md) resolves conflicts among 01–13; [01-brambly-hedge-canon.md](docs/research/01-brambly-hedge-canon.md) is the only source of canon facts — never invent canon |

## IP rule (breaking this is a project-killing incident)

The Brambly Hedge licence is **not held**. This repo is private and may use canon names internally, but the licensed name must **never** appear in anything public-facing:

- builds and build/product metadata, compiled assembly names, shipped file names
- store text, achievements, save keys, telemetry, logs
- marketing copy, devlogs, screenshots, clip captions, file names of posted media

Public name: **Project Hedgerow**, always. Test: *if a stranger could ever see it, it says Project Hedgerow.* Details: [docs/gdd/01-working-title.md](docs/gdd/01-working-title.md).

## Tech stack and sprint-0 status

- **Target: Unity 6.3 LTS (6000.3.x) + URP** (Forward+, Render Graph, linear colour). The Unity project lives in **`game/`** — open `game/` in Unity Hub, never the repo root.
- **The scaffold on disk is still Unity 2022.3.50f1 / built-in RP.** Migration is sprint-0 task 0.1 ([docs/gdd/20-mvp.md](docs/gdd/20-mvp.md)); do not build features, shaders, or content on the old scaffold. The repo is not yet under Git — Git+LFS init (`.gitattributes` before any binary) is also sprint 0 ([docs/development.md](docs/development.md)).
- Packages: **Cinemachine 3.1.x** (namespace `Unity.Cinemachine` — CM2 APIs/tutorials do not apply), Input System, Unity Localization, `com.unity.ai.navigation`, **Yarn Spinner 3**, Newtonsoft JSON.
- Six asmdefs, inward-only: `Hedgerow.Core` ← `Data` ← `Sim` ← `Presentation`; `UI` reaches Sim via event channels only; `EditorTools` sees all. Codename in all assembly/namespace names, never the licensed name.
- After sprint 0, the **2-week camera greybox is the first production task** — before any art or systems (D3).

## Conventions

- **British English in all docs** (colour, neighbours, localisation); code identifiers and package names stay as-is.
- **Rename-ready data layer (D1):** no hardcoded character/location names in code, prefabs, or scenes. Stable, role-based string IDs (`npc.dairy_keeper`, not `npc.poppy`) resolved through the ID registry in `Hedgerow.Data`.
- **No player-facing literal strings in code or prefabs, ever** — everything through Unity Localization string tables / `LocalizedString` (D15). Code review rejects inline user-visible strings.
- Data doctrine: ScriptableObject definitions + plain C# runtime state; saves are versioned JSON, save-on-sleep only, atomic writes ([docs/gdd/19-technical-direction.md](docs/gdd/19-technical-direction.md)).
- SO event channels only for the ~10 cross-system seams listed in §19.5 — adding one requires removing or justifying one.
- Use the D17 vocabulary everywhere: *Storybook Isometric Camera, community project, Store Stump economy, the Journal, heart-scene, season valve, canon layer / rename-safe layer*.

## Definition of done — pointers

- **Performance gate (D2):** 60 fps @ 1080p on GTX 1060-class **and** Steam Deck; budgets (batches, overdraw, VRAM) in [19-technical-direction §19.4](docs/gdd/19-technical-direction.md). Profiled at every weekly build.
- **Screenshot test (D3):** 10 random screenshots per playtest, team-voted "could this be a book illustration?" — the count must not decline build over build.
- MVP step gates (sprint-0 exit, camera C1–C7, G1 GIF traction, G2 playtest + cost model) are in [docs/gdd/20-mvp.md](docs/gdd/20-mvp.md) — work is not done until its step's gate criteria are met.
