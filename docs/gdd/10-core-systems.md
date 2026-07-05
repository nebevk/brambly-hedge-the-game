# 10. Core Systems

[← Back to Index](./INDEX.md) | [Previous](./09-gameplay-loop.md) | [Next: Home →](./11-home.md)

Hard specs for the systems that feed the [gameplay loop](./09-gameplay-loop.md): gathering, cooking, crafting, gardening, fishing, and journal sketching. Traversal/exploration verbs (climb, squeeze, scamper, balance-run) are specced in [05-world](./05-world.md) and [15-progression](./15-progression.md); community projects — the system these all pour into — in [18-community-philosophy](./18-community-philosophy.md).

Every system here obeys three global rules:

1. **No money, no shops** ([D8](./00-decisions.md)). The output sink for everything is the **Store Stump contribution economy**, gifts, and project contributions.
2. **No quality tiers, no crafting/cooking XP, no fail results.** An item is an item; a made dish is a made dish. Grind cannot be reintroduced through the back door.
3. **Recipes and discoveries are Journal-recorded automatically** ([17-ui-philosophy](./17-ui-philosophy.md)) — nobody should ever need a wiki.

## 10.0 Scope & Shared Data Architecture

| System | MoSCoW ([D5](./00-decisions.md)) | 1.0 content target | MVP slice (summer, [D16](./00-decisions.md)) |
|---|---|---|---|
| Gathering | **Must** | ~26 gatherable types across 4 seasons | 8 summer types |
| Cooking | **Must** | ~28 recipes (16 dishes, 9 drinks/preserves, 3 festival set-pieces) | 6 summer recipes |
| Crafting | **Should — proposed, not yet in [D5](./00-decisions.md)** (kept shallow by design; see 10.3) | ~30 craftables: 4 tools, ~20 furniture/decorations, per-project components | absent — no crafting station in the slice ([20-mvp](./20-mvp.md)) |
| Gardening | **Should** | 8 seed types, 4→8 home beds + 2 shared beds | absent |
| Fishing | **Could** | 1 interaction reuse, ~6 stream-forage yields | absent |
| Journal sketching | **Could** ([D13](./00-decisions.md)) | capture + ~12 authored sketch prompts | absent (photo mode arrives at demo hardening — [20-mvp](./20-mvp.md), backlog DEMO-04) |

**Data-model doctrine** (per [19-technical-direction](./19-technical-direction.md)): ScriptableObject definitions + plain-C# runtime state + a string-ID registry validated by editor tooling. IDs are namespaced (`item.*`, `node.*`, `recipe.*`, `station.*`, `npc.*`, `sketch.*`). All display strings are Unity Localization keys — never literals ([D15](./00-decisions.md)) — and every canon-derived name (NPC teachers, canon locations) carries the rename-safe flag so a licence-driven rename stays a content swap, not a code change ([D1](./00-decisions.md)). Botanical item names (blackberry, meadowsweet, chestnut) are real hedgerow botany, not estate IP: they live in the rename-safe layer and survive any outcome.

```csharp
public class ItemDef : ScriptableObject {
    public string id;                 // "item.berry.blackberry" — registry-validated
    public LocalizedString displayName;
    public ItemCategory category;     // Berry, Nut, Flower, Mushroom, Seed, Herb, Material, Dish, Drink, Special
    public Sprite icon;
    public bool canonLayer;           // true → name/strings live in the canon-quarantined table (D1)
    public string[] tags;             // "giftable", "depositable", "festival_dish", ...
}
```

Runtime inventories, node states, ledgers, and sketches are plain serialisable C# in the versioned-JSON save ([D2](./00-decisions.md)).

---

## 10.1 Gathering — **Must**

The most-used verb in the game. Tool-free, one press, always pleasant, never punished.

### Node categories

Six everyday categories plus canon specials:

