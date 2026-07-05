# 9. Gameplay Loop

[← Back to Index](./INDEX.md) | [Previous](./08-visual-identity.md) | [Next: Core Systems →](./10-core-systems.md)

This section defines the shape of a play session, the verb set at 1.0, and the loop that connects the player's small daily actions to the state of the community. It is the contract every other system serves: [core systems](./10-core-systems.md) feed the loop, [community projects](./18-community-philosophy.md) give it a spine, [time and seasons](./13-time-and-seasons.md) give it a horizon.

The loop's one-sentence identity, from [00-decisions](./00-decisions.md) and the [synthesis](../research/00-synthesis.md): *the community demonstrably runs, works, and celebrates with or without you — your reward is belonging, not credit.*

---

## 9.1 The Session Contract

**One in-game day = one session = 20–40 real minutes.** This is a design contract, not an average we hope for. Per [D6](./00-decisions.md), 1 game minute = 1 real second and the clock runs ~06:00–24:00: 1,080 clock seconds ≈ 18 real minutes of unpaused play. Time pauses in dialogue, the Journal, and cutscenes, so a normally-paced day lands at 20–40 real minutes — matching the session-shape target validated across the cozy comps ([cozy quests research §10](../research/06-comps-cozy-quests.md)).

Every in-game day offers, guaranteed at dawn by the day-beat scheduler (§9.6):

| Slot | Count | What it is | Time cost (real) |
|---|---|---|---|
| Story / community beat | 1 | A scene, meeting, proposal, heart-scene, or project-phase event with narrative payload | 3–6 min (paused time) |
| Small favours | 2–3 | Light hand-authored requests from neighbours (deliver, find, gather, cook) | 2–4 min each |
| Project contribution | 1 | One meaningful act toward the active community project (deposit, work shift, errand) | 2–5 min |
| Freeform | unlimited | Gather, cook, wander, climb, sketch, garden, eavesdrop, poke about in dollhouse interiors | player's choice |

Rules on the slots:

- **Nothing expires.** A favour not done today is still there tomorrow (soft exceptions: seasonal forage availability only — see [10.1](./10-core-systems.md)). No slot is ever a daily-capped currency or a wall ([Ooblets/Cozy Grove anti-patterns](../research/06-comps-cozy-quests.md)).
- **The story beat is the "real" reward track.** Favours and contributions are texture; the beat always pays out narrative. Never attach a multi-step chain to zero story ([cozy quests §8](../research/06-comps-cozy-quests.md)).
- **Favours come from a hand-authored pool of ≥60 variants at 1.0**, no repeat within 7 in-game days per NPC — Garden Story's small random pool is the documented failure ([cozy quests §5](../research/06-comps-cozy-quests.md)).
- **Reciprocity within one in-game day**: every completed favour returns something tangible — a doorstep basket, a taught recipe, an opened shortcut, an NPC gathering alongside you next morning ([Spiritfarer's reciprocity loop](../research/06-comps-cozy-quests.md)).
- **The session ends at sleep, and only sleep saves** ([D2](./00-decisions.md)). Sleep runs the overnight simulation: NPC work shifts advance the project, forage nodes respawn, reciprocity gifts are queued to doorsteps, tomorrow's beats are scheduled.

## 9.2 The Day Template — Hour-by-Hour Example

A representative early-autumn day, mid blanket-drive project. Paused-clock segments marked ⏸.

| Clock | What happens | Slot |
|---|---|---|
| 06:00 | Wake in the burrow. The Journal lies open on yesterday's entry: what you did, and two hooks for today ("Flax asked after more wool tufts"; "the meeting at the Palace is at noon"). ⏸ | orientation |
| 06:30 | Doorstep: a cloth-wrapped parcel of blackberry buns from Dusty — thanks for yesterday's flour errand. | reciprocity |
| 07:00–09:00 | Amble along the hedge bank towards the Store Stump; gather blackberries, rosehips, a windfall of chestnuts. Two harvest mice are out picking the same run — they wave. | freeform |
| 09:00 | Store Stump: deposit the chestnuts. Mr Apple, checking shelves, mentions the drive: "Fleece we've nearly enough of. Dyed wool's short." No bar fills; his sentence *is* the progress read-out. ⏸ | project surface |
| 10:00 | **Favour 1** — Mrs Toadflax needs someone to carry a jar of rosehip jam up to Old Mrs Eyebright. The climb to her door is a small balance-run. | favour |
| 12:00 | **Story beat** — community meeting in the Old Oak Palace hall: Mr Apple proposes the expedition date to the High Hills; the player seconds it (never commands). Wilfred begs to come along. ⏸ | beat |
| 14:00 | **Project contribution** — a work shift at the weavers': treadle the loom with Flax while Lily dyes. Two other mice are visibly working the same room on their own schedules. | contribution |
| 16:00 | **Favour 2** — find Wilfred's catapult, lost somewhere along the cornfield edge (his grass-seed shots give it away). | favour |
| 18:00 | Weekly hedgerow supper at the Store Stump — chat with three neighbours, give Primrose the interesting pebble she loves, overhear that Basil has mislaid a cordial recipe *again*. ⏸ dialogue only | chat/gift, attend |
| 20:00–23:00 | Home. Cook chestnut soup at the hearth for tomorrow's deposit; sketch the mill against the dusk from the bank (Lady Daisy asked for exactly this view). | freeform |
| 23:30 | Sleep → save. Overnight: the loom output ticks up from NPC shifts, nodes respawn, Old Mrs Eyebright's thank-you note is queued to the doorstep. | end of day |

Real time: ~18 minutes of running clock + ~8–14 minutes of paused dialogue/Journal ≈ **26–32 minutes**. Skipping every optional slot compresses a day to ~15 minutes; a wallowing freeform day stretches past 40. Both are valid.

## 9.3 The Verb List at 1.0

Six verbs, all Must-tier ([D5](./00-decisions.md)). Everything the player ever does resolves to one of these.

| Verb | Input shape | What it touches | Specced in |
|---|---|---|---|
| **Explore / climb** | move + contextual climb, squeeze, scamper, balance-run (jumping de-emphasised, [D14](./00-decisions.md)) | traversal, camera registers, discovery | [05-world](./05-world.md), [07-camera-direction](./07-camera-direction.md) |
| **Gather** | single interact press on a node; no tools | gathering, seasonal availability, satchel | [10.1](./10-core-systems.md) |
| **Cook** | station interaction, Journal recipe pick, one tactile gesture | cooking, recipes, Store Stump deposits | [10.2](./10-core-systems.md) |
| **Contribute / help** | deposit at the Store Stump, work a project shift, complete a favour | community projects, Store Stump economy | [18-community-philosophy](./18-community-philosophy.md), [14-quests](./14-quests.md) |
| **Chat / gift** | talk (+20/day), give (2 gifts/week cap, no decay — [D9](./00-decisions.md)) | relationships, hearts, heart-scenes | [12-npcs](./12-npcs.md) |
| **Attend** | show up; events start without you and never freeze time ([D10](./00-decisions.md)) | festivals, meetings, suppers, ceremonies | [13-time-and-seasons](./13-time-and-seasons.md) |

Sub-verbs that reuse these inputs rather than adding new ones: **gardening** = gather + time (Should), **fishing** = gather at water's edge (Could), **sketching** = attend-to-a-view via the Journal (Could, [D13](./00-decisions.md)). See [10.4–10.6](./10-core-systems.md).

Deliberately absent verbs: fight, buy, sell, grind. There is no combat anywhere in canon ([canon bible](../research/01-brambly-hedge-canon.md)) and no money anywhere in the design ([D8](./00-decisions.md)).

## 9.4 The Loop, Routed Through Community State

The old fetch-loop ("receive request → gather → hand in → repeat") is replaced. Every cycle now writes into, and reads back out of, a single shared blackboard: **community state** — active project phase, Store Stump stock, NPC schedules, festival readiness, and the season valve.

```
                    ┌─────────────────────────────────────────┐
                    │            COMMUNITY STATE              │
                    │  project phase · Store Stump stock ·    │
                    │  NPC schedules · festival readiness ·   │
                    │  season valve ([D6],[D7])               │
                    └────────▲────────────────────┬───────────┘
              player + NPC   │                    │  world writes back:
              inputs         │                    │  new access, recipes,
                             │                    │  schedules, dialogue
              ┌──────────────┴──────┐    ┌────────▼─────────────┐
              │ CONTRIBUTE & ATTEND │    │ DISCOVER & HEAR      │
              │ deposit · shift ·   │    │ beats · proposals ·  │
              │ favour · festival   │    │ favours · gossip ·   │
              │                     │    │ new places opened    │
              └──────────▲──────────┘    └────────┬─────────────┘
                         │                        │
              ┌──────────┴──────────┐    ┌────────▼─────────────┐
              │ PREPARE             │◄───┤ PLAN                 │
              │ gather · cook ·     │    │ Journal hooks ·      │
              │ craft · garden      │    │ tomorrow's intent    │
              └─────────────────────┘    └──────────────────────┘
```

Two properties make this loop different from every comp ([community sims research §6](../research/03-comps-community-sims.md)):

1. **NPCs write to the same blackboard.** Their scheduled work shifts advance projects; their deposits raise Store Stump stock; their proposals create beats. Projects complete slightly slower without the player — *but they complete* ([D7](./00-decisions.md)). Walking past the sawing and thatching is content.
2. **The write-back is functional, never cosmetic.** Every completed project changes ≥1 NPC schedule + ≥1 service/recipe + ≥1 ambient/visual layer ([D7](./00-decisions.md); Garden Story's cosmetic-only restoration is the documented failure — [cozy quests §5](../research/06-comps-cozy-quests.md)). Progression = community state + relationships + traversal access + Journal completion. No XP, no levels, no ratings.

## 9.5 Nested Loops

| Loop | Duration | Atom | Payoff |
|---|---|---|---|
| Minute | 10 s – 2 min | one verb: pick a berry, climb a stem, one line of chat | tactile charm; a composed frame ([D3](./00-decisions.md)) |
| Day | 20–40 real min | the session contract (§9.1) | Journal entry written; reciprocity lands tomorrow |
| Project | 5–8 in-game days | five phases: Proposal → Contribution → Construction → Celebration → Function ([D7](./00-decisions.md)) | permanent functional change; traversal opens |
| Season | 14 in-game days ([D6](./00-decisions.md)) | 1 major project + story beat → festival unlocked → **player triggers the season valve** | new palette, new forage, new dressing — "same hedge, four books" |
| Year | ~25–35 hours | 4 seasons + the *Poppy's Babies*-style secret refurbishment climax | belonging; year two stays ≥20% novel ([21-long-term-vision](./21-long-term-vision.md)) |

The season valve is the top-level pacing device: seasons advance only when the player holds the festival ([Wylde Flowers' most-praised pattern](../research/06-comps-cozy-quests.md)). Nobody is ever rushed out of a season they are enjoying.

## 9.6 The Pacing Rule: Accomplished Today, Anticipating Tomorrow

The loop's emotional target is Cozy Grove designer David Edery's formulation — "you've accomplished something today and have something to look forward to tomorrow" — **without its hard wall** ([cozy quests §1](../research/06-comps-cozy-quests.md)). Cozy Grove enforced anticipation with a real-time lockout and earned a forum revolt; we enforce it with content structure on in-game days.

Operationally, the **sleep-screen test**: the end-of-day Journal entry must always render both halves —

- **Accomplished** — ≥1 concrete thing recorded in prose ("Helped Flax at the loom; the pile of blankets is growing").
- **Anticipating** — ≥1 visible tomorrow-hook ("Mr Apple expects the dye delivery in the morning"; "the first frost can't be far off").

The **day-beat scheduler** guarantees this is never vacuously false. At each dawn it must be able to seed: 1 available story/community beat (or an active project phase event), 2–3 favours from the pool, and 1 contribution opportunity. If the anticipation list would be empty (e.g. between projects), the scheduler queues a hook overnight — a letter under the door, an NPC trailing a rumour, a seasonal forage note ("the blackberries are nearly over"). An empty sleep screen is a shippable bug, tracked like a crash.

Anticipation sources, in priority order: project phase advancing overnight → promised reciprocity → approaching festival/ceremony → seasonal forage window opening or closing → relationship hook (an NPC "had something to ask you").

## 9.7 What Is Deliberately Absent — and Why the Loop Still Pulls

Per [D6](./00-decisions.md)/[D8](./00-decisions.md) and the anti-pillars in [03-design-pillars](./03-design-pillars.md), the loop contains **no fail states, no stamina/hunger meters, no money, no XP or player levels, no quest-log checklists or progress bars, no real-time gating, no expiring content**. Each absence is a lesson paid for by a comp:

| Absent | Comp evidence | What replaces the pull it provided |
|---|---|---|
| Fail states | Canon: worst outcome is "found, cold, and brought home to soup" ([canon bible §8](../research/01-brambly-hedge-canon.md)) | Gentle jeopardy — fog, storms, a drifting raft — resolved by community, not retry screens |
| Stamina/hunger meters | Eastshade cut its survival bars ("entirely at odds with how we wanted the game to feel"); Ooblets died by meters ([cozy quests §4, §6](../research/06-comps-cozy-quests.md)) | Daylight and season are the only clocks; the day ends because it is *night*, not because a bar emptied |
| Money | Stardew's meaningless year-3 millions; ACNH's loan grind ([community sims §3, §2](../research/03-comps-community-sims.md)) | The Store Stump contribution economy: what you deposit visibly provisions festivals and winter ([D8](./00-decisions.md)) |
| Real-time gating | Cozy Grove's "come back tomorrow" revolt; ACNH's 2021 drought backlash ([both research docs](../research/03-comps-community-sims.md)) | In-game days the player paces; the season valve |
| Quest-log UI | The checklist trap makes cozy games a second job ([14-quests](./14-quests.md), [17-ui-philosophy](./17-ui-philosophy.md)) | Journal prose restates goals; Mr Apple's sentences are the progress bar |

Why the loop still pulls — the four engines of "one more day":

1. **Seasonal scarcity, the only soft timer.** "Blackberries only in autumn" creates gentle urgency with zero punishment; missing a window costs a season, never content ([10.1](./10-core-systems.md)).
2. **The anticipation ledger** (§9.6). Something concrete is always arriving tomorrow, and the player knows it at the sleep screen.
3. **Narrative as loot.** Beats, heart-scenes, gossip, and diary pages pay out story on a reliable cadence — the Cozy Grove lesson that players do chores happily when the story track is clearly the real reward.
4. **Witnessable momentum.** Scaffolding rises, thatch appears, NPC shifts happen on-screen; the world is visibly mid-sentence when you sleep, and you want to see the next word.

## 9.8 Testable Rules (build acceptance)

1. A full day with all slots taken completes in ≤40 real minutes at default clock speed; a minimal day in ≥15.
2. The sleep screen always shows ≥1 accomplishment and ≥1 anticipation line — automated check on the Journal entry generator.
3. No favour, beat, or contribution opportunity ever expires (seasonal forage availability is the sole soft exception, and it returns next year).
4. Every completed favour produces a tangible give-back within 1 in-game day — validated per favour variant in the favour-pool spreadsheet.
5. Favour pool ≥60 hand-authored variants at 1.0; no identical favour within 7 in-game days per NPC.
6. During any project Contribution/Construction phase, ≥2 NPCs are visibly working on-site at some point of every in-game day.
7. Zero UI elements display a percentage, fill-bar, or checklist for community progress.

---

The community-project spine this loop routes through is specced in [18-community-philosophy](./18-community-philosophy.md); the systems that feed it are next.

[← Back to Index](./INDEX.md) | [Previous](./08-visual-identity.md) | [Next: Core Systems →](./10-core-systems.md)
