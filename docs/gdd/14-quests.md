# 14. Quests

[← Back to Index](./INDEX.md) | [Previous](./13-time-and-seasons.md) | [Next: Progression →](./15-progression.md)

Never "kill 10 rats." But also never fill a bar, race a timer, or fail. This chapter specifies the game's two quest tracks: **small favours** (the daily texture of neighbourliness) and **community projects** (the differentiator system, [D7](./00-decisions.md)). Both are diegetic — there is no quest board, no exclamation marks, no log with checkboxes. NPCs ask in person or leave notes; the Journal records everything as prose ([17-ui-philosophy.md](./17-ui-philosophy.md)).

## 14.1 Two Tracks

| Track | Timing | Narrative payload | Volume at 1.0 |
|---|---|---|---|
| **Small favours** | Optional, refresh daily from an eligibility-filtered pool; 0–3 offered per day through natural encounters | Light — a character moment, a preference learned, a lore line | **≥60 hand-authored one-off favours** + per-NPC repeatable micro-favours with variant lines |
| **Community projects** | Untimed spine; 5–8 in-game days each, one per season + the year-one climax | Heavy — every phase pays out scenes, permanent dialogue, world change | 4 seasonal projects + 1 secret project (14.7) |

The split is Cozy Grove's proven taxonomy with the timer removed: players tolerate small tasks because the story track visibly carries the real reward ([cozy quest comps](../research/06-comps-cozy-quests.md)). The 60-favour floor exists because Garden Story's small random pool served players the identical request 2–3 times in a row — the single most cited flaw in its reviews. A one-off favour never repeats; repeatable micro-favours must carry ≥3 dialogue variants each.

Session shape target ([09-gameplay-loop.md](./09-gameplay-loop.md)): one in-game day comfortably holds 1 story/community beat + 2–3 small favours + 1 project contribution + unlimited freeform.

## 14.2 The Reciprocity Rule — BINDING

> **Every completed favour returns something tangible to the player within one in-game day.**

