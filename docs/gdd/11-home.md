# 11. Home

[← Back to Index](./INDEX.md) | [Previous](./10-core-systems.md) | [Next: NPCs →](./12-npcs.md)

The player's home is a small, slightly neglected burrow at the quiet end of the hedge. It is the place the game saves from, the place neighbours leave gifts, the place the weekly supper occasionally lands — and the physical record of the player's growing place in the community. It is deliberately **not** an empire, a farm, or a renovation business. The palace stays the grandest building in the hedge; the player's burrow stays the cosiest.

## 11.1 Purpose & Framing

- The player is **a newcomer mouse who moves into the hedge** and must find their place (per [D9](./00-decisions.md)). ⚠ DEFAULT — owner to confirm (alternative: canon-adjacent resident child, which would replace the "disused burrow" framing with a family home).
- The home expresses the game's core promise spatially: *belonging accumulates*. Every restored room, every quilt on the bed, every doorstep gift is evidence that the community has taken the player in — the inverse of ACNH's island the player owns and grades (see [community-sims research](../research/03-comps-community-sims.md), §2).
- Functionally the home is: the **save point** (sleep-to-save only, [D2](./00-decisions.md)), the **cooking and crafting anchor** (stations live here), the **wardrobe**, and the **doorstep** where reciprocity gifts arrive.

## 11.2 Fiction, Placement & Rename Safety

- **Working name: Bramble End Burrow** — a long-empty burrow in the hedge bank near the field margin, at the opposite end of the hedge from Old Oak Palace. This name is **original content, not canon**; treat it as a placeholder string like all names.
- The home is **100% rename-safe layer** ([D1](./00-decisions.md)): the player character, the burrow, its name, and its story exist in no Barklem book. Nothing in this section depends on the licence. The canon layer touches this document only through the *names of the helping NPCs* (Mr Apple, Flax & Lily, etc.), which already live behind the localisation/data layer.
- Fictional justification for the starter state: burrows in the hedge pass between generations; this one's family moved downstream years ago. Neighbours have used it for overflow storage, which is why the workshop is full of someone else's crates on day one — an immediate, gentle hook into meeting them.
- The burrow is one of the **6–10 dollhouse interiors** at 1.0 ([D14](./00-decisions.md)) and uses the standard cutaway camera treatment ([07-camera-direction](./07-camera-direction.md)): dithered roof/wall fade, interactables valid at all 8 yaws.

## 11.3 The Burrow at a Glance

