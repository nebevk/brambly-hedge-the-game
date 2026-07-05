# 19. Technical Direction

[← Back to Index](./INDEX.md) | [Previous](./18-community-philosophy.md) | [Next: MVP →](./20-mvp.md)

This is the technical bible for Project Hedgerow. It implements decisions **D2** (engine & stack), and the technical halves of **D3** (camera), **D6** (time), **D9** (NPCs/dialogue) and **D15** (localization) from the [binding decisions brief](./00-decisions.md). Where this document and the brief disagree, the brief wins. Sources: [systems architecture research](../research/12-tech-systems-architecture.md), [watercolour rendering research](../research/10-tech-watercolor-rendering.md), [camera research](../research/11-tech-camera.md).

The stance throughout: **boring, proven technology arranged carefully.** Our two differentiators — the Storybook Isometric Camera and community projects — are design achievements built on ordinary engine features. Every clever piece of tech we don't build is a week returned to texture painting and heart-scenes.

---

## 19.1 Engine Decision: Unity 6.3 LTS + URP

**Binding (D2): Unity 6.3 LTS (6000.3.x) with the Universal Render Pipeline.** The current scaffold (`game/`, Unity 2022.3.50f1, built-in RP) is abandoned in place during sprint 0.

Why, in one table ([rendering research §1](../research/10-tech-watercolor-rendering.md)):

| Fact | Consequence |
|---|---|
| Unity 2022.3 LTS is end-of-life (updates Enterprise-only since mid-2025) | Our 2022.3.50f1 install receives no fixes for the next 2+ years of development |
| Built-in RP deprecated with Unity 6.5 (June 2026); HDRP in maintenance mode | URP is the only pipeline receiving investment; Asset Store stylized content now assumes URP |
| Shader Graph on built-in RP is "compatibility only" | Every shader we need (dither fade, cutout, storybook pass) is URP-first in docs and tooling |
| GPU Resident Drawer requires URP Forward+ | Our dense-vegetation batching strategy (§19.4) does not exist on built-in RP |
| Unity 6.3 LTS shipped Dec 2025, supported through Dec 2027 | Covers us to the Q3 2028 launch window with one planned LTS hop at most |
| The project contains zero code, zero shaders, zero art (six `.gitkeep` files) | **Migration cost is as close to zero as it will ever be.** A year from now it is a month of work |

Stay on 6.3 LTS; do **not** chase 6.5+ tech-stream releases unless a feature is load-bearing. Plan one engine-version review per year, at a milestone boundary, never mid-milestone.

### Migration checklist (sprint 0, timebox: 1 day)

Because `Assets/_Project` is empty, we do not upgrade in place — we create fresh and carry the conventions over:

1. [ ] Install Unity 6.3 LTS (latest 6000.3.x) via Unity Hub.
2. [ ] Create a new project from the **URP 3D template** at `game/` (move the old scaffold aside first; delete it once step 8 passes).
3. [ ] Recreate `Assets/_Project/` with the folder tree in §19.13 (supersedes the old Art/Audio/Prefabs/Scenes/Scripts/Settings set).
4. [ ] Remove template clutter: sample scenes/readmes, `com.unity.visualscripting`, `com.unity.collab-proxy`, `com.unity.feature.development`. Keep Timeline (festival set-pieces will want it).
5. [ ] Add the packages in §19.3 at the pinned versions; commit `Packages/manifest.json` + `packages-lock.json`.
6. [ ] Project settings: **linear colour space** (template default — verify), **Active Input Handling = Input System only**, Asset Serialization = **Force Text**, **Visible Meta Files**, company/product name = **"Project Hedgerow"** (never the licensed name in build metadata — D1).
7. [ ] URP settings per §19.2 (Forward+, Render Graph native, SRP Batcher, GPU Resident Drawer, HDR).
8. [ ] Acceptance: an empty scene with one URP Lit sphere builds to Windows and runs on the Steam Deck; a trivial custom Render Graph pass (solid-colour vignette) compiles and renders — proving the post-stack path works before we author real passes.
9. [ ] Initialise Git with `.gitattributes` + `.gitignore` **before any binary asset exists** (§19.12), then first commit.

Only after this checklist passes does the **2-week camera greybox begin — the first production task (D3)**.

---

## 19.2 Render Setup

