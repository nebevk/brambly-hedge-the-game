# 18. Community Philosophy

[← Back to Index](./INDEX.md) | [Previous](./17-ui-philosophy.md) | [Next: Technical Direction →](./19-technical-direction.md)

> **You don't build your empire. You build the community.**

This section is the doctrine behind the game's primary design differentiator. It is not a system spec — the community project system is specified in [Quests](./14-quests.md), NPC schedules and dialogue in [NPCs](./12-npcs.md), festivals and the season valve in [Time & Seasons](./13-time-and-seasons.md), and the contribution economy in [Core Systems](./10-core-systems.md). This document defines *why* those systems are shaped the way they are, and the binding acceptance criteria they must pass. Where this section and [00-decisions.md](./00-decisions.md) (D7–D10) state a number, the number is binding.

**The identity sentence, locked:** *the first cosy sim where the community demonstrably runs, works, and celebrates with or without you — your reward is belonging, not credit.*

---

## 18.1 The Core Idea

Most cosy games sell a hero fantasy in soft colours: the town is broken until you arrive, the projects wait for your hand, the festival cannot begin until you walk through the gate. We sell a different fantasy — one the genre has never shipped at scale — the fantasy of **being welcomed into a community that was already whole**.

The player is a newcomer mouse who moves into the hedge and must find their place (per D9 — **⚠ DEFAULT — owner to confirm**). They are one pair of paws among many. The hedge got on fine before they arrived and would get on fine without them; what the player earns, hour by hour, is not power over the world but a *place in it* — a seat at the supper table, a name in the toast, a standing invitation to tea.

This is not a softer version of the genre's reward loop. It is a different reward loop, and it must be delivered mechanically, not through writing alone. Every rule in §18.4 exists to make the sentence "the community works with or without you" *observably true* on screen.

## 18.2 Why This Design Space Is Unoccupied

The [community-sims research](../research/03-comps-community-sims.md) examined the genre's three landmark titles and found the same architecture in all of them: **the player is the indispensable hero of a town that cannot act on its own.**

| Game | Scale | How the player-hero framing shows |
|---|---|---|
| **Animal Crossing: New Horizons** (2020) | 49.9M units | Player is "Resident Representative" with sole building and terraforming authority; the island *rating* grades the player's decorating; villagers cannot move a fence; the K.K. Slider concert is a monument to the player's project management. |
| **Stardew Valley** (2016) | 41M+ units | The town decays until the farmer arrives; *only the player* can fill Community Center bundles — villagers never contribute one item; the completion ceremony celebrates the player; festival time literally freezes until the player shows up; Grandpa's ghost grades your life. |
| **Palia** (2023) | $49M VC raised | Every player is simultaneously told they are "the returning human of legend" — the multiplayer context breaks the spell and exposes how thin the trick was ("it's hard to feel special when multiple players are being told the same things"). |

Three corroborating facts make the inversion not just unoccupied but *wanted*:

1. **The loudest complaints in every comp are hollow-community complaints**: repetitive archetype dialogue (ACNH), post-max-heart dialogue loops and villagers who never acknowledge your wedding (Stardew), relationship systems that hard-stop (Palia), festivals that rerun identically until the calendar becomes "proof the world is a music box, not a place" (ACNH 2021 backlash). Players notice the puppet strings and resent them.
2. **The genre's own ancestor did it our way.** The original Animal Crossing (2001) was designed by Eguchi as a village that ran on its own clock, where villagers moved away while you were absent — attachment was real *because it could be lost*. Critics argue the series abandoned exactly this. We walk through the door it left open (gently — see §18.7: we borrow the autonomy, never the loss-as-punishment).
3. **It is defensible.** Community autonomy is a *content-shape* choice — NPC work-shift schedules, proposal scenes, diffused-credit lines — cheap-ish to build at our cast size (12 scheduled NPCs, D9) and effectively impossible to patch into a shipped player-hero game, because every quest, festival, and ceremony in those games is authored around the player's presence. A 40M-seller cannot retrofit this; we can build it from line one.