| Room | Day-one state | Restored function | Scope tier ([D5](./00-decisions.md)) |
|---|---|---|---|
| **Bedroom** | Habitable: bed, hearth, hook by the door | Sleep/save; wardrobe (outfits); journal writing desk | Must (it's the save point) |
| **Kitchen** | Cold range, collapsed shelf, one pan | Home cooking station; preserves shelf (cooked-goods storage); supper hosting | Must (cooking is a Must system) |
| **Workshop** | Shuttered; stacked with neighbours' crates | Crafting bench (furniture, decorations, storage, simple tools); herb drying rack | Should (crafting/gardening support) |
| **Garden** | Overgrown bramble patch behind the door | 4 planting beds, expandable to 8 via the Mr Apple favour arc (gardening, [10-core-systems](./10-core-systems.md), §10.4); rain barrel; bench | Should (gardening is Should) |

Hard cap: **four rooms plus the garden, forever.** The burrow never expands beyond this footprint. Test: place the finished burrow's exterior silhouette beside Crabapple Cottage and the Hornbeam Tree — it must read as the smallest of the three.

**MVP note:** the vertical slice ([20-mvp](./20-mvp.md), Step 3) ships **one burrow room only** (bed = save point); cooking in the slice is staged at the Crabapple Cottage kitchen, and no home-upgrade favour arcs run there. The kitchen-restoration beat, the remaining rooms, and decoration land in Plan B production, subject to the quarterly scope review.

## 11.4 Starter State (Day One)

The player wakes on a borrowed mattress in the one habitable room. Concretely present at minute zero:

- Bedroom: bed (save works immediately), cold hearth, a stub of candle, the Journal on the floor beside the bed (the diegetic UI begins here — [17-ui-philosophy](./17-ui-philosophy.md)).
- Kitchen door ajar: visibly unusable — no cooking until restored (this is the tutorial pull toward Mrs Apple).
- Workshop door blocked by crates addressed to three different households (three introductions waiting to happen — matches the MVP's 3 NPCs).
- Garden: brambles; one gap showing a rusted trowel (a promise, not a task).
- Doorstep: a covered dish and a note of welcome — the reciprocity loop demonstrated before the player has done anything.

## 11.5 The Upgrade Path — Community Help, Never Money

There is **no money and no shop** ([D8](./00-decisions.md)); rooms are restored because neighbours help, in the spirit of the community's refurbishment of Mayblossom Cottage in *Poppy's Babies* ([canon bible](../research/01-brambly-hedge-canon.md), §2). The player's home upgrades are deliberately *smaller* than community projects: they are **neighbourly favours** (1–2 in-game days, one or two helpers), so they never compete with the *Poppy's Babies*-style secret refurbishment that is the year-one climax ([D7](./00-decisions.md)).

| Stage | Season (default) | Who helps | Trigger | Player contribution (soft ask) | Days | What changes |
|---|---|---|---|---|---|---|
| Kitchen restored | Spring, week 1 | Mr Apple (range & shelf), Mrs Apple (scrubbing, first stock) | Story beat: return the welcome dish | "A few armfuls of dry kindling" + one foraging trip with Mrs Apple | 2 | Cooking station live; Mrs Apple teaches 2 starter recipes; supper-hosting becomes possible later |
| Workshop opened | Late spring | Crate owners collect crates; Dusty Dogwood lends tools and sets the bench | Deliver all 3 crates (meets 3 households) | "Whatever's underneath must be swept out" | 1 | Crafting bench live; drying rack; Dusty's toolset on the wall |
| Garden cleared | Early summer | Wilfred & Teasel hack brambles; Mr Apple brings seed from the Store Stump | Spring community project complete + 2 hearts with any Toadflax | Clear alongside them (one session) | 2 | 4 beds plantable (expandable to 8 via a later favour arc with Mr Apple, [10-core-systems](./10-core-systems.md) §10.4); rain barrel; bench |
| Soft furnishings | Autumn | Flax & Lily (weavers) | 4 hearts with Flax or Lily | Gather "a good basketful" of thistledown & dry grass | 1 | Quilt, curtains, rug set (warm-palette bedroom); winter cloak pattern unlocked |
| Winter-tight | Early winter | Mr Apple (door, draught-proofing) | Autumn community project complete | "About a dozen" moss bundles | 1 | Hearth burns brighter; snow-day interior dressing; home appears on the winter snow-tunnel network |

Binding rules for every stage:

1. **Soft thresholds, no fill-bars** — asks are phrased in prose ("a few armfuls"), tracked internally, never displayed as N/M ([D7](./00-decisions.md)).
2. **The helper visibly works.** Mr Apple is *at the range with his sleeves rolled up* during the kitchen days; his schedule shows it ([12-npcs](./12-npcs.md)). No off-screen construction, no timers.
3. **Every stage completes even if the player dawdles** — one extra day per missing contribution, then a neighbour quietly covers it and says so kindly. Projects-complete-without-you applies at house scale too.
4. **Every stage ends with reciprocity within one in-game day** (a taught recipe, a doorstep gift, a tool left behind) — the Spiritfarer rule ([cozy-quests research](../research/06-comps-cozy-quests.md), §8).
5. **No rent, no loan, no debt.** The anti-Nook test: search the design and strings for any deferred obligation attached to the home. There must be none.

## 11.6 Room Functions (What Each Unlocks)

**Kitchen.** The home cooking station — the only player-owned station at 1.0 (festival and NPC kitchens exist but are theirs). Restoring it unlocks: cooking from the journal's recipe pages; the **preserves shelf** (holds 12 cooked/preserved items; visible jars, not an abstract inventory — what you've put by for winter is literally on the shelf); Store Stump deposit runs (cooked goods now count toward contributions, [D8](./00-decisions.md)); and, later, supper hosting (§11.8).

**Bedroom.** Habitable from minute zero because it is the save point. Upgrades add the **wardrobe** — outfit changes using the shared base-mesh costume variants ([D4](./00-decisions.md)); outfits come from festivals and friendship, never purchase ([15-progression](./15-progression.md), §15.4) — and the writing desk, where journal sketches are mounted and ancestors'-diary pages are re-read.

**Workshop.** Unlocks the crafting verbs listed in [10-core-systems](./10-core-systems.md): furniture, decorations, storage, and simple tools, plus the herb drying rack (converts fresh herbs to keepable ones — the gentle bridge between gathering and winter). Weaving patterns from Flax & Lily and festival keepsake patterns are crafted here.

**Garden.** Four raised beds, expandable to eight via the Mr Apple favour arc ([10-core-systems](./10-core-systems.md), §10.4; two further **shared community beds** live near Crabapple Cottage, not here), reusing the gather + time systems (gardening is Should-tier): plant in one season, harvest within the same or next; because the **season only advances when the player holds the festival** ([D6](./00-decisions.md)), nothing planted can ever be lost to a surprise season turn — the bed simply waits. Garden output feeds cooking and Store Stump deposits; there is no sell price because there is nothing to sell.

## 11.7 Decoration — Scope, Rules, and What We Refuse to Score

Decoration is **Could tier** ([D5](./00-decisions.md)). If the quarterly scope review cuts it, the fallback is the journal micro-feature: fixed display shelves (mantel, dresser, gift shelf) that accept keepsakes with no free placement.

If shipped, the full system:

**Sources of decor** (no shop exists): workshop crafting; festival keepsakes (bunting from the picnic, a lantern from Midwinter's Eve); NPC friendship gifts (Flax & Lily textiles, one of Lady Daisy's paintings at high hearts); found curios (a brass button, sea-glass) mounted via the workshop.

**Placement rules — concrete:**
- Socket-based placement: **floor**, **wall hook**, **mantel/shelf**, **table-top**. No terraforming, no wall-moving, no room resizing.
- Rotation in **45° steps** so every item reads correctly at all 8 camera yaws ([D3](./00-decisions.md)).
- Per-room cap of **~40 placed items** (draw-call budget, [D2](./00-decisions.md); tune in the slice).
- Footprint validation only: items may not overlap or block doorways, stairs, or the path between door and table (supper guests must be able to navmesh to a seat). Rejection is diegetic and warm: *"Wilfred would trip over that there."* Never an error buzz.
- Everything placeable is placeable anywhere valid. There are no themed set bonuses, no adjacency effects, no "correct" arrangement.

**No wrong answers — as a hard rule, not a mood.** We explicitly reject the ACNH Happy-Home-Academy pattern and the island-rating pattern: a literal score for decorating, graded by an authority ([community-sims research](../research/03-comps-community-sims.md), §2 and §7 "no player-graded world metrics"). Binding tests:

1. **The evaluator does not exist.** No code path reads decoration state to produce a number, star, rank, or reward. Test: delete every placed item from a save — zero gameplay variables change except the decor list itself.
2. **No decoration quests.** No NPC ever asks the player to place, own, or display anything.
3. **NPC reactions are warm, specific, and never comparative.** A visiting NPC picks one placed item (line-group keyed to item tags via Yarn Spinner saliency, [D9](./00-decisions.md)) and says something in character about *that item* — never about the room's quality, never relative to anyone else's home.

## 11.8 The Home in Community Life

**Hosting a hedgerow supper.** The weekly supper ([D9](./00-decisions.md)) is held at the **Store Stump hall** ([12-npcs](./12-npcs.md), §12.8; [13-time-and-seasons](./13-time-and-seasons.md), §13.2) and is where NPC-to-NPC life concentrates. **At most once per season**, as a special event — explicitly the exception, not a rotation — the supper temporarily moves to the player's burrow, once: kitchen restored **and** the player has attended ≥2 suppers at the Store Stump. An honour, not a chore. Format mirrors the contribution festivals: every guest brings a dish; the soft ask of the host is the table and one cooked dish. Time does not pause; guests arrive on their schedules, talk to each other, and leave when it's late. Hosting grants the normal daily talk credit (+20, [D9](./00-decisions.md)) with each attendee — no new point category — and one thank-you doorstep gift arrives next morning. If the player never cooks, a neighbour gently co-hosts; there is no fail state.

**Doorstep reciprocity.** The doorstep is the physical endpoint of the reciprocity rule (every completed favour returns something tangible within one in-game day — [cozy-quests research](../research/06-comps-cozy-quests.md), §8). Gifts appear on the step overnight with a note in the giver's voice; the most recent sits on the **gift shelf** by the door until replaced. Doorstep gifts are the primary delivery channel for: taught-recipe cards, keepsake decor, seasonal letters from maxed friends ([15-progression](./15-progression.md), §15.3).

**Visitors.** From 2 hearts, an NPC whose schedule passes the burrow may knock (≤1 visit per in-game day, weighted by friendship). Visits are short, scheduled, and watchable — a mouse actually walks there. This is the home's share of the "community acts without you" pillar ([18-community-philosophy](./18-community-philosophy.md)).

**Absence, gently.** Nothing at home decays, ever — no weeds-as-punishment, no cobweb shame. After several days away, the only trace is accumulated doorstep notes: evidence the community kept moving, never a penalty ([community-sims research](../research/03-comps-community-sims.md), §6, inversion 6).

## 11.9 Presentation Notes

- The burrow interior is a single-cutaway dollhouse (one floor plus a low cellar nook) — the *smallest* interior in the game, so it also serves as the camera team's minimum-complexity test case for the roof-fade system.
- Near zoom in the bedroom at night (candle, hearth-light) is a designated "pallet moment" register ([D3](./00-decisions.md)); the kitchen at supper, seen at Default zoom with eight mice around the table, is a designated book-plate composition for the 10-screenshot test.
- Seasonal dressing applies indoors: the same LUT + dressing-set pipeline as the world ([D4](./00-decisions.md)) — frost on the window in winter, elderflower on the sill in summer.

## 11.10 Data Model Sketch

```
HomeState {
  saveVersion: int
  rooms: {
    bedroom:  Restored                       // always
    kitchen:  Shuttered | Restoring | Restored
    workshop: Shuttered | Restoring | Restored
    garden:   Overgrown | Clearing | Cleared
  }
  upgrades: [upgradeId]                      // softFurnishings, winterTight, ...
  decor:  [ { itemId, socketId, yaw45: 0..7 } ]
  shelf:  [itemId]                           // preserves shelf, max 12
  doorstep: [ { giftId, fromNpcId, noteStringId } ]
  hostingEligible: derived (kitchen == Restored && suppersAttended >= 2)
}
```

No field in `HomeState` feeds any score, rating, or currency. Room states are set only by favour-stage completion flags; upgrade favours use the same phase machinery as community projects ([14-quests](./14-quests.md)) with a reduced two-phase template (Contribution → Function).

## 11.11 Rules as Tests (Summary)

| # | Rule | Test |
|---|---|---|
| 1 | No money touches the home | String + data audit: no price, rent, loan, or debt field or line anywhere in home content |
| 2 | No decoration scoring | Deleting all decor changes no gameplay variable; no evaluator code path exists |
| 3 | Upgrades are favours, not purchases | Every room-state transition traces to a completed favour with a named NPC helper |
| 4 | Helpers visibly work | During any Restoring state, the helper's schedule places them at the burrow working ≥1 shift/day |
| 5 | Reciprocity within a day | Every completed favour spawns a doorstep gift or taught unlock ≤1 in-game day later |
| 6 | Modesty cap | Burrow never exceeds 4 rooms + garden; silhouette reads smaller than every canon family home |
| 7 | Rename-safe | Home passes the find-and-replace drill ([D1](./00-decisions.md)) with zero design change |

---

[← Back to Index](./INDEX.md) | [Previous](./10-core-systems.md) | [Next: NPCs →](./12-npcs.md)
