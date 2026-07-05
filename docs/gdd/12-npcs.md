# 12. NPCs

[← Back to Index](./INDEX.md) | [Previous](./11-home.md) | [Next: Time & Seasons →](./13-time-and-seasons.md)

**Status: production-ready. Binding numbers come from [D9 in the decisions brief](./00-decisions.md); nothing here may contradict it.**

NPCs are equals in the community, not quest dispensers. The player is a newcomer mouse finding their place in an established world (**⚠ DEFAULT — owner to confirm**, per [D9](./00-decisions.md)); every mouse in this document had a full life before the player arrived and keeps one afterwards. Lifeless, repetitive NPCs are the single most repeated review killer in this genre ([cozy pitfalls](../research/09-cozy-pitfalls.md)), and our pitch — the community that runs with or without you — dies first if the mice feel hollow. This section is therefore a core-systems spec, not a lore appendix. See also [Community Philosophy](./18-community-philosophy.md) and [Quests](./14-quests.md).

All character names live in the canon layer: localisation/data assets only, never hardcoded, rename-swappable in a week ([D1](./00-decisions.md)). Canon facts below are sourced from the [canon bible](../research/01-brambly-hedge-canon.md); anything the books do not specify is marked **(game-original)** and is rename-safe by construction.

---

## 12.1 Casting principles

- **12 scheduled NPCs at 1.0, no more** ([D5](./00-decisions.md), [D9](./00-decisions.md)). Fewer, deeper mice beat many shallow ones — ACNH's 400 villagers on 8 shared scripts is the documented anti-model ([comps](../research/03-comps-community-sims.md)).
- Drawn from the **5 canon households**: Woodmouse (Old Oak Palace), Toadflax (Hornbeam Tree), Apple (Crabapple Cottage), Eyebright/Dogwood (Dairy & Mill), and the elders. The full canon cast is only ~20 named mice — we schedule 12, and every other named mouse still exists as a **named extra** (§12.3), never as a cut character.
- Two content tiers: **Major** (≥200 dialogue lines, 4 heart-scenes, 10 hearts) and **Minor** (≥80 lines, 3 heart-scenes, 8 hearts). Both tiers get a full seasonal schedule, gift table, festival roles and ≥1 community-project role.
- **Who missed the twelve and why:** Mrs Crustybread (palace cook) is fully represented by Mrs Apple + Lady Daisy's menu scenes; Old Vole is canonically a neighbour who "joins for spiritual occasions" — a perfect *ceremonial extra* (blessings, officiating) rather than a daily schedule; Old Mrs Eyebright is retired (her Dairy history lives in Poppy's heart-scenes); Mr Toadflax and the three Toadflax siblings are household extras (§12.3). Any of these can be promoted to scheduled status in a year-2 update without new systems.

## 12.2 The twelve — roster

| # | NPC | Household | Home | Occupation | Tier | Birthday | Hearts | Ships in |
|---|---|---|---|---|---|---|---|---|
| 1 | **Mr (Pip) Apple** | Apple | Crabapple Cottage | Warden of the Store Stump | Major | Winter 4 | 10 | **MVP-3** |
| 2 | **Mrs (Flora) Apple** | Apple | Crabapple Cottage | Cook, preserver, diarist | Major | Autumn 6 | 10 | **MVP-3** |
| 3 | **Wilfred Toadflax** | Toadflax | Hornbeam Tree | Child; aspiring explorer | Major | Spring 12 | 10 | Slice-5 (presence) |
| 4 | **Primrose Woodmouse** | Woodmouse | Old Oak Palace | Child of the palace | Major | Autumn 11 | 10 | 1.0† |
| 5 | **Poppy Eyebright** | Eyebright/Dogwood | Dairy → Mill → Mayblossom Cottage* | Dairymouse | Major | Summer 5 | 10 | Slice-5 (presence) |
| 6 | **Dusty Dogwood** | Eyebright/Dogwood | Flour Mill → Mayblossom Cottage* | Miller, experimental baker | Major | Summer 10 | 10 | **MVP-3** |
| 7 | **Basil Brightberry** | Elders | Elderberry Lodge | Cellarmouse — wines, syrups, cordials | Major | Winter 9 | 10 | 1.0 |
| 8 | **Lord (Quercus) Woodmouse** | Woodmouse | Old Oak Palace | Presides over the hedge | Minor | Summer 2 | 8 | 1.0 |
| 9 | **Lady (Daisy) Woodmouse** | Woodmouse | Old Oak Palace | Palace hostess; painter | Minor | Spring 3 | 8 | 1.0 |
| 10 | **Mrs (Betony) Toadflax** | Toadflax | Hornbeam Tree | Keeper of the Hornbeam household (game-original framing) | Minor | Winter 13 | 8 | 1.0 |
| 11 | **Flax** | Elders | Weavers' Cottage (game-original name) | Weaver | Minor | Autumn 3 | 8 | 1.0 |
| 12 | **Lily** | Elders | Weavers' Cottage | Weaver, dyer | Minor | Spring 8 | 8 | 1.0 |

