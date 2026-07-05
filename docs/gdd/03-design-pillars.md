# 3. Design Pillars

[← Back to Index](./INDEX.md) | [Previous](./02-vision.md) | [Next: Inspirations →](./04-inspirations.md)

---

The five pillars are unchanged from the first draft — **Cozy, Wonder, Community, Seasons, Detail** — but a pillar you cannot test is a mood board. Each pillar now carries an **operational bar**: a measurable condition a build either meets or fails. These bars feed the quarterly scope review ([D5](./00-decisions.md)): any system that cannot serve at least one pillar, or that violates any anti-pillar (§3.7), does not ship.

**How to use this document:** when two good ideas conflict, the one that passes more pillar bars wins. Anti-pillars are absolute — they outrank all five pillars and can only be changed by editing [00-decisions.md](./00-decisions.md).

---

## 3.1 Cozy — the player is always safe

**Statement.** Nothing the player values can be lost, failed, or taken away. Tension comes from weather, fog, and "can I reach that?" — never from threat, scarcity pressure, or a clock.

**Why.** This is both the licence's identity (canon has no on-screen predators; all peril is weather and getting lost — [canon research](../research/01-brambly-hedge-canon.md)) and the genre's enforced expectation: the cozy audience punishes deviation hard ([cozy pitfalls §2](../research/09-cozy-pitfalls.md)).

**Operational bar — the soup test.** For every system, ask: *what is the worst thing that can happen to the player here?* The only acceptable answer, anywhere in the game, is being **found, cold, and brought home to soup** ([synthesis §3.05](../research/00-synthesis.md)). Concretely:

- No item, recipe, relationship point, or progress state can ever be lost or reduced (friendship has **no decay**, [D9](./00-decisions.md)).
- No content expires; nothing is missable forever ([D6](./00-decisions.md)). A missed festival moment recurs next year with variants.
- Gentle jeopardy is permitted and encouraged — the drifting raft, the mist on the high bank — but it must always resolve warmly and cost nothing.
- Save-on-sleep with atomic writes and rotating backups ([D2](./00-decisions.md)): the player can also never lose progress to us.

**Build test:** a playtester who walks away from the controller for an hour, mid-game, anywhere, loses nothing and misses nothing permanent.

## 3.2 Wonder — every path leads to something worth stopping for

**Statement.** At mouse scale, small *is* the wonder. One hedgerow strip must feel like a world because every few steps reframes it.

**Why.** Our world is deliberately tiny (30–50 real metres, [D14](./00-decisions.md)); density and composition are what make that a feature rather than a content cliff. Grounded proves a back garden carries 30+ hours when the scale does the work ([synthesis §1.7](../research/00-synthesis.md)).

**Operational bars:**

1. **POI cadence:** a point of interest every **5–10 seconds of walking** in every exterior zone ([D14](./00-decisions.md)).
2. **Landmark discipline:** from any exterior point at default zoom, **≥1 landmark breaks the canopy line**; one mega-landmark is visible from everywhere ([D14](./00-decisions.md)). This substitutes for the minimap we refuse to add.
3. **Verticality:** every hedge "block" is a stacked column — roots → floor → stems → canopy; **no bare ground plane longer than ~5 character-lengths** ([D14](./00-decisions.md)).
4. **Two scale registers, both authored:** diorama tilt-shift at Vista zoom ("what a lovely miniature world") and low "pallet moments" — light shafts through stems — at Near zoom ("I am a mouse") ([D3](./00-decisions.md)).
5. **The book-plate screenshot test:** every playtest build, take 10 random screenshots; the team votes "could this be a book illustration?"; the pass rate is tracked build over build ([D3](./00-decisions.md)).

**Build test:** hand a new player the controller with no objectives; if they are not photographing something within two minutes, the zone fails.

## 3.3 Community — the hedge runs with or without you

**Statement.** The community demonstrably lives: it proposes, schedules, physically works, celebrates, and benefits — with the player, or slightly slower without them. Belonging, not credit, is the reward.

