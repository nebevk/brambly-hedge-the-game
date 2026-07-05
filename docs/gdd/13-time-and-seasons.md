# 13. Time & Seasons

[← Back to Index](./INDEX.md) | [Previous](./12-npcs.md) | [Next: Quests →](./14-quests.md)

Time is the game's only pressure and its only clock. There are no fail states, no stamina or hunger meters, no real-world-clock gating and no expiring content ([D6](./00-decisions.md)). Daylight decides what today feels like; the season decides what the hedge is. Everything below is binding unless [00-decisions.md](./00-decisions.md) says otherwise.

## 13.1 The Clock

| Parameter | Value | Source |
|---|---|---|
| Time scale | **1 game minute = 1 real second** | D6 |
| Day span | **06:00–24:00** (1,080 game minutes = 18 real minutes of running clock) | D6 |
| Effective day length | **~20–30 real minutes** once pauses (dialogue, journal, scenes) are included — the "~20-minute day" | D6 |
| Display resolution | **10-minute ticks** (06:00, 06:10, 06:20…); internal resolution 1 minute | D6 |
| Speed constant | `TimeService.RealSecondsPerGameMinute = 1.0` — the **one** place speed lives ([19-technical-direction.md §19.7](./19-technical-direction.md)) | D6 |
| Unhurried mode | Options toggle, sets the constant to **~1.43 real seconds per game minute** (≡ 0.7 game-minutes per real second — a *slower* clock; ~26 real minutes of running clock per day). No other system may know or care which mode is active | D6 |

There is no midnight-oil mechanic and no penalty clock. Stardew's 14m20s day is the proven session atom ([community sims research](../research/03-comps-community-sims.md)); ours runs slightly longer because this game asks players to *look* — the camera is the point.

### The week

A season is **14 in-game days = two 7-day weeks**. Day-of-week is pure arithmetic, never stored: `dayOfWeek = ((DayOfSeason − 1) mod 7) + 1`. Therefore **Day 3 and Day 10 fall on the same weekday** — the Hedgerow Supper day (13.2, 13.4). That derived day-of-week is the value the `<season>_<dayOfWeek>` NPC schedule cascade key resolves ([12-npcs.md §12.7](./12-npcs.md)); it is the only week structure the game defines — there are no named weekdays.

### Pause states

Time **pauses** during:

- Dialogue (any conversation, including barks that open into exchanges)
- The Journal (all spreads — map, recipes, notes, sketching)
- Cutscenes, heart-scenes and community-meeting scenes
- Photo mode / sketch composition
- The system menu

Time **never pauses** during:

- Festivals and celebrations — they start at their scheduled hour and run whether the player is present or not ([D10](./00-decisions.md)); arrive late and the dance is mid-song
- Ordinary play, weather, NPC labour shifts

### End of day and sleep

- The player may sleep in their own bed (see [11-home.md](./11-home.md)) at any hour after 18:00.
- **Sleep is a simulated fast-forward, not a time-lapse.** No per-minute ticks fire; the game runs one discrete overnight resolution pass (order below), then wakes the player at 06:00.
- If the clock reaches 24:00 in the open world, the screen fades gently — *"A neighbour saw you home."* — and the same overnight pass runs. No item loss, no fee, no scolding. It is narratively a kindness, not a punishment.
- **Autosave happens on sleep and only on sleep** (atomic write, rotating backups, [D2](./00-decisions.md)). There is no manual save; a day is the unit of play.

**Overnight resolution pass (fixed order, deterministic):**

1. End-of-day events resolve: community-project goals receive their NPC labour units for the day ([14-quests.md](./14-quests.md)); Store Stump ledger updates.
2. Date increments (`DayOfSeason` and `TotalDaysElapsed` advance; `MinuteOfDay` resets to 06:00 — [§19.7](./19-technical-direction.md)).
3. Tomorrow's weather is rolled (or taken from an authored override — see 13.5).
4. Growth/respawn pass: gathering nodes, garden beds, seasonal set-dressing deltas.
5. Reciprocity deliveries spawn: doorstep gifts, letters, taught-recipe journal entries owed from yesterday's favours ([14-quests.md](./14-quests.md)).
6. NPC schedules are assigned for the new day (season × day × weather × project flags cascade, [12-npcs.md](./12-npcs.md)).
7. Autosave.
8. `EC_DayStarted` fires; the Journal opens on a fresh day page.

## 13.2 Day Phases

Phase boundaries are fixed on the clock; **lighting shifts by season** (13.4) so winter evenings *feel* early without breaking schedule predictability.