\* Home changes are story-driven ([D7](./00-decisions.md) Function phase): Poppy moves to the Mill after the Midsummer wedding, and both move to Mayblossom Cottage at the year-one climax — the schedule system must support home reassignment via story flags from day one.
† Slice-5 = the five NPCs of the M3–6 vertical slice ([D16](./00-decisions.md)): the MVP-3 plus presence NPCs Wilfred and Poppy. Primrose joins at slice hardening if budget allows, else at 1.0 content lock.

Birthdays are game-original placements on the 14-day season calendar ([13 — Time & Seasons](./13-time-and-seasons.md)) — three per season, spaced at least three days apart. One canon anchor: Wilfred's birthday is in spring and is celebrated at the spring picnic, exactly as in *Spring Story* ([canon](../research/01-brambly-hedge-canon.md)).

**Why these three in the MVP** (Mr Apple, Mrs Apple, Dusty):
1. **One household pair** — the Apples share Crabapple Cottage, so the MVP exercises interlocking spouse schedules and NPC-to-NPC visible life in miniature at zero extra interior cost.
2. **A visible Function phase** — Dusty's schedule visibly changes the morning the bridge reopens: his grind-and-delivery route swings out across the newly reachable far bank. That before/after is the D7 Function-phase proof the slice exists to demonstrate ([D7](./00-decisions.md), backlog NPC-07) — two settled adults plus one mouse whose whole day *rearranges* when the community project lands. (The structurally different child-schedule shape — play POIs, no occupation block, roaming radius — is deferred to slice hardening with Wilfred.)
3. **The systems trifecta** — Mr Apple fronts the Store Stump economy ([D8](./00-decisions.md)) and is the canon project proposer (he organised the picnic in *Spring Story*); Mrs Apple fronts cooking/recipes and the journal's diary canon; Dusty fronts the mill/flour supply, gathering-alongside (the player forages his clover) and the project-driven recipe unlocks of the Function phase. Three NPCs, every 1.0 NPC-facing system touched.
4. **Geography** — the Apples' Crabapple Cottage and the Store Stump sit together on the near bank; the Flour Mill sits just across the stream. One exterior zone, the Store Stump and Mill hero interiors, and the single bridge crossing between them cover the whole MVP — and that crossing is the traversal gate the Function-phase proof (point 2) turns on.

## 12.3 Extras policy

Named extras keep the world canon-complete without schedule cost. Rules:

- **Named extras at 1.0:** Mr (Alf) Toadflax; Teasel, Clover and Catkin Toadflax (children); Mrs Violet Crustybread (palace cook); Old Vole (ceremonial elder); Old Mrs Eyebright (retired dairymouse). Post-climax: the babies Rose, Buttercup and Pipkin. Expedition/festival visitors: the High Hills voles, Purslane & Thrift Saltapple's sea mice, the harvest mice ([canon roster](../research/01-brambly-hedge-canon.md)).
- Extras have a **name, a fixed unique look, and a personal line pool of ≤20 lines** — never anonymous clones, never shared pools. They have **no daily schedule, no hearts, no gift table**.
- Extras appear through **placement sets**: authored spawn layouts keyed to festivals, project phases (Mr Toadflax leads heavy-lift shifts in every Construction phase — visible labour, cheap presence), the weekly supper (rotating two guest seats), and expeditions.
- **Children policy:** Teasel, Clover and Catkin spawn at play POIs near the Hornbeam Tree on fine afternoons and at all festivals; they are never quest-givers and never gift targets. Wilfred and Primrose, as scheduled cast, are full participants in every system.
- **Extras are never load-bearing:** no extra may speak a project-critical or story-critical line. This keeps the extra layer cheap to cut, recast or rename ([D1](./00-decisions.md)). Old Vole's blessings at ceremonies are staged spectacle with subtitle text, not quest logic.

## 12.4 Character sheets

Gift lists are seeds for the full data tables (loved +80 / liked +45 — see §12.5); all foods are canon dishes and forageables ([canon §6](../research/01-brambly-hedge-canon.md)). Rule: an NPC's own signature dish is never their loved gift (they make it better than you); prefer the *ingredients* of their craft. Every loved gift must be gatherable or cookable in at least two seasons. Preserved and stored goods (jams, syrups, cordials, and soups laid up in the Store Stump) count as available in every season, so the two-season rule bites only on raw forage. Heart-scene themes are one-line briefs for the bespoke scenes of §12.6.