| Category | Examples | Notes |
|---|---|---|
| Berries | blackberry, wild strawberry, wild raspberry, elderberry, rosehip, crabapple | the autumn glut is the fiction's harvest engine |
| Nuts | chestnut, acorn, hazelnut | windfall piles, heavier carry animation |
| Flowers | primrose, bluebell, cowslip, violet, elderflower, meadowsweet, sweet briar, snowdrop | drive drinks, puddings, decoration, sketch subjects |
| Mushrooms | field mushroom (autumn), St George's mushroom (spring) | botanically real per season ([D4](./00-decisions.md)) |
| Seeds | grass/corn seed-heads, dried winter seed-heads | double as gardening inputs (10.4) |
| Herbs | watercress, dandelion leaf, clover | stream-edge and field-margin flavour |
| Materials | reeds, moss, twigs, bark, wool tufts (fence snags) | crafting and project inputs |
| **Canon specials** | **salt — never gatherable locally**: a scarce import justifying the Sea Story-style expedition ([D8](./00-decisions.md), [canon bible](../research/01-brambly-hedge-canon.md)); honey — Store Stump stock provided by the community, not a node | scarcity with a story attached |

### Seasonal availability — the only soft timer

Seasonal windows are the single sanctioned form of time pressure in the game ([synthesis §3.10](../research/00-synthesis.md)). Missing a window never loses content; it waits a year.

| Gatherable | Cat. | Spr | Sum | Aut | Win | Where | Respawn (in-game days) |
|---|---|:-:|:-:|:-:|:-:|---|:-:|
| Primrose | Flower | ● | – | – | – | hedge bank | 2 |
| Bluebell | Flower | ● | – | – | – | Bluebell Bank | 2 |
| Cowslip | Flower | ● | – | – | – | field margin | 2 |
| Violet | Flower | ● | – | – | – | root shade | 2 |
| St George's mushroom | Mushroom | ● | – | – | – | damp floor | 3 |
| Watercress | Herb | ● | ● | – | – | stream edge | 1 |
| Dandelion leaf | Herb | ● | ● | – | – | field margin | 1 |
| Elderflower | Flower | – | ● | – | – | near Elderberry Lodge | 2 |
| Meadowsweet | Flower | – | ● | – | – | stream bank | 2 |
| Clover | Herb | – | ● | – | – | field margin | 1 |
| Wild strawberry | Berry | – | ● | – | – | sunny bank | 2 |
| Wild raspberry | Berry | – | ● | – | – | hedge heart | 2 |
| Sweet briar petals | Flower | – | ● | – | – | hedge top | 2 |
| Grass & corn seed | Seed | – | ● | ● | – | cornfield edge | 1 |
| Reeds | Material | – | ● | ● | – | stream shallows | 1 |
| Blackberry | Berry | – | – | ● | – | bramble runs | 1 |
| Elderberry | Berry | – | – | ● | – | near Elderberry Lodge | 2 |
| Rosehip | Berry | – | – | ● | ●¹ | hedge | 2 |
| Crabapple | Berry | – | – | ● | – | Crabapple Cottage tree | 2 |
| Chestnut | Nut | – | – | ● | – | Chestnut Woods edge | 1 (windfall) |
| Acorn | Nut | – | – | ● | – | beneath the Old Oak | 1 |
| Hazelnut | Nut | – | – | ● | – | hedge heart | 2 |
| Field mushroom | Mushroom | – | – | ● | – | shaded floor | 3 |
| Snowdrop | Flower | – | – | – | ●² | late-winter banks | 3 |
| Dried seed-heads | Seed | – | – | – | ● | frosted stems | 2 |
| Moss / twigs / bark / wool | Material | ● | ● | ● | ● | throughout | 1–2 |

¹ early winter only. ² late winter only.