| Phase | Clock | Light & mood | What changes |
|---|---|---|---|
| **Dawn** | 06:00–08:00 | Pale gold, long shadows, dew sparkle | Dew-only forage (snails, dew-water, night-closed flowers opening); NPCs at breakfast, kitchens lit; birdsong peak |
| **Morning** | 08:00–12:00 | Clear, high saturation | Work shifts begin; Store Stump staffed; deliveries and most favour offers happen here |
| **Afternoon** | 12:00–17:00 | Warm, softest shadows | Community-project labour shifts on-site (the witnessed sawing and thatching); prime gathering; children playing outdoors |
| **Evening** | 17:00–21:00 | Amber, lamps and candles lit window by window | Suppers; the Hedgerow Supper (Day 3 and Day 10 of each season — the same weekday, 13.1; Store Stump hall, 18:00–21:00 — the community-meeting venue, [D9](./00-decisions.md)); social favours |
| **Night** | 21:00–24:00 | Blue hour; fireflies (summer), moths, candlelit dollhouse windows | Most NPCs home (visible through cutaways); quiet exploring; moth/night forage; soft sleep prompt from 22:00 |

Each phase change fires TimeService's `PhaseChanged` — the hook for lighting/LUT blends, ambience beds and mixer snapshots ([16-music-and-audio.md](./16-music-and-audio.md)), and schedule keyframes.

## 13.3 Seasons and the Season Valve