### 1. Mr (Pip) Apple — Major, MVP-3
- **Canon personality:** "solid, reliable"; practical problem-solver; organised the surprise picnic; led the High Hills blanket expedition; hates dressing up for palace occasions. (TV voice reference: Michael Williams.)
- **Project roles:** proposes the **spring picnic** at the community meeting (canon lift); standing **quartermaster** of every project (materials flow through the Store Stump); co-leads the **autumn expedition**.
- **Festival roles:** picnic organiser; Midwinter — provisions the palace feast, endures his best waistcoat (running gag).
- **Gifts:** loved — hot chestnut soup, crabapple syrup; liked — acorn coffee, honey.
- **Heart-scenes (H2/4/6/8):** *Every Shelf Has a Story* (after-hours Stump tour; deposit lore) · *The Best Waistcoat* (formal-dress dread before a palace do) · *The Mountain Night* (the cold night on the High Hills with Wilfred) · *Daisy's Father* (quiet pride in the palace hostess — canon-implied kinship, flagged as such).

### 2. Mrs (Flora) Apple — Major, MVP-3
- **Canon personality:** the hedge's great cook and preserver (rosehip jam, seed cake); keeps a daily journal and holds her mother's, grandmother's and great-grandmother's diaries — the in-fiction root of our [journal-as-UI](./17-ui-philosophy.md). (TV voice reference: June Whitfield.)
- **Project roles:** feast lead for picnic and wedding; preserving drives the autumn Store Stump push; teaches project-unlocked recipes (Function phase).
- **Festival roles:** picnic hampers; Midwinter feast baking.
- **Gifts:** loved — basket of fresh rosehips, wild blackberries (her jam inputs); liked — honey, elderberry syrup.
- **Heart-scenes:** *Four Hands of Writing* (the matrilineal diaries) · *The Rosehip Standard* (jam-making side by side; teaches the recipe) · *A Page for Everything* (reads a diary entry about the hedge before the player arrived — the world predates you) · *The Empty Line* (asks the player to write today's entry in *her* diary).

### 3. Wilfred Toadflax — Major, Slice-5 (presence)
- **Canon personality:** the books' child protagonist; mischievous, energetic, plays whistle and drums, fires grass seeds from a catapult, wants to be "an intrepid explorer", keeps a permanently packed expedition backpack. (TV voice reference: Neil Morrissey.)
- **Project roles:** self-appointed scout on the picnic route; begs onto the **autumn expedition** (canon); proud secret-keeper in the **Mayblossom climax** (canon).
- **Festival roles:** the spring picnic is his birthday surprise (canon); recites the Midwinter poem with Primrose (canon, *The Secret Staircase*).
- **Gifts:** loved — blackberry buns, meringues; liked — honey creams, wild strawberries; also loves "expedition finds" — curious pebbles and feathers (game-original category).
- **Heart-scenes:** *The Expedition Kit* (backpack inventory, item by item) · *Sir Hogweed Horehound* (reads from his explorer book) · *Gold in the High Hills* (what his mountain "treasure" really was) · *The Secret* (proves he can keep Mayblossom quiet — seeds the climax).

### 4. Primrose Woodmouse — Major
- **Canon personality:** the Woodmouses' only child; curious, early-rising, restless; loves the palace's "unexpected little rooms and secret passageways"; got lost in the cornfield in *Autumn Story*. (TV voice reference: Charlotte Coleman.)
- **Project roles:** decorations for picnic and wedding raft; her wandering is the fictional excuse for teaching the player far-zone geography.
- **Festival roles:** picnic flower-gathering; Midwinter recital with Wilfred (canon).
- **Gifts:** loved — a posy of wildflowers (gatherable craft), wild strawberries; liked — primrose pudding, meringues.
- **Heart-scenes:** *Unexpected Little Rooms* (palace passage exploring) · *The Cornfield* (retells being lost — "I wasn't scared. Mostly.") · *Sitting Still* (roped into modelling for her mother's portrait) · *The Dusty Staircase* (shares the hidden apartment — the [Secret Staircase exploration reward](./05-world.md), coordinated with world design).

### 5. Poppy Eyebright — Major, Slice-5 (presence)
- **Canon personality:** runs the Dairy her grandmother handed down; keeps cool in the mossy shadow of the mill wheel; marries Dusty on Midsummer's Day; mother of Rose, Buttercup and Pipkin by the year-one climax.
- **Project roles:** the **Midsummer wedding raft** project centres on her and Dusty (Proposal = their engagement announcement at a meeting); Dairy supplies every feast; the **Mayblossom climax** is her family's story.
- **Festival roles:** picnic dairy spread (syllabubs, honey creams); dances at Midwinter.
- **Gifts:** loved — honey creams, meadowsweet wine; liked — wild strawberries, fresh honey.
- **Heart-scenes:** *Cool by the Wheel* (Dairy tour) · *Granny Eyebright's Slabs* (the inherited scrubbed stones and heavy pans) · *Louder Every Day* (the clattering mill as a family home — post-wedding story condition; seeds the climax) · *Naming Names* (trusts the player with the baby-name shortlist).

### 6. Dusty Dogwood — Major, MVP-3
- **Canon personality:** the miller, taught by his father; shy and initially under-confident (feared Poppy would refuse him); experimental baker famous for clover bread and blackberry buns; owns the boat *Periwinkle*. (TV voice reference: Neil Morrissey.)
- **Project roles:** co-subject of the **wedding raft**; mill output gates feast recipes (Function phase); boat-owner hook for post-launch Sea Story content ([21 — Long-Term Vision](./21-long-term-vision.md)).
- **Festival roles:** picnic fresh buns; hauls the midwinter log with the heavy-lift team (canon element).
- **Gifts:** loved — fresh clover, wild blackberries (his baking inputs); liked — cheese, acorn coffee.
- **Heart-scenes:** *How the Wheel Turns* (mill tour) · *Clover Bread* (experimental bake; player forages the clover) · *Asking Properly* (rehearses his proposal on the player — pre-wedding condition) · *The Periwinkle* (shows the boat; promises the sea, someday).

### 7. Basil Brightberry — Major
- **Canon personality:** elder of Elderberry Lodge; makes and keeps all the hedge's wines, syrups and cordials by season; mixes the celebration punches; good-natured but forgetful. (TV voice reference: Jim Broadbent.)
- **Project roles:** proposes the **winter Ice Hall** ("in the time-honoured way" — elder memory); cellar supplies every Celebration phase.
- **Festival roles:** punch at both 1.0 festivals (canon).
- **Gifts:** loved — basket of elderflowers, basket of cowslips (cellar inputs by season); liked — wild blackberries, crabapples.
- **Heart-scenes:** *The Cellar Ledger* (cordial cellar tour; what is ready when) · *A Forgotten Barrel* (hunt for a mislaid vintage through the Lodge) · *The Punch Secret* (the festival punch recipe, sworn to secrecy) · *To Old Friends* (a toast to mice long gone — elder memory beat).

### 8. Lord (Quercus) Woodmouse — Minor
- **Canon personality:** head of Brambly Hedge; presides over public occasions; grew up in the Old Oak Palace; devoted, slightly indulgent father. (TV voice reference: Anton Rodgers.)
- **Project roles:** chairs every community meeting (Proposal phase host — he convenes, the community decides; he never commands).
- **Festival roles:** presides at picnic and Midwinter (canon).
- **Gifts:** loved — bramble brandy, pies; liked — cheeses, hot chestnut soup.
- **Heart-scenes (H2/5/8):** *The Palace Rounds* (walking the Old Oak; a palace with open doors) · *A Father's Fret* (asks the player, as an equal, to keep half an eye on Primrose) · *The Weight of Oak* (what "presiding" means when nobody commands anyone — the class-without-conflict beat).

### 9. Lady (Daisy) Woodmouse — Minor
- **Canon personality:** palace hostess; plans menus with the cook; a keen artist who paints and sketches — the canon anchor for journal sketching ([D13](./00-decisions.md)). (TV voice reference: Rosemary Leach.)
- **Project roles:** decoration lead for wedding raft and Ice Hall; hosts Construction-phase teas.
- **Festival roles:** Midwinter hostess; picnic menu planning with Mrs Crustybread (extra).
- **Gifts:** loved — primrose pudding, syllabub; liked — wild strawberries, dandelion salad.
- **Heart-scenes:** *Paint and Patience* (a sketching lesson — unlocks a journal sketch frame) · *Menus with Mrs Crustybread* (feast planning; the player tastes) · *Portrait of the Hedge* (gifts a painting of the player *among* their neighbours — belonging, not celebrity).

### 10. Mrs (Betony) Toadflax — Minor
- **Canon personality:** canon gives only "parent of four"; the game reads her as the unflappable keeper of the hedge's busiest kitchen (game-original characterisation, canon-compatible).
- **Project roles:** catering logistics on every Contribution phase; blankets-and-cushions detail at outdoor events.
- **Festival roles:** picnic rugs and child-wrangling; Midwinter cushions and early bedtimes enforced (unsuccessfully).
- **Gifts:** loved — seed cake, fresh rhubarb; liked — clover bread, honey.
- **Heart-scenes:** *Four at the Table* (dinner-hour chaos at the Hornbeam Tree) · *Hand-Me-Down Patchwork* (quilt mending; every scrap has a history) · *One of Mine* (counts heads at a festival and includes the player without noticing she did — the game's best belonging beat).

### 11. Flax — Minor
- **Canon personality:** one of the two weavers who made the vole blankets on paw-driven looms (*The High Hills*). Canon is silent on Flax and Lily's relationship to each other; we leave it unstated.
- **Project roles:** co-proposes the **autumn blanket drive** (the moths, again); weaving shifts are the project's visible labour.
- **Festival roles:** picnic rugs; Midwinter hangings for the palace hall.
- **Gifts:** loved — teasel heads (for carding — real hedgerow craft, game-original as a gift), hot chestnut soup; liked — clover bread, acorn coffee.
- **Heart-scenes:** *Warp and Weft* (loom demonstration) · *The Moth Year* (why the voles' blankets mattered) · *A Thread of Your Own* (weaves the player's gathered wool into a blanket for their burrow — reward feeds [11 — Home](./11-home.md)).

### 12. Lily — Minor
- **Canon personality:** the other weaver; the game gives her the dye-pots (game-original specialisation, craft-accurate).
- **Project roles:** co-proposes the autumn blanket drive; dye colours gate blanket variants; bunting for every Celebration phase.
- **Festival roles:** picnic and Midwinter bunting and ribbons.
- **Gifts:** loved — elderberries and elderflowers (dye and craft stock), wild raspberry cordial; liked — seed cake, cheese.
- **Heart-scenes:** *Dye Day* (colour from hedgerow berries) · *Patterns Remember* (each weave pattern commemorates a hedge event — oral history in cloth) · *The Longest Winter* (a blanket that once mattered, given forward).

Flax and Lily share one schedule asset with paired POIs (two agents, offset positions at the same loom/hearth) — a deliberate authoring economy for a household that canonically lives and works together.

---

## 12.5 Friendship system — the numbers

Binding skeleton from [D9](./00-decisions.md); liked/neutral values adopted from the proven Stardew scale ([comps](../research/03-comps-community-sims.md)). **No decay, ever** — decay is the most resented number in the genre.

| Parameter | Value | Notes |
|---|---|---|
| Points per heart | **250** | D9, binding |
| Hearts | **10 major / 8 minor** (2,500 / 2,000 pts) | instantiates D9's 8–10 band |
| First talk of the day | **+20** | later talks give fresh lines, no points |
| Gift: loved | **+80** | |
| Gift: liked | **+45** | |
| Gift: neutral | **+20** | |
| Gift: not to their taste | **+5**, gentle deflecting line | never negative — no punishment mechanics ([D6](./00-decisions.md) spirit) |
| Birthday gift | **×8** (loved = 640) | does not count against the weekly cap |
| Gift caps | **1/NPC/day, 2/NPC/week** | D9, binding |
| Decay | **none** | D9, binding |
| Supper conversation | counts as the daily talk | see §12.8 |

**Pacing math (tuning intent, testable):** maximum ordinary week = 7×20 + 2×80 = **300 pts ≈ 1.2 hearts**. An attentive player maxes their first favourite (2,500 pts) in ~8–9 weeks of the 56-day year — i.e. **one, at most two, maxed friendships in year one**, with three or four more at hearts 5–8. This is deliberate: friendship is a year-scale rhythm, not a checklist, and it feeds the year-2 novelty budget ([21 — Long-Term Vision](./21-long-term-vision.md)). If playtests show <1 maxed friendship per completed year-one save, raise talk to +25 before touching gift values.

**Discovery is in-fiction, never wiki-shaped:** preferences surface through NPC dialogue, overheard supper lines and journal gossip; every discovered preference is auto-recorded on the NPC's journal page ([17 — UI Philosophy](./17-ui-philosophy.md)).

**Post-max content (anti-hard-stop):** at max hearts an NPC sends one seasonal letter per season and gains standing-invitation lines ("supper's not supper without you") — a thin, permanent stream so maxed friendships feel settled, not dead ([comps](../research/03-comps-community-sims.md)).

## 12.6 Heart-scenes — the protected budget

Each heart tier is gated by a small bespoke scene (Palia's best idea, single-player-ised). **Points accumulate freely, but the tier — and its dialogue band and perks — unlocks only when the scene has played.**

- **Budget: 43 scenes at 1.0** (7 majors × 4 + 5 minors × 3), inside D9's 40–50 band. This is the highest-value content in the game; it is the **last** budget line that may be cut, after fishing, sketching extras and festival variants ([D9](./00-decisions.md)).
- **Placement:** majors at hearts 2/4/6/8; minors at hearts 2/5/8. Heart 10 (majors) is pointed, not scene-gated: it converts to the post-max letter/invitation stream.
- **Trigger rule:** a pending scene attaches an availability window to a POI the NPC's default schedule already visits ≥3 days a week (e.g. Mr Apple's H2: enter the Store Stump 08:00–12:00, any non-festival day). No teleporting NPCs, no appointments. The journal hints in prose: "Mr Apple seemed to want to show me something in the Stump."
- **Scenes never expire and re-offer indefinitely** ([D6](./00-decisions.md): no expiring content). Story-conditioned scenes (Poppy H6 requires the wedding; Dusty H6 requires pre-wedding state) are annotated in data; if a story window closes, a replacement variant line-set must exist — no dead tiers.
- **Format:** 1–3 minutes, 10–20 lines, one location, at most two participants, camera treated as an authored [arrival shot](./07-camera-direction.md). Time pauses ([D6](./00-decisions.md)).

## 12.7 Schedules — data model and runtime

We copy Stardew's proven schedule-as-data shape and upgrade the addressing to named points of interest, per the [systems architecture research](../research/12-tech-systems-architecture.md). The clock runs 06:00–24:00 ([D6](./00-decisions.md)).

**Priority cascade** — one key resolves per NPC at day start, first match wins:

1. `festival_today` — schedule suspended; festival placement set takes over ([D10](./00-decisions.md): festivals start without the player)
2. `<season>_flag_<projectFlag>` — community-project phases (e.g. `summer_flag_raft_construction`, `autumn_flag_blanket_expedition`, `spring_flag_bridge_repaired`) — **the mechanical heart of "the world visibly changes"** ([D9](./00-decisions.md))
3. `<season>_<weather>` — `rain` / `snow`
4. `<season>_<dayNum>` — day 1–14 specials (own birthday, story days)
5. `<season>_<dayOfWeek>` — weekly rhythms
6. `<season>` — the default day
7. `default` — safety net; `GOTO <key>` aliasing keeps 80% of a year written once

**Named POIs, never coordinates:** destinations are authored transforms — `Store.Counter`, `Dairy.Churn`, `Stream.RaftYard`, `Hedge.FlowerBank.PicnicSpot` — so level art can change freely through pre-production. Departure times are back-solved from arrival times using per-leg travel budgets; the build fails loudly if a leg cannot be made on time.

**Runtime FSM (6 states, no utility AI** — dependable rhythms are the point; "Poppy churns on Tuesdays" is a feature, not a limitation):

| State | Behaviour |
|---|---|
| `Asleep` | at home POI, lights out |
| `Travel` | NavMesh route between POIs; interruptible (below) |
| `Routine` | activity loop at POI (churn, saw, knead) + location barks |
| `Chat` | player conversation; time pauses |
| `Social` | paired NPC-NPC loop (supper, courtship, quarrel beats) |
| `Ceremony` | festival / heart-scene / project-celebration placement |

Interrupt rules: talking in `Routine`/`Social` is always allowed; talking in `Travel` pauses the NPC ≤10 s, grants the daily talk credit, then resumes with catch-up speed ≤1.15× — **never an on-screen teleport**. Off-screen NPCs are `(locationId, routeProgress)` records, instantiated on scene entry.

**Tooling gate (binding, D9):** the in-editor schedule visualiser — scrub the clock, see every NPC's planned day as paths on the map — must exist **before the third schedule is authored**. This is the genre's #1 breakage point.

**Example schedule asset — Dusty, two seasons** (YAML-flavoured sketch of the `NpcScheduleSO`):

```yaml
npc: npc.miller
keys:
  # -- SUMMER ---------------------------------------------------------
  summer_flag_raft_construction:        # Construction phase, wedding raft
    - { at: "07:00", poi: Mill.Kitchen,        act: Breakfast }
    - { at: "08:00", poi: Mill.GrindFloor,     act: Milling }          # short shift
    - { at: "10:00", poi: Stream.RaftYard,     act: Sawing,  bark: miller.raft.work }
    - { at: "13:00", poi: Stream.RaftYard.Log, act: Lunch }
    - { at: "13:30", poi: Stream.RaftYard,     act: Sawing }
    - { at: "18:00", poi: Dairy.Door,          act: Social,  with: npc.dairy_keeper }
    - { at: "21:30", poi: Mill.Bedroom,        act: Sleep }
  summer_rain:                          # wheel needs watching in weather
    - { at: "06:30", poi: Mill.WheelPlatform,  act: InspectWheel, bark: miller.rain.wheel }
    - { at: "08:00", poi: Mill.GrindFloor,     act: Milling }
    - { at: "12:30", poi: Mill.Kitchen,        act: Lunch }
    - { at: "13:30", poi: Mill.GrindFloor,     act: Milling }
    - { at: "19:00", poi: Mill.Kitchen,        act: ExperimentalBaking, bark: miller.baking }
    - { at: "22:30", poi: Mill.Bedroom,        act: Sleep }
  summer:                               # the default summer day
    - { at: "06:30", poi: Mill.WheelPlatform,  act: InspectWheel }
    - { at: "07:30", poi: Mill.GrindFloor,     act: Milling, bark: miller.mill.work }
    - { at: "12:00", poi: Stream.Bank.WillowRoot, act: LunchBasket }   # canon: walks the stream banks
    - { at: "13:30", poi: Mill.GrindFloor,     act: Milling }
    - { at: "16:00", poi: Store.Counter,  act: FlourDelivery, bark: miller.delivery }
    - { at: "17:30", poi: Dairy.Door,          act: Social, with: npc.dairy_keeper }   # courtship beat, pre-wedding
    - { at: "20:00", poi: Mill.Kitchen,        act: ExperimentalBaking }
    - { at: "22:30", poi: Mill.Bedroom,        act: Sleep }
  # -- AUTUMN ---------------------------------------------------------
  autumn_rain: GOTO summer_rain         # a wet mill day is a wet mill day
  autumn:                               # harvest: longer grind, buns for the Store
    - { at: "06:00", poi: Mill.WheelPlatform,  act: InspectWheel }
    - { at: "06:30", poi: Mill.GrindFloor,     act: Milling, bark: miller.harvest.rush }
    - { at: "12:00", poi: Mill.Kitchen,        act: Lunch }
    - { at: "12:30", poi: Mill.GrindFloor,     act: Milling }
    - { at: "17:00", poi: Store.Counter,  act: FlourDelivery }
    - { at: "19:00", poi: Mill.Kitchen,        act: BlackberryBunBaking, bark: miller.buns }
    - { at: "22:00", poi: Mill.Bedroom,        act: Sleep }
```

Departure legs (e.g. Mill → Store Stump) are computed, not authored. The hedgerow supper (Day 3 and Day 10 of each season) is **not** a schedule key — see below.

## 12.8 The weekly hedgerow supper

Day 3 and Day 10 of each season, 18:00–21:00 — the same weekday (see [13 — Time & Seasons §13.1](./13-time-and-seasons.md)) — in the Store Stump great hall. This is the Mistria-Friday-inn / Stardew-saloon pattern: concentrate NPC-to-NPC social life where the player can watch it ([synthesis](../research/00-synthesis.md), [pitfalls](../research/09-cozy-pitfalls.md)).

- Implemented as a **partial-day overlay**, not a cascade key: at 18:00 the supper placement set overrides remaining entries for all attendees, whatever key won their morning. Suppers therefore survive rain, project crunches and player absence. Project night-shifts (rare) are the only exemption.
- **Attendance:** all 12 scheduled NPCs by default, plus two rotating named-extra guest seats. NPCs mid-expedition are absent — and are talked *about*.
- **Seating is state-driven:** courting mice sit together; quarrelling mice sit apart (§12.9); the newest heart-scene partner tends to wave the player over. Seating is the cheapest visible read of the social graph in the game.
- **Player-facing:** attending is optional and unrewarded beyond fiction; chatting counts as the daily talk (+20); any dish the player deposited in the Store Stump that day appears on the table with a one-line acknowledgement — reciprocity made visible ([09 — Gameplay Loop](./09-gameplay-loop.md)).
- **Content budget:** ≥40 overheard NPC-to-NPC exchange snippets at 1.0, saliency-filtered by season, active project, and live relationship beats, so eavesdropping stays fresh across the year.

## 12.9 NPC-to-NPC visible life

NPCs gift, quarrel and reconcile with each other, surfaced through overheard lines and journal gossip — the cheapest aliveness multiplier we have ([comps §6](../research/03-comps-community-sims.md)).

**Relationship beats** are small data-driven arcs:

```
RelationshipBeatSO {
  id: beat.autumn_floursacks
  participants: [npc.warden, npc.miller]
  window: autumn, requires flag_harvest_push
  arc:  Spark  (overheard exchange at the Stump)
     →  Simmer (journal gossip entry; supper seating separates; 1–2 grumbled lines each)
     →  Mend   (overheard reconciliation; shared POI restored)
  playerAssist: favour.deliver_peace_buns   # optional; accelerates Mend by 1 day
  maxDuration: 4 days
}
```

- **Cadence: 2 beats per season at 1.0** (8 total) plus 2 standing courtship beats (Poppy & Dusty pre-wedding; butter left at the mill, buns left at the dairy).
- **Tone guardrails:** quarrels are gentle (a borrowed funnel, flour-sack priority, a disputed blanket pattern), always reconcile within ≤4 in-game days, and never involve the player as judge. The player may **assist** (deliver the apology basket), never **fix** — assistance accelerates, absence never blocks.
- **Journal gossip:** each beat stage auto-writes a 1–2 line prose entry ("Flax and Lily are not speaking about the wedding-blanket border. Mrs Apple says give it a week."). Prose, never a status widget ([17 — UI Philosophy](./17-ui-philosophy.md)).
- **Own-life threads:** every scheduled NPC has ≥1 personal goal per season with nothing to do with the player (Basil's lost vintage, Wilfred's expedition drills, Lady Daisy's four-season hedge portrait), surfaced in ≥3 dialogue lines and ≥1 gossip entry per season.

## 12.10 Dialogue — budgets, axes, tooling

Binding floors from [D9](./00-decisions.md): **4,000–8,000 reactive lines at 1.0; ≥200 per major, ≥80 per minor; every completed project adds ≥3 permanent lines per involved NPC.**

**1.0 allocation (target ≈ 4,600 lines, floor-checked):**

| Pool | Lines | Notes |
|---|---|---|
| 7 majors × ~350 | 2,450 | per-NPC: 60 core, ~100 seasonal (25×4), 40 friendship-band, 60 project-reactive, 30 festival, 60 supper/social |
| 5 minors × ~120 | 600 | same shape, thinner |
| Heart-scenes (43 × ~15) | 645 | the protected budget (§12.6) |
| Supper overheard exchanges | 200 | §12.8 |
| Gossip + relationship beats | 250 | §12.9 |
| Project permanent lines + phase barks | 320 | 4 projects + climax; ≥3 permanent lines per involved NPC per project, kept forever ("the mill Dusty runs now…") |
| Festival variants | 150 | 2–3 state-reactive variants per festival ([D10](./00-decisions.md)) |
| **Total** | **≈ 4,615** | within D9's 4,000–8,000 band |

**Reactivity axes** (saliency conditions, not a matrix to fill): season (4) × weather (fine/rain/snow) × friendship band (0–2, 3–5, 6–8, 9–10) × active project phase × recent festival (3-day echo window). Author *against* the axes — most lines carry one or two conditions; only hero moments carry three.

**Tooling (binding):** Yarn Spinner 3 **Line Groups + saliency** ("most specific matching line, least recently seen") replace any hand-rolled bark tables, integrated with Unity Localization from month one ([D2](./00-decisions.md), [architecture research](../research/12-tech-systems-architecture.md)). Repetition rule: any state combination a player hits ≥3 times per season must have ≥3 interchangeable variants in its Line Group.

**Word-budget guard ([D15](./00-decisions.md)):** dialogue owns **≤50k words** of the enforced 60–80k total (we pay per word eight times). Therefore: ambient lines average ≤12 words; heart-scene lines may run longer; a monthly word-count report is part of the localisation pipeline. Writing must work unvoiced ([D12](./00-decisions.md)) — short, rhythmic, readable aloud in a parent's storybook voice.

## 12.11 Anti-patterns — testable rules

Each rule is a build gate, not an aspiration. Sources: [comps](../research/03-comps-community-sims.md), [pitfalls](../research/09-cozy-pitfalls.md).

1. **No archetype pools (the ACNH failure).** Every dialogue line is owned by exactly one character; the shared/generic pool size is **zero**. Enforced by a Yarn node-ownership lint in CI. Extras have their own ≤20-line personal pools.
2. **No player-worship (the genre failure).** NPCs are equals with their own lives. ≤10% of an NPC's ambient/overheard lines may reference the player at all; gratitude lines name at least one other contributing mouse; project-completion toasts name ≥2 NPCs alongside the player ([D7](./00-decisions.md) diffused credit). Nobody says "thank goodness you're here" — the hedge managed for generations.
3. **No stranger-greetings (the Fae Farm failure).** A `met` flag kills first-meeting lines forever; a "gap" variant fires when last conversation was >7 days ago ("Haven't seen you since the rain came in.").
4. **No relationship hard-stops (the Palia/Stardew failure).** Post-max = seasonal letters + standing invitations (§12.5). No tier ever displays as "complete".
5. **No maintenance anxiety.** No decay, no negative gifts, no disappointed states, no expiring scenes ([D6](./00-decisions.md)).
6. **No quest-dispenser posture.** Favours arise in conversation and end in reciprocity within one in-game day ([14 — Quests](./14-quests.md)); NPCs propose community projects at meetings — the player seconds, never commands ([D7](./00-decisions.md)).
7. **The world remembers.** Post-project permanent lines never rotate out; season-1 events are still referenced in winter. Reactivity is cheaper than volume and reads as life.

## 12.12 Data model sketch

Definitions are ScriptableObjects with stable string IDs; runtime state is plain serialisable C# ([architecture research](../research/12-tech-systems-architecture.md), [19 — Technical Direction](./19-technical-direction.md)). Display names are `LocalizedString` references — the canon layer lives entirely in localisation tables ([D1](./00-decisions.md)).

```csharp
NpcDefinitionSO {
  string id;                     // "npc.preserver" — stable, rename-safe
  LocalizedString displayName;   // canon layer (D1)
  HouseholdId household;
  LocationId homeLocation;       // reassignable via story flags (Poppy/Dusty moves)
  (Season season, int day) birthday;
  NpcTier tier;                  // Major | Minor  (hearts, budgets derive from tier)
  GiftTasteEntry[] giftTable;    // itemId → Loved | Liked | Neutral (absent ⇒ polite +5)
  NpcScheduleSO schedule;        // key cascade of §12.7
  HeartSceneDef[] heartScenes;   // { tierBoundary, yarnNode, poiWindow, storyConditions }
  string yarnCharacter;          // Line Group prefix for saliency queries
}

NpcRuntimeState {                // saved, per NPC (save-on-sleep, D2)
  int friendshipPoints;
  int heartTier;                 // advances only when the gate scene has played
  bool[] heartScenesPlayed;
  int giftsThisWeek; int lastGiftDay; int lastTalkDay;
  string offscreenLocationId; float routeProgress;
  Dictionary<string,bool> flags; // met, gossip beats, letters sent, preference discoveries
}
```

Validation in CI: no duplicate/missing IDs, every `giftTable` item exists in the item registry, every schedule POI exists in a scene, every heart-scene window intersects the NPC's default schedule ≥3 days/week, per-NPC line counts ≥ tier floor.

---

**Cut order if scope bites** (per [D5](./00-decisions.md) quarterly review): festival dialogue variants → relationship-beat count (8→4) → minor-NPC line counts (never below 80) → *never* the heart-scene budget, and never below 12 scheduled NPCs' schedule fidelity — a smaller cast done fully beats twelve done thinly.

[← Back to Index](./INDEX.md) | [Previous](./11-home.md) | [Next: Time & Seasons →](./13-time-and-seasons.md)
