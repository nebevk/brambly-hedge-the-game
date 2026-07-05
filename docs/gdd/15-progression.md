# 15. Progression

[← Back to Index](./INDEX.md) | [Previous](./14-quests.md) | [Next: Music & Audio →](./16-music-and-audio.md)

There is no XP, no player level, no skill tree, no rating, and no power curve — as hard constraints, not omissions. Progression is the state of the world and the player's place in it, carried on **four axes**: community state, relationships, traversal access, and journal completion. The research base is unambiguous: every successful no-combat comp runs on a braid of three or four gate types — relationship gates, story gates, tool/ability gates, area gates — and **none uses player levels as the primary axis** ([cozy-quests research](../research/06-comps-cozy-quests.md), Key Takeaways).

## 15.1 The Four Axes

### Axis 1 — Community State (projects completed, functions changed)

The spine. Four seasonal community projects plus the secret cottage refurbishment ([D7](./00-decisions.md)), each ending in the binding **Function** phase: the morning after the celebration, **≥1 NPC schedule changes + ≥1 service/recipe changes + ≥1 ambient/visual layer changes**. Progression is therefore *readable in the world*: busier paths, a grinding mill, lit windows — Cozy Grove's returning-colour trick rendered as hedgerow life ([cozy-quests research](../research/06-comps-cozy-quests.md), §1). Garden Story's documented failure — restoration that is "almost entirely aesthetic" — is the anti-model; a project that changes nothing functional does not ship ([cozy-quests research](../research/06-comps-cozy-quests.md), §5).

| Project (season) | Traversal change | Service/recipe change | Schedule change | Ambient change |
|---|---|---|---|---|
| Spring picnic logistics | Grassy track to Bluebell Bank cleared → meadow zone | Picnic dishes enter the recipe pool; Store Stump spring stock | Mr Apple's provisioning rounds | Bluebell Bank in bloom; picnic remnants → new NPC leisure spot |
| Midsummer wedding raft | Moored raft becomes a stream crossing → far bank; mill-wheel lift rigged during preparations → upper-hedge ledge | Dairy-side goods (Poppy); Dusty's clover bread & blackberry buns taught | Poppy & Dusty's married routine; mill workday shifts | Flower-decked stream; lift creaks in the wind |
| Autumn blanket drive & expedition | NPC-rigged ropes up the bank → upland ledge & vantage (High Hills margin) | Flax & Lily take weaving commissions; warm clothing patterns | Weavers' overtime ends; Mr Apple's delivery route | Looms audible at the Hornbeam; laden shelves in the Store Stump |
| Winter Ice Hall | Snow-tunnel network links doorways (winter dressing); Ice Hall interior | Festival kitchen; hot chestnut soup at the hall | Evening skating/ball routines | Lantern-lit tunnels; the hall glowing through snow |
| Secret cottage refurbishment (threaded through autumn–winter; year-one climax) | Cottage interior joins the visitable set | A family's new home = new visiting routines, new hosted supper venue | The recipient family's entire day changes | A dark cottage becomes a lit one — the year's emotional payoff |

(Zone naming and final gate placement are owned by [05-world](./05-world.md); narrative placement of the refurbishment by [14-quests](./14-quests.md). The rows above are the binding *shape*: every project pays out on all four columns.)

Credit is diffused by design: completion moments name at least three NPCs alongside the player ([D7](./00-decisions.md)).

### Axis 2 — Relationships (hearts and heart-scenes)

Numbers are binding from [D9](./00-decisions.md):

| Parameter | Value |
|---|---|
| Points per heart | 250 |
| Heart cap | 10 (major NPCs), 8 (minor NPCs) |
| Talk | +20/day per NPC |
| Loved gift | +80 (liked +45, neutral +20) |
| Birthday multiplier | ×8 |
| Gift cap | 2/week per NPC (1/day) |
| Decay | **None, ever** |