- A season is **14 in-game days** ([D6](./00-decisions.md)). Fourteen 18-minute days plus paused time and festival days lands each season at the target **6–10 hours**; year one ≈ **25–35 hours**.
- **A season advances only when the player triggers its seasonal festival** — the **season valve** (D6, proven pattern: Wylde Flowers' player-performed season ritual, praised precisely for pressure-free pacing — [cozy quest comps](../research/06-comps-cozy-quests.md)).
- The festival unlocks once that season's **community project + story beat** are complete (paced to land around Day 9–12 in playtests). The lead mouse then asks the player to set the date — diegetically a courtesy ("we'd not hold it without you"), mechanically the valve. **Once the date is set, the festival begins at its hour with or without the player** (D10).
- The season turns on the **morning after** the festival concludes (the project's Function morning — see [14-quests.md](./14-quests.md)).
- If Day 14 passes without the festival: the calendar simply shows **"Late Spring — Day 15, 16…"**. Weather and dialogue take on a lingering, expectant cast; NPCs gently mention looking forward to the picnic. Nothing expires, nothing is lost, nothing advances without the player's word. Ever.

Consequence for architecture: **the season is *not* derivable from the day number.** It is state, advanced only by the valve (13.7).

### Festival tiers at 1.0

Per [D10](./00-decisions.md), two festivals are **full** at 1.0 (contribution formats, 2–3 state-reactive variants, spectacle beats); the other two seasonal celebrations ship as **celebration set-pieces** (scene-scale, still the season valve) and are upgraded to full festivals in free post-launch updates. ⚠ DEFAULT — owner to confirm (which two are full; the wedding is the strongest emotional set-piece but raises 1.0 cost).

| Season | Season-valve celebration | 1.0 tier |
|---|---|---|
| Spring | **The Picnic at Bluebell Bank** (Wilfred's surprise birthday picnic, canon *Spring Story*) | **Full festival** |
| Summer | **The Midsummer Wedding** on the raft (canon *Summer Story*) | Celebration set-piece (full festival post-launch) |
| Autumn | **Harvest Home supper** (homecoming from the High Hills expedition) | Celebration set-piece |
| Winter | **Midwinter's Eve** at Old Oak Palace + lantern walk to the Ice Hall (canon *The Secret Staircase* / *Winter Story*) | **Full festival** |
| Winter (floating, post-launch) | **The Snow Ball** in the Ice Hall — occurs only in deep-snow winters (canon-conditional rare event) | Post-launch update |

## 13.4 The Year-One Calendar

The structure below is rename-safe; the names are canon layer ([D1](./00-decisions.md)). All canon facts from the [canon bible](../research/01-brambly-hedge-canon.md).

### Spring — "The Picnic at Bluebell Bank"

| Days | What happens |
|---|---|
| 1–2 | The player (a newcomer mouse moving into the hedge — ⚠ DEFAULT — owner to confirm, [D9](./00-decisions.md)) settles in; introductions; first forage |
| 3 | Hedgerow Supper: **Proposal** — Mr Apple proposes a surprise birthday picnic for Wilfred at Bluebell Bank; the storm-broken plank bridge must be mended to get there |
| 4–7 | **Contribution**: baking, bottling, plank-gathering (NPC shifts visible; see [14-quests.md](./14-quests.md)) |
| 8–10 | **Construction**: the bridge is repaired in three witnessed stages |
| 10 | Hedgerow Supper: picnic plans confirmed; the date is put to the player |
| 11–13 | Festival window; NPCs suggest holding it on Wilfred's birthday (Spring 12) |
| 12 | **Wilfred's birthday** (canon: his birthday is the spring picnic day). If the picnic is held another day, dialogue folds the birthday in — "an early surprise!" |
| Valve | **The Picnic at Bluebell Bank** → next morning: bridge permanent, Bluebell Bank opens, season turns |

### Summer — "The Wedding Raft"

| Days | What happens |
|---|---|
| 1–2 | Heatwave presentation; Poppy keeps cool by the mill wheel, Dusty walks the banks (canon); Dusty's-nerves social favour |
| 3 | Hedgerow Supper: the **engagement** is announced "to nobody's surprise" — **Proposal** of the wedding raft |
| 4–6 | **Contribution**: reeds, timber, garland flowers, feast dishes; Basil cools wine in the stream |
| 7–9 | **Construction**: the raft rises at the mill mooring |
| 10 | Hedgerow Supper: Old Vole and Lord Woodmouse settle the ceremony; date put to the player |
| 11–14 | Wedding window; gentle jeopardy at the ceremony: the raft slips its rope and drifts into the reeds (canon mishap) |
| Valve | **The Midsummer Wedding** → next morning: raft re-moored as a punt-ferry; mill-wheel lift running; season turns |

### Autumn — "The Blanket Drive & the High Hills"

| Days | What happens |
|---|---|
| 1–4 | **Harvest rush**: all-hedge gathering into the Store Stump before the rains (canon *Autumn Story*); winter-comfort stock thresholds ([D8](./00-decisions.md)) |
| 5–6 | Story beat: **Primrose is lost** in the Chestnut Woods — mist evening, search party, found and brought home to hot chestnut soup. The tone-setting "peril" (13.5) |
| 6 | A tired vole messenger arrives: moths have eaten the High Hills voles' blankets (canon *The High Hills*) |
| 7 | Called meeting at the Store Stump: **Proposal** — blankets must be woven and delivered before winter |
| 8–10 | **Contribution**: thistledown and wool-tuft gathering; Flax & Lily weave visibly at the looms |
| 11–12 | **Construction/packing**: blankets baled; Mr Apple plans the route; Wilfred begs to come along |
| 12–14 | Expedition window: the journey, Wilfred stuck on the rock face, a cold misty night out, home to soup |
| Valve | **Harvest Home supper** in the Store Stump hall → next morning: fixed ropes stay on the rock face, the upland trail opens, season turns |

### Winter — "The Ice Hall" and "A Home for the Babies"

| Days | What happens |
|---|---|
| 1–2 | **Deep snow** buries doors and windows; dig-out day; snow tunnels connect the households (canon *Winter Story*) |
| 3 | Hedgerow Supper (by tunnel!): **Proposal** — an Ice Hall, "in the time-honoured way" |
| 4–6 | **Contribution**: snow blocks cut, lanterns made, feast food laid in |
| 7–9 | **Construction**: floor, walls, vaulted roof — the most spectacular witnessed build of the year |
| 8 | **Rose, Buttercup and Pipkin are born**; the mill is too loud and floury for babies. That evening, a whispered kitchen meeting at Crabapple Cottage: the **secret refurbishment** of Mayblossom Cottage begins ([14-quests.md](./14-quests.md)) |
| 9–12 | Secret Contribution/Construction at Mayblossom, hidden from Poppy and Dusty; Primrose and Wilfred, rehearsing their recital in the palace attics, find the **Secret Staircase** and the forgotten apartment (exploration reward, canon *The Secret Staircase*) |
| 13 | **Naming Day**: Old Vole gives the blessing; the cottage is revealed — the year-one emotional climax ([D7](./00-decisions.md)) |
| 14 | Festival window opens |
| Valve | **Midwinter's Eve**: the midwinter log hauled along the frosty hedgerow, blazing fire at the palace, the children's recital in antique finery, lantern walk to the Ice Hall → next morning: **Spring, Year Two** |

### Birthdays (fixed calendar days)

Birthday = gift multiplier **×8** ([D9](./00-decisions.md)) + a small doorstep scene. Only Wilfred's spring birthday is canon; the rest are game-assigned (rename-safe). **The birthday column below and the roster in [12-npcs.md §12.2](./12-npcs.md) are identical** — one settled table, no correction pending. Wilfred's **Spring 12** is the canon anchor: his birthday *is* the spring picnic day (both documents state it). Only the 12 scheduled NPCs have birthdays — the ×8 multiplier only means anything for mice with gift tables, so named extras (Old Vole, Mr Toadflax…) have none ([12-npcs.md §12.3](./12-npcs.md): no gift table ⇒ no ×8, no doorstep scene). If a birthday collides with a player-scheduled festival, it folds into the festival with an acknowledging line.

| Season | Birthdays |
|---|---|
| Spring | Lady Daisy — Spring 3 · Lily — Spring 8 · **Wilfred — Spring 12** (canon) |
| Summer | Lord Woodmouse — Summer 2 · Poppy — Summer 5 · Dusty — Summer 10 |
| Autumn | Flax — Autumn 3 · Mrs Apple — Autumn 6 · Primrose — Autumn 11 |
| Winter | Mr Apple — Winter 4 · Basil — Winter 9 · Mrs Toadflax — Winter 13 |

### Floating events

- **Engagement → wedding → Naming Day** chain: authored for Poppy & Dusty in year one (Summer 3 → Midsummer wedding → Winter 13). The chain is a reusable template for post-launch NPC arcs.
- **Heart-scenes** float on friendship thresholds, never on dates ([12-npcs.md](./12-npcs.md)).
- **Hedgerow Supper**: Day 3 and Day 10 of every season (the same weekday — 13.1) — the community's meeting and the player's window on NPC-to-NPC life (D9).
- **The Snow Ball** (post-launch): only in winters where the deep-snow weather state occurred ≥2 days — a delightful rare event, never guaranteed.

## 13.5 Weather

Weather is rolled once per day at the overnight pass from the seasonal table below, unless an authored story override is queued (Primrose-lost mist, expedition mist, deep snow on Winter 1–2). Player-scheduled festival days force fair season-appropriate weather (gentle snowfall permitted at Midwinter).

| State | Spring | Summer | Autumn | Winter |
|---|---|---|---|---|
| Fair | 45% | 70% | 35% | 30% |
| Overcast | 20% | 15% | 25% | 20% |
| Rain | 25% | 10% | 25% | 5% |
| Mist | 10% | 5% | 15% | 10% |
| Snow | — | — | — | 25% |
| Deep snow | — | — | — | 10% (re-rolled as Snow if no existing snow cover) |

**Weather is three things and only three things:**

1. **Presentation** — particles, LUT shift, wet-surface response, audio bed, NPC umbrella/indoor schedule variants ([12-npcs.md](./12-npcs.md)). Rain on a candlelit dollhouse window is a marketing shot; treat it as one.
2. **Gathering modifiers** — see table:

| State | Gathering effect |
|---|---|
| Rain | Mushrooms +50% spawns next morning; snails come out; stream margin forage refreshed |
| Mist | Vista visibility shortened (fog volume); shy forage (certain moths, lichens) available; "lost" ambience |
| Snow | Berries gone; rosehips and winter forage highlighted; animal tracks reveal hidden caches |
| Deep snow | Overground paths closed, snow tunnels only; ice-block cutting enabled (Ice Hall project) |

3. **The only "peril"** — per canon tone ([canon bible](../research/01-brambly-hedge-canon.md) §8): danger vocabulary is fog, storm, snowdrift, a rising stream, being lost. These occur **only in authored story beats** (Primrose in the Chestnut Woods; the misty night on the High Hills), never systemically. There is no cold meter, no damage, no death. **The worst outcome in the entire game is being found, cold, and brought home to soup.** That sentence is a testable design rule: if any content can end worse, it is out of scope.

## 13.6 Seasonal Impact Summary

"Same hedge, four books" ([D4](./00-decisions.md)): each season is a data problem — 4–5 LUTs, foliage colormap swaps, dressing sets — plus the systemic changes below. Botanical accuracy per season, never generic cottagecore.

| Layer | Spring | Summer | Autumn | Winter |
|---|---|---|---|---|
| Botanicals (art keys) | Bluebells, primroses, cowslips, blossom | Meadowsweet, dog roses, tall grasses, poppies | Blackberries, chestnuts, rosehips, gold leaves | Snow, bare branches, hips, candlelit windows |
| Gathering set | Primroses, dew snails, spring greens, cowslips | Watercress, wild strawberries, elderflower, honey | Blackberries, chestnuts, seeds, thistledown, mushrooms | Rosehips, stored goods, ice blocks, winter herbs |
| Signature recipes ([10-core-systems.md](./10-core-systems.md)) | Primrose pudding, cowslip wine | Watercress soup, syllabubs, honey creams | Rosehip jam, seed cake, acorn coffee | Chestnut soup, clover bread, midwinter cake |
| Dialogue axes (D9) | Picnic anticipation, new arrivals | Heatwave, engagement gossip | Harvest urgency, expedition talk | Snow wonder, babies, Midwinter |
| Dusk LUT begins | 19:30 | 21:00 | 18:00 | 16:30 |
| Community project | Picnic logistics | Wedding raft | Blanket drive / expedition | Ice Hall + secret refurbishment |

The changing world is the retention loop: players return not to grind but to see what the hedge looks like *now* — and seasonal availability ("blackberries only in autumn") is the only acceptable form of time pressure in the game ([cozy quest comps](../research/06-comps-cozy-quests.md)).

## 13.7 TimeService Architecture

One service owns time. Nothing else ticks, accumulates, or stores a date. All consumers subscribe to events; nothing polls in Update. **The canonical API contract — field names, the code sketch, the tick loop — lives in [19-technical-direction.md §19.7](./19-technical-direction.md), the technical bible.** This section states only the design rules that contract implements; if the two ever drift, 19 wins and this section is corrected.

- **One speed constant.** `TimeService.RealSecondsPerGameMinute` is the only place speed lives (D6): normal mode `1.0`, unhurried mode ~`1.43` (13.1 states the direction of the ratio — a bigger number is a slower clock). Nothing else may scale time.
- **Calendar fields are state, not arithmetic.** `MinuteOfDay`, `DayOfSeason`, `SeasonIndex`, `Year` and `TotalDaysElapsed` are stored on TimeService and advanced explicitly — the season valve (13.3) means a season can run past Day 14, so season is **never** derived from a day or minute counter. `AdvanceSeason()` has exactly one caller: FestivalService, on the morning after a season-valve festival (13.8, §19.7).
- **Event-driven ticks.** `EC_MinuteTick` (every 10 game minutes — the [§19.5](./19-technical-direction.md) channel table) is the workhorse: NPC schedule keyframes, the displayed clock and gathering-node checks all key off it. `PhaseChanged` (13.2) drives lighting/LUT blends, ambience beds and mixer snapshots ([16-music-and-audio.md](./16-music-and-audio.md)). `EC_SeasonChanged` fires dressing-set, LUT-set and schedule swaps. Per-frame accumulation happens only inside TimeService.
- **Sleep never ticks.** `EC_DayEnded` → discrete overnight pass (13.1) → date fields advance and `MinuteOfDay` resets to 06:00 → `EC_DayStarted`. Systems that need "N days passed" read `TotalDaysElapsed`; none may rely on observing every minute.
- **Pause is a state, not a branch.** A single `PauseState` on TimeService (§19.7) halts ticking whenever it is anything but `Running`; it covers every pause source listed in 13.1. `RealSecondsPerGameMinute` is never touched by pause — speed mode and pausing are orthogonal.
- **Saves** store the [§19.6](./19-technical-direction.md) `time` block — `seasonIndex`, `dayOfSeason`, `year`, `totalDaysElapsed`; `minuteOfDay` is always 06:00 on load because saves happen only on sleep — plus today's weather, the festival-scheduled date and any queued overnight overrides in their own blocks. Nothing else about time is persisted.
- Debug: a time-scrub console command set (`time.set`, `time.sleep`, `season.force`) exists from the first playable — the schedule visualizer ([D9](./00-decisions.md)) depends on it.

## 13.8 Festival System Spec

Festivals are a Must-tier set-piece system and the mechanism of the season valve ([D6](./00-decisions.md), [D10](./00-decisions.md)). This is their operational spec. [14-quests.md](./14-quests.md) owns how a project's Celebration phase schedules one; [12-npcs.md](./12-npcs.md) §12.3 owns placement sets.

### Ownership and events

**FestivalService** lives in the Sim layer (`Hedgerow.Sim`, [§19.5](./19-technical-direction.md)) and is driven by `EC_MinuteTick`. It is the "festival FSM" that [18-community-philosophy.md](./18-community-philosophy.md) R5 tests against. It publishes `EC_FestivalStarted` (the §19.5 channel table) when a festival begins, raises `FestivalService.StateChanged` on every state and stage transition (the subscription named in [16-music-and-audio.md](./16-music-and-audio.md) — continuous festival music, the diegetic band handover), and is the **only** caller of `TimeService.AdvanceSeason()` (13.7, §19.7).

FSM: `Scheduled → Dressing → Running(stage 1…n) → Afterglow → Done`. There is no waiting-for-player state anywhere in it (R5).

### The festival day

Once the player sets the date (the valve courtesy, 13.3; scheduled by the project's Celebration phase, [14-quests.md](./14-quests.md)), the day runs on the game clock **with or without the player** (D10):

| Clock | State | What happens |
|---|---|---|
| 06:00 | `Dressing` | Setup placement set spawns — trestles, garlands, lanterns rigged by visible NPC labour; every scheduled NPC's day is already overridden by the `festival_today` cascade key ([12-npcs.md](./12-npcs.md) §12.7) |
| Start hour | `Running` | Stages begin (picnic 12:00; Midwinter's Eve 17:00 — per definition) |
| + stage durations | `Running` | **3–5 sequenced stages**, each an authored placement set plus an optional Timeline asset for spectacle beats, advancing on the clock whether or not the player attends. A late player lands mid-stage — soup half-eaten, dance mid-song — and dialogue saliency picks event-in-progress lines (R5) |
| Last stage end → 24:00 | `Afterglow` | Embers, lanterns, stragglers; the normal soft sleep prompt |
| Next morning | `Done` | Teardown deltas applied in the overnight pass; if `seasonValveFor` matches the current season, `AdvanceSeason()` fires and the project's Function morning begins ([14-quests.md](./14-quests.md)) |

A festival never spans a sleep, so **no mid-festival state is ever saved** (save-on-sleep, [D2](./00-decisions.md)); only the scheduled date and a completed flag persist ([§19.6](./19-technical-direction.md) `community` block).

Example — the Picnic at Bluebell Bank (start 12:00): hamper procession across the new bridge (Timeline arrival shot) → the surprise, and Wilfred's birthday beat → the feast on the cloth, every named deposit visible → games on the bank → packing up at dusk.

### FestivalDefinition — data sketch

```
FestivalDefinitionSO {
  festivalId:         "festival.spring_picnic"        // stable string ID (§19.5)
  seasonValveFor:     Spring | Summer | Autumn | Winter | None
  startHour:          12:00
  stages[]:           { placementSetId, timelineAsset?, durationMinutes }   // 3–5
  contributionFormat: DishTable | GiftExchange | None                       // D10
  variants[]:         { conditions { yearIndex, projectFlags[], weather, relationshipBeats[] },
                        lineGroupSet, dressingDeltaSet }                    // 2–3 per full festival
}
```

Contribution formats (D10 — formats over contests; no scoring, no failure):

- **DishTable** — communal dishes: Store Stump deposits tagged for the festival appear, named, on the feast cloth; the toast names ≥3 NPCs alongside the player ([D7](./00-decisions.md)).
- **GiftExchange** — assigned gift exchange (Midwinter): recipients drawn at the preceding Hedgerow Supper; the player's assigned gift resolves through the normal gift-taste table ([12-npcs.md](./12-npcs.md) §12.5) and earns a bespoke acknowledging line, never a score.
- **None** — pure spectacle, zero mechanics. **≥1 festival per year is this tier** (D10); year one's is the Midsummer Wedding ceremony set-piece.

The celebration set-pieces of 13.3 use the same definition shape with 2–3 stages and no variants at 1.0 — one system, two tiers. (Autumn's Harvest Home supper is the FestivalDefinition; the expedition preceding it is quest content, [14-quests.md](./14-quests.md).)

### Variant selection

Each full festival ships **2–3 state-reactive variants** (D10) so year two isn't a music box. A variant is a line-group set plus dressing deltas over the *same* stages — never a second festival's worth of content. Selection happens once, at `Dressing`, by the same most-specific-match saliency rule as dialogue (the [D9](./00-decisions.md) axes): year index × completed-project flags × weather × live relationship beats. Example: the Year-Two picnic has no bridge to unveil — the procession stage swaps its line set and the surprise beat becomes an (unsurprising, beloved) birthday toast for Wilfred.

[← Back to Index](./INDEX.md) | [Previous](./12-npcs.md) | [Next: Quests →](./14-quests.md)
