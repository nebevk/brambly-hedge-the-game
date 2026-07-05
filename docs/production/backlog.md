# Production Backlog — Project Hedgerow

**Status: the working engineering/art backlog for Plan A (M1–M10).** It implements [D2/D3/D16](../gdd/00-decisions.md), the step plan in [GDD 20 — MVP](../gdd/20-mvp.md) and the doctrine in [GDD 19 — Technical Direction](../gdd/19-technical-direction.md). Dates and gates live in the [roadmap](./roadmap.md). Evidence: [camera research](../research/11-tech-camera.md), [systems architecture research](../research/12-tech-systems-architecture.md), [scoping research](../research/13-scoping-and-production.md).

[← GDD Index](../gdd/INDEX.md) | [Roadmap](./roadmap.md)

---

## 0. Conventions

- **Sizes**: S ≤ 1 dev-day · M = 2–4 dev-days · L = 5–10 dev-days. Nothing bigger than L exists — split it. All sizes are **re-estimated weekly** (A Short Hike's discipline, [scoping research §2](../research/13-scoping-and-production.md)).
- **Tiers**: every story is **Core** (on the shippable path) or **Stretch** (the build ships without it). The stretch tier is cut without a meeting.
- **One owner per story; one owner per scene at a time** ([GDD 19.12](../gdd/19-technical-direction.md)).
- **IDs** are stable and used in commits: `SPR0-x`, `CAM-x`, `LOOK-x`, `TIME-x`, `WLD-x`, `GAT-x`, `CKG-x`, `NPC-x`, `DLG-x`, `JRN-x`, `PRJ-x`, `SAV-x`, `INP-x`, `TOOL-x`, `DEMO-x`.
- **Capacity sanity**: the M3–M6 slice epics below total roughly 150 person-days ≈ 2 FTE × 4 months *with* the 25–30% buffer. If weekly re-estimation pushes the total materially past that, the cut conversation happens that week, not at G2.

## 1. Definition of Done (every story, no exceptions)

A story is Done when **all** of these hold:

1. **Perf gate**: the affected scene stays inside the [GDD 19.4 budgets](../gdd/19-technical-direction.md) — 60 fps / 16.6 ms at 1080p on the GTX 1060 reference machine **and** on Steam Deck (1280×800); densest-exterior tripwires respected (batches ≤ 500, SetPass ≤ 150, skinned meshes ≤ 14, VRAM ≤ 2.0 GB). A regression > 1 ms vs the previous weekly build blocks the merge.
2. **Screenshot test** (any story touching camera, art, lighting or UI): the weekly 10-random-screenshots "could this be a book illustration?" vote does not decline; camera stories additionally keep greybox rows C1–C7 green ([GDD 20](../gdd/20-mvp.md)).
3. **No player-facing literal strings** in code or prefabs — all text through Localization tables ([D15](../gdd/00-decisions.md)); new IDs registered; **ID validator passes** (it fails the build on error).
4. **Save round-trip**: if the story touches persistent state, save → load reproduces it exactly; `saveVersion` bumped + a sequential migration added if the schema changed ([GDD 19.6](../gdd/19-technical-direction.md)).
5. **Both input schemes**: KB+M and gamepad work; any new screen is fully d-pad navigable with a visible selection ([GDD 19.10](../gdd/19-technical-direction.md)).
6. **All 8 yaws**: any world interactable works from every camera yaw — never require a camera angle ([D3](../gdd/00-decisions.md)).
7. Zero new console warnings; committed with meta files; the weekly build is still green from a clean clone.
8. **Asset-hours logged** (art/content stories): actual hours recorded the day the asset is made, into the [G2 cost model](../gdd/20-mvp.md).

---

## 2. Sprint 0 — Foundations (Week 1, timebox 5 working days)

Concrete steps; "open + upgrade" is **rejected** in favour of create-fresh because the 2022.3.50f1 scaffold contains zero content — see the [GDD 19.1 migration checklist](../gdd/19-technical-direction.md) (timebox: 1 day for steps 1–6).

| # | Step | Done when |
|---|---|---|
| SPR0-1 | **Unity Hub**: install Unity **6.3 LTS (latest 6000.3.x)** with modules: Windows Build Support (IL2CPP + Mono), **Linux Build Support (IL2CPP)** for Steam Deck | Editor listed in Hub; both build targets available |
| SPR0-2 | Move the old `game/` scaffold aside; create a fresh project from the **URP 3D template** at `game/`; delete the scaffold once SPR0-13 passes | Project opens clean under 6000.3.x |
| SPR0-3 | Strip template clutter (`com.unity.visualscripting`, `com.unity.collab-proxy`, `com.unity.feature.development`, sample scenes); keep Timeline | Package manifest contains nothing unpinned |
| SPR0-4 | Project settings: **linear colour**, **Active Input Handling = Input System only**, Asset Serialization = **Force Text**, **Visible Meta Files**, product/company name = **"Project Hedgerow"** (never the licensed name in build metadata — [D1](../gdd/00-decisions.md)) | Settings diff reviewed and committed |
| SPR0-5 | URP config: **Forward+**, **Render Graph native (compatibility mode OFF)**, SRP Batcher on, **GPU Resident Drawer** on, HDR on, MSAA 4×/2× desktop/Deck; trivial custom Render Graph pass (solid-colour vignette) renders | Test pass visible in Game view and in a Windows build |
| SPR0-6 | **Packages, pinned** ([GDD 19.3](../gdd/19-technical-direction.md)): `com.unity.cinemachine` **3.1.x (≥3.1.5, never 2.x)** · `com.unity.inputsystem` 1.14.x · `com.unity.localization` 1.5.x (≥1.5.11) · `com.unity.addressables` 2.x (pulled by Localization) · `com.unity.ai.navigation` 2.0.x · `com.unity.nuget.newtonsoft-json` 3.2.1 · `com.unity.splines` (verified) · Yarn Spinner `dev.yarnspinner.unity` 3.2.x via OpenUPM/git URL · `com.unity.timeline` | `Unity.Cinemachine` namespace compiles; manifest + lock committed; zero warnings on open |
| SPR0-7 | **Git + LFS, in this order**: `.gitattributes` with LFS rules (`*.fbx *.blend *.png *.psd *.tga *.wav *.ogg *.mp3 *.mp4 *.exr *.unitypackage` → `filter=lfs -text`, nemotoo-style) **before any binary asset**; `.gitignore` (`Library/ Temp/ Obj/ Logs/ UserSettings/ Build*/`, IDE folders); **UnityYAMLMerge** as merge driver for `.unity/.prefab/.asset`; host with real LFS quotas (**Azure DevOps free unlimited LFS** default, or GitHub + data pack) | A test texture round-trips through LFS from a second clone; a prefab merge resolves |
| SPR0-8 | Folder tree per [GDD 19.13](../gdd/19-technical-direction.md) under `game/Assets/_Project/` (Art, Audio, Data, Dialogue, Localization, Prefabs, Scenes, Scripts, Settings, UI; `ThirdParty/` outside) | Tree committed with `.gitkeep`s |
| SPR0-9 | **asmdef skeleton — six, inward-only** ([GDD 19.5](../gdd/19-technical-direction.md)): `Hedgerow.Core`, `Hedgerow.Data`, `Hedgerow.Sim`, `Hedgerow.Presentation`, `Hedgerow.UI`, `Hedgerow.EditorTools` | A deliberate wrong-direction reference **fails to compile** |
| SPR0-10 | Input actions asset: `Gameplay` + `UI` maps with the [GDD 19.10](../gdd/19-technical-direction.md) default bindings; `InputSystemUIInputModule` in the base UI prefab | Map switch toggles between a test action in each map |
| SPR0-11 | `Boot` scene + composition root (`Game` constructs TimeService → SaveService → Registry in order); event-channel base class + inspector listener list + debug **Raise** button; TimeService stub ticks and raises `EC_MinuteTick` | Tick visible in the channel debugger |
| SPR0-12 | **Save-system walking skeleton** ([GDD 19.6](../gdd/19-technical-direction.md)): `SaveService` with `saveVersion = 1`, atomic write (`save.json.tmp` → rename), two rotating backups, corrupt-file fallback path stubbed; dummy `GameState` round-trips | Automated round-trip test passes; a hand-corrupted file loads `.bak1` with a clear message |
| SPR0-13 | **Weekly-build script**: batch-mode Windows + Linux builds from a clean clone; smoke test = boot to `Boot`, exit code 0; calendar ritual entry; frame-time HUD in dev builds | **Build #1 produced**; empty scene runs on the Steam Deck |
| SPR0-14 | **Localisation bootstrap**: locales `en` + pseudo-locale; string tables `UI` (+ empty `Items`, `Dialogue`); one debug label rendered via `LocalizedString`; word-count reporter stub | Pseudo-locale visibly mangles the label |
| SPR0-15 | **ID registry + validator**: registry SO maps string ID → definition; validator scans duplicates/missing/dangling and **fails the build**; wired into the build script | Planted duplicate ID fails build #1a |
| SPR0-16 | Buy **nothing** ([GDD 19.3](../gdd/19-technical-direction.md)): the ~$250 asset budget is spent when a step needs it | — |

**Exit** = [GDD 19.14](../gdd/19-technical-direction.md): a colleague can clone the repo and produce both builds in under an hour. Only then does CAM begin.

---

## 3. Epic CAM — Storybook Camera Greybox (Weeks 2–3; the first production task, [D3](../gdd/00-decisions.md))

Acceptance rows **C1–C7** referenced below are the binding greybox pass/fail table in [GDD 20 Step 1](../gdd/20-mvp.md); techniques and citations in the [camera research](../research/11-tech-camera.md). Grey primitives only — no art.

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| CAM-01 | Greybox scene: ~40 m hedge corridor, two-room cottage with door, "mill" landmark, 6 large occluder plants, slope, stream crossing | S | Authored at 1 unit ≈ 10 cm (player capsule ~1 unit); NavMesh-bakeable geometry |
| CAM-02 | `CinemachineBrain` + player follow rig: perspective, FOV 28° (band 22–35° exposed), pitch 38° (band 35–45°); `CinemachinePositionComposer` — player slightly below centre, dead zone 0.1×0.1, damping 0.8–1.2 s | M | All values tunable from a runtime dev panel; default 0.5 s EaseInOut blend + Custom Blends asset in place |
| CAM-03 | Yaw snap controller: 8 × 45° steps, 0.35 s smoothstep tween, Q/E + bumpers, **input latching** through tweens | M | **C1**: walk at all 8 yaws, zero control reversals; latching holds direction through every snap |
| CAM-04 | 3 zoom bands (Near/Default/Vista) as named follow-distance + FOV pairs, 0.4 s lerp, scroll/triggers; pivot on player, never cursor | S | Band values are assets (each an art-directed composition); no analog zoom exists |
| CAM-05 | Camera-relative movement basis (ground-projected forward/right) shared with CAM-03's latch | M | No diagonal drift at any yaw; basis freezes while movement input is held |
| CAM-06 | Mill arrival: trigger-volume vcam + `CinemachineSplineDolly` on an authored spline; translation-dominant, 1.5–2.5 s, EaseInOut, cancellable by any movement input | M | **C2**: blend ≤ 2.5 s, interruptible, never clips geometry |
| CAM-07 | Trigger hysteresis (exit collider > enter) + 2 s minimum live time on all camera triggers | S | **C5**: standing on any boundary → zero ping-pong over 60 s |
| CAM-08 | `Lit-DitherFade` shader: 8×8 Bayer → alpha clip in the **opaque** queue, `_FadeAlpha` via MaterialPropertyBlock | M | Faded object still writes depth + casts shadows; no sorting artefacts against foliage; SRP-batchable |
| CAM-09 | `CameraOcclusionFader`: SphereCast (radius **0.1 m**, [GDD 7 §7.4.4/§7.6](../gdd/07-camera-direction.md)) camera→player on `Occluder` layer; fade in 0.2 s / out 0.4 s; never fades small props | M | **C3**: player never fully hidden > 0.5 s anywhere on the planted path |
| CAM-10 | Dollhouse interior: `CM_Interior` vcam (~60% Near follow distance, pitch 45–50°, yaw clamped to the opening, `CinemachineConfiner3D`) + building shell groups (`RoofShell`/`UpperWalls`/`Interior`) fading with the door trigger, 0.6–0.8 s | L | **C4**: exterior→interior reads as one continuous move (no cut); roof fade and vcam blend arrive together |
| CAM-11 | Tilt-shift toggle: subtle, **Vista band only**, off at Default (Near gets the DoF profile — [D3](../gdd/00-decisions.md), [GDD 7 §7.7](../gdd/07-camera-direction.md)) | S | A/B toggle bound; team vote confirms mice read as characters, not toys |
| CAM-12 | Vegetation stress test: 20–50k wind-animated grass blades; GPU Resident Drawer on/off batch comparison ([GDD 19.4](../gdd/19-technical-direction.md)) | M | **C7**: 60 fps @1080p GTX 1060-class **and** Steam Deck in the greybox scene; batch counts logged both ways |
| CAM-13 | Comfort playtest + screenshot ritual bootstrap: 3+ external testers, arrival reframe + yaw snap asked about explicitly, tested at 60 **and** 120+ fps; first 10-screenshot vote logged | S | **C6**: zero discomfort reports; ritual entry #1 recorded |

**Stretch**: CAM-S1 `Lit-CutoutCircle` screen-space cutout (only if C3 fails in hedge corridors — [camera research §5](../research/11-tech-camera.md)) · CAM-S2 narrow free-look (±10° drag) — only if playtests ask.

**On epic fail**: iterate ≤ 2 weeks inside the D3 tuning bands; if dollhouse fade or comfort stays red, stop — flagship-level escalation before any art is commissioned ([GDD 20](../gdd/20-mvp.md)).

---

## 4. Epic LOOK — Look-Dev Slice (M1–M2 → Gate G1)

Quality bar: ship quality. Quantity bar: minimal. Zero NPCs. Every review happens with scanned Barklem plates side-by-side ([D4](../gdd/00-decisions.md)).

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| LOOK-01 | Player mouse: base mesh (the shared base for all later costume variants), rig, locomotion set (idle/walk/run) + one interact | L | Reads at all 3 zoom bands; clean silhouette at Vista; 10 cm canonical scale |
| LOOK-02 | Hero uber-shader v1: 2–3 stop ramp, tinted violet-grey shadows (never black), triplanar granulation, noise-wobbled shadow rims, Fresnel edge darkening, mip paint-mask | L | One shader family (vegetation/prop/character variants) — SRP Batcher never breaks; every feature has an A/B toggle |
| LOOK-03 | Storybook full-screen pass (Render Graph native): warm edge darkening, 5–15% paper overlay (world-anchored), white paper vignette, 32³ LUT slot | M | Each pass toggleable; total full-screen work ≤ 4 cheap passes ([GDD 19.4](../gdd/19-technical-direction.md)); **no Kuwahara, no animated watercolour filters** ([D4](../gdd/00-decisions.md)) |
| LOOK-04 | Exterior postcard pocket: bank, stems, flowers, a door in the roots; hand-painted albedo throughout; purchased grass (~$35) + height fog (~$20) integrated | L | Plate side-by-side vote ≥ 6/10 "book illustration"; POI-dense; no bare ground > 5 character-lengths ([D14](../gdd/00-decisions.md)) |
| LOOK-05 | Dollhouse interior room dressed to plate density; CAM-10 fade running on real assets | L | C4 stays green with production geometry; interior lighting ≤ 4 shadowed local lights |
| LOOK-06 | Season LUT proof: the same pocket under two seasonal LUT sets + a foliage colormap swap | S | Team vote: "same hedge, two books"; swap is data-only (no remodel) |
| LOOK-07 | GIF capture kit + G1 package: in-editor capture, 3–5 clips (clip #1 = Vista→lit-interior pull) | M | Rename-safe audit passed (no canon names in captions/signage/filenames/metadata — [D1](../gdd/00-decisions.md)); posting thresholds pre-registered ([roadmap G1](./roadmap.md)) |

---

## 5. Vertical-Slice Epics (M3–M6 → Gate G2)

Binding scope: [GDD 20 Step 3](../gdd/20-mvp.md). Summer, village core, 3 scheduled + 2 presence NPCs, one compressed project arc, 20–30 min.

### Epic TIME — Clock, day/night, sleep

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| TIME-01 | TimeService full ([D6](../gdd/00-decisions.md), [GDD 19.7](../gdd/19-technical-direction.md)): 1 game min = 1 real s, clock ~06:00–24:00, 10-min display ticks, pause enum (Running/Dialogue/Menu/Cutscene), speed in **one constant** (+ unhurried-mode hook), event channels | M | No system polls the clock — everything subscribes; pausing dialogue provably stops NPC motion |
| TIME-02 | Day/night presentation: directional light arc + clock-driven LUT blending (4–5 LUTs across the day) | M | Dusk reads as a Barklem evening plate in the screenshot vote; zero extra full-screen passes |
| TIME-03 | Sleep flow: bed interact → `EC_DayEnded` → simulated overnight step (restock, project progress) → autosave → `EC_DayStarted` at 06:00 | M | Fast-forward is simulation, not real-time; save lands atomically before the new day renders |

### Epic WLD — World building (the village core)

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| WLD-01 | Village-core layout greybox: hedge bank around the Store Stump, stream edge, **broken footbridge**, all POIs placed as named markers | M | POI every 5–10 s of walking; one landmark breaks the canopy line from every exterior point ([D14](../gdd/00-decisions.md)); camera C1–C7 re-verified in layout |
| WLD-02 | Zone dressing to ship quality (bank, stems, flowers, water — buy Stylized Water 3 ~$49 here, not before) | L | Plate vote holds ≥ 6/10; perf tripwires green at Vista in the densest frame |
| WLD-03 | Far-bank pocket (small; reachable only after the project's Function phase) | M | Unreachable before the traversal flag; visibly enticing from the near bank |
| WLD-04 | Store Stump interior (hero dollhouse) | L | Dressed to plate density; shelves reflect deposits (CKG-03 hook) |
| WLD-05 | Crabapple Cottage kitchen (cooking venue) | M | Cooking station framed at Near band as a "pallet moment" register ([D3](../gdd/00-decisions.md)) |
| WLD-06 | Flour Mill ground floor | M | Arrival spline shot composed; wheel animates |
| WLD-07 | Player burrow room (bed = save point) | S | Sleep flow works end-to-end here |
| WLD-08 | NavMesh: per-scene bakes, `NavMeshLink`s for door/bridge/plank crossings, area costs | M | Every schedule leg in NPC-05..08 resolves; no agent stuck in 30 min of soak |
| WLD-09 | Modular burrow kit v1 + trim sheets (the interior cost lever — [D4](../gdd/00-decisions.md)) | L | All 3 interiors + burrow built ≥ 70% from kit pieces; hours logged per piece |
| WLD-10 | Prop families pass (one bramble kit → many placements; 2048² foliage atlas per family) | M | Batch budget respected; hours logged per prop class |

### Epic GAT — Gathering

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| GAT-01 | Interactable/pickup framework (shared by gathering, doors, stations) | M | Works at all 8 yaws and all 3 zoom bands; prompt is a `LocalizedString` |
| GAT-02 | Inventory: SO definitions + plain-C# runtime slots `{itemId, count, quality}` + `EC_InventoryChanged` | M | Save round-trip; no SO references serialised ([GDD 19.5](../gdd/19-technical-direction.md)) |
| GAT-03 | Summer forage set: 6–8 canon-botanical items (wild strawberries, watercress, dandelion, elderflower among them — [canon](../research/01-brambly-hedge-canon.md)) with seasonal-availability data | M | Every plant is a real summer hedgerow species; availability is data on the SO |
| GAT-04 | Colourblind-safe forage highlighting ([D15](../gdd/00-decisions.md)) | S | Distinguishable in deuteranopia/protanopia/tritanopia sim views; never colour-only |

### Epic CKG — Cooking & Store Stump

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| CKG-01 | Cooking station interaction at Crabapple kitchen | M | One uninterrupted charm-first interaction; time pauses per [D6](../gdd/00-decisions.md) rules |
| CKG-02 | `RecipeSO` + 4–6 summer recipes from the canon feast list (cold watercress soup, honey creams, wild-strawberry dishes — [canon](../research/01-brambly-hedge-canon.md)) | M | Recipes are data + icon + strings; journal auto-records on first cook |
| CKG-03 | Store Stump deposits (the no-money economy — [D8](../gdd/00-decisions.md)): deposit flow + simple ledger | M | Deposits visible on Store Stump shelves; ledger in the save; **no prices anywhere** |
| CKG-04 | Recipe-taught flow (Function-phase reward: an NPC teaches a new recipe) | S | Teaching moment is diegetic dialogue, not a popup |

### Epic NPC — Schedules, FSM, cast

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| NPC-01 | Schedule data model + interpreter: per-NPC `ScheduleSO`, priority key cascade (`festival > project-flag > weather > season_day > dayOfWeek > season > default`) with GOTO aliasing; entries = `{time, locationId, poiId, activity, [dialogue]}` — named POIs, never coordinates | L | Cascade resolution unit-tested; a project flag (`bridge_open`) provably outranks `summer` |
| NPC-02 | NPC runtime FSM: Idle / Walk / Routine / Chat + a tiny interrupt stack (pause, face player, resume) — **no utility AI** ([D9](../gdd/00-decisions.md)) | M | NPC resumes its route correctly after any chat; departure times back-solved so arrivals are on time |
| NPC-03 | Off-screen abstraction: NPCs in inactive locations exist as `(locationId, route-progress)` records; instantiate on scene entry | M | Leaving/re-entering a scene shows NPCs where the clock says they should be |
| NPC-04 | Travel-leg budget validation (with TOOL-01): flags impossible legs and unreachable POIs at authoring time | S | A deliberately broken schedule is flagged in-editor, not discovered in play |
| NPC-05 | **Mr Apple**: full schedule + Store Stump warden role + project proposer ([GDD 12](../gdd/12-npcs.md)) | M | Full day runs clean in the visualizer; ~40–60 slice dialogue lines wired |
| NPC-06 | **Mrs Apple**: full schedule + cooking-teacher role + journal-fiction seed | M | Same bar as NPC-05 |
| NPC-07 | **Dusty Dogwood**: full schedule + miller role; **his schedule visibly changes when the bridge opens** | M | Post-Function schedule variant active the next morning — the [D7](../gdd/00-decisions.md) proof |
| NPC-08 | Presence NPCs **Wilfred + Poppy**: two-block placements, small bark pools, no project role | M | Never block the scheduled three; barks vary by time of day |
| NPC-09 | Costume variants ×5 from the LOOK-01 shared base mesh + shared locomotion set | L | ≤ 14 skinned meshes on screen; hours logged per variant (a critical G2 number) |

**Ordering rule (binding, [D9](../gdd/00-decisions.md)):** TOOL-01 (schedule visualizer) must be Done **before NPC-07 starts** — before the third schedule exists.

### Epic DLG — Dialogue pipeline

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| DLG-01 | Yarn Spinner 3 ↔ Unity Localization integration: .yarn files generate/maintain string tables; buy Yarn Spinner+ (~$37.50) | M | A line edited in .yarn round-trips to the `Dialogue` table; pseudo-locale renders it |
| DLG-02 | Speech-bubble presenter in the storybook style | M | Readable at Default band; time pauses; input map switches to `UI` |
| DLG-03 | Line Groups + saliency wired to world state: season, weather, project phase, friendship stub ([D9](../gdd/00-decisions.md) axes) | M | The "most specific matching line, avoid repeats" behaviour demonstrated across a 3-day soak |
| DLG-04 | Slice writing: ~40–60 lines each for the scheduled three + bark pools for presence NPCs; ≥ 3 permanent post-project lines per involved NPC | L | Hours-per-100-lines logged (G2 model); word counts in the reporter |
| DLG-05 | Dialogue events: `EC_DialogueStarted/Ended` drive time pause, camera hold, input map | S | No per-script "is dialogue open?" checks anywhere |

### Epic JRN — Journal skeleton (the diegetic UI — [D17 terminology](../gdd/00-decisions.md))

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| JRN-01 | Journal shell: open/close with map-switch + time pause; page-turn navigation | M | Fully d-pad navigable, always one visible selection; opens in < 0.5 s |
| JRN-02 | Map spread: illustrated prose map (this is not a minimap — [D14](../gdd/00-decisions.md)) | M | Restates the current goal in words; no markers, no player dot |
| JRN-03 | Recipe spread: auto-records known recipes | S | First-cook auto-entry works; **no completion percentages** |
| JRN-04 | Goal prose restatement driven by project phase (wayfinding safety net) | M | Text updates within one tick of `EC_ProjectPhaseChanged`; reads as diary prose, never a checklist |

### Epic PRJ — The community project arc (the differentiator — [D7](../gdd/00-decisions.md))

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| PRJ-01 | Project state machine: Proposal → Contribution → Construction → Celebration → Function, flags into save + schedule cascade + dialogue saliency | L | Phase transitions fire `EC_ProjectPhaseChanged`; the arc completes (slower) with **zero** player contribution — projects finish without you |
| PRJ-02 | Proposal: Store Stump community meeting; **an NPC proposes, the player seconds — never commands** | M | Meeting is witnessed, not menu-driven; player absence delays nothing beyond the soft rule |
| PRJ-03 | Contribution: soft thresholds ("about twelve bundles of reeds") — **no fill-bars, no counters**, low raw-material caps | M | UI shows prose status only; over-contribution is gracefully declined in dialogue |
| PRJ-04 | Visible NPC work shifts during Contribution/Construction (schedule-flag driven) | M | At any daylight hour ≥ 1 NPC is observably working the site; playtest observation question passes ([GDD 20 Goal 3](../gdd/20-mvp.md)) |
| PRJ-05 | Staged construction site: ≥ 3 visible build states of the footbridge | M | Each state a composed shot; no popping between states while observed |
| PRJ-06 | Celebration: the shared supper on the bank (Timeline set-piece; the demo's golden moment) | L | Starts on time **without** the player; time never freezes; completion moment names NPCs alongside the player |
| PRJ-07 | Function morning: bridge opens (traversal flag → WLD-03), ≥ 1 schedule change (NPC-07), ≥ 1 new recipe (CKG-04), ≥ 1 ambient change | M | All three changes land the next morning; ≥ 50% of testers notice one unprompted |

### Epic SAV / INP — Persistence & input (slice level)

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| SAV-01 | GameState integration: time, world flags, community/project, NPC stubs, player, journal, dialogue variables ([GDD 19.6](../gdd/19-technical-direction.md) blocks) | M | Full slice round-trip mid-arc: phase, deposits and schedules all restore |
| SAV-02 | Sleep-save UX at the bed + slot stub | S | Save-on-sleep only ([D2](../gdd/00-decisions.md)); no manual save anywhere |
| SAV-03 | Corrupt-file fallback: `.bak1` → `.bak2` → in-fiction "smudged page" message | S | Never a crash, never silent loss; newer-version files politely refused |
| INP-01 | Rebinding stub screen (`RebindingOperation`; hold/toggle variants) | M | Every Gameplay action rebindable; conflicts surfaced |
| INP-02 | Button-prompt glyph swap off the detected control scheme | S | KB+M ↔ pad swap < 1 s, no restart |
| INP-03 | Text scaling baseline | S | UI survives 1.5× text without clipping |

### Epic TOOL — Editor tooling ([GDD 19.11](../gdd/19-technical-direction.md) — scoped work with deadlines, not aspiration)

| ID | Story | Size | Due | Acceptance criteria |
|---|---|---|---|---|
| TOOL-01 | **Schedule visualizer**: scrub the clock in-editor; draws every NPC's planned day as routes over the maps; flags unreachable POIs and impossible travel legs | L | **Before the third NPC schedule exists** (before NPC-07) | A planted broken leg is flagged without entering play mode; scrubbing 06:00→24:00 draws all routes < 1 s |
| TOOL-02 | **Save inspector**: load/inspect/edit any `SaveData` as a tree; run migration chains on demand; diff two saves | M | With the first persisted system | A v1 save migrates to current in-tool; diff highlights a single changed flag |
| TOOL-03 | ID validator extensions: schedule POI references, recipe ingredient references, dangling project flags | S | With NPC-01 / CKG-02 | Build fails on a dangling `poi.` or `item.` reference |
| TOOL-04 | Word-count reporter: words per string table vs the 60–80k budget ([D15](../gdd/00-decisions.md)) | S | Month one | Weekly build log prints the running total |
| TOOL-05 | Event-channel debugger (listener list + Raise button) | S | Sprint 0 (free with the base class) | Raise from inspector triggers subscribers in play mode |

### G2 instrumentation

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| G2-01 | Playtest protocol build: instrumented session length, day completions; structured exit-interview sheet covering the [four validation goals](../gdd/20-mvp.md) | M | 10–15 external testers run unguided; per-goal green/red verdict producible from the data alone; the build ships the **codename content flavour** and passes the [GDD 01 §1.4 rename-safe audit](../gdd/01-working-title.md) — zero canon strings on screen, in logs, filenames, save JSON or build metadata — before any tester receives it ([D1](../gdd/00-decisions.md)) |
| G2-02 | Per-asset cost model assembled from the running hours log, extrapolated to 1.0 counts | S | The [GDD 20 G2 table](../gdd/20-mvp.md) filled with measured numbers; fit test computed against 24–30 content person-months incl. buffer |

---

## 6. Epic DEMO — Demo Hardening (M7–M10, summary level; stories split at M6 planning)

| ID | Story | Size | Acceptance criteria |
|---|---|---|---|
| DEMO-01 | Demo content pacing to a **30–45 min median**: one full day + complete project arc + shared-supper golden moment as the ending beat | L | Gold-tier bar: median ≥ 30 min across ≥ 20 external sessions ([demo benchmarks](../research/13-scoping-and-production.md)) |
| DEMO-02 | Full save pipeline: versioned sequential migrations exercised, rotating backups, settings in a separate versioned file | M | A planted v1 save loads through the migration chain in the shipped demo |
| DEMO-03 | Options + day-one accessibility ([D15](../gdd/00-decisions.md)): text scaling, full remapping (hold/toggle), **reduced-motion camera** (arrival dollies → crossfades, faster snaps), colourblind check, single-hand controller layout, audio sliders | L | Every option persists; reduced-motion verified by an affected tester |
| DEMO-04 | **Photo mode with one-click "storybook plate" tilt-shift render — ships from the first public build** ([D13](../gdd/00-decisions.md)) | M | Plate render is share-ready (aspect, paper border); second Cinemachine channel; no canon names in overlays |
| DEMO-05 | Performance pass to the [GDD 19.4](../gdd/19-technical-direction.md) budgets on GTX 1060 + Steam Deck | L | C7 green in the densest demo frame; load ≤ 15 s cold, ≤ 3 s scene transition |
| DEMO-06 | Opt-in telemetry: median session, day completions, drop-off point | M | GDPR-clean consent; numbers feed the publisher deck and G3/G4 |
| DEMO-07 | Pseudo-localisation stress pass + literal-string audit | S | Zero player-facing literals found; UI survives 1.4× (+40%) string expansion ([GDD 17 §7](../gdd/17-ui-philosophy.md)) |
| DEMO-08 | Steam page + build plumbing: page assets live (M4–5 track), Steamworks depots, demo app | M | Page passes the rename-safe audit; demo installs from Steam clean |
| DEMO-09 | Streamer/curator build + key mail-out 2–4 weeks pre-fest | S | 20+ cozy-adjacent creators contacted with press kit |
| DEMO-10 | **External-build rename-safe audit** ([D1](../gdd/00-decisions.md), [GDD 01 §1.2/§1.4](../gdd/01-working-title.md), [IP strategy §3.3](./ip-strategy.md)): before **any** build leaves team machines — G2 playtest build, Next Fest demo, streamer/curator build — the **codename content flavour** is active (the slice is authored with canon names; the swap is never the default) and the §1.4 audit passes | S | Codename flavour verified active in the shipped build; grep of the build finds zero canon strings across screen text, logs, filenames, save JSON, achievements and build metadata; gates release of the G2-01 build and DEMO-08/DEMO-09 distribution |

---

## 7. Beyond the Demo (Plan B seeds — expanded only after G4 passes)

Held as epic-level placeholders so nothing here is accidentally started early: relationship hearts + gifts + journal preferences ([D9](../gdd/00-decisions.md) numbers) · heart-scenes (40–50, the protected budget) · weekly hedgerow supper scene · seasonal package template (the [roadmap §6](./roadmap.md) checklist as a story set) · festivals #1–2 · gardening (reuses GAT + TIME) · NPC roster 5→12 · unhurried mode option · fishing (Could — only if it reuses GAT-01 verbatim) · journal sketching (Could). Fallback-game backlog (if G4 fails) derives from §5–§6 per the [roadmap fallback spec](./roadmap.md).

---

[← GDD Index](../gdd/INDEX.md) | [Roadmap](./roadmap.md)