**Heart-scenes gate the tiers.** Points carry the player *to* a tier boundary; the tier takes effect only after its bespoke scene plays (Palia's per-level quest pattern, the strongest idea in its relationship system — [community-sims research](../research/03-comps-community-sims.md), §4 and §7). Overflow points bank while a scene is pending. Allocation at 1.0: majors get 4 scenes (hearts 2/4/6/8), minors get 3 (hearts 2/5/8) — 7 majors × 4 + 5 minors × 3 = **43 scenes**, inside D9's 40–50 budget, which is the most protected content budget in the game; the roster split and scene count are owned by [12-npcs](./12-npcs.md), §12.6.

**The arithmetic is the pacing.** Daily talk (+140/week) plus two loved gifts (+160/week) ≈ 300 points/week ≈ 1.2 hearts/week for one attended NPC. Year one is 8 weeks of in-game time (4 × 14 days), so a player who talks daily, gifts twice weekly, and remembers one birthday (loved birthday gift = 640) maxes **roughly one major NPC in year one** — by design. Friendship moves at hedge pace; most of the cast sits at 2–4 hearts when the first Midwinter arrives, leaving years of headroom. After max hearts, a thin permanent stream continues — seasonal letters, standing supper invitations — so settled friendships feel settled, not dead ([community-sims research](../research/03-comps-community-sims.md), §7).

### Axis 3 — Traversal Access (gates opened by projects, not by the player's body)

**The player's moveset never grows.** Climb, squeeze, scamper, balance-run ([D14](./00-decisions.md)) are all available in hour one and never upgrade. Access changes because *the world* changes: projects repair, rig, and open things ([D7](./00-decisions.md)). This is the deliberate inversion of the metroidvania and of Spiritfarer's boat-upgrade gates — same satisfying map-opening rhythm, but the key is always something the community built together.

| Gate (data ID) | Opened by | Opens |
|---|---|---|
| `gate.bluebellTrack` | Spring project, Function phase | Bluebell Bank meadow zone |
| `gate.streamCrossing` | Summer project (raft moored) | Far bank, dairy-side meadows |
| `gate.mill_lift` | Summer project (lift rigged) | Upper-hedge ledge, canopy vantage |
| `gate.uplandRopes` | Autumn project (expedition ropes left in place) | Upland ledge, High Hills vantage |
| `gate.palace_tree_attic` | Winter story beat (the found key) | Hidden apartment atop Old Oak Palace — the *Secret Staircase* exploration reward ([canon bible](../research/01-brambly-hedge-canon.md), §2) |
| `gate.snowTunnels` | Winter project + deep-snow dressing | Door-to-door tunnel network (seasonal transformation) |

Rules: gates are **permanent once open** (no regression; winter transforms routes — snow tunnels replace surface paths — but never removes access to any interior). A locked gate may be *visible* at most one season before its project can begin; we never dangle objectives many hours before they are actionable (Spiritfarer's most-cited pacing flaw — [cozy-quests research](../research/06-comps-cozy-quests.md), §2, §8). One or two soft equipment gates are permitted (winter cloak for the upland in winter; lantern for the palace cellars) — equipment is **binary access, never stats** (§15.6, test 6).

### Axis 4 — Journal Completion (collection without percentages)

The Journal ([17-ui-philosophy](./17-ui-philosophy.md)) is the collection log, continuing Mrs Apple's matrilineal diary tradition ([canon bible](../research/01-brambly-hedge-canon.md), §6). Its collections at 1.0:

- **Recipes** — indicative 24–32 at launch, all from canon dishes and Basil's cellar; final list owned by [10-core-systems](./10-core-systems.md).
- **Sketches** — journal sketching per [D13](./00-decisions.md) (⚠ DEFAULT — owner to confirm): ~12 authored sketch prompts (owned by [10-core-systems](./10-core-systems.md), §10.6) fill illustrated pages; capturing a vista is the exploration reward made tangible.
- **Notes** — ancestors' diary pages hidden in interiors (indicative 12–16), overheard-gossip entries, project chronicle pages (auto-written after each Function phase), and auto-recorded gift preferences (no wiki required — [community-sims research](../research/03-comps-community-sims.md), §7).

**The no-percentage rule, operationally:** the journal shows what you have and stays silent about what you lack. Full shelves *look* full; empty pages are simply blank paper, not silhouetted slots. Nowhere in the journal (or anywhere else) does a numeral-with-% or an "X/Y" counter appear. Completion is felt (a fat, painted, dog-eared book), never computed for the player.

## 15.2 What Is Unlocked When — Routing Table

| Content type | Route (only route) | Examples |
|---|---|---|
| **Recipes** | Taught by NPCs at heart tiers; taught during project/festival phases; found on ancestors' diary pages | Mrs Apple's seed cake at 2 hearts; chestnut soup during Ice Hall build; great-grandmother's rosehip jam page in the Store Stump |
| **Areas** | Community projects (exterior gates); story beats (interior gates) | Table in §15.1 Axis 3 |
| **Decorations** | Festival keepsakes; NPC friendship gifts; workshop crafting | Picnic bunting; Flax & Lily rug at 5 hearts; crafted shelf ([11-home](./11-home.md), §11.7) |
| **Clothes** | Festival costumes; friendship gifts; seasonal patterns | Midwinter finery from the palace attic trunks; winter cloak pattern from Flax & Lily |
| **Verbs/abilities** | **Never unlocked — full moveset from hour one** | — |
| **Tools/equipment** | Lent or gifted by NPCs; binary access only | Dusty's toolset; lantern; winter cloak |
| **Dialogue** | Every completed project adds ≥3 permanent lines per involved NPC ([D9](./00-decisions.md)) | Post-wedding lines for Poppy & Dusty |

No content of any type is purchasable (no money exists, [D8](./00-decisions.md)) and none is time-gated by the real-world clock ([D6](./00-decisions.md)).

## 15.3 Pacing — the Year-One Rhythm

Seasons are 14 in-game days; a day is ~20 real minutes; the **season valve** ([D6](./00-decisions.md)) means each season ends only when the player triggers its festival, which unlocks once the season's community project + story beat complete. Nothing is missable: the season waits. Target **6–10 hours per season, 25–35 hours year one** ([D6](./00-decisions.md), [D11](./00-decisions.md)).

**Hour-budget sanity check:** 56 days × 20 minutes = ~18.7 hours of running clock; dialogue, journal, heart-scenes, cutscenes, and festival set-pieces (where the clock pauses or the content is authored) supply the remainder → ~26–33 hours for an unhurried year. The maths lands inside the target without padding.

Every season ends in a celebration (the project's Celebration phase); **two of the four are full festivals at 1.0** — the spring picnic and Midwinter's Eve, with the Midsummer wedding and the snow-conditional Snow Ball as free post-launch updates per [D10](./00-decisions.md) ⚠ DEFAULT — owner to confirm.

| Season | Hours (target) | Opens with | Community beat | New access | Relationship expectation | Journal growth | Season valve |
|---|---|---|---|---|---|---|---|
| **Spring** | 6–9 | Arrival; kitchen restored; 3-NPC core met (MVP scope) | Picnic logistics (proposed at the player's first community meeting — they second it, never command) | Bluebell Bank | 1–2 hearts with 2–3 NPCs; first heart-scenes | First 6–8 recipes; first sketches; gift prefs begin | **Spring picnic (full festival)** |
| **Summer** | 6–9 | Whole cast introduced; workshop + garden open | Wedding raft build | Far bank; upper-hedge ledge | 2–4 hearts spread; first 4-heart scene with a favourite | +6–8 recipes (Dusty's baking, dairy dishes); far-bank sketch spots | Midsummer wedding (project celebration; full-festival variant post-launch) |
| **Autumn** | 6–8 | Harvest urgency (soft: seasonal availability only) | Blanket drive + upland expedition; refurbishment secretly proposed | Upland ropes & vantage | 3–5 hearts with favourites; letters of introduction open palace doors (Eastshade key-ring — [cozy-quests research](../research/06-comps-cozy-quests.md), §4) | +6–8 recipes (preserves, syrups); upland sketches; first diary pages | Harvest supper (celebration) |
| **Winter** | 7–10 | Deep-snow dressing; supper rotation indoors | Ice Hall build; refurbishment reveal (year-one climax) | Snow tunnels; Ice Hall; palace attic | One maxed (or near-maxed) major NPC; 8-heart scene | +6–8 recipes (festival dishes); Midwinter sketches; chronicle thickens | **Midwinter's Eve (full festival)** |

**Within-season rhythm** (mirrors [09-gameplay-loop](./09-gameplay-loop.md)): days 1–3 proposal & early contribution; days 4–9 contribution/construction interleaved with favours and freeform; days 10–13 construction complete, festival available — the player lingers as long as they like; day 14+ festival when *they* choose. The valve is the single most-praised pacing device in the comp set (Wylde Flowers' ritual: "reinforcing its cozy, relaxed pace" — [cozy-quests research](../research/06-comps-cozy-quests.md), §3).

**Year two and beyond** is reactivity, not new gates: festival state-reactive variants, second-year NPC arcs, the snow-conditional Snow Ball ([21-long-term-vision](./21-long-term-vision.md)). The four axes keep moving (hearts headroom, journal depth) without any new progression machinery.

## 15.4 Anti-Progression Rules, Restated as Tests

| # | Rule | Test (run at every milestone review) |
|---|---|---|
| 1 | No XP, no levels | Save-schema audit: no `xp`, `level`, `skill`, or `rank` field exists on player state; code grep returns zero |
| 2 | No completion percentages | UI sweep: no numeral+`%` and no `X/Y` counter renders on any journal or HUD surface |
| 3 | No fill-bars on projects | Project UI audit: contribution state surfaces only as prose + world dressing (piles grow, scaffolds rise) |
| 4 | No decoration/world scoring | Deleting all decor and dressing state changes zero gameplay variables ([11-home](./11-home.md), §11.7) |
| 5 | No money | Global: no currency type exists in the data model |
| 6 | No stat-bearing items | Item schema has no modifier fields; equipment gates are boolean access checks only |
| 7 | No relationship decay | Simulate 100 idle in-game days: every hearts value unchanged |
| 8 | No real-time gating | Set the OS clock forward a year: game state identical ([D6](./00-decisions.md)) |
| 9 | No expiring content | Every gate, scene, recipe, and collectible remains obtainable indefinitely; seasonal availability delays, never deletes |
| 10 | Credit is diffused | Every project-completion scene names ≥3 NPCs alongside the player ([D7](./00-decisions.md)) |
| 11 | No dangling locks | No locked gate or greyed content is visible more than one season before it can be pursued |
| 12 | The next step is always speakable | At any save point, the journal's current page states in prose what would help next (the Spiritfarer vague-trigger fix — [cozy-quests research](../research/06-comps-cozy-quests.md), §8) |
| 13 | The spreadsheet test | Playtest exit question: "did any part feel like filling a spreadsheet?" Any recurring yes triggers a design review of the named system |

## 15.5 Why This Still Satisfies (Evidence)

1. **Traversal-as-progression carries whole games.** A Short Hike and Little Kitty, Big City are beloved on exactly this loop — the map opening *is* the reward ([synthesis](../research/00-synthesis.md), §5.3). Our twist: the key is never a feather in the player's pocket; it is a raft the community moored together.
2. **The braid is the proven genre standard.** Spiritfarer (area + ability + relationship + story gates), Eastshade (civic + social + quest-chain gates), Wylde Flowers (story + relationship) — at least three gate types each, zero player levels ([cozy-quests research](../research/06-comps-cozy-quests.md), Key Takeaways). We ship four axes.
3. **World-state change is the reward that never fatigues.** Cozy Grove's island regaining colour; Stardew's Community Center — the one restoration players still cite years later, precisely because it changed schedules, services, and the town's fabric ([community-sims research](../research/03-comps-community-sims.md), §3). Our Function phase makes that payoff mandatory, per project.
4. **Social standing as key ring reads as belonging, not grinding.** Eastshade's letters of recommendation prove friendship-gated access feels diegetic and warm ([cozy-quests research](../research/06-comps-cozy-quests.md), §4); our heart-scenes add Palia's best idea so every tier is a story beat, not a threshold crossed silently.
5. **The valve removes the genre's one legitimate anxiety.** Player-triggered season turns (Wylde Flowers) and player-triggered emotional climaxes (Spiritfarer's Everdoor) are the most consistently praised pacing choices in the no-combat space; both are structural here.
6. **The failure modes are named and fenced.** Ooblets' capped-currency grind, Garden Story's cosmetic restoration and tiny repeating request pools, Cozy Grove's "come back tomorrow" wall — each maps to a numbered test in §15.4 ([cozy-quests research](../research/06-comps-cozy-quests.md), §8 anti-patterns).

## 15.6 Data Model Sketch

```
ProgressionState {
  saveVersion: int
  projects:   { [projectId]: Proposal | Contribution | Construction | Celebration | Function }
  hearts:     { [npcId]: points }        // int; tier = floor(points/250), capped 8 or 10
  tierLocks:  { [npcId]: pendingSceneId? } // tier held until heart-scene seen; points bank
  scenesSeen: [sceneId]
  gates:      [gateId]                   // append-only; never removed
  equipment:  [itemId]                   // boolean access keys, no stats
  journal: {
    recipes:  [recipeId]
    sketches: [sketchId]
    notes:    [noteId]                   // diary pages, gossip, chronicles
    giftPrefs:{ [npcId]: [itemId] }      // auto-recorded on discovery
  }
  calendar:   { season, dayOfSeason, year }  // owned by TimeService (13-time-and-seasons)
}
```

All unlock conditions are data-driven predicates over this state (e.g. `gate.streamCrossing.requires = projects.weddingRaft >= Celebration`; `recipe.cloverBread.requires = hearts['npc.miller'] >= 1000 && scenesSeen has npc.miller.h4`). There is no derived aggregate — no "total progress" value exists anywhere, which is what makes tests 1 and 2 in §15.4 mechanically enforceable.

---

[← Back to Index](./INDEX.md) | [Previous](./14-quests.md) | [Next: Music & Audio →](./16-music-and-audio.md)