**Winter is deliberately lean (3–4 active types).** That leanness is the fiction: winter comfort is *supposed* to come off the Store Stump shelves the community filled in autumn ([canon bible §6](../research/01-brambly-hedge-canon.md)). Autumn dialogue and Journal notes telegraph this ("the blackberries are nearly over") so the scarcity reads as season, not starvation — there are no hunger meters to starve ([D6](./00-decisions.md)).

### Respawn logic

- Node states: `Ready → Gathered → Regrowing(n days) → Ready`. The respawn tick runs in the overnight simulation at sleep.
- Respawn by rarity: common 1 day, uncommon 2, scarce 3 (table above). No permanent depletion, ever.
- Density: 25–40 active nodes per zone per season (matching the POI-every-5–10-s rule, [D14](./00-decisions.md)). A leisurely day's route yields 15–25 items.
- NPC foragers gather from the same node pool on their schedules — you can watch Mrs Apple picking rosehips — but NPC pickings are simulated against a separate budget so the player is never visibly "robbed" of a node they walked towards.

### Interaction design — tool-free

- Walk within reach → single interact press → 0.8–1.2 s bespoke pick animation (stretch up for a berry, two-paw scoop for windfall nuts) → item to satchel with a soft chime. No tools, no durability, no energy cost at 1.0.
- Inventory is Wilfred-style: one **satchel**, 20 slots × stacks of 10. On overflow the prompt suggests the nearest Store Stump shelf — inventory pressure becomes a community nudge, never a punishment.
- Everything works at all 8 camera yaws ([D3](./00-decisions.md)).

### Colourblind-safe highlighting ([D15](./00-decisions.md))

A `Ready` node within ~4 player-lengths at Default zoom signals through **three redundant channels, never hue alone**:

1. **Shape** — a small sparkle glyph pulsing above the node (1 Hz);
2. **Motion** — a gentle 2–3 cm bob on the gatherable element;
3. **Luminance** — rim-light boost ≈ +30% over base albedo.

Acceptance tests: every highlight must remain legible in a greyscale screenshot, and under deuteranopia/protanopia/tritanopia simulation, checked each milestone build. Options menu ships a **High-visibility forage** toggle (persistent outline, doubled glyph size) and honours reduced-motion (bob replaced by glyph-only).

### Data model

```csharp
public class GatherNodeDef : ScriptableObject {
    public string id;               // "node.bramble.autumn_run_03"
    public ItemDef yield;
    public int yieldMin = 1, yieldMax = 3;
    public Season[] activeSeasons;
    public string zoneId;
    public int respawnDays;         // 1–3
    public GatherAnimation anim;    // pick, scoop, pluck, cut
}
// Runtime: NodeState { nodeId, phase, daysUntilReady } — saved per node.
```

### Store Stump / community hooks

- Deposits at Store Stump shelves are the primary sink; the ledger records `ContributionRecord { goalId, itemId, count, dayStamp, contributorId }` — **NPC contributions appear in the same ledger**, and the Journal renders it as prose ("Mr Apple says the reed pile looks nearly enough"), never as a fill-bar ([D7](./00-decisions.md)).
- Project Contribution phases request gathered goods against soft thresholds ("about twelve bundles of reeds"); raw-material caps stay low to forbid material-dump grind ([D7](./00-decisions.md)).
- Gathering near a foraging NPC triggers the shared-basket nicety: they hand you one of theirs with a line — Palia's proximity reward, single-player-ised ([community sims §7](../research/03-comps-community-sims.md)).

---

## 10.2 Cooking — **Must**

Cooking converts the hedgerow into comfort, and comfort into community standing. The launch recipe set comes almost entirely free from canon ([canon bible §6](../research/01-brambly-hedge-canon.md)) — every dish is botanically real and forageable.

### Launch recipe set (1.0 ≈ 28)

Stations: **Hearth** (pot), **Oven** (bake), **Preserving bench** (jams/syrups), **Cordial cellar** (Basil's, drinks), **Dairy** (Poppy's). Teacher NPC names are canon-layer ([D1](./00-decisions.md)); dish names are rename-safe botany.