And it is **canon-accurate** (§18.5): in Barklem's books there are no heroes, only neighbours.

## 18.3 The Inversion Table

The old two-column contrast, now with the mechanical commitments that make each row true. Every "ours" cell is implemented by a named system and tested by a rule in §18.4.

| Typical cosy game | Brambly Hedge: The Game | Mechanical specifics (ours) |
|---|---|---|
| World revolves around the player | Player is one equal member of ~12 scheduled households' worth of neighbours | NPCs run full daily/seasonal schedules whether observed or not ([NPCs](./12-npcs.md)); the player has no authority verbs — no placement, zoning, or command of NPCs |
| Projects come from a quest board or mayor's checklist | Projects are proposed by NPCs at community meetings; the player **seconds, never commands** | Proposal phase (D7) is a scene: a named NPC raises the idea, others respond, the player may second it; at least once in year one the community adopts a project the player did *not* second (Rule R2) |
| The player alone fills the bundles | Contribution is genuinely shared | NPC work shifts are scheduled and visible on-site (Rule R3); thresholds are soft and prose-stated ("about twelve bundles of reeds"), never fill-bars (D7) |
| Festival time freezes until the player arrives | Festivals start on time, with or without you | No time freeze, ever (D10); arrive two hours late and the dance is mid-song (Rule R5) |
| Completion ceremony celebrates the player | Credit is diffused by design | The completion moment names **at least three NPCs and the player**, drawn from the actual contribution ledger (Rule R4) |
| Progression = XP, levels, town ratings | Progression = community state + relationships + traversal opened by projects | No player levels or ratings anywhere ([Progression](./15-progression.md)); the repaired bridge, the mill-wheel lift, and NPC-rigged ropes open the map (D7) |
| Money economy; helping pays wages | Store Stump contribution economy; no money, no shops | Deposits of foraged/cooked goods gate festivals and winter comfort for *everyone* (D8, §18.8) |
| Restoration is cosmetic | Every community change is functional | ≥1 schedule change + ≥1 service/function change + ≥1 ambient change, live the next morning (Rule R1) |
| Friendship decays if unattended; the town emits guilt | No decay, no reproach | Friendship never decays (D9); NPC lines may never scold the player for absence (Rule R7) |
| The world waits, inert, for the player's input | The world advances slightly slower — but surely — without the player | NPC-only project pace is a tuned fraction of with-player pace; every project completes even with zero player contribution (Rule R6) |

## 18.4 The Testable Rules (binding)

These are acceptance criteria. A build that fails one of these fails review, exactly as a build that drops below 60 fps fails D2. Each rule has an operational test a playtester or QA script can run.