| Setting | Value | Reason |
|---|---|---|
| Pipeline | URP 17.x | §19.1 |
| Rendering path | **Forward+** | Required by GPU Resident Drawer; removes the per-object light limit for lantern-lit interiors and evening scenes |
| Custom passes | **Render Graph native** — compatibility mode OFF from day one | Retrofitting Render Graph into an upgraded project is the documented pain path; starting native avoids it entirely |
| SRP Batcher | On | One uber-shader family keeps every material batchable (§19.4) |
| GPU Resident Drawer | On (static geometry) | Collapses thousands of foliage/prop instances into hundreds of batches ([benchmark: 35k objects → 128 batches](../research/10-tech-watercolor-rendering.md)) |
| Colour space | Linear | Non-negotiable for URP + LUT grading |
| HDR | On | LUT grading and soft bloom-free highlights need headroom; storybook pass grades in HDR before tonemap |
| MSAA | 4× desktop / 2× Steam Deck starting values | Alpha-clip foliage + dither fades benefit; tune against the §19.4 budget |
| Shadows | 1 directional light, 2 cascades, soft; ≤4 shadowed local lights per interior | Watercolour shadows are tinted, soft and cheap — never crisp high-res cascades |

**The post stack is the storybook pass** — the only full-screen work in the game, in this order (art specification in [Art Direction](./06-art-direction.md); techniques in [rendering research §4](../research/10-tech-watercolor-rendering.md)):

1. Height fog / ground mist (purchased, §19.3) — diorama depth separation.
2. Edge darkening — depth+normal edges as warm darkened pigment, noise-wobbled UVs, never black ink.
3. Paper overlay + white paper vignette — 5–15% opacity, world-anchored to avoid shower-dooring.
4. LUT colour grading — one 32³ LUT format project-wide; 4–5 LUTs per season blended by the game clock (D4).
5. Tilt-shift / DoF — **Near and Vista bands only**, per the two scale registers (D3); off at Default.

Hard rules: **no animated watercolour filters, no Kuwahara** (D4). All custom passes are written against Render Graph; every pass has an on/off toggle for the art-direction A/B ritual and the performance budget.

---

## 19.3 Packages & Purchases

### Unity packages (pinned at sprint 0, upgraded only at milestone boundaries)

| Package | Version | Role |
|---|---|---|
| `com.unity.render-pipelines.universal` | 17.x (ships with 6000.3) | Pipeline |
| `com.unity.cinemachine` | **3.1.x (≥3.1.5) — never 2.x** | Storybook camera rig; CM3 is the only line with a future ([camera research §1](../research/11-tech-camera.md)) |
| `com.unity.inputsystem` | 1.14.x | Two action maps, rebinding (§19.10) |
| `com.unity.localization` | 1.5.x (≥1.5.11) | String tables, Smart Strings, pseudo-loc (§19.9) |
| `com.unity.addressables` | 2.x | Pulled in by Localization; not otherwise adopted at MVP |
| `com.unity.ai.navigation` | 2.0.x | NavMesh baking, links, modifiers (§19.8) |
| `com.unity.nuget.newtonsoft-json` | 3.2.1 | Save serialisation (§19.6) |
| `com.unity.splines` | latest verified | CM3 spline-dolly arrival shots |
| Yarn Spinner (`dev.yarnspinner.unity`) | 3.2.x via OpenUPM/git URL | Dialogue (§19.9) |
| `com.unity.timeline` | shipped version | Festival set-pieces, heart-scenes |
| Optional, later: `com.unity.behavior` | 1.x | Only if the hand-rolled NPC FSM outgrows code — not expected |

### Asset purchases (cap: ~$250 total — D2; buy when needed, never before)

| Asset | Price (full / typical sale) | Buy when |
|---|---|---|
| Stylized Grass Shader (Staggart) | ~$35 / ~$17 | Week 1 of look-dev — wind, player-bend trails ("mouse parting grass" is a signature shot), terrain colour blending |
| Atmospheric Height Fog (BOXOPHOBIC) | $20 / $10 | With the first exterior diorama — mouse-height ground mist, tinted distance fog |
| Stylized Water 3 (Staggart) | $49 / $24.50 | When the stream/mill enters the slice, not before |
| Yarn Spinner+ | ~$37.50 | With dialogue month one — supports the tool; speech-bubble presenters fit the storybook look |
| One reference toon/watercolour kit (Flat Kit *or* MK Watercolor) | ~$20–40 on sale | Dissection and prototyping only; the shipped hero shader is ours |