| Recipe | Station | Key ingredients | Season affinity | Learned from |
|---|---|---|---|---|
| Fresh buns | Oven | flour, butter | Spring | starter Journal |
| Dandelion salad | Hearth | dandelion leaf, watercress | Spring | starter Journal |
| Primrose pudding | Oven | primrose, flour, honey | Spring | **heirloom diary page** (Mrs Apple's grandmother) |
| Cowslip wine | Cordial cellar | cowslip, honey | Spring | Basil Brightberry |
| Watercress soup (cold) | Hearth | watercress, cream | Summer | Poppy Eyebright |
| Clover bread | Oven | flour, clover | Summer | Dusty Dogwood |
| Honey creams | Dairy | cream, honey | Summer | Poppy Eyebright |
| Syllabub | Dairy | cream, elderflower cordial | Summer | Poppy Eyebright |
| Meringues & wild strawberries | Oven | egg white, wild strawberry | Summer | Mrs Crustybread |
| Rhubarb crumble | Oven | rhubarb (grown, 10.4), flour, butter | Summer | Mrs Toadflax |
| Elderflower cordial | Cordial cellar | elderflower, honey | Summer | Basil Brightberry |
| Wild raspberry cordial | Cordial cellar | wild raspberry | Summer | Basil Brightberry |
| Sweet briar cordial | Cordial cellar | sweet briar petals | Summer | Basil Brightberry |
| Clover cordial | Cordial cellar | clover | Summer | Basil Brightberry |
| Meadowsweet wine | Cordial cellar | meadowsweet, honey | Summer | Basil (wedding project unlock) |
| Butter | Dairy | milk | any | Old Mrs Eyebright |
| Cheese | Dairy | milk, salt | any | Old Mrs Eyebright |
| Seed cake | Oven | seed, flour, butter | Autumn | Mrs Apple |
| Acorn coffee | Hearth | acorn (roasted) | Autumn/Winter | Mrs Apple (served with seed cake) |
| Blackberry buns | Oven | blackberry, flour | Autumn | Dusty Dogwood |
| Rosehip jam | Preserving | rosehip, honey | Autumn | Mrs Apple |
| Hedgerow pie | Oven | blackberry, crabapple, flour | Autumn | Mrs Apple |
| Blackberry syrup | Cordial cellar | blackberry | Autumn | Basil Brightberry |
| Elderberry syrup | Cordial cellar | elderberry | Autumn | Basil Brightberry |
| Crabapple syrup | Cordial cellar | crabapple | Autumn | Basil Brightberry |
| Chestnut soup (hot) | Hearth | chestnut, cream | Winter | Mrs Apple, at first snow (calendar event teach) |
| Celebration cake | Oven | flour, butter, honey, preserved berries | festival | Mrs Crustybread (Midwinter project Function unlock) |
| Celebration punch | Cordial cellar | any 3 syrups/cordials | festival | Basil (festival Function unlock) |

Flour, milk, cream, and egg white are **Store Stump withdrawals** (flour milled by Dusty; dairy goods from Poppy; the rest stocked by the community) — cooking depends on the community's services working, which is exactly the point. MVP slice ships exactly 6 summer recipes ([20-mvp](./20-mvp.md)): watercress soup (cold), clover bread, honey creams, meringues & wild strawberries, elderflower cordial, and wild raspberry cordial. Rhubarb crumble stays out of the slice (it needs gardening, absent per 10.0), and so does syllabub (the only recipe that consumes another made dish).

### How recipes are learned

No recipe shop, no research tree. Four sources, all Journal-recorded the moment they're learned:

1. **Starter Journal** (2 recipes: fresh buns, dandelion salad) — the newcomer arrives with a modest family cookbook; Mrs Apple walks the player through both when the kitchen is restored ([11-home §11.5](./11-home.md)).
2. **NPC-taught** (majority) — via heart-tier scenes, favour reciprocity ("taught recipe" is a standard give-back within one in-game day), and standing lessons in their own kitchens (you cook *at Poppy's dairy*, beside her).
3. **Project Function unlocks** — every completed community project changes ≥1 service/recipe ([D7](./00-decisions.md)).
4. **Heirloom diary pages** — lore collectibles from Mrs Apple's matrilineal diaries hidden in the world ([14-quests](./14-quests.md)); canon: recipes are handed down mother to daughter.

### Cooking interaction sketch

1. Approach a station → near-register arrival framing (interruptible, [D3](./00-decisions.md)).
2. Journal opens to the recipe spread (time paused, [D6](./00-decisions.md)). Recipes with all ingredients in satchel + shelf reach are bright; missing ingredients are described in prose ("blackberries — the bramble runs, in autumn"), never map-pinned.
3. Confirm → one tactile gesture **per station type, not per recipe** (knead for Oven, stir for Hearth, press for Preserving, pour for Cordials, churn for Dairy), 8–15 s, skippable in accessibility options. One gesture per station is the explicit guard against Spiritfarer's repeated-micro-minigame fatigue ([cozy quests §2](../research/06-comps-cozy-quests.md)).
4. 30–60 game minutes pass in a short montage; the dish lands in the satchel; the Journal records the make (first-make gets an illustrated entry).
5. No burn state, no quality stars, no cooking level.

### Data model

```csharp
public class RecipeDef : ScriptableObject {
    public string id;                    // "recipe.chestnut_soup"
    public ItemDef output;
    public IngredientLine[] ingredients; // ItemDef + count; max 4 lines
    public StationType station;          // Hearth, Oven, Preserving, CordialCellar, Dairy
    public Season seasonAffinity;        // journal/display only — never a hard gate
    public RecipeSource source;          // Starter, NpcTaught, ProjectUnlock, DiaryPage
    public string teacherNpcId;          // canon layer (D1); empty for Starter/DiaryPage
    public string journalPageId;
}
```

### Store Stump / community hooks

- **Deposits are the output sink**: cooked goods carry more "shelf-warmth" than raw forage in festival-readiness checks (soft thresholds, prose feedback). Depositing a dish an upcoming festival needs draws a bespoke thank-you line from Mr Apple.
- Festival Contribution formats consume dishes directly — the communal-dish table at the spring picnic, the Midwinter gift exchange ([D10](./00-decisions.md)).
- Gifting a cooked dish an NPC loves follows the standard gift numbers (+80, [D9](./00-decisions.md)); loved-dish knowledge auto-records in the Journal.

---

## 10.3 Crafting — **Should (proposed — not yet in D5)**, kept intentionally shallow

Deep crafting trees are a **Won't** ([D5](./00-decisions.md)) — and D5 assigns crafting no tier of its own, so the Should here is a **proposed D5 addition awaiting owner confirmation**, not a binding tier. Its parts already serve tiers D5 does grant: project components feed Must-tier community projects ([D7](./00-decisions.md)), furniture/decorations exist only for Could-tier house customisation, and the tools support Should-tier gardening and gentle progression pacing. Crafting exists to (a) furnish the burrow, (b) provide 3–5 gentle tool gates, (c) give community projects tactile component work. It must never grow intermediate-component chains, tiers, or a tech-tree UI.

**Hard rules:** every craftable is single-step (ingredients → item at a station); max 4 ingredient lines; no station upgrades; recipes learned exactly like cooking (taught, project unlock, diary page).

**Station-based, and the stations belong to the community** — you borrow the workshop and the company, you don't build a home factory:

| Station | Where | Categories made there |
|---|---|---|
| Workbench | Store Stump workshop (Mr Apple's) | tools, storage, project components |
| Loom | the weavers' (Flax & Lily) | cloth, blankets, soft furnishings |
| Home bench | player burrow (ships with [house customisation, Could](./11-home.md)) | small furniture, decorations |

**Categories & 1.0 content:**

- **Tools (4):** lantern (dusk gathering comfort), winter cloak (long outdoor winter days), garden set (unlocks 10.4 beds), satchel upgrade (+8 slots). These are the quiet tool-gates that pace the map alongside friendship gates ([cozy quests §7](../research/06-comps-cozy-quests.md)); the big traversal gates stay with community projects ([D7](./00-decisions.md)).
- **Furniture & decorations (~20):** stools, shelves, quilts, pressed-flower frames — relevant only if house customisation ships; first candidate for the quarterly scope cut ([D5](./00-decisions.md)).
- **Project components (authored per project):** reed bundles, woven blanket lots, snow blocks — these are *contribution work*, requested in soft quantities, crafted beside visibly-working NPCs.

```csharp
public class CraftableDef : ScriptableObject {
    public string id;                    // "craft.tool.lantern"
    public ItemDef output;
    public IngredientLine[] ingredients; // max 4
    public string stationId;             // "station.loom" — canon-layer location binding
    public CraftCategory category;       // Tool, Furniture, Decoration, ProjectComponent
    public RecipeSource source;
}
```

**Community hooks:** project components feed the Contribution-phase ledger like deposits; crafting at a community station while its owner works there grants ambient chat lines (cheap aliveness, [community sims §5](../research/03-comps-community-sims.md)).

---

## 10.4 Gardening — **Should**

Gardening is deliberately a *reuse* system: it recombines the gathering interaction with the time system, adding almost no new mechanics ([D5](./00-decisions.md)).

- **Plots:** 4 raised beds at the player burrow, expandable to 8 via a small favour arc with Mr Apple; plus 2 **shared community beds** near Crabapple Cottage that NPCs visibly tend on their schedules — the player can water and harvest there too (shared, like everything in the hedge).
- **Loop:** plant a seed (seeds come from the gathering Seed category, NPC gifts, and diary pages) → grows 2–4 in-game days → becomes a standard `Ready` gather node (same interaction, same highlighting as 10.1).
- **Seasonal seeds only grow in-season**; out-of-season sowing is gently refused with a Journal note ("rhubarb sleeps till spring"). Winter beds rest under mulch.
- **Watering is positive-only care:** watering trims one day off growth; *not* watering never kills a plant. No wilt state, no fertiliser economy, no sprinkler tech — those are farming-sim furniture and this is not a farming sim.
- **1.0 seed list (8):** rhubarb (the canon crumble input), corn-salad, radish, chamomile, marigold, forget-me-not, teasel (craft material), winter-sown broad bean (sprouts in spring).

```csharp
public class PlantingDef : ScriptableObject {
    public string id;                // "plant.rhubarb"
    public ItemDef seed;
    public GatherNodeDef matureNode; // reuses the gathering system wholesale
    public int growDays;             // 2–4 (−1 if watered each day)
    public Season[] sowSeasons;
}
```

**Community hooks:** grown produce is depositable and giftable like anything else; the shared beds contribute to festival readiness; an NPC who gifted you seeds comments when the first harvest reaches the Store Stump.

---

## 10.5 Fishing — **Could**

One line, per [D5](./00-decisions.md): fishing ships only as a reskin of gathering — stream-edge nodes where the interact press casts a line and a single timing tap on the bobber's dip lands the catch; no rods, no tiers, no fish AI.

**Canon note:** no documented Brambly Hedge dish contains fish ([canon bible §6](../research/01-brambly-hedge-canon.md)) — the mice's table is entirely hedgerow-vegetarian. If fishing ships, its yields are therefore **stream forage** (watercress clumps, reeds, freshwater shells, the occasional lost trinket for a favour hook), not fish-as-food. If even this reuse threatens the schedule, fishing is cut without design debt — nothing else references it.

---

## 10.6 Journal Sketching — **Could** (replaces photography, [D13](./00-decisions.md)) ⚠ DEFAULT — owner to confirm

Canon-native: Lady Daisy Woodmouse is the hedge's keen sketcher and painter ([canon bible §3](../research/01-brambly-hedge-canon.md)). The photography system is demoted to diegetic journal sketching; the separate marketing-grade **photo mode** (tilt-shift "storybook plate" render) is a camera feature, ships from the first public build, and is specced in [07-camera-direction](./07-camera-direction.md) — do not conflate the two.

**Capture flow:**

1. Open the Journal to a blank sketch page → sketch mode: frame the view with the existing camera controls (8 yaws, 3 zoom bands — no new camera code).
2. Press capture → 2–3 s watercolour wash-in animation paints the page.
3. The page auto-captions in prose: location, season, day, and recognised subjects (NPCs in frame, landmark, active project scaffolding).
4. Pages live permanently in the Journal's sketchbook section; they are the game's collection album.

**Subject tagging** drives the content: ~12 authored **sketch prompts** at 1.0, mostly from Lady Daisy ("the mill wheel, in autumn, from the far bank") — Eastshade's compositional-constraint commissions at journal scale ([cozy quests §4](../research/06-comps-cozy-quests.md)). Fulfilled prompts earn reciprocity like any favour.

```csharp
// Runtime record, not an SO — sketches are player-created state.
[Serializable] public class SketchRecord {
    public string captureId;        // "sketch.0042"
    public string zoneId; public Season season; public int dayStamp;
    public string[] subjectTags;    // "npc.miller", "landmark.mill", "project.blanket_drive.construction"
    public string thumbnailPath;    // PNG alongside the save file
    public string promptId;         // empty if freeform
}
```

**Community hooks:** sketches are giftable (a sketch featuring an NPC is a liked gift for them); a completed prompt set for a season earns a small scene with Lady Daisy; project Construction phases are prime sketch subjects — the sketchbook becomes the player's private record that the hedge *changed*.

---

## 10.7 Store Stump & Community Hooks — Summary

Every system pours into the same two sinks, by design:

| System | Immediate reciprocity (≤1 in-game day) | Store Stump / project hook |
|---|---|---|
| Gathering | shared-basket moments; NPC thanks | deposits vs soft thresholds; expedition imports (salt) |
| Cooking | taught recipes; loved-dish gift reactions | cooked deposits gate festival readiness & winter comfort |
| Crafting | station-owner chat; tool utility | project components into the Contribution ledger |
| Gardening | seed-gifter comment lines | shared beds + produce deposits |
| Fishing | trinket favour hooks | stream forage deposits |
| Sketching | prompt reciprocity; sketch-as-gift | the visual record of project phases |

## 10.8 Testable Rules (build acceptance)

1. Every gatherable in the table above is obtainable in its listed season(s) and in no other; each returns the following year.
2. No node stays depleted longer than 3 in-game days; the respawn tick runs only at sleep.
3. All forage highlights pass greyscale + three-axis colourblind simulation at every milestone.
4. Zero tools are required for gathering; zero items carry quality tiers; zero systems award XP.
5. Every recipe/craftable has exactly one station, ≤4 ingredient lines, and a recorded Journal page on learning.
6. Every recipe is learnable without a wiki: its source (NPC, project, diary page) is discoverable through play and restated in Journal prose.
7. Cooking gestures: exactly one per station type; all skippable via accessibility options.
8. All ingredient/teacher/station strings resolve through the localisation table; the ID validator reports zero orphan `item.*`/`recipe.*`/`node.*` references per build.
9. The Store Stump ledger records player and NPC contributions identically; at least one NPC deposit occurs per in-game day during any active project.
10. Removing fishing or sketching from the build breaks no other system's references (Could-tier isolation).

---

[← Back to Index](./INDEX.md) | [Previous](./09-gameplay-loop.md) | [Next: Home →](./11-home.md)