**Why.** This is the design differentiator ([synthesis §5.1](../research/00-synthesis.md)): every 40M+ genre seller makes the player the indispensable hero of a town that cannot act. It is also canon-accurate — the books' undertakings are collective.

**Operational bars:**

1. **The three-layer rule (binding):** every completed community change alters **≥1 NPC schedule + ≥1 function (service, recipe, or traversal route) + ≥1 ambient/visual layer** the next morning ([D7](./00-decisions.md), Function phase). A restoration that changes only how a place *looks* is cut or reworked — cosmetic-only restoration is a documented failure mode ([synthesis §3.11](../research/00-synthesis.md)).
2. **Agency without the player:** projects are NPC-initiated at community meetings; the player *seconds*, never commands; projects complete slightly slower without the player — **but they complete** ([D7](./00-decisions.md)).
3. **Festivals start without you and never freeze time** ([D10](./00-decisions.md)).
4. **Visible labour:** during Contribution and Construction phases, NPCs work witnessed shifts — the player can walk past the sawing and thatching ([D7](./00-decisions.md)). No fill-bars anywhere.
5. **Diffused credit:** every completion moment names NPCs alongside the player ([D7](./00-decisions.md)).
6. **Permanent memory:** every completed project adds **≥3 permanent reactive dialogue lines per involved NPC** ([D9](./00-decisions.md)) — reactivity is cheaper than volume and reads as life ([cozy pitfalls, pitfall 1](../research/09-cozy-pitfalls.md)).

**Build test:** a player who contributes nothing for a full project cycle still sees the project proposed, built, and celebrated — and notices what they weren't part of.

## 3.4 Seasons — same hedge, four books

**Statement.** The world changes the way the four 1980 books change: the same lane, transformed. Seasons are the game's largest content multiplier and its only legitimate timer.

**Why.** Four seasonal re-dressings quadruple one handcrafted space ([synthesis §1.7](../research/00-synthesis.md)); seasonal availability is the sole acceptable form of time pressure ([synthesis §3.10](../research/00-synthesis.md)).

**Operational bars — each season must change all four of:**

1. **Presentation:** its own LUT set (4–5 per season), foliage colormap swaps, and dressing sets ([D4](./00-decisions.md)) — seasons are a data problem, not a rebuild.
2. **Systems:** forage and recipe availability lists ("blackberries only in autumn"); the Store Stump's needs shift with the calendar ([D8](./00-decisions.md)).
3. **People:** NPC schedules and dialogue treat season as a top-level reactivity axis ([D9](./00-decisions.md)).
4. **Story:** one major community project and one festival anchor each season ([D7](./00-decisions.md), [D10](./00-decisions.md)).

**Pacing:** 14 in-game days per season, 6–10 hours each; the season advances **only when the player triggers its festival** — the season valve ([D6](./00-decisions.md)). No real-world clock anywhere.

**Build test:** show a stranger two screenshots of the same location in different seasons — they must identify the season at a glance, and both shots must pass the book-plate test.

## 3.5 Detail — botanical accuracy, not generic cottagecore

**Statement.** Small handcrafted environments beat huge empty maps — and "handcrafted" means *researched*. The bar is Barklem's own: the books were called "the most research-crammed fantasy ever set before small children" ([canon research](../research/01-brambly-hedge-canon.md)).

**Operational bars:**