Worst-case total ≈ $180 full-price for the core four; ≈ $110 on sales — comfortably inside the cap with headroom for one surprise.

**Deliberate non-purchases** (each has a named fallback condition): **Easy Save 3** — lock-in on the one system that must outlive everything; revisit only if the custom save stalls > 2 weeks. **A\* Pathfinding Project Pro ($140)** — NavMesh covers a small handcrafted world with ≤12 agents; revisit only if steering through narrow hedge-tunnels proves poor. **Nature Renderer ($99)** — only pays off with Unity-terrain detail scattering; a handcrafted, no-procgen hedge won't use it.

---

## 19.4 Performance Budget

**Binding gate (D2): 60 fps at 1080p on a GTX 1060-class GPU, and 60 fps on Steam Deck (1280×800).** Frame budget 16.6 ms. The cozy audience plays on modest hardware, and Steam Deck Verified is a 1.0 commercial requirement (D11).

**Philosophy: draw calls are the budget, not polygons** (Eastshade's ordering: draw calls first, fillrate second, polycount last — [rendering research §7](../research/10-tech-watercolor-rendering.md)). At mouse scale the camera sits *inside* dense vegetation, so the two killers are batch count and alpha overdraw.

Budgets for the densest exterior scene at Vista band (tripwires — exceeding one triggers investigation at the next weekly build, not automatic cuts):

| Metric | Budget |
|---|---|
| Batches (SRP Batcher + GPU Resident Drawer active) | ≤ 500 |
| SetPass calls | ≤ 150 |
| Full-screen passes | ≤ 4 cheap (fog, edge, paper+vignette, LUT); DoF only at Near/Vista |
| Shadow-casting lights | 1 directional; ≤ 4 local (interiors only) |
| Skinned meshes on screen | ≤ 14 (12 scheduled NPCs + player + one spare) |
| Average alpha-tested overdraw in grass at Near band | ≤ 2.5× |
| VRAM | ≤ 2.0 GB |
| Load: cold boot → playable | ≤ 15 s HDD-class; scene transition ≤ 3 s |

**Vegetation batching strategy** (the one place density threatens the budget):

- **One hero uber-shader family** — vegetation/prop/character variants of a single Shader Graph — so the SRP Batcher never breaks (a second reason, beyond art discipline, to forbid a zoo of shaders — D4).
- **GPU Resident Drawer** handles every static plant, prop and hedge module; it does not cover skinned meshes or particles, which is fine — our skinned count is tiny.
- **Mesh-blade grass, not large alpha cards.** At mouse height the camera looks *through* layers of vegetation; big transparent cards collapse fillrate. Blades are hero meshes (the purchased grass shader is mesh-based).
- **One 2048² foliage atlas** per biome family; trim sheets for burrow interiors (D4 cost levers).
- LODs authored so LOD1 is a whole-canopy simplification; static-combine LOD1 shells only if batch counts demand it (Eastshade's hex-grid trick, held in reserve).

**Measurement ritual:** the reference GTX 1060 machine and the Steam Deck are profiled at every weekly build (§19.12). The camera greybox acceptance test already includes 20–50k wind-animated grass blades at 60 fps with GPU Resident Drawer toggled on/off for the batch-count comparison ([rendering research §7 checklist](../research/10-tech-watercolor-rendering.md)).

**World scale rule:** author the world at **1 Unity unit ≈ 10 cm real** — the player mouse is ~1 unit tall, the hedgerow strip 300–500 units long. Physics, NavMesh, shadow cascades and floating-point precision all behave best around unit-scale characters; simulating at literal 0.1 m would fight every engine default. Gravity, wind and walk speeds are tuned to *feel*, never to real-world values, and exact sizes are never stated in fiction (D14).

---

## 19.5 Project Architecture

### Assembly definitions — six, inward-only

Namespaces, asmdef names and build artefacts use the codename (`Hedgerow.*`), **never the licensed name** — compiled assembly names ship inside public demos, and D1 forbids the name in anything public. This is the rename-safe layer applied to code.

| Assembly | Contents | May reference |
|---|---|---|
| `Hedgerow.Core` | TimeService, SaveService, event-channel base types, string-ID types, pause state | (engine only) |
| `Hedgerow.Data` | ScriptableObject definitions (items, recipes, NPCs, schedules, projects, festivals) + the ID registry | Core |
| `Hedgerow.Sim` | Headless game logic: schedule interpreter, inventory, friendship, community-project state machine, weather, Store Stump ledger | Core, Data |
| `Hedgerow.Presentation` | Camera rig (D3), roof-fade/occlusion, NPC views & animation binding, VFX, audio binding, season dressing swaps | Core, Data, Sim |
| `Hedgerow.UI` | The Journal and all menus ([UI Philosophy](./17-ui-philosophy.md)) | Core, Data (reaches Sim only via event channels/commands) |
| `Hedgerow.EditorTools` | Editor-only: schedule visualizer, save inspector, ID validator (§19.11) | everything |

Dependency arrows point inward only; nothing references UI or Presentation; `Sim` never references a scene object directly. Third-party assets live under `Assets/ThirdParty/` with their own asmdefs and are never edited.

### Event channels — ~10 seams, no more

ScriptableObject event channels (the Chop Chop pattern, applied with restraint — [architecture research §10](../research/12-tech-systems-architecture.md)) are used **only** for cross-system seams. Inside a system, plain C# events and method calls. Adding a channel beyond this table requires removing or justifying one at review:

| Channel | Payload | Publisher → typical subscribers |
|---|---|---|
| `EC_MinuteTick` | minuteOfDay (every 10 game min) | Time → schedules, lighting, ambience |
| `EC_DayStarted` / `EC_DayEnded` | day, season | Time → schedules, growth, restock, autosave |
| `EC_SeasonChanged` | seasonIndex | Time → dressing swaps, LUT sets, schedules |
| `EC_WeatherChanged` | weatherId | Sim → schedules, VFX, dialogue saliency |
| `EC_InventoryChanged` | itemId, delta, source | Sim → journal, project tracker, UI |
| `EC_DialogueStarted` / `EC_DialogueEnded` | npcId, nodeName | Dialogue → time pause, camera, input map |
| `EC_ProjectPhaseChanged` | projectId, phase | Sim → schedules, world dressing, dialogue |
| `EC_FestivalStarted` | festivalId | Sim → set-piece, season valve eligibility |
| `EC_SceneTransitionRequested` | locationId, spawnPoiId | Any → scene loader |
| `EC_SaveRequested` | reason | Sleep flow → SaveService |

Every channel asset shows its current listeners in the inspector and has a debug **Raise** button — this is half the debugging story for free.

### Composition root — no DI framework

A `Boot` scene contains one `Game` MonoBehaviour that constructs services in explicit order (TimeService → SaveService → Registry → Sim services), then additively loads the requested location scene. Services are exposed through one tiny static locator populated only by `Game`. No Zenject/VContainer (complexity priced for teams we aren't), no scattered singletons, no `FindObjectOfType` at runtime.

### Data doctrine — definitions, state, IDs

- **Definitions are ScriptableObjects**: immutable, designer-tuned in the inspector, each carrying a **stable string ID** (`item.blackberry`, `npc.preserver`, `loc.village_store`, `poi.mill_door`, `recipe.springflower_pudding`, `flag.project.winter_ice_hall.phase`).
- **Runtime state is plain C#**: `InventorySlot { string itemId; int count; int quality; }` — never SO references, never scene objects.
- **One registry SO** maps ID → definition, resolved on load; the **ID validator** (§19.11) fails the build on duplicate, missing or dangling IDs.
- IDs are internal and never player-facing; display strings live in localization tables (`LocalizedString` on the SO). Consequence for D1: a licence rename touches string tables and art only — **no code, no IDs, no save formats change**.

### Canonical role-ID registry

**This table is the single source of truth for every NPC, location, gate and recipe ID in the codebase, data assets and save format.** IDs describe a *role*, never a canon character or place name — so the rename-safe layer (D1) holds even inside identifiers that ship in public demos. The **ID validator (§19.11) fails the build on any ID containing a canon character or place name**; the canon display names below live *only* in Unity Localization string tables (D1), never in code, data keys or saves. Other GDD sections cite this registry rather than re-deriving mappings.

| Category | Canon (display, localisation layer) | Role-based ID (code / data / save) |
|---|---|---|
| NPC | Mr Apple (Warden of the Store Stump) | `npc.warden` |
| NPC | Mrs Apple (cook, preserver, diarist) | `npc.preserver` |
| NPC | Wilfred Toadflax (child) | `npc.child_a` |
| NPC | Primrose Woodmouse (child) | `npc.child_b` |
| NPC | Poppy Eyebright (dairy) | `npc.dairy_keeper` |
| NPC | Dusty Dogwood (miller) | `npc.miller` |
| NPC | Basil Brightberry (cellarer) | `npc.cellarer` |
| NPC | Lord Woodmouse (presides) | `npc.squire` |
| NPC | Lady Woodmouse (hostess, painter) | `npc.hostess` |
| NPC | Mrs Toadflax (household keeper) | `npc.homemaker` |
| NPC | Flax (weaver) | `npc.weaver_a` |
| NPC | Lily (weaver, dyer) | `npc.weaver_b` |
| Location | Store Stump | `loc.village_store` |
| Location | Old Oak Palace | `loc.palace_tree` |
| Location | Flour Mill | `loc.mill` |
| Location | Dairy | `loc.dairy` |
| Location | Crabapple Cottage | `loc.orchard_cottage` |
| Location | Weavers' Cottage | `loc.weavers_cottage` |
| Location | Old Mrs Eyebright's cottage | `loc.elder_cottage` |
| Location | Mayblossom Cottage | `loc.riverside_cottage` |
| Location | Elderberry Lodge | `loc.cellar_lodge` |
| Location | Hornbeam Tree | `loc.hornbeam` |
| Location | Bluebell Bank | `loc.flower_bank` |
| Gate | Old Oak Palace attic access | `gate.palace_tree_attic` |
| Gate | Mill-wheel lift | `gate.mill_lift` |
| Gate | Bluebell track | `gate.bluebellTrack` *(kept — "bluebell" is a real-world plant name)* |
| Recipe | Primrose pudding | `recipe.springflower_pudding` |

**POI and favour prefixes follow the same rule:** schedule POIs `StoreStump.*` → `Store.*` and `Hedge.BluebellBank.*` → `Hedge.FlowerBank.*`; favour/beat IDs `favour.basil.*` → `favour.cellarer.*` (beat participants use the NPC role IDs above). Real-world common and botanical words (mill, dairy, stream, hornbeam, chestnut, clover, rosehip, bluebell, blackberry, honey) are **safe** in IDs and stay as-is; canon character names and distinctive canon place names are **not** and must map through this table.

---

## 19.6 Save System

**Binding (D2): Newtonsoft JSON, `saveVersion` + sequential migrations, atomic writes, rotating backups, save-on-sleep only.** No Easy Save (§19.3). Sleep-only saving shrinks the surface enormously: we never serialise mid-day pathfinding, animation or camera state — everything transient is recomputed on load at the start of a day.

**What is saved** (the model, nothing but the model):

| Block | Contents |
|---|---|
| `time` | seasonIndex, dayOfSeason, year, totalDaysElapsed (minuteOfDay is always 06:00 on load) |
| `world` | weather seed/state, unlocked traversal flags, placed/dressing deltas from projects |
| `community` | per-project: phase, soft-threshold contributions, NPC shift progress; Store Stump ledger (deposits by itemId) |
| `npcs` | per NPC: friendship points, hearts, gifts-this-week counter, heart-scenes seen, permanent dialogue flags |
| `player` | home locationId, inventory slots, known recipes, equipped cosmetics |
| `journal` | entries, sketches (as capture parameters, not images), auto-recorded gift preferences, goal restatements |
| `dialogue` | Yarn variable storage snapshot (§19.9) |
| `meta` | saveVersion, build version, timestamp, play time |

Options/settings live in a **separate, independently versioned file** and save immediately on change.

**Rules, all testable:**

1. `int saveVersion` in every file; bumped on any structural change, independent of build version.
2. **Sequential migrations**: a v4 file runs `Migrate4to5`, then `Migrate5to6`, then loads. One small pure function per step; old steps are never edited, only appended.
3. All file I/O lives in one `SaveService`. **Atomic write**: serialise to `save.json.tmp`, flush, then rename over `save.json`.
4. **Rotating backups**: on each save, `save.json` → `save.json.bak1` → `save.json.bak2` (two generations kept).
5. Corrupt file → try `.bak1`, then `.bak2`, then a clear in-fiction message ("this page of the journal is smudged…") offering the recovered day. A file from a *newer* saveVersion → polite refusal. **Never a crash, never silent data loss.**
6. Save corruption and quest/project blockers are the #1 target of the closed beta (D16) — the save inspector (§19.11) exists to make these bugs findable.

---

## 19.7 TimeService & Event Bus

Numbers are binding from D6: **1 game minute = 1 real second**; the clock runs **06:00–24:00** (18 game hours ≈ 18–20 real minutes with pauses); 10-minute display ticks; time pauses in dialogue, journal and cutscenes; **seasons are 14 in-game days and advance only via the festival (the season valve)**.

Architectural consequence of the season valve: **calendar fields are state, not arithmetic.** A season can run past day 14 while the player finishes its project, so `seasonIndex`/`dayOfSeason` are stored and advanced explicitly — never derived from a total-minutes counter. Sketch:

```csharp
public sealed class TimeService
{
    // D6 — the ONE speed constant. "Unhurried mode" option sets ~1.3–1.5.
    public float RealSecondsPerGameMinute = 1.0f;
    public const int DayStartMinute = 6 * 60;    // 06:00
    public const int DayEndMinute   = 24 * 60;   // 24:00 → sleep flow

    public int MinuteOfDay      { get; private set; }  // 360..1440
    public int DayOfSeason      { get; private set; }  // 1..n (≥14 possible — season valve)
    public int SeasonIndex      { get; private set; }  // 0 Spring … 3 Winter
    public int Year             { get; private set; }
    public int TotalDaysElapsed { get; private set; }  // monotonic, for stats/festivals
    public PauseState Pause     { get; set; }          // Running | Dialogue | Journal | Cutscene

    float _accum;
    public void Tick(float dt)
    {
        if (Pause != PauseState.Running) return;
        _accum += dt;
        while (_accum >= RealSecondsPerGameMinute) { _accum -= RealSecondsPerGameMinute; AdvanceMinute(); }
    }
    // AdvanceMinute(): ++MinuteOfDay; every 10 → EC_MinuteTick; on the hour → HourChanged;
    // at DayEndMinute → BeginSleepFlow(). Nothing in the game polls the clock — ever.

    public void AdvanceSeason() { /* called ONLY by FestivalService — the season valve (D6) */ }
}
```

**Sleep = simulated fast-forward, not real-time**: `EC_DayEnded` → overnight steps run synchronously in a fixed order (schedule reset → growth → Store Stump restock → NPC project-shift progress → weather roll) → `EC_SaveRequested` → `EC_DayStarted` at 06:00. The pause enum lives on TimeService so "does the journal pause time?" stays a one-line playtest change.

---

## 19.8 NPC Schedule Runtime

Design authority: [NPCs](./12-npcs.md) and D9. This section is the runtime contract. **12 scheduled NPCs at 1.0, 3 at MVP; FSM, no utility AI** — dependable rhythms ("Poppy bakes on Tuesdays") are the design goal, and emergent AI fights them ([architecture research §1–3](../research/12-tech-systems-architecture.md)).

**Data.** One `NpcScheduleSO` per NPC containing a **priority key cascade** (first match wins), copied from Stardew's proven shape with community-project flags added as first-class keys:

```
festival > project flags (e.g. summer_flag_raft_construction) > weather (rain) >
season_day (spring_15) > dayOfWeek + hearts > season > default
```

`GOTO`-style aliasing lets one key reuse another, so most of a year is written once. Entries are `{ time, locationId, poiId, activityId, optional dialogue node }`. Destinations are **named points of interest** — transforms registered per location scene (`poi.mill_door`, `poi.teasel_bench`) — never coordinates, so level art can change freely through pre-production. The ID validator confirms every referenced POI exists.

**Runtime.** A 4–6 state FSM per active NPC: `Idle → Travel → Activity → Chat` plus a small interrupt stack (player approach pauses, faces, chats, resumes). The schedule cascade decides *where/what* at day start; the FSM only decides *how*.

**Pathfinding.** Unity NavMesh (`com.unity.ai.navigation`): surfaces baked per location scene at edit time; **off-mesh links** for doorways, plank bridges, root climbs and squeeze-gaps; modifier volumes to price muddy or steep areas. Agent dimensions tuned to the unit-scale world (§19.4). A\*PP remains the named fallback only if steering in narrow hedge-tunnels fails playtests.

**Off-screen abstraction — NPCs in inactive locations do not pathfind.** They exist as plain records: `(npcId, locationId, routeId, progress01)`, advanced by the 10-minute tick. Entering a location instantiates the NPC at the interpolated route position. This makes interiors-as-additive-scenes cheap and keeps the skinned-mesh budget honest.

**Travel-leg budgeting.** Departure times are computed, not authored: the interpreter back-solves when an NPC must leave using authoring-time leg estimates (baked path length ÷ walk speed × 1.25 safety). The schedule validator flags any leg that cannot arrive on time — Stardew's modding community proved broken legs are the genre's #1 breakage point, which is why the **schedule visualizer ships before the third schedule exists** (§19.11, binding per D9).

---

## 19.9 Dialogue & Localization Pipeline

**Yarn Spinner 3 (3.2.x) + Unity Localization 1.5.x, integrated from month one** (D9, D15). Dialogue is a core system, not polish — 4,000–8,000 reactive lines at 1.0.

- **Line Groups + saliency** select the most specific line for the current world state across our reactivity axes (season × weather × friendship tier × active project × recent festival) and avoid repeats — this replaces the hand-rolled bark tables other teams build and regret.
- **Smart Variables** expose sim state (hearts, project phase, weather) to writers without programmer round-trips.
- Yarn's **variable storage is bridged into `SaveData.dialogue`** (§19.6) so permanent post-project lines and heart-scene flags persist.
- Yarn Spinner generates and maintains the Unity Localization **string tables** from `.yarn` files; UI text goes through `LocalizedString`; item/NPC display names are `LocalizedString` references on their SOs.

**Hard rules (D15, testable):**

1. **No player-facing literal strings in code or prefabs — from the first commit.** Code review rejects any inline user-visible string.
2. **Pseudo-localization stress test** (accented, +30%-length pseudo-locale) runs before the vertical-slice UI freeze and again before the demo — it catches truncation and hardcoded strings while they are cheap.
3. Word budget **60–80k, enforced**: an editor tool (§19.11) reports total words across all string tables monthly; we pay per word eight times (EFIGS + zh-Hans + JA at 1.0).
4. CJK fonts: TMP dynamic font atlases during development; **static baked atlases at release** for zh-Hans/JA with per-locale font assets and fallbacks.
5. Canon-layer discipline (D1): every canon name is a string-table entry; the rename drill (swap tables, rebuild) is actually run once during the vertical slice to prove the one-week Plan B claim.

---

## 19.10 Input Architecture

**Input System 1.14.x, two action maps** — `Gameplay` and `UI` (D15, [architecture research §9](../research/12-tech-systems-architecture.md)). Opening the journal or entering dialogue switches maps — that *is* the input isolation; no per-script "is the menu open?" checks anywhere.

| Action | Map | KB+M default | Gamepad default |
|---|---|---|---|
| Move | Gameplay | WASD | Left stick |
| Interact | Gameplay | F / left-click | A |
| Rotate camera CW/CCW (45° snap) | Gameplay | Q / E | LB / RB |
| Zoom band up/down (Near/Default/Vista) | Gameplay | Scroll | LT / RT |
| Journal | Gameplay | Tab | Y |
| Cancel / close | both | Esc | B |
| Navigate / Submit / Cancel / page-turn | UI | arrows+Enter+Esc, Q/E pages | D-pad + A + B, LB/RB pages |

Defaults are placeholders pending the camera greybox playtest; **everything is rebindable** (hold/toggle variants included) via `InputActionRebindingExtensions.RebindingOperation`, shipping from the first public build. Movement input is camera-relative with **input latching through yaw-snap tweens** (the camera basis freezes while input is held — [camera research §6](../research/11-tech-camera.md)).

Controller rules from day one: `InputSystemUIInputModule` (never StandaloneInputModule); every screen fully d-pad navigable with a visible selection — "always one selected Selectable" is enforced from the first journal prototype; button prompts swap off the auto-detected control scheme; a single-hand controller layout must be constructible from the rebinding screen (D15).

---

## 19.11 Editor Tooling Commitments

Tooling is scoped work with deadlines, not aspiration. All of it lives in `Hedgerow.EditorTools`:

| Tool | What it does | Due (binding) |
|---|---|---|
| **Schedule visualizer** | Scrub the clock in-editor; draws every NPC's planned day as routes over the location maps; flags unreachable POIs and impossible travel legs | **Before the third NPC schedule exists** (D9) |
| **Save inspector** | Load/inspect/edit any `SaveData` as a tree; run migration chains on demand; diff two saves | With the first persisted system (TimeService save) |
| **ID validator** | Registry scan: duplicate/missing/dangling string IDs, schedule POI references, recipe ingredient references; **fails the build** on error | Month one; runs on every build + weekly CI |
| **Event-channel debugger** | Inspector listener list + Raise button on every channel asset | Free with the channel base class, sprint 0 |
| **Word-count reporter** | Total words per string table vs the 60–80k budget | With the localization tables, month one |

---

## 19.12 Version Control & Builds

The repo is not yet under Git — initialise during sprint 0, in this order (retrofitting LFS is the documented disaster — [architecture research §11](../research/12-tech-systems-architecture.md)):

1. **`.gitattributes` first, before the first binary asset**: LFS rules for `*.fbx *.blend *.png *.psd *.tga *.wav *.ogg *.mp3 *.mp4 *.exr *.unitypackage` (`filter=lfs -text`, nemotoo-style template), plus `* text=auto` defaults.
2. `.gitignore`: `Library/`, `Temp/`, `Obj/`, `Logs/`, `UserSettings/`, `Build*/`, IDE folders. Commit `Assets/`, `Packages/` (manifest + lock), `ProjectSettings/`.
3. Editor settings: Force Text serialization, Visible Meta Files (already in the §19.1 checklist).
4. **UnityYAMLMerge** registered as the merge driver for `.unity` / `.prefab` / `.asset`.
5. Host with real LFS quotas: **Azure DevOps (free unlimited LFS)** or GitHub + a data pack — GitHub's free ~1 GB LFS allowance dies fast under watercolour textures.

Social rules that prevent merge pain at our team size: **one owner per scene at a time**; prefab-heavy workflow so scenes stay thin; data changes (SO assets) in separate commits from code.

**Weekly builds are a ritual, not an option**: every week from sprint 0, a Windows build is produced (one-line build script; CI later if it earns its keep), smoke-tested, profiled on the GTX 1060 reference machine and run on the Steam Deck. Build product name and metadata carry only **Project Hedgerow** (D1). The 10-random-screenshots book-plate vote (D3) happens on this build.

---

## 19.13 Folder Conventions

Builds on the existing `game/Assets/_Project` root (everything ours under one folder so purchased assets can never tangle with ours):

```
game/Assets/
  _Project/
    Art/            (by family: Characters/, Hedge/, Props/, Interiors/, TrimSheets/)
    Audio/          (Music/, SFX/, Mixers/)
    Data/           (SO instances: Items/, Recipes/, NPCs/, Schedules/, Projects/,
                     Festivals/, EventChannels/, Registry.asset)
    Dialogue/       (.yarn files, Yarn projects — one folder per NPC)
    Localization/   (string tables, locales, fonts)
    Prefabs/        (Characters/, Props/, Buildings/, Systems/)
    Scenes/         (Boot.unity, Zones/, Interiors/, Greybox/)
    Scripts/        (Core/, Data/, Sim/, Presentation/, UI/, EditorTools/ — one asmdef each, §19.5)
    Settings/       (URP assets, volume profiles, LUTs/, InputActions.inputactions)
    UI/             (journal sprites, nine-slices, icons)
  ThirdParty/       (purchased assets, own asmdefs, never edited)
```

Naming: prefabs and scenes PascalCase; SO instances type-prefixed (`Item_Blackberry.asset`, `Schedule_MrsApple.asset`, `EC_DayStarted.asset`); string IDs lowercase dotted (§19.5). Interiors are additive scenes loaded through `EC_SceneTransitionRequested`.

---

## 19.14 Sprint 0 Exit Criteria

Sprint 0 is done — and the **camera greybox (D3) begins** — when all of these are true:

- [ ] Unity 6.3 LTS + URP project at `game/`, §19.1 checklist complete, first commit made with LFS rules in place.
- [ ] Forward+, Render Graph native, SRP Batcher + GPU Resident Drawer on, linear colour, HDR on; the trivial Render Graph test pass renders.
- [ ] All §19.3 packages installed at pinned versions; zero console warnings on open.
- [ ] Six asmdefs compile with the §19.5 reference graph enforced (a deliberate wrong-direction reference fails).
- [ ] `Boot` scene + composition root runs; TimeService ticks and raises `EC_MinuteTick` visible in the channel debugger.
- [ ] Empty-scene Windows build runs on the Steam Deck; weekly-build script exists and has produced build #1.

---

[← Back to Index](./INDEX.md) | [Previous](./18-community-philosophy.md) | [Next: MVP →](./20-mvp.md)
