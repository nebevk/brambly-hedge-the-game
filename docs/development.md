# Development Guide

Day-to-day working rules for Project Hedgerow. This guide operationalises the [technical direction](./gdd/19-technical-direction.md) and the [MVP plan](./gdd/20-mvp.md); where anything here seems to disagree with the [binding decisions brief](./gdd/00-decisions.md), the brief wins and this file needs fixing.

## The Design-First Workflow

1. **Read [00-decisions.md](./gdd/00-decisions.md) before implementing anything.** It is binding: every number, name, and rule in code must agree with it. Never "improve" a decided number in code — change the brief first (owner sign-off) or don't change it.
2. **Then the GDD section for the system you are touching** (see the [references table](#references-during-implementation) below) and the [MVP staging](./gdd/20-mvp.md) — if a feature is not in the current step, it does not get built, however small it looks. Task ordering lives in the [backlog](./production/backlog.md).
3. **Strings and names:** no player-facing literal strings in code or prefabs, ever ([D15](./gdd/00-decisions.md)); no canon character/location names in identifiers — string IDs describe *role* (`npc.dairy_keeper`), never canon name ([01-working-title §1.3](./gdd/01-working-title.md)).
4. **Commits:** small and focused; ScriptableObject data changes in separate commits from code; one owner per scene at a time.
5. **Weekly build ritual** (from sprint 0, never skipped): produce a Windows build, smoke-test it, profile on the GTX 1060 reference machine and the Steam Deck, and run the 10-random-screenshots "could this be a book illustration?" vote ([D3](./gdd/00-decisions.md)).

## Unity Project

The Unity project lives in [`game/`](../game/). Always open **`game/`** in Unity Hub, not the repository root.

**Editor version — target: Unity 6.3 LTS (6000.3.x) with URP** (Forward+, Render Graph native, SRP Batcher + GPU Resident Drawer, linear colour, HDR). `game/ProjectSettings/ProjectVersion.txt` is the single authority for the exact version; the whole team pins to the same 6000.3.x patch.

> **Migration note (sprint 0):** the scaffold currently on disk is Unity **2022.3.50f1 on the built-in render pipeline** — end-of-life and deprecated respectively. It is abandoned in place: sprint-0 task 0.1 creates a fresh project from the **URP 3D template** at `game/` and carries the conventions over, per the step-by-step checklist in [19-technical-direction §19.1](./gdd/19-technical-direction.md). **Do not build features, shaders, or content on the 2022.3 scaffold** — the project is empty, which makes this the one week the migration is free. Stay on 6.3 LTS afterwards; engine-version reviews happen once a year at milestone boundaries, never mid-milestone.

**Packages** are pinned at sprint 0 and upgraded only at milestone boundaries. Headlines: Cinemachine **3.1.x — never 2.x** (the namespace is `Unity.Cinemachine`; CM2 APIs and tutorials do not apply), Input System, Unity Localization, `com.unity.ai.navigation`, Yarn Spinner 3, Newtonsoft JSON, Splines, Timeline. Full pinned table and the ~$250 asset-purchase policy: [19-technical-direction §19.3](./gdd/19-technical-direction.md).

## Asset Folder Conventions

All game content goes under `game/Assets/_Project/`:

| Folder | Purpose |
|--------|---------|
| `Scenes/` | `Boot.unity`, `Zones/`, `Interiors/` (additive), `Greybox/` (camera/system test scenes) |
| `Scripts/` | C# by assembly: `Core/`, `Data/`, `Sim/`, `Presentation/`, `UI/`, `EditorTools/` — one asmdef each (below) |
| `Art/` | Models, textures, materials, animations — by family: `Characters/`, `Hedge/`, `Props/`, `Interiors/`, `TrimSheets/` |
| `Audio/` | `Music/`, `SFX/`, `Mixers/` |
| `Prefabs/` | `Characters/`, `Props/`, `Buildings/`, `Systems/` |
| `Data/` | SO instances: `Items/`, `Recipes/`, `NPCs/`, `Schedules/`, `Projects/`, `Festivals/`, `EventChannels/`, `Registry.asset` |
| `Dialogue/` | `.yarn` files and Yarn projects — one folder per NPC |
| `Localization/` | String tables, locales, fonts |
| `Settings/` | URP assets, volume profiles, `LUTs/`, `InputActions.inputactions` |
| `UI/` | Journal sprites, nine-slices, icons |

Third-party and purchased assets live in `game/Assets/ThirdParty/` with their own asmdefs and are **never edited**. Naming: prefabs and scenes PascalCase; SO instances type-prefixed (`Item_Blackberry.asset`, `Schedule_MrsApple.asset`, `EC_DayStarted.asset`); string IDs lowercase dotted (`item.blackberry`, `poi.mill_door`).

## Assembly Definitions — six, inward-only

Assembly and namespace names use the **codename** (`Hedgerow.*`), never the licensed name — compiled assembly names ship inside public builds ([D1](./gdd/00-decisions.md)).

| Assembly | Contents | May reference |
|----------|----------|---------------|
| `Hedgerow.Core` | TimeService, SaveService, event-channel base types, string-ID types, pause state | (engine only) |
| `Hedgerow.Data` | SO definitions (items, recipes, NPCs, schedules, projects, festivals) + the ID registry | Core |
| `Hedgerow.Sim` | Headless logic: schedule interpreter, inventory, friendship, community-project state machine, weather, Store Stump ledger | Core, Data |
| `Hedgerow.Presentation` | Camera rig, roof-fade/occlusion, NPC views/animation, VFX, audio binding, season dressing | Core, Data, Sim |
| `Hedgerow.UI` | The Journal and all menus | Core, Data (reaches Sim via event channels only) |
| `Hedgerow.EditorTools` | Editor-only: schedule visualizer, save inspector, ID validator, word-count reporter | everything |

Arrows point inward only; nothing references UI or Presentation; `Sim` never touches a scene object. A deliberately wrong-direction reference failing to compile is a sprint-0 exit test ([19-technical-direction §19.14](./gdd/19-technical-direction.md)).

## Git + LFS Setup (sprint 0 — in this exact order)

The repository is not yet under Git. Retrofitting LFS after binaries land is the documented disaster path ([architecture research §11](./research/12-tech-systems-architecture.md)), so the order below is binding:

1. **Unity editor settings first:** Asset Serialization = **Force Text**; **Visible Meta Files** (both in the §19.1 migration checklist).
2. **`.gitattributes` before the first binary asset is ever committed.** LFS-track binaries (nemotoo-style template), plus text defaults:

   ```gitattributes
   * text=auto
   *.cs text diff=csharp
   # Unity YAML — merged by UnityYAMLMerge, kept as text
   *.unity  text merge=unityyamlmerge
   *.prefab text merge=unityyamlmerge
   *.asset  text merge=unityyamlmerge
   # Binaries → LFS
   *.fbx filter=lfs diff=lfs merge=lfs -text
   *.blend filter=lfs diff=lfs merge=lfs -text
   *.png filter=lfs diff=lfs merge=lfs -text
   *.psd filter=lfs diff=lfs merge=lfs -text
   *.tga filter=lfs diff=lfs merge=lfs -text
   *.exr filter=lfs diff=lfs merge=lfs -text
   *.wav filter=lfs diff=lfs merge=lfs -text
   *.ogg filter=lfs diff=lfs merge=lfs -text
   *.mp3 filter=lfs diff=lfs merge=lfs -text
   *.mp4 filter=lfs diff=lfs merge=lfs -text
   *.unitypackage filter=lfs diff=lfs merge=lfs -text
   ```

3. **`.gitignore`:** `game/Library/`, `game/Temp/`, `game/Obj/`, `game/Logs/`, `game/UserSettings/`, `Build*/`, IDE folders. **Commit** `game/Assets/`, `game/Packages/` (manifest + lock), `game/ProjectSettings/`.
4. `git init` → `git lfs install` → first commit (attributes + ignore + scaffold), *then* the first texture.
5. **UnityYAMLMerge** registered as the merge driver for scenes/prefabs/assets (path per installed editor version):

   ```
   git config merge.unityyamlmerge.name "Unity SmartMerge"
   git config merge.unityyamlmerge.driver "'C:/Program Files/Unity/Hub/Editor/<6000.3.x>/Editor/Data/Tools/UnityYAMLMerge.exe' merge -p %O %B %A %A"
   ```

6. **Remote with real LFS quotas:** Azure DevOps (free unlimited LFS) or GitHub + a paid data pack — GitHub's free ~1 GB LFS allowance dies fast under watercolour textures.
7. **Name the remote codename-neutral.** The remote repository name must be the codename or a neutral string (e.g. `project-hedgerow`) — never anything containing "brambly" or the licensed title, even on a private remote. Hosting UIs default the repository name to the local folder (`brambly-hedge-the-game`), so override it at creation: the local folder name must not dictate the remote name. The repo may *contain* canon names ([D1](./gdd/00-decisions.md)), but its name, URL, CI badges, and LFS endpoint must not — verify all four in the monthly codename-hygiene audit ([ip-strategy §3.3](./production/ip-strategy.md)).

Acceptance: a test texture round-trips through LFS; a deliberately conflicted prefab resolves through UnityYAMLMerge ([20-mvp task 0.3](./gdd/20-mvp.md)). Social rules that matter more than tooling at this team size: one owner per scene at a time; prefab-heavy workflow so scenes stay thin.

## MVP Checklist (four gated steps)

The road to first playable is **strictly sequential** — no art before the camera is proven, no systems content before the art direction earns traction. Full gates, metrics, and pass/fail tables: [20-mvp.md](./gdd/20-mvp.md).

### Step 0 — Sprint 0: foundations (week 1)

- [ ] Unity 6.3 LTS + URP project at `game/` (fresh from URP template; §19.1 checklist)
- [ ] Packages installed at pinned versions; `Unity.Cinemachine` (CM3) compiles
- [ ] Git + LFS per the section above; first commit made
- [ ] One-click Windows + Steam Deck (Linux) builds from a clean clone
- [ ] Six `Hedgerow.*` asmdefs with the inward-only graph enforced
- [ ] Two input action maps (Gameplay / UI); Localization string tables initialised
- [ ] Frame-time HUD in dev builds; 60 fps @ 1080p gate wired
- [ ] **Exit:** a colleague can clone the repo and produce both builds in under an hour

### Step 1 — Camera greybox MVP (weeks 2–3) — *the first production task*

- [ ] Greybox corridor scene: ~40 m hedge, two-room cottage, mill landmark, occluder plants, slope, stream
- [ ] Follow rig: perspective, FOV 28°, pitch 38°; 8 × 45° yaw snaps with 0.35 s tween + input latching
- [ ] 3 zoom bands (Near / Default / Vista); spline-dolly arrival shot at the mill, interruptible
- [ ] Dither-fade occlusion + dollhouse interior transition (roof fade + vcam blend arriving together)
- [ ] **Exit:** all seven acceptance rows C1–C7 green, including 60 fps on the 1060 and the Deck

### Step 2 — Look-dev slice (months 1–2) → Gate G1

- [ ] One postcard hedgerow pocket at **ship quality**: hand-painted albedo, hero uber-shader, storybook full-screen pass
- [ ] One dressed dollhouse interior with working roof fade
- [ ] One player mouse (10 cm canonical scale) with locomotion; **zero NPCs**
- [ ] Every art review runs with scanned Barklem plates side-by-side
- [ ] **Exit (G1):** 3–5 public clips as *Project Hedgerow*, rename-safe content only — at least one earns clearly organic traction

### Step 3 — Vertical slice, the real MVP (months 3–6) → Gate G2

- [ ] One **summer** zone: village core around the Store Stump, stream edge, broken footbridge
- [ ] 3 dollhouse interiors (Store Stump, cottage kitchen, mill ground floor) + one-room player burrow (bed = save)
- [ ] **3 fully scheduled NPCs** (schedules, dialogue pools, project roles) + up to 2 presence NPCs
- [ ] Gathering: 6–8 canon summer forageables, colourblind-safe highlighting
- [ ] Cooking: 4–6 canon recipes; goods deposit into the Store Stump — **no crafting station** (removed from the old draft)
- [ ] One compressed community project (footbridge repair) with **all five phases** present
- [ ] Full ~20-minute day/night; journal skeleton (map, recipes, prose goals — no checklists); controller + KBM complete
- [ ] 20–30 minutes median playtime
- [ ] **Exit (G2):** four validation goals green with 10–15 external playtesters **and** the measured per-asset cost model fits Plan B

## References During Implementation

| Topic | Design authority | Evidence / plan |
|-------|------------------|-----------------|
| Everything (numbers, scope, names) | [00-decisions.md](./gdd/00-decisions.md) — **binding** | [Research synthesis](./research/00-synthesis.md) |
| Camera | [07-camera-direction.md](./gdd/07-camera-direction.md) | [Camera research](./research/11-tech-camera.md) — greybox test plan lives here |
| Engine, architecture, saves, tooling | [19-technical-direction.md](./gdd/19-technical-direction.md) | [Systems architecture research](./research/12-tech-systems-architecture.md) |
| Community projects | [18-community-philosophy.md](./gdd/18-community-philosophy.md), [14-quests.md](./gdd/14-quests.md) | [Community-sim comps](./research/03-comps-community-sims.md) |
| NPCs, schedules, dialogue | [12-npcs.md](./gdd/12-npcs.md) | [Architecture research §1–3, §6](./research/12-tech-systems-architecture.md) |
| Time & seasons | [13-time-and-seasons.md](./gdd/13-time-and-seasons.md) | — |
| UI / the Journal | [17-ui-philosophy.md](./gdd/17-ui-philosophy.md) | — |
| Art & shaders | [06-art-direction.md](./gdd/06-art-direction.md), [08-visual-identity.md](./gdd/08-visual-identity.md) | [Watercolour rendering research](./research/10-tech-watercolor-rendering.md) |
| Canon facts (names, foods, festivals) | — | [Canon bible](./research/01-brambly-hedge-canon.md) — never invent canon |
| Naming & IP discipline | [01-working-title.md](./gdd/01-working-title.md) | [IP research](./research/02-ip-licensing.md) |
| What to build next | [20-mvp.md](./gdd/20-mvp.md) | [Backlog](./production/backlog.md), [Roadmap](./production/roadmap.md) |
