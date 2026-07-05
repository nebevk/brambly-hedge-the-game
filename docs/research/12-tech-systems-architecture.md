# Tech Research 12: Unity Architecture & Tooling for a Cozy Life-Sim

Research date: 2026-07-04. Scope: NPC schedules & pathfinding, time-of-day, save systems, dialogue tools, item/inventory data architecture, localization, input, project architecture, version control, and a concrete package list for Unity 6 LTS and 2022.3.

## Key Takeaways

- **Stardew's schedule system is data, not code**: per-NPC schedule files with keys checked in priority order (marriage → rain → `season_day` → day-of-week+hearts → season fallback), each entry = `time / location / tileX tileY / facing / [animation] / [dialogue]`. Copy this shape as ScriptableObjects; it is proven, moddable, and debuggable ([Stardew wiki: Schedule data](https://stardewvalleywiki.com/Modding:Schedule_data), [LemurKat schedule guide](https://lemurkat.wordpress.com/2020/10/10/npc-creation-schedules/)).
- **Use Unity's built-in NavMesh** (`com.unity.ai.navigation`) for our 3D semi-isometric handcrafted maps — free, baked offline, `NavMeshLink` handles doorways/bridges. A* Pathfinding Project Pro ($140) only earns its cost for grids, huge agent counts, or runtime graph changes we don't have ([AI Navigation docs](https://docs.unity3d.com/6000.3/Documentation/Manual/com.unity.ai.navigation.html), [A* 5.0 announcement](https://arongranberg.com/2024/02/a-pathfinding-project-5-0/)).
- **Simple FSM + schedule interpreter beats utility AI** for cozy NPCs: the schedule decides *where/what*, a 4–6-state machine (Idle / Walk / Routine action / Chat) decides *how*. Utility AI and behavior trees add authoring cost without visible benefit at Brambly Hedge's sim depth ([FSM vs BT](https://queenofsquiggles.github.io/guides/fsm-vs-bt/), [GameAIPro on utility-in-BT](https://www.gameaipro.com/GameAIPro/GameAIPro_Chapter10_Building_Utility_Decisions_into_Your_Existing_Behavior_Tree.pdf)).
- **Time**: Stardew runs 0.7 real seconds per game minute (10-min visible ticks, day 6:00–2:00 ≈ 14 real minutes), pauses during dialogue/menus/cutscenes in single-player; the popularity of TimeSpeed-style mods (default: 50% speed indoors) shows players want *slower* cozy time ([Day Cycle wiki](https://stardewvalleywiki.com/Day_Cycle), [TimeSpeed](https://www.nexusmods.com/stardewvalley/mods/169)).
- **Save on sleep only** (genre standard) shrinks the save surface enormously; build JSON saves with Newtonsoft (`com.unity.nuget.newtonsoft-json`), a `version` int from day one, and sequential vN→vN+1 migration routines ([Bugnet save best practices](https://bugnet.io/blog/game-save-best-practices-unity), [Meta save best practices](https://developers.meta.com/horizon/documentation/unity/ps-save-game-best-practices/)). Easy Save 3 (~$69 list, [Asset Store](https://assetstore.unity.com/packages/tools/utilities/easy-save-the-complete-save-game-data-serializer-system-768)) is excellent but is lock-in on the one system that must outlive everything.
- **Dialogue: Yarn Spinner 3** is the fit. Free/open-source (paid "+"-tier optional at ~$37.50), released 3.0 May 2025 (3.2.x current), requires Unity 2022.3+, ships first-class Unity Localization integration, and its new Line Groups/Saliency + Smart Variables are *exactly* the "many NPCs × seasons × conditions" feature we need ([YS3 overview](https://docs.yarnspinner.dev/readme/ys3), [3.2 release](https://yarnspinner.dev/blog/yarn-spinner-3-2-release/), [Unity Localization integration](https://docs.yarnspinner.dev/next/yarn-spinner-for-unity/assets-and-localization/unity-localization)).
- **Items/recipes as ScriptableObjects, runtime state as plain C#**: SO = immutable definition asset with a stable string ID; the inventory saves `{itemId, count, quality}` only, and an ID→SO registry resolves on load ([SO asset registry pattern](https://bronsonzgeb.com/index.php/2021/09/11/the-scriptable-object-asset-registry-pattern/), [Unity SO architecture guide](https://unity.com/how-to/architect-game-code-scriptable-objects)).
- **Unity Localization 1.5.x is mature** (string tables, Smart Strings for plurals/gender, CSV/Google Sheets, pseudo-localization) and is what Yarn Spinner plugs into; it pulls in Addressables ([Localization docs](https://docs.unity3d.com/Packages/com.unity.localization@1.5/manual/Smart/SmartStrings.html)).
- **Engine call**: 2022.3 is past end-of-support; Unity 6.3 LTS (6000.3, released 5 Dec 2025, supported to Dec 2027) is the correct pre-production target — migrate now while the project is small, and move built-in RP → URP at the same time ([Unity 6.3 LTS](https://unity.com/blog/unity-6-3-lts-is-now-available), [GameFromScratch](https://gamefromscratch.com/unity-6-3-released/)).

---

## 1. NPC Schedules — the Stardew Valley model

Stardew stores one schedule file per NPC (`Content/Characters/schedules/*.xnb`). Each file is a dictionary of **schedule keys → slash-delimited entries**; each entry is space-separated fields ([wiki: Modding:Schedule_data](https://stardewvalleywiki.com/Modding:Schedule_data)):

```
<time> [location] <tileX> <tileY> [facingDirection] [animation] ["dialogue"]
```

Example from a modder's guide ([LemurKat](https://lemurkat.wordpress.com/2020/10/10/npc-creation-schedules/)):
`700 EastScarpe 33 101 2/1200 EastScarpe 69 21 2/1800 Beach 4 6 2/2200 BoardingHouse 36 19 3`

Mechanics worth copying:

- **Key resolution is a priority cascade** evaluated once at day start: festival days suspend schedules; then marriage variants; then `rain` (with a 50% `rain2` alternate); then `<season>_<dayNumber>` (e.g. `spring_15`); then day-number + friendship-hearts variants; then `<dayOfWeek>` (e.g. `Mon`); then `<season>`; final fallback `spring`. First match wins ([wiki](https://stardewvalleywiki.com/Modding:Schedule_data)).
- **`GOTO <key>`** lets one key alias another (e.g. `fall: GOTO spring`), so 80% of a year's schedule is written once.
- **Entries are absolute clock times, destinations are named points** (map + tile + facing), optionally an idle animation and a location-specific dialogue line. Time is 24h-style int, earliest 610 ([LemurKat](https://lemurkat.wordpress.com/2020/10/10/npc-creation-schedules/)).
- **Departure times are computed, not authored**: the game back-solves when the NPC must leave to arrive on time; a cross-map leg takes roughly "2 hours" of game time per map crossing, and modders debug broken schedules constantly when map names/tiles are wrong ([LemurKat](https://lemurkat.wordpress.com/2020/10/10/npc-creation-schedules/), [SDV forums](https://forums.stardewvalley.net/threads/i-am-at-a-complete-loss-at-how-npc-scheduling-works-help.21337/)).
- **Cross-location routing uses the warp graph**: locations are nodes connected by warps/doors; tools like NPC Map Locations reconstruct "a hierarchical tree of the in-game locations based on the warps between them" ([Bouhm author guide](https://github.com/bouhm/stardew-valley-mods/blob/main/NPCMapLocations/docs/author-guide.md)). Within a location it's tile A* (`PathFindController`).
- The ecosystem of schedule debug tools ([Schedule Viewer](https://www.nexusmods.com/stardewvalley/mods/19305), [NPC Schedulers](https://www.nexusmods.com/stardewvalley/mods/31494)) is a signal: **build an in-editor schedule visualizer early** — this is the #1 breakage point in the genre.

**Translation to Unity for Brambly Hedge**: `NpcScheduleSO` per NPC per season (or with key cascade inside), entries = `{ time, LocationId, PointOfInterestId, activity, optional dialogue node }`. Points of interest are named transforms placed in scenes ("MillDoor", "TeasleBench"), so schedules never hardcode coordinates — sturdier than Stardew's raw tiles when maps change during development. Community projects (restore the mill) work naturally as **condition flags in the key cascade** (`mill_restored_summer` beats `summer`), exactly how Stardew layers `rain`/hearts variants.

## 2. Pathfinding: built-in NavMesh vs A* Pathfinding Project

- **Unity AI Navigation** (`com.unity.ai.navigation`): NavMeshSurface (bake per scene/agent type), NavMeshLink (doors, bridges, plank crossings — width + two endpoints), NavMeshModifier/ModifierVolume for area costs; works at edit time and runtime; verified 1.1.x on 2022.3 and 2.0.x on Unity 6 ([manual](https://docs.unity3d.com/6000.3/Documentation/Manual/com.unity.ai.navigation.html), [package guide thread](https://discussions.unity.com/t/a-guide-on-using-the-new-ai-navigation-package-in-unity-2022-lts-and-above/371872)).
- **A\* Pathfinding Project 5.x**: Pro is now **$140** (free tier exists); v5 uses Burst/ECS internals, minimum Unity 2021.3.35, 2022.3+ recommended ([arongranberg.com](https://arongranberg.com/2024/02/a-pathfinding-project-5-0/), [download page](https://arongranberg.com/astar/download)). Its wins are grid graphs (2D/tile games), very large agent counts, runtime graph rebuilds, and fine algorithm control ([comparison](https://sivakumar-prasanth.medium.com/a-algorithm-vs-unity-navmesh-choosing-the-right-pathfinding-for-your-game-202a5c776385), [A* forum](https://forum.arongranberg.com/t/a-pathfinding-project-vs-unitys-nav-mesh-agent-for-many-monsters-in-a-big-map/17425)).
- Brambly Hedge is **3D, small, handcrafted, static geometry, ~10–30 NPCs**: NavMesh's weaknesses (2D support, dynamic worlds, huge crowds) don't apply. Verdict: **NavMesh; keep A\*PP as a fallback** only if agent steering quality on narrow hedge-tunnels proves poor.
- **Off-screen NPCs should not pathfind.** Stardew effectively advances NPCs along precomputed routes and snaps them when a location isn't active. Same plan: when the player isn't in a location, NPCs are just `(locationId, progress-along-route)` records; instantiate + place on entry. This also makes "interiors as separate scenes" cheap.

## 3. NPC behavior: FSM vs behavior trees vs utility AI

- FSMs "are fantastic for simple AI" but get messy as transition logic grows; BTs add hierarchy/readability; utility AI scores actions for nuanced, context-dependent choices ([FSM vs BT](https://queenofsquiggles.github.io/guides/fsm-vs-bt/), [Game Developer on BTs](https://www.gamedeveloper.com/programming/are-behavior-trees-a-thing-of-the-past-), [utility vs BT](https://www.toolify.ai/ai-news/choosing-the-best-ai-approach-utility-ai-vs-behavior-trees-2211885)).
- The key insight for a *schedule-driven* life sim: the hard decision ("what should Mrs. Apple do at 14:00 on a rainy autumn Tuesday?") is answered by **data (the schedule cascade), not by AI**. The runtime brain only needs: follow route → arrive → play activity loop → react to player (pause, face, chat, resume). That's a 4–6 state FSM with a tiny interrupt stack. Stardew, the genre benchmark, has no utility AI at all.
- Unity's Open Project "Chop Chop" shipped a reusable SO-based state machine for exactly this class of NPC ([wiki: State Machine](https://github.com/UnityTechnologies/open-project-1/wiki/State-machine)); Unity 6 also offers the free `com.unity.behavior` graph package if visual authoring is wanted later.
- **Avoid** utility AI/GOAP: it makes NPC days *emergent*, which fights our design goal of Barklem-style dependable rhythms ("Poppy bakes on Tuesdays") that players learn and love.

## 4. Time-of-day architecture

Genre reference numbers (Stardew, [Day Cycle wiki](https://stardewvalleywiki.com/Day_Cycle)):

- 1 game minute = **0.7 real seconds** (clock displays 10-minute steps every 7 s); day runs 6:00 → 2:00 = 20 game hours ≈ **14 real minutes/day**.
- Single-player: clock **pauses on dialogue, menus, cutscenes, some animations**; multiplayer never pauses.
- Player demand trends slower: the TimeSpeed/Time Master mod family (defaults: 50% speed indoors, 80% outdoors) is perennially popular ([TimeSpeed](https://www.nexusmods.com/stardewvalley/mods/169), [Time Master](https://www.nexusmods.com/stardewvalley/mods/16192)). Vanilla Stardew does *not* slow time indoors — mods add it because players want it.

Recommended architecture (matches common farming-RPG implementations, e.g. a `TimeManager` owning years/seasons/days/hours and raising events ([course pattern](https://www.udemy.com/course/unity-2d-game-developer-course-farming-rpg/), [Unity clock management](https://docs.unity3d.com/Simulation/manual/author/clock-management/overview.html))):

- **One `TimeService`** accumulates real `deltaTime` → game minutes; everything else is event-driven: `MinuteTick(10)`, `HourChanged`, `DayStarted`, `DayEnded`, `SeasonChanged`, `FestivalStarted`. NPC schedule interpreter, lighting, shop hours, plant growth all subscribe; nothing polls the clock.
- Store canonical time as **`int totalMinutesSinceStart`** (derive year/season/day/time) — trivially serializable, no float drift, easy save migration.
- Sleep = fast-forward: fire `DayEnded` → simulate overnight steps (growth, restock) → autosave → `DayStarted`. No real-time simulation during the skip.
- Pause states as a small enum (Running / DialoguePause / MenuPause / CutscenePause) owned by TimeService, so "does the journal pause time?" is one line to change during playtesting.

## 5. Save system

**Options compared**:

- **JsonUtility (built-in)**: fast, zero deps, but no polymorphism, no Dictionary support — quickly painful for a sim ([JsonUtility vs Newtonsoft](https://medium.com/@rohan5210work/a-unity-developers-guide-to-mastering-json-from-jsonutility-to-newtonsoft-102de5ef9c11)).
- **Newtonsoft Json via `com.unity.nuget.newtonsoft-json` 3.2.1**: free official package; handles dictionaries, polymorphism (`TypeNameHandling` or converters), versioned POCOs. The standard serious-indie choice ([polymorphism thread](https://discussions.unity.com/t/need-to-json-serialize-object-with-polymorphism/1572807)).
- **Easy Save 3** (~$69 list, [Asset Store](https://assetstore.unity.com/packages/tools/utilities/easy-save-the-complete-save-game-data-serializer-system-768)): ~15 years of updates, serializes "almost any type" including GameObjects/Components/SO references, AES-128 encryption, Gzip (~85% smaller files), key-based multi-file storage, no-code Auto Save ([moodkie.com](https://moodkie.com/easy-save-unity/)). Cons: your most critical long-lived system becomes third-party-shaped; "just save the scene objects" encourages saving *presentation* instead of *model*; migrations are still your problem.
- **Unity's newer options** (`[SerializeReference]`, com.unity.serialization) solve polymorphism inside Unity's serializer ([SerializeReference docs](https://docs.unity3d.com/ScriptReference/SerializeReference.html)) but aren't a save *system*.

**Verdict: hand-rolled JSON + Newtonsoft.** A life sim's save is naturally a clean model (time int, flags, inventories, NPC friendship, project progress, placed objects) — precisely the case where a custom `SaveData` POCO graph is small and fully under our control. Save-on-sleep-only (Stardew's rule) means we never serialize mid-day pathfinding/animation state.

**Versioning/migration from day one** ([Bugnet](https://bugnet.io/blog/game-save-best-practices-unity), [Meta best practices](https://developers.meta.com/horizon/documentation/unity/ps-save-game-best-practices/)):

- `int saveVersion` field in every file; bump on any structural change (independent of build version).
- **Sequential migrations**: v4 file → run Migrate4to5 → Migrate5to6 → load. One small function per step, never edit old ones.
- Centralize ALL file I/O in one `SaveService` (encryption/backup/versioning added in one place); **atomic writes** (write `save.tmp`, then rename) + keep 1–2 rotating backups; on corrupt/newer-version files, fail into a clear message, never a crash.
- Stable **string IDs** for every item/NPC/quest/location (never array indices or SO instance refs) — this is what makes migrations survivable.

## 6. Dialogue systems compared

| | Yarn Spinner 3 | Ink | Pixel Crushers Dialogue System |
|---|---|---|---|
| Cost/license | Free, open source; optional paid Yarn Spinner+ from **$37.50** on itch ([get](https://yarnspinner.dev/install/), [itch](https://yarnspinner.itch.io/yarn-spinner)) | Free, **MIT** ([GitHub](https://github.com/inkle/ink-unity-integration)) | Paid asset, ≈$75–95 list, v2.2.55 (Jun 2025) ([store](https://assetstore.unity.com/packages/tools/behavior-ai/dialogue-system-for-unity-11672), [comparison](https://generalistprogrammer.com/tutorials/best-unity-dialogue-systems-complete-asset-comparison)) |
| Authoring | Screenplay-style .yarn nodes; VS Code extension | Prose-first .ink, best-in-class for deep branching | Node graph editor + Lua conditions |
| Localization | **Built-in provider AND official Unity Localization integration** (string tables, addressable voice/assets) ([docs](https://docs.yarnspinner.dev/next/yarn-spinner-for-unity/assets-and-localization/unity-localization)) | Weak: no choice tagging; text-as-key breaks with dynamic text/glue/diverts ([Nordhagen postmortem](https://johnnemann.medium.com/localizing-ink-with-unity-42a4cf3590f3)) | Mature CSV export/import round-trip ([tutorial](https://www.pixelcrushers.com/dialogue_system/manual2x/html/tutorial_localization.html)) |
| Conditions/variables | `<<if>>`, variables persisted via variable storage; **YS3 adds Line Groups + saliency strategies and Smart Variables** — pick the best line given world state ([YS3](https://docs.yarnspinner.dev/readme/ys3)) | Full logic, but flow-centric | Lua-scripted conditions, quest states, big API |
| Unity integration | Requires 2022.3+; 3.2.x current; used by DREDGE, A Short Hike, Lil' Guardsman ([3.2 release](https://yarnspinner.dev/blog/yarn-spinner-3-2-release/)) | Auto-recompile, Ink Player debug window ([README](https://github.com/inkle/ink-unity-integration/blob/master/README.md)) | Deep: save subsystem, quests, Timeline, many asset integrations; heavyweight onboarding ([Pixel Crushers](https://www.pixelcrushers.com/dialogue-system/)) |

**Verdict: Yarn Spinner 3.** Our dialogue is exactly its sweet spot: hundreds of short conditional lines per NPC varying by season/weather/friendship/community-project state → Line Groups with saliency ("most specific matching line, avoid repeats") replaces the hand-rolled bark databases other teams build. Ink's localization weaknesses disqualify it for a localized cozy game; Pixel Crushers is powerful but drags in quest/save/HUD systems we're deliberately building around a journal instead.

## 7. Items, recipes, inventory — ScriptableObject architecture

- **Definitions as SOs**: `ItemDefinitionSO { string id; LocalizedString displayName; icon; category; stackSize; seasonAvailability... }`, `RecipeSO { id; ingredients: [{ItemDefinitionSO, count}]; result; station; unlockedBy }`. Designers tune in the inspector; no scene coupling ([Unity SO architecture](https://unity.com/how-to/architect-game-code-scriptable-objects), [inventory with SOs](https://toqoz.svbtle.com/a-unity-inventory-system-that-actually-works)).
- **Runtime state is plain C#**: `InventorySlot { string itemId; int count; int quality; }`. Never serialize SO references into saves; resolve `id → SO` through a **registry** SO that holds all definitions (validated for duplicate/missing IDs at build time) — the "Scriptable Object Asset Registry" pattern ([Bronson Zgeb](https://bronsonzgeb.com/index.php/2021/09/11/the-scriptable-object-asset-registry-pattern/)).
- **Addressables**: genuinely optional for a small handcrafted game (no DLC/patch-content plans) — direct references + one registry are simpler. But **Unity Localization is built on Addressables** ([docs](https://docs.unity3d.com/Packages/com.unity.localization@1.5/manual/Addressables.html)), so the package will be in the project regardless; if load-time memory becomes an issue later, moving icons/meshes to addressable groups is a mechanical change when IDs already exist ([GUID loading](https://habr.com/en/articles/522834/)).
- Keep systems decoupled: inventory raises `ItemAdded/ItemRemoved` events; cooking, journal, and community-project trackers listen — no hard refs between systems ([painless inventory](https://toqoz.svbtle.com/a-unity-inventory-system-that-actually-works)).

## 8. Localization

- **Unity Localization 1.5.x** (1.5.11 current docs): String Tables + Asset Tables, **Smart Strings** (String.Format-style placeholders, plurals, gender/choice logic), pseudo-localization for early UI stress-testing, CSV and Google Sheets sync, per-locale fonts, UI Toolkit bindings; use 1.5+ on 2022.3 and Unity 6 ([Smart Strings](https://docs.unity3d.com/Packages/com.unity.localization@1.5/manual/Smart/SmartStrings.html), [changelog](https://docs.unity3d.com/Packages/com.unity.localization@1.5/changelog/CHANGELOG.html), [manual](https://docs.unity3d.com/Manual/com.unity.localization.html)).
- Yarn Spinner can generate/maintain the string tables from .yarn files and fetch lines at runtime, including sorting tables by line position in the file ([integration docs](https://docs.yarnspinner.dev/next/yarn-spinner-for-unity/assets-and-localization/unity-localization)).
- Practical rule from every localization postmortem: **no player-facing literal strings in code or prefabs from month one**; UI text goes through `LocalizedString`, item names live on the SO as LocalizedString references. Retrofitis the expensive part, not the package.

## 9. Input: KB+M + controller

- **Input System package** (1.7.0 verified on 2022.3; 1.14.x on Unity 6 ([changelog](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.14/changelog/CHANGELOG.html))). Two action maps minimum: `Gameplay` and `UI`; switch maps when the journal opens — this *is* the pause/dialogue input isolation ([action map guidance](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/)).
- Replace StandaloneInputModule with **InputSystemUIInputModule**; controller UI navigation comes from its move/submit/cancel actions driving Unity's selection system ([UI support docs](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.4/manual/UISupport.html)). Journal-as-UI means we must guarantee **every screen is fully navigable by d-pad/stick with a visible selection** — enforce "always one selected Selectable" from the first journal prototype.
- Rebinding via `InputActionRebindingExtensions.RebindingOperation`; exclude mouse position/delta from listening; ship the package's Rebinding UI sample as a starting point ([rebinding sample discussion](https://discussions.unity.com/t/input-systems-rebind-ui-sample-and-advice/853345), [API](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.InputActionRebindingExtensions.RebindingOperation.html)).
- Use `PlayerInput` (or a thin custom reader à la Chop Chop's SO input reader ([wiki](https://github.com/UnityTechnologies/open-project-1/wiki/Input))) for automatic KB+M ↔ gamepad control-scheme detection, and swap button prompts off the active scheme.

## 10. Project architecture for a 1–3 person team

- **Chop Chop / Unity Open Project 1** is the closest official reference for our stack: ScriptableObject **event channels** as the glue ("channels on which scripts broadcast events; listeners implement reactions"), no singletons, systems live in different additively-loaded scenes and stay independent; channels show listeners in the inspector plus a debug RaiseEvent button ([Event system wiki](https://github.com/UnityTechnologies/open-project-1/wiki/Event-system), [architecture overview](https://github.com/UnityTechnologies/open-project-1/wiki/Game-Architecture-Overview), [Unity how-to](https://unity.com/how-to/scriptableobjects-event-channels-game-code)).
- **Caution**: adopt event channels for the ~10 real cross-system seams (time ticks, day started, item added, dialogue started/ended, save requested, scene transition, community-project progressed) — not for everything. Chop Chop itself was never finished, and community experience says full SO-architecture maximalism creates asset-wiring overhead ([discussion](https://discussions.unity.com/t/scriptable-object-architecture-and-triggering-events-methods-from-data/892334)). Within a single system, plain C# events/methods are fine.
- **Service access**: for 1–3 people, a tiny static service locator (or even a `Game` composition-root MonoBehaviour that constructs TimeService/SaveService/etc. in order) beats a DI framework (VContainer/Zenject) — DI containers earn their complexity with team size we don't have.
- **Assembly definitions**: worth it even solo — faster iteration (only changed assemblies recompile) and, more importantly, **enforced dependency direction**; create asmdefs from zero-dependency folders upward, reference by GUID ([Unity manual](https://docs.unity3d.com/6000.4/Documentation/Manual/cus-asmdef.html), [compile-time analysis](https://medium.com/@juris.savos/how-assembly-definitions-can-turbocharge-unity-compile-times-2d88eedbaf9c), [when to use](https://discussions.unity.com/t/when-to-use-assembly-definitions/936377)). Keep it to ~6 assemblies (below), not 40.

## 11. Version control: Git + LFS

- **Editor settings first**: Asset Serialization = Force Text, Visible Meta Files ([Hextant guide](https://hextantstudios.com/unity-using-git/)).
- `.gitignore`: `Library/`, `Temp/`, `Obj/`, `Logs/`, `UserSettings/`, `Build*/`, IDE folders. Commit `Assets/`, `Packages/` (manifest + lock), `ProjectSettings/` ([comprehensive guide](https://www.virtualmaker.dev/blog/git-and-unity-a-comprehensive-guide-to-version-control-for-game-devs)).
- `.gitattributes` with **LFS rules committed before the first binary asset lands** — retrofitting LFS is painful; track `*.fbx *.blend *.png *.psd *.tga *.wav *.mp3 *.mp4 *.unitypackage` etc. with `filter=lfs -text`; canonical template: [nemotoo's gist](https://gist.github.com/nemotoo/b8a1c3a0f1225bb9231979f389fd4f3f); template repo: [mikewesthad/unity-git-and-lfs](https://github.com/mikewesthad/unity-git-and-lfs).
- Configure **UnityYAMLMerge** as the merge driver for `.unity`/`.prefab`/`.asset`, but the real conflict strategy for a tiny team is social: one owner per scene at a time + prefab-heavy workflow so scenes stay thin ([Unity VCS best practices](https://unity.com/how-to/version-control-systems)).
- Host on a remote with generous LFS quotas — GitHub's free LFS allowance (≈1 GB storage/bandwidth) exhausts fast on a Unity art project; Azure DevOps (free unlimited LFS) or a paid GitHub data pack are the usual answers ([LFS pitfalls](https://medium.com/@0xJake/getting-started-with-git-lfs-in-unity-without-wrecking-your-repo-89c1140cedbd)).

## 12. Recommended packages & project structure

**Engine**: Unity 6.3 LTS (6000.3.x) — released 5 Dec 2025, supported through Dec 2027 (+1 yr Enterprise); first LTS since 6.0 ([Unity blog](https://unity.com/blog/unity-6-3-lts-is-now-available), [80.lv](https://80.lv/articles/unity-6-3-lts-released)). Fallback column given for staying on 2022.3.50f1 temporarily.

| Package | Unity 6.3 LTS | 2022.3 LTS | Notes |
|---|---|---|---|
| `com.unity.inputsystem` | 1.14.x | 1.7.0 | KB+M + gamepad, UI module ([changelog](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.14/changelog/CHANGELOG.html)) |
| `com.unity.localization` | 1.5.x (≥1.5.11) | 1.5.x | Pulls in Addressables ([docs](https://docs.unity3d.com/Manual/com.unity.localization.html)) |
| `com.unity.addressables` | 2.x (as released for 6000.3) | 1.21.x/1.22.x | Required by Localization ([manual](https://docs.unity3d.com/2022.3/Documentation//Manual/com.unity.addressables.html)) |
| `com.unity.ai.navigation` | 2.0.x | 1.1.x (1.1.7) | NavMeshSurface/Link/Modifier ([docs](https://docs.unity3d.com/6000.3/Documentation/Manual/com.unity.ai.navigation.html)) |
| `com.unity.cinemachine` | 3.1.x (3.1.5+) | 2.9.x (or 3.x ≥2022.3.16) | Storybook camera rig; CM3 API differs from CM2 ([manual](https://docs.unity3d.com/6000.2/Documentation/Manual/com.unity.cinemachine.html)) |
| `com.unity.nuget.newtonsoft-json` | 3.2.1 | 3.2.1 | Save serialization |
| `com.unity.render-pipelines.universal` | 17.x | 14.x | Migrate off built-in RP now (roof-fade shaders, stylized lighting) |
| Yarn Spinner (`dev.yarnspinner.unity`) | 3.2.x | 3.x (needs ≥2022.3) | Via OpenUPM/git URL or Asset Store ([install](https://docs.yarnspinner.dev/yarn-spinner-for-unity/installation-and-setup)) |
| Optional: `com.unity.behavior` | 1.x | n/a | Only if FSM authoring outgrows code |
| Optional: Easy Save 3 | ~$69 | ~$69 | Only if custom save stalls |
| Optional: A* Pathfinding Project | 5.x ($140 Pro) | 5.x | Only if NavMesh steering fails us |

**Folder / assembly layout** (everything under one root folder so third-party assets can't tangle with ours):

```
Assets/
  _BramblyHedge/
    Art/  Audio/  Prefabs/  Scenes/  Settings/  UI/
    Dialogue/            (.yarn files, Yarn projects)
    Localization/        (string tables, locales)
    Data/                (SO instances: Items/, Recipes/, NPCs/, Schedules/, EventChannels/)
    Scripts/
      Core/       -> BH.Core.asmdef       (no deps: TimeService, SaveService, event channel types, IDs)
      Data/       -> BH.Data.asmdef       (SO definitions; refs Core)
      Gameplay/   -> BH.Gameplay.asmdef   (NPCs, schedules, inventory, gardening, fishing; refs Core, Data)
      UI/         -> BH.UI.asmdef         (journal, HUD-less UI; refs Core, Data — talks to Gameplay via events)
      Editor/     -> BH.Editor.asmdef     (editor-only: schedule visualizer, ID validators)
  ThirdParty/            (own asmdefs; never edited)
```

Dependency rule: arrows point inward only (UI/Gameplay → Data → Core); no assembly references UI. Editor tooling (schedule visualizer, save inspector, registry validator) lives in BH.Editor from month one.

---

## Implications for Brambly Hedge: The Game

1. **Copy Stardew's schedule data model, upgrade the addressing.** Per-NPC schedule assets with a priority key cascade (`festival > weather > season_day > dayOfWeek+friendship > season > default`) and GOTO-style aliasing — but target *named points of interest*, not tile coordinates, so level art can change freely in pre-production. Add community-project flags as first-class schedule keys (`mill_restored_*`): that is the mechanical heart of "the world visibly changes."
2. **Build the schedule debug visualizer before building many schedules.** Stardew's modding community had to build three separate tools for this; an editor window that scrubs the clock and draws every NPC's planned day on the map will pay for itself within a month.
3. **NavMesh + off-screen abstraction.** Bake NavMesh per location scene, NavMeshLinks for doors/bridges; NPCs in inactive locations exist only as `(location, route-progress)` data. Budget "travel legs" in schedule authoring (Stardew's ~2h per map crossing rule) so NPCs are never late.
4. **Time defaults**: start at 1 game minute = 1 real second (≈20 real min for a 6:00–02:00 day — slower than Stardew's 0.7, fitting our calmer pace), 10-minute display ticks, pause on dialogue/journal/cutscenes, and expose time speed as a single constant — playtest it hard. Given TimeSpeed-mod demand, consider an in-game "unhurried mode" toggle rather than making players mod it.
5. **Save = Newtonsoft JSON, sleep-only, versioned from the first save ever written.** `saveVersion` int + sequential migrations + atomic write + rotating backup, all inside one SaveService. Stable string IDs everywhere. Skip Easy Save 3 — our model-layer state is small and clean, and owning the format protects a 2–4 year project.
6. **Yarn Spinner 3 for dialogue**, integrated with Unity Localization from day one; use Line Groups + saliency for seasonal/weather/friendship-conditional NPC lines instead of hand-rolled bark tables, and buy Yarn Spinner+ (~$37.50) both to support the tool and for the speech-bubble presenters that match our storybook look.
7. **Architecture**: Unity 6.3 LTS + URP migration now (2022.3 support has ended; every added system raises migration cost); ~6 asmdefs with inward-only dependencies; SO event channels for the ~10 cross-system seams (Chop Chop pattern) and plain C# inside systems; a tiny composition root instead of a DI framework.
8. **Repo hygiene day one**: Force Text serialization, nemotoo-style `.gitattributes` committed before the first texture, Library/ ignored, UnityYAMLMerge configured, and an LFS host with real quotas (Azure DevOps free tier or GitHub + data pack).