**R1 — The Functional-Change Rule.** Every completed community project changes, by 06:00 the next in-game morning: **(a)** ≥1 NPC schedule (a new route, shift, or location in the schedule data), **(b)** ≥1 function available to the player or community (a service, recipe, traversal route, or Store Stump stock line), and **(c)** ≥1 ambient/visual layer (dressing set, soundscape, lighting, path traffic). *Test:* per-project QA checklist with the three boxes; a project that ticks two of three does not ship. (Anti-pattern: Garden Story's "almost entirely aesthetic" rebuilding — the most cited flaw in [cozy-quest research](../research/06-comps-cozy-quests.md).)

**R2 — The Proposal Rule.** No community project may enter its Contribution phase from a menu, board, or player-initiated dialogue option. Each begins as an NPC-voiced proposal at a community meeting (Store Stump or Old Oak Palace); the player's maximum agency is to **second** a proposal or express a preference between two. At least one project in year one proceeds against or without the player's expressed preference. *Test:* trace every project's start trigger in data — the trigger must be a meeting-scene node, and the year-one content plan must contain the "outvoted" beat.

**R3 — The Visible-Labour Rule.** During the Contribution and Construction phases (2–4 and 2–3 in-game days respectively, D7), every participating NPC has ≥1 scheduled work shift per in-game day at the project site, with a readable work animation (sawing, thatching, carrying, weaving) that runs whether or not the player interacts. Scaffolding, part-built structures, and material piles are staged visibly between days — diegetic progress, never an opaque countdown. *Test:* stand at the site from 08:00 to 18:00 game-time without interacting; you must witness ≥2 different NPCs working, and the site must look different from yesterday.

**R4 — The Diffused-Credit Rule.** Every project-completion moment (the celebration toast, the journal entry, the plaque line if any) names **at least three NPCs and the player**, selected from the contribution ledger (§18.6) weighted by logged work — never from a hard-coded list. The player is named *among*, not *above*. *Test:* complete the same project in two saves with different NPC shift participation → the named NPCs differ; complete it with zero player contribution → at least three NPCs are named and the player is warmly welcomed as a guest instead.

**R5 — The Festivals-Start-Without-You Rule.** Every festival begins at its scheduled hour and proceeds on the game clock; time never freezes during festivals (D10). A late player arrives mid-event: the soup is half-eaten, the dance mid-song, and dialogue acknowledges the event in progress, not the player's entrance. *Test:* arrive 2 game-hours late; verify elapsed event stages and no "waiting for you" state anywhere in the festival FSM.

**R6 — The World-Moves-Without-You Rule.** Projects progress on NPC labour alone at a tuned fraction of the with-player pace — **tuning default: 60–75% of full pace, and no phase may extend beyond +50% of its nominal duration** — so a wholly ignored project still completes within its season. Nothing ever stalls waiting for a player deposit. On returning after ≥2 in-game days away from the village core, ≥1 NPC line reports what happened in the player's absence ("we got the last of the reeds in on Tuesday") — as news, never as reproach. *Test:* automated soak — run a full season contributing nothing; every project must complete, the festival must fire, and the absence lines must trigger.

**R7 — The No-Guilt Rule (writing-side, enforced in review).** No NPC line, journal entry, or system message may condition *negatively* on player inactivity, absence, or refusal. Absence is referenced only as neutral or warm news. There is no reputation meter, no approval score, no disappointment state (§18.7). *Test:* dialogue-database query — every line whose conditions include player-absence flags is reviewed against the writing guide; forbidden tones fail review.

**R8 — The Reciprocity Rule.** Every completed favour or project contribution returns something tangible to the player within one in-game day: a doorstep gift, a taught recipe, an NPC who gathers alongside you, a shortcut opened ([cozy-quest research](../research/06-comps-cozy-quests.md), Spiritfarer's proven loop). Belonging must *give back*, or it reads as unpaid labour. *Test:* per-favour content checklist; the give-back is authored, not random.

**R9 — The Prose-Not-Progress Rule.** Community state is communicated in world detail and journal prose — never percentages, fill-bars, or checklists ([UI Philosophy](./17-ui-philosophy.md)). "About twelve bundles of reeds, Mr Apple reckons" is a quantity; a progress bar is a spreadsheet. *Test:* UI audit — zero numeric or bar-shaped progress widgets attached to any community system.

## 18.5 Canon Grounding: Every Book Is a Collective Undertaking

This philosophy is not imposed on the licence — it is extracted from it. Per the [canon bible](../research/01-brambly-hedge-canon.md), Barklem's hedge has **no money economy and no player-style heroes**: surplus is shared through the Store Stump (Mr Apple, warden), everyone has a trade, and every plot resolves through mutual aid. All eight books turn on a communal effort:

| Book | The collective undertaking | What our system borrows |
|---|---|---|
| *Spring Story* | The whole hedge secretly organises Wilfred's surprise birthday picnic at Bluebell Bank | The secret, community-planned celebration; the spring picnic project (D7) |
| *Summer Story* | The community builds and decorates the wedding raft; the whole hedge feasts | The Midsummer wedding raft project; contribution-format festivals |
| *Autumn Story* | All mice race the rain to fill the Store Stump; the community mounts the search for Primrose | Harvest contribution drives; the search-party template — rescue is communal, not heroic |
| *Winter Story* | The Ice Hall is built "in the time-honoured way" by the whole hedge for the Snow Ball | The winter Ice Hall project; construction as tradition, witnessed and shared |
| *The Secret Staircase* | The hedge prepares Midwinter's Eve at the palace: the log hauled together, the grand entertainment performed *by the mice themselves* | Festivals with NPC performers — the entertainment does not centre the player |
| *The High Hills* | Flax and Lily weave overtime; Mr Apple delivers blankets to the poorer voles | The autumn blanket drive; the strong provisioning the weak as a project motive |
| *Sea Story* | Four mice sail the Periwinkle to fetch salt *for the whole hedge* | Scarce-import expeditions justified by community need, not personal profit |
| *Poppy's Babies* | The entire community secretly refurbishes Mayblossom Cottage, revealed on Naming Day | The year-one emotional climax (D7): the community's gift to one of its own — and the player is one of many keeping the secret |

Note the shape of *Poppy's Babies* especially: the recipients are NPCs, the givers are the whole community, and the reveal is a ceremony. That is our endgame emotion — and no player-hero game can produce it.

**Licence note (D1):** the *philosophy* in this section is entirely rename-safe — collective undertakings, contribution economy, diffused credit survive any renaming untouched. The specific names above (Store Stump, Mr Apple, Mayblossom Cottage) are canon-layer and live behind the localisation/data layer like all names.

## 18.6 Making Belonging Mechanically Legible

"Belonging" fails as a pillar if it is only a mood. It must arrive as **discrete, authored signals the player can notice, screenshot, and remember**. These are the signals, with their triggers; volumes are bound by D9's dialogue budget.

| Signal | Trigger | Implementation |
|---|---|---|
| **Greeted by name** | Friendship ≥1 heart (250 pts) with that NPC | Greeting line-pool swaps from polite-stranger to by-name pool; first by-name greeting is an authored micro-beat |
| **Referenced contributions, permanently** | Each completed project | ≥3 permanent lines per involved NPC (D9) that cite the project *and*, where the ledger allows, the player's specific act ("that wool you hauled up from the field margin wove true") |
| **A seat at the supper** | First project completed | The weekly hedgerow supper (D9) gains a place laid for the player; NPC-to-NPC life is watchable there whether or not the player attends |
| **Standing invitations** | Max hearts with an NPC | A recurring, no-pressure invitation (tea at Crabapple Cottage, a walk to the weir) — the post-max content stream that keeps maxed friendships *settled, not dead* |
| **Seasonal letters** | Max hearts; each season turn | ≥1 letter per maxed NPC per season, referencing current world state |
| **Doorstep reciprocity** | Any completed favour | Rule R8's tangible return within one in-game day |
| **Absence as news** | ≥2 in-game days away | Rule R6's "here's what happened" lines — the world proves it moved, warmly |
| **Journal as memory** | Continuous | The journal ([UI Philosophy](./17-ui-philosophy.md)) records contributions as prose alongside NPC gossip — the player's story interleaved with the hedge's, never a completion tracker |

### Data-model sketch: the Contribution Ledger

One small structure powers diffused credit (R4), permanent dialogue (above), and journal prose. Sketch, not final schema:

```yaml
ContributionLedger:
  projectId: autumn_blanket_drive
  entries:
    - { actor: npc.weaver_a, task: weave_blankets, day: 34, shifts: 3 }
    - { actor: npc.weaver_b, task: weave_blankets, day: 34, shifts: 3 }
    - { actor: npc.warden,   task: pack_hampers,   day: 36, shifts: 2 }
    - { actor: player,       task: carry_wool,     day: 33, shifts: 1 }
  onComplete:
    creditToast: ≥3 distinct npc actors weighted by shifts, + player  # R4
    setFlags:
      - project_complete.autumn_blanket_drive                        # dialogue axis (D9)
      - player_helped.autumn_blanket_drive.carry_wool                # per-act memory
    journalEntry: prose template referencing top entries by name     # R9
```

Dialogue conditions off these flags via Yarn Spinner line groups (per [NPCs](./12-npcs.md)); a line like Flax's wool-hauling thank-you above carries `when: player_helped.autumn_blanket_drive.carry_wool` and lives in the permanent pool forever after.

## 18.7 Boundary Conditions — What This Is NOT

The inversion has a failure mode: a community that acts without you can curdle into a community that *judges* you. We forbid that outright. This is **not a social-pressure sim**.

- **No reputation meter, no approval score, no town rating.** Community standing is never a number, visible or hidden-but-datamineable. If the hedge has an opinion of you, it is expressed diegetically, one NPC at a time, and it is always somewhere between polite and loving.
- **No disappointment states.** NPCs never scold, sulk, or cool toward the player. Friendship has no decay (D9 — Stardew's −2/day is the most resented number in the genre). A festival missed is a festival you hear warm stories about, never one you "failed".
- **No guilt mechanics.** No expiring content, no daily obligations, no "the voles went cold because you didn't help" (D6: no fail states, no expiring content). Projects cannot fail; the player's contribution enriches and accelerates, but the safety net is the community itself — which is precisely the theme.
- **No moral grading.** No Grandpa's-ghost evaluation, no virtue scores, no Joja-style temptation mirror. The worst outcome in this game, as in the books, is being *found, cold, and brought home to soup*.
- **Autonomy is a gift, not a competition.** The community never outpaces the player in a way that removes content: the player can always join any active phase, and the give-backs (R8) scale with participation, so playing more is always warmer — just never *required*.

Operationally (folds into R7): any proposed mechanic that makes a playtester say "I feel bad for not logging in" is cut in review, whatever else it does.

## 18.8 Relationship to the No-Money Economy

The Store Stump economy (D8) is not an adjacent feature — it is this philosophy made material. Money would quietly re-centre the hero:

- **Wages individualise; contribution communalises.** The moment helping pays coin, the wedding raft becomes *your* transaction; the toast in R4 becomes absurd. Deposits into a shared store keep every contribution pointed at the same pot everyone eats from.
- **Money creates the genre's proven late-game failure.** Stardew's year-3 players sit on meaningless millions with no sinks ([community-sims research](../research/03-comps-community-sims.md)); ACNH ends in loan-grinding. A contribution economy's "endgame" is a full larder before winter — which resets meaningfully every year.
- **It is canon.** The books have no currency at all; surplus flows through the Store Stump and favours flow between households ([canon bible](../research/01-brambly-hedge-canon.md)).
- **Mixed provenance is visible.** Store Stump shelves display who contributed what — Mrs Apple's rosehip jam beside your blackberry buns beside Basil's cordials — so the stockroom itself is a portrait of the community, not a player inventory. NPC deposits appear on NPC schedules (R3 applies to provisioning shifts during harvest drives).
- **Scarcity motivates stories, not grinding.** What the hedge cannot make (salt), it fetches — the *Sea Story* expedition template — so the only "shopping trip" in the game is an adventure undertaken for everyone.

## 18.9 Emotional Target

Players should return to the game simply because it feels like home — not because a checklist is unfinished, but because **they want to know whether the blackberries ripened in time for the autumn festival.**

That sentence is the acceptance test for this entire section, and it is measurable. In every external playtest from the vertical slice onward (per [MVP](./20-mvp.md) and the G2 gate), the exit survey asks two questions:

1. *"Why would you come back tomorrow?"* — target: a majority of answers name the world, an NPC, a season, or an upcoming event, rather than an unfinished task.
2. *"Did the hedge feel like it needed you, or like it welcomed you?"* — target: **welcomed**, by a wide margin. If playtesters say *needed*, we have drifted back toward the hero fantasy and this document has been violated somewhere; find where.

The books never once made the reader indispensable. They made the reader *at home*. So must we.

---

[← Back to Index](./INDEX.md) | [Previous](./17-ui-philosophy.md) | [Next: Technical Direction →](./19-technical-direction.md)