1. **Botanical accuracy per season:** every hero plant is a real, named hedgerow species rendered in its correct seasonal state — bluebells in spring, meadowsweet in summer, blackberries and rosehips in autumn. **Wrong-season flora count in any zone: zero.** A good field guide (or a botanist playtester) can identify hero flora on sight.
2. **Real food culture:** recipes are built from genuinely forageable hedgerow ingredients, as canon does (primrose puddings, chestnut soup, rosehip jam — [canon research](../research/01-brambly-hedge-canon.md)); the launch recipe list comes from the books' documented dishes ([synthesis §3.10](../research/00-synthesis.md)).
3. **Scale honesty:** the scale-ratio table is honoured everywhere (mouse 10 cm; doors 1.2–1.4×; grass 3–6×; cow parsley 15–20×; gameplay props exaggerated 1.2–1.5×) and **exact sizes are never stated in fiction** ([D14](./00-decisions.md)).
4. **Plate calibration:** art reviews happen side-by-side with scanned Barklem plates ([D4](./00-decisions.md)); the watercolour lives in hand-painted albedo textures, never in animated filters.

**Build test:** pick any screenshot; a reviewer should be able to caption it with month and species, not just "cute forest".

---

## 3.6 Pillar Conflicts

- **Wonder vs Cozy:** wonder may create gentle jeopardy (a high climb, a fog bank) but never a fail state — the soup test wins.
- **Detail vs scope:** detail applies to what ships, not to shipping more. When the quarterly review cuts a system, its detail budget moves to the survivors ([D5](./00-decisions.md)).
- **Community vs player convenience:** if a feature would let the player skip, command, or speed-run the community's own work, Community wins — the waiting *is* the belonging, provided it is measured in in-game days the player can play through, never in real-world time.

## 3.7 Anti-Pillars — hard constraints, not preferences

These seven prohibitions outrank everything above. They exist because each one has a named corpse in the research ([cozy pitfalls](../research/09-cozy-pitfalls.md), [market analysis](../research/08-market-analysis.md)). A feature that touches one is rejected without escalation; only an edit to [00-decisions.md](./00-decisions.md) can change them.

| # | Never | Rule in practice | Evidence |
|---|---|---|---|
| 1 | **No combat** | No damage, no health, no "shoot" verb — not even a cute one | Canon has no on-screen predators; the cozy audience tolerates no shoot verb (Lost Nova postmortem, [market analysis §2](../research/08-market-analysis.md)) |
| 2 | **No money** | No currency, no prices, no shops; the Store Stump contribution economy only ([D8](./00-decisions.md)) | Canon has no money; Stardew's endgame drowns in meaningless millions ([synthesis §5.2](../research/00-synthesis.md)) |
| 3 | **No fail states** | Nothing can be lost, failed, or reduced; gentle jeopardy always resolves warmly | The genre's baseline expectation; the soup test (§3.1) |
| 4 | **No meters** | No stamina, hunger, durability, spoilage, or decay of any kind — including friendship decay ([D9](./00-decisions.md)) | Eastshade cut its meters; Ooblets died by grind-meters ([synthesis §3.10](../research/00-synthesis.md), [cozy pitfalls §2](../research/09-cozy-pitfalls.md)) |
| 5 | **No minimap** | Landmark discipline + diegetic signposting + the Journal restating goals in prose ([D14](./00-decisions.md)); no quest arrows, no completion percentages | The Journal is the UI; checklist-UI recreates FarmVille's "second job" ([cozy pitfalls, pitfall 11](../research/09-cozy-pitfalls.md)) |
| 6 | **No real-time gating** | Daylight and season are the only clocks; no daily caps, no wall-clock waits, no expiring content ([D6](./00-decisions.md)) | Cozy Grove's players revolted and time-travelled by system clock until the devs surrendered ([cozy pitfalls §6](../research/09-cozy-pitfalls.md)) |
| 7 | **No FOMO, ever** | No premium currency, rotating shops, battle-pass structures, or limited-time monetization — at launch or after ([D11](./00-decisions.md)) | One FOMO system permanently reframed Dreamlight Valley as predatory ([cozy pitfalls §6](../research/09-cozy-pitfalls.md)) |

**Trailer test:** if any clip of the game could be mistaken for showing combat, a timer, or a shop, re-cut the clip — and if the *game* caused the mistake, fix the game.

---

[← Back to Index](./INDEX.md) | [Previous](./02-vision.md) | [Next: Inspirations →](./04-inspirations.md)