Not hearts, not a thank-you line — a *thing* ([cozy quest comps](../research/06-comps-cozy-quests.md), Spiritfarer's care-in-labour-out loop). Legal reciprocity payloads:

1. **Doorstep gift** (spawned in the overnight pass, [13-time-and-seasons.md](./13-time-and-seasons.md) §13.1) — food, a preserve, a keepsake
2. **Taught recipe** — a Journal recipe entry, in the giver's voice
3. **Shortcut opened** — an NPC shows or rigs a squeeze-through, gate, or plank
4. **Helper day** — the NPC gathers alongside the player tomorrow (shared-basket bonus)
5. **Invitation** — to a supper, a kitchen, a room otherwise closed (Eastshade's social key ring)
6. **Journal keepsake** — a pressed flower, a sketch, a diary page (lore collectible)

Enforcement is mechanical, not editorial: `FavourDefinition.reciprocity` is a required field and the content validator ([19-technical-direction.md](./19-technical-direction.md)) **fails the build** if it is null. Friendship points also accrue ([12-npcs.md](./12-npcs.md)) but never count as the reciprocity payload.

## 14.3 Favour Taxonomy

Six types. Each reuses an existing core-system interaction ([10-core-systems.md](./10-core-systems.md)) — favours are content, never new mechanics. Two fully specced examples per type; these twelve are 1.0 content.

### Deliver — carry a thing to a mouse

**"Basil's Spring Delivery"**
- **Giver/trigger:** Basil Brightberry, at Elderberry Lodge cellar, spring mornings, no friendship gate, once only.
- **Steps:** Take the crate of cowslip wine → carry it to the Old Oak Palace kitchen → hand it to Mrs Crustybread (she has a line about Basil's forgetfulness — he's sent last year's labels).
- **Reciprocity (≤1 day):** that evening a corked bottle of elderflower cordial and a recipe note appear at the player's door.

**"Warm Loaves"**
- **Giver/trigger:** Dusty Dogwood, at the mill on a baking morning (repeatable, seasonal variants), friendship ≥1 heart.
- **Steps:** Take the basket of clover bread → deliver to Old Mrs Eyebright's cottage. The bread is "still warm" *whenever* it arrives — flavour text, never a timer; if delivered next day, Dusty's follow-up line adjusts gently.
- **Reciprocity:** next morning Dusty leaves blackberry buns on the doorstep; at 3 completions he teaches the clover bread recipe.

### Prepare — cook or make something asked for

**"A Pudding for the Picnic"**
- **Giver/trigger:** Mrs Apple, Crabapple Cottage kitchen, spring, during the picnic project's Contribution phase.
- **Steps:** Gather primroses (6, Bluebell path verges) → cook 2 primrose puddings at any hearth → bring them to the Store Stump.
- **Reciprocity:** Mrs Apple writes her own primrose-pudding variant into the player's Journal and adds the player's puddings, by name, to the picnic hamper manifest (they appear on the picnic cloth at the festival).

**"Soup for the Searchers"**
- **Giver/trigger:** Mrs Crustybread, palace kitchen, the evening Primrose is found (Autumn 6, authored beat).
- **Steps:** Cook hot chestnut soup (chestnuts from the harvest stock) → carry the pot to the palace hall where the search party warms up.
- **Reciprocity:** a standing invitation to the palace kitchen (interior access — Eastshade-style social gate) and the chestnut soup recipe.

### Find — locate a lost thing (authored spots, no pixel hunt)

**"Basil's Missing Spectacles"**
- **Giver/trigger:** Basil (canonically forgetful), any season, at Elderberry Lodge.
- **Steps:** Search the cellar — the spectacles are at one of 3 authored, softly-glinting spots (bottle rack, cordial press, window ledge). Interactable at all 8 camera yaws ([D3](./00-decisions.md)).
- **Reciprocity:** Basil names his new cordial blend after the player and a bottle arrives next morning.

**"Wilfred's Catapult"**
- **Giver/trigger:** Wilfred Toadflax, near the Hornbeam Tree, friendship ≥1 heart; Mrs Toadflax confiscated it, then lost it while hanging washing.
- **Steps:** Find the catapult in the leaf litter along the washing-line run (3 authored spots) → decide with Wilfred not to mention it to his mother (dialogue moment, no consequence system — just charm).
- **Reciprocity:** Wilfred shows the player his squeeze-through under the Hornbeam roots — a permanent shortcut opens.

### Gather — bring "about" N of a forageable (soft threshold)

**"Blackberries Before the Rain"**
- **Giver/trigger:** Mrs Apple, autumn days 1–4 (harvest rush), overcast/fair days.
- **Steps:** Gather about ten blackberries (internal target 10; 8+ accepted with a warm line, 12+ earns a delighted one — never a counter on screen) → deliver to Crabapple Cottage.
- **Reciprocity:** a jar of blackberry-and-rosehip jam on the doorstep next morning + the jam recipe at second completion.

**"Dew-Fresh Watercress"**
- **Giver/trigger:** Poppy Eyebright, the Dairy, summer mornings during the wedding project (feast trials).
- **Steps:** Gather watercress at the stream margin at Dawn or Morning (it wilts by afternoon — *seasonal/phase availability, not a timer*: the favour simply waits for tomorrow's dawn) → bring it to the Dairy.
- **Reciprocity:** Poppy shares honey creams from the trial batch and the player is named a feast-taster (invitation to the pre-wedding tasting scene).

### Social — sit, listen, keep company

**"Tea with Old Mrs Eyebright"**
- **Giver/trigger:** Poppy asks the player to look in on her grandmother, any season, friendship (Poppy) ≥2 hearts.
- **Steps:** Visit Old Mrs Eyebright's cottage in the Afternoon → share tea (sit interaction; three dialogue choices, all warm) → hear a story of the Dairy's old days (lore payout).
- **Reciprocity:** she gives a quilt square keepsake (Journal item); at the third visit, her butter recipe.

**"A Word at the Mill"**
- **Giver/trigger:** authored, Summer 1–2 (pre-engagement beat): Dusty paces the mill mooring at Evening, working up his courage.
- **Steps:** Listen (dialogue scene; the player encourages, never decides for him — he was canonically afraid Poppy would refuse).
- **Reciprocity:** next morning, warm clover loaves at the door and Dusty's permanent line change: he stands straighter. Feeds directly into the Summer 3 engagement announcement.

### Escort-lite — walk with someone (no protection, no failure)

Escort-lite means: an NPC walks a route; the player accompanies; conversation plays at authored pause points; if the player wanders, the NPC waits, amused. **There is nothing to defend anyone from.**

**"Walking Grandmother Home"**
- **Giver/trigger:** after a Hedgerow Supper (Day 3/10, any season), Old Mrs Eyebright at the Store Stump door, lantern lit.
- **Steps:** Walk her home at dusk; three bench pauses, each with a story fragment about the hedge's past (rotates by season).
- **Reciprocity:** a knitted scarf (cosmetic, winter-warm) left at the player's door; a new permanent greeting from her.

**"Teasel in the Mist"**
- **Giver/trigger:** Mrs Toadflax, a misty autumn afternoon; Teasel has dawdled off toward the cornfield edge.
- **Steps:** Find Teasel (one authored spot per mist variant, hinted by his whistling — audio wayfinding) → walk him home through the mist; he chats about what he found.
- **Reciprocity:** blackberry buns at the door next morning; Teasel thereafter waves from wherever he's dawdling — a running visual gag and a live "the world knows you" signal.

## 14.4 The Never-List — BINDING

Favours and projects must never contain:

1. **No violence of any kind** — nothing is killed, fought, or chased off. Not even "pests."
2. **No fill-bars, counters, or completion percentages** — progress is physical (the pile of reeds grows) and prose (the Journal describes it). [D7](./00-decisions.md).
3. **No timers and no expiry** — the only time-shaped availability is seasonal/phase gating ("watercress at dawn," "blackberries in autumn"). A favour offered is a favour that waits.
4. **No fail states** — a favour can be *not done yet*, never failed. Escort NPCs wait; found items stay findable; nothing breaks or is lost.
5. **No fetch chains deeper than 2 links** — "get A to make B" is the maximum. "Get A for B to give C for D" is banned (the genre's most-mocked filler).
6. **No zero-narrative multi-step quests** — every favour with ≥2 steps carries at least one character or lore line ([cozy quest comps](../research/06-comps-cozy-quests.md): fetch chains with no payload are the universal complaint).
7. **No quest board, no floating markers** — offers come from mice, notes, and the Journal's prose restatement of goals ([D14](./00-decisions.md): diegetic signposting).
8. **No currency or XP rewards** — there is no money ([D8](./00-decisions.md)) and no XP ([15-progression.md](./15-progression.md)); reciprocity payloads only.
9. **No dangling visibly-locked objectives** — never show the player a goal that is many hours from actionable (Spiritfarer's gated seas complaint).
10. **No daily caps or "come back tomorrow" walls** — favours refresh daily, but running out of *offers* never means running out of *game* (open verbs always remain: gather, cook, explore, sketch).

## 14.5 Favour System Rules & Data Model

- **Offering:** each morning the eligibility filter (season × weather × day phase × friendship tier × project phase × flags) selects up to 3 favours; they surface only through natural encounters — an NPC on their schedule route, a note pinned to the player's door.
- **Active limit:** no hard cap; the Journal simply narrates what's outstanding. In practice offers stop while ≥3 are open.
- **Journal:** every favour is a prose entry ("Basil has muddled his spectacles again — I said I'd look in the cellar"), auto-updated, never a checklist ([17-ui-philosophy.md](./17-ui-philosophy.md)).
- **Word budget:** favour prose is lean — offer + 1 mid-line + resolution + reciprocity note ≈ 60–100 words each; 60 favours ≈ 5–6k words of the 60–80k cap ([D15](./00-decisions.md)).

```
FavourDefinition (ScriptableObject — SO definition + plain-C# runtime state, see 19)
  id            : "favour.cellarer.spring_delivery"   // string-ID registry
  giver         : npc.cellarer
  type          : Deliver | Prepare | Find | Gather | Social | EscortLite
  eligibility   : { season, dayPhase, weather, minHearts, requiredFlags, onceOnly }
  offer         : { poi, yarnNode }                   // where and how it is asked
  steps[]       : { verb, item/target, poi, yarnNode? }   // max depth 2 (validator-enforced)
  softThreshold : { tag, target:int, acceptFloor:int, delightCeiling:int }?   // Gather only
  reciprocity   : { type, payload[], deadlineDays: 1 }    // REQUIRED — build fails if null
  journalProse  : loc-key                              // localized from month one (D15)
```

Validator rules (run in CI): reciprocity non-null; step depth ≤ 2; no timer/expiry fields exist in the schema at all; every yarnNode resolves; every id unique.

## 14.6 The Community Project System

Community projects are how the world changes and how traversal opens ([D7](./00-decisions.md) — binding five-phase template). They are the inversion of the genre's player-hero framing: NPCs propose them, NPCs visibly work on them, and they finish with or without the player ([community sims research](../research/03-comps-community-sims.md) §6).

### The five phases, operationally

**1. Proposal — one scene**
- NPC-initiated at a community meeting — normally the Hedgerow Supper (Day 3/10, Store Stump hall, 18:00); urgent news can call a special meeting. **The player seconds; never commands.** Seconding is a dialogue beat that earns a bonus scene — it is *not* a gate: if the player misses the meeting, the Journal records the news and the project proceeds identically.
- Output: Journal project page opens (prose + the lead mouse's sketch of the plan); contribution goals are stated in soft language ("about twelve bundles of reeds").

**2. Contribution — 2–4 in-game days (minDays 2 / maxDays 4)**
- Each goal is an integer number of units behind a soft label. The player never sees the number; NPC dialogue tracks it in warm approximations ("nearly there — another armful or two").
- **NPC visible labour:** the project roster works scheduled shifts at real POIs — Mrs Apple baking in her kitchen, Flax & Lily at the looms, Mr Toadflax measuring timber — walk past and watch ([D9](./00-decisions.md) schedule cascade keys on project flags).
- **NPC contribution rate:** goals receive `npcUnitsPerDay` (typically 3 per 12-unit goal) at every day rollover.
- **Player actions:** deposit matching items at the project site or Store Stump; `playerDailyCap` (typically 4 units/day) prevents solo-hero completion and keeps the player one pair of paws among many.
- **Progress display:** the physical pile *is* the progress bar — reed bundles stack, planks lean, jars line up. Plus one thanking line per deposit from a named NPC.
- Phase ends when all goals are met **and** minDays have elapsed; in every case it ends at maxDays (see the completion rule below).

**3. Construction — 2–3 in-game days (minDays 2 / maxDays 3), staged, witnessed**
- The build advances through 3–4 visual stages (prefab swaps: frame → surfaces → finish → dressing). At least one stage transition per day happens **on camera during play hours**, never overnight-only — multi-day waits must be diegetic and visible ([cozy quest comps](../research/06-comps-cozy-quests.md) pacing rule 1).
- **Player action:** one **lend-a-paw** interaction per day (hold the plank, pass the pegs, steady the ladder) → a bespoke micro-scene with whoever is on shift. Helping can advance at most one extra stage per day, down to minDays.

**4. Celebration — the festival set-piece (the season valve)**
- When Construction completes, the lead mouse asks the player to set the date ([13-time-and-seasons.md](./13-time-and-seasons.md) §13.3). Once set, **the celebration starts at its hour whether the player attends or not** ([D10](./00-decisions.md)). Contribution formats over contests: every mouse brings something; the player's deposits appear, named, in the scene.

**5. Function — the next morning, always all three ([D7](./00-decisions.md)):**
- **≥1 NPC schedule change** (a new route, a new workplace, a new habit)
- **≥1 service/recipe change** (something new the community does or makes)
- **≥1 ambient/visual change** (persistent dressing, audio, light)
- Plus ≥3 permanent reactive dialogue lines per involved NPC ([D9](./00-decisions.md)), and — for every 1.0 project — **a traversal gate opens** (D7: this replaces player-level progression).

### The completes-without-the-player rule — exact, binding

> At every day rollover, each active Contribution goal gains its `npcUnitsPerDay`, and Construction advances at least one stage per day. Therefore: **a project the player never touches after Proposal reaches Celebration-ready in exactly `maxDays(Contribution) + maxDays(Construction)` days** — slower than a helping player (who can compress each phase to its `minDays`), but never stalled, never regressed, never failed. Units still missing at Contribution maxDays are narrated as found by the community ("Teasel turned up the last planks behind the mill"). No project waits on a real-world clock. The only thing the community defers to the player on is the festival date — the season valve ([D6](./00-decisions.md)); once the date is set, nothing waits at all.

### Credit diffusion — binding

Completion moments name NPCs alongside the player: the toast at every Celebration names **at least three NPCs and the player**, weighted toward whoever actually worked shifts. The Journal's completion page lists contributors the same way. No "you did it!" — ever ([D7](./00-decisions.md), [community sims research](../research/03-comps-community-sims.md)).

### Project data model

```
ProjectDefinition (SO)
  id, season, leadNpc, proposalMeeting { seasonDay, venue }
  contribution : { minDays:2, maxDays:4,
                   goals[]: { itemTag, softLabelLocKey, units:int,
                              npcUnitsPerDay:int, playerDailyCap:int } }
  construction : { minDays:2, maxDays:3, stages[]: prefabRef, lendAPawScenes[] }
  celebration  : festivalId                       // the season valve
  function     : { scheduleChangeIds[], serviceChangeIds[], ambientChangeIds[],
                   traversalGateId, permanentLineGroups[] }
Runtime: ProjectState { phase, daysInPhase, unitsByGoal[], stageIndex, playerUnitsToday }
```

## 14.7 Year-One Project Arcs (day-by-day)

Calendar context in [13-time-and-seasons.md](./13-time-and-seasons.md) §13.4; canon sources in the [canon bible](../research/01-brambly-hedge-canon.md). Names are canon layer; structures are rename-safe ([D1](./00-decisions.md)).

### Spring — The Picnic at Bluebell Bank (*Spring Story*)

| Days | Phase | Detail |
|---|---|---|
| 3 | Proposal | Hedgerow Supper: Mr Apple proposes Wilfred's surprise birthday picnic at Bluebell Bank; the grassy track to the bank, winter-tangled and overgrown, must be cleared first ([05-world.md](./05-world.md) §5.2). Wilfred is kept out of the room (running gag: he nearly walks in twice). |
| 4–7 | Contribution | Goals: **12 hamper dishes** (Store Stump deposits — seed cake, primrose puddings, preserves; NPC 3/day, player cap 4/day), **6 bound besoms** (twig brooms for the sweeping teams; NPC 2/day, cap 3), **8 garland posies**. Visible labour: Mrs Apple & Mrs Crustybread baking; Basil bottling cowslip wine; Mr Toadflax pacing the overgrown track and tutting. |
| 8–10 | Construction | Track cleared in 3 stages: scythed → swept and levelled → waymarked and garlanded — NPCs visibly scything and sweeping across the days before the festival ([05-world.md](./05-world.md) §5.11). Shifts: Mr Toadflax + Mr Apple, mornings. Lend-a-paw: haul cut stems / sweep with a besom / tie garlands. |
| 11+ | Celebration | **Full festival** ([D10](./00-decisions.md)): hamper procession along the newly cleared track, the surprise, the feast on the cloth (every deposit visible), games on the bank. NPCs suggest Spring 12 — Wilfred's actual birthday. |
| Next morning | Function | **Traversal:** the track stays clear — **Bluebell Bank and the picnic meadow open** (`gate.bluebellTrack`, [15-progression.md](./15-progression.md) §15.1). Schedule: Mr Apple adds a Bluebell Bank provisioning round. Service: the Store Stump lends picnic hampers (portable gathering basket, +4 capacity). Ambient: worn path to the bank, garlands fade over 3 days, new birdsong layer. Season → Summer. |

### Summer — The Wedding Raft (*Summer Story*)

| Days | Phase | Detail |
|---|---|---|
| 3 | Proposal | Hedgerow Supper: Poppy & Dusty's engagement announced "to nobody's surprise"; Lord Woodmouse offers the ceremony, Old Vole will officiate; the community resolves to build the wedding raft. |
| 4–6 | Contribution | Goals: **12 bundles of reeds** (the far-bank reed beds — on Day 4 Mr Toadflax mends the storm-broken **twig bridge** so the cutting teams can cross; NPC 3/day, cap 4), **8 lengths of timber**, **20 garland stems** (meadowsweet, dog roses), **10 feast dishes** (watercress soup, syllabubs, honey creams, meringues — canon menu). Visible labour: Flax & Lily weaving the canopy; Mr Toadflax carpentry; Mrs Crustybread baking; **Basil cooling wine bottles in the stream** (signature vignette). |
| 7–9 | Construction | Raft at the mill mooring, 3 stages: deck → canopy frame → flowers and mooring. Lend-a-paw: caulking, garlands, ferrying dishes. |
| 10+ | Celebration | **Celebration set-piece at 1.0** (full festival post-launch — ⚠ DEFAULT — owner to confirm, [D10](./00-decisions.md)): the ceremony on the water; gentle jeopardy as the raft slips its rope mid-vows and drifts into the reeds — laughter, punt poles, no harm done (canon mishap; the TV series' gentle-jeopardy model). |
| Next morning | Function | **Traversal:** the mended **twig bridge** stays — **the far bank opens** (reed beds, watercress, willow root; [D7](./00-decisions.md): repaired bridge → far bank, [05-world.md](./05-world.md) §5.11); the raft is re-moored as a **punt-ferry** at the crossing point; and Dusty keeps running the **mill-wheel lift** he rigged to hoist the timbers — **the mill's upper floors and the canopy walk open.** Schedule: Poppy & Dusty's married routine (shared suppers at the Dairy; Dusty's baking mornings move). Service: blackberry buns shared at the mill window on baking days. Ambient: garlands on the mooring, dragonflies, the wheel's new creak-and-splash loop. Season → Autumn. |

### Autumn — The Blanket Drive & the High Hills (*The High Hills* + *Autumn Story* beats)

| Days | Phase | Detail |
|---|---|---|
| 1–4 | (Pre-project) | Harvest rush: all-hedge gathering into the Store Stump ([D8](./00-decisions.md) winter-comfort thresholds); Primrose-lost beat on 5–6 sets the season's tone. |
| 7 | Proposal | Called meeting at the Store Stump (a tired vole messenger arrived Day 6: moths have eaten the High Hills voles' blankets). Mr Apple will lead the delivery before winter; Flax & Lily need fibre. |
| 8–10 | Contribution | Goals: **12 sacks of thistledown + wool tufts** (fence lines, seed heads; NPC 3/day, cap 4), **6 jars of dye-stuff** (elderberry, walnut husk). Visible labour: **Flax & Lily at the paw-looms** (their cottage interior — the year's best interior vignette); the player can turn the loom crank (lend-a-paw comes early in this project). |
| 11–12 | Construction (= weaving & packing) | Blankets finished and baled; route planned; ropes and supplies packed; Wilfred begs to come and packs his explorer's backpack (canon). |
| 12–14 | Celebration (= the expedition staged + Harvest Home) | The expedition is **staged as departure and return set-pieces** ([05-world.md](./05-world.md) §5.13) — the party climbs off-map; the trail itself is not walked. **Day 12, the send-off:** the player helps load the blanket bales at the Z4 trailhead and sees Mr Apple, Wilfred and the vole messenger off into the mist. **Day 13, the night of worry:** a quiet at-home beat — lit windows along the hedge, overheard doorstep lines, Mrs Apple's kitchen vigil. **Day 14, the return:** the party comes back out of the mist, weary and triumphant — Wilfred bursting with tales of ropes, gold-hunting and a cold night by the campfire, his explorer's backpack a badge of honour — straight into the **Harvest Home supper** (the celebration set-piece). |
| Next morning | Function | **Traversal:** Mr Apple's **fixed ropes stay on the rock face — the upland ledge and vantage open** (the High Hills *margin*, the game's highest framed vista — `gate.uplandRopes`, [15-progression.md](./15-progression.md) §15.1; the Hills themselves stay off-map). Schedule: Flax & Lily take commissions at the looms. Service: the voles send mountain herbs and lichen to the Store Stump each season (new ingredients); players may commission a blanket for their burrow ([11-home.md](./11-home.md)). Ambient: geese overhead, first frosts, the voles' thank-you letter read at supper. Season → Winter. |

*Template note:* this project's Celebration is a staged expedition (departure + return set-pieces) + homecoming supper rather than a stationary festival — the one sanctioned variation, because the send-off and the return *are* the set-piece. Expedition staging per [05-world.md](./05-world.md) §5.13; **the walkable High Hills map is post-1.0** ([21-long-term-vision.md](./21-long-term-vision.md), Expansion B — the vole-expedition expansion is where the playable climb, the getting-lost mist and Wilfred's gold-hunt live).

### Winter — The Ice Hall (*Winter Story* + *The Secret Staircase*)

| Days | Phase | Detail |
|---|---|---|
| 1–2 | (Pre-project) | Deep snow buries doors; dig-out day; **snow tunnels** connect the households — the winter traversal network, player and NPCs alike. |
| 3 | Proposal | Hedgerow Supper (reached by tunnel): "There's enough snow for something special" — an **Ice Hall, in the time-honoured way**. Mr Toadflax leads construction; Lord Woodmouse will host Midwinter's Eve. |
| 4–6 | Contribution | Goals: **16 snow blocks** (cut at authored drifts — enabled by Deep Snow weather state), **8 lanterns** (made at hearths: tallow + rosehip shades), **10 feast dishes** (chestnut soup, midwinter cake). Visible labour: block-sledging teams; children rolling lantern-snow; Mrs Crustybread's kitchen going day and night. |
| 7–9 | Construction | The year's most spectacular witnessed build, 4 stages: floor → walls → **vaulted roof** → lanterns lit. Lend-a-paw: steady the block sledge, pass blocks up, place lanterns. |
| 13–14+ | Celebration | **Midwinter's Eve** (full festival, [D10](./00-decisions.md)): the midwinter log hauled along the frosty hedgerow, blazing fire and grand entertainment at Old Oak Palace — Primrose and Wilfred's recital in antique finery from the secret apartment — then the **lantern walk to the finished Ice Hall**. |
| Next morning | Function | Schedule: evening skating/gathering shifts at the Ice Hall while snow lasts. Service: the Ice Hall is a venue (indoor social scenes, echoing audio snapshot); chestnut soup and midwinter cake join the recipe set. Ambient: lantern-glow across the snow, the tunnels' blue light. **Traversal:** tunnels while snow lasts; after the thaw, the passage cleared between the **Store Stump and the Palace cellars remains as a permanent shortcut.** Season → Spring, Year Two. |

### The year-one climax — A Home for the Babies (*Poppy's Babies*, secret project)

Runs **interleaved with the Ice Hall**, using the same system with two flags: `secret` and `noProposalMeeting`.

| Days | Phase | Detail |
|---|---|---|
| Winter 8 | Proposal (whispered) | Rose, Buttercup and Pipkin are born; the mill is too loud, too cold, too floury. That evening, a kitchen meeting at Crabapple Cottage — Mrs Apple proposes secretly refurbishing **Mayblossom Cottage** near the Dairy. The player is sworn in. **Even Wilfred keeps the secret** (canon — and a running test of his heroic self-control). |
| 9–11 | Contribution (secret) | Goals: **8 pieces of furniture mended** (workshop deposits), **6 quilts and blankets** (Flax & Lily moonlight after loom hours), **10 pantry goods**. Visible labour is *hidden in plain sight*: windows glowing at Mayblossom after dark, mice slipping away from the Ice Hall site "for a breath of air." The `secret` flag adds hush-dialogue: conversations about the cottage cut off when Poppy or Dusty approach (systemic charm, cheap to build). |
| 11–12 | Construction (secret) | Chimney swept, whitewash, dressers filled, cradles placed — 3 stages visible only by peeking through Mayblossom's windows (the dollhouse camera as gameplay). |
| Winter 13 | Celebration | **Naming Day**: Old Vole gives the blessing at the palace; the family is led along the hedgerow — and the cottage is revealed. The toast names the whole roster of secret workers, and the player among them. The year's emotional payload; scored with the ceremony leitmotif ([16-music-and-audio.md](./16-music-and-audio.md)). |
| Next morning | Function | Schedule: **the Dogwood family lives at Mayblossom** — Poppy's Dairy walk shortens, Dusty commutes to the mill, pram outings at Dawn (the babies are visible, growing set-dressing). Service: **Mayblossom Cottage interior** joins the dollhouse set; the mill becomes workplace-only (quieter interior state). Ambient: washing lines, a nursery window lit at Night. Traversal: the bramble path to Mayblossom is cleared as part of the refurbishment. |

If the player contributes nothing, the secret project still completes on the same rule as every other — but the hush-dialogue and window-glow make it the project most likely to pull players in unprompted, which is the point.

## 14.8 What This Chapter Guarantees

- Every favour pays back within a day (14.2 — validator-enforced).
- Every project changes ≥1 schedule + ≥1 service + ≥1 ambient layer and opens a traversal gate (14.6).
- Nothing fails, expires, or fills a bar (14.4).
- The community demonstrably works — and finishes — with or without the player (14.6, exact rule). The player's reward is belonging, not credit.

[See Community Philosophy →](./18-community-philosophy.md)

[← Back to Index](./INDEX.md) | [Previous](./13-time-and-seasons.md) | [Next: Progression →](./15-progression.md)
