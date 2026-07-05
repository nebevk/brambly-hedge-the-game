# 4. Inspirations

[← Back to Index](./INDEX.md) | [Previous](./03-design-pillars.md) | [Next: World →](./05-world.md)

This chapter is the project's evidence base. Every comparative claim made elsewhere in the GDD — camera numbers, friendship points, season lengths, price, the community-projects pillar itself — traces back to a comp analysed here. Entries follow one format: **Facts** (team, dev time, price, playtime, reception — hard numbers where the research has them), **We take** (specific mechanics and numbers we adopt), **We avoid** (specific, observed failures). Full analyses live in the research files: [community sims](../research/03-comps-community-sims.md), [gentle exploration](../research/04-comps-gentle-exploration.md), [storybook visuals](../research/05-comps-storybook-visual.md), [cozy quests](../research/06-comps-cozy-quests.md), [small-scale worlds](../research/07-comps-small-scale-worlds.md), plus [market analysis](../research/08-market-analysis.md) and [cozy pitfalls](../research/09-cozy-pitfalls.md).

Where a comp's lesson has been turned into a binding rule, the entry cites the decision (D-number) in [00-decisions.md](./00-decisions.md). If anything here appears to disagree with that brief, the brief wins.

**Comp map at a glance:**

| Category | Comps | Primarily feeds |
|---|---|---|
| The source | Brambly Hedge books (Jill Barklem) | Everything; [05 World](./05-world.md), [06 Art](./06-art-direction.md), [18 Community](./18-community-philosophy.md) |
| Storybook visual | Snufkin, Tiny Glade, Dordogne, Plucky Squire, Season | [06 Art](./06-art-direction.md), [07 Camera](./07-camera-direction.md), [17 UI](./17-ui-philosophy.md) |
| Gentle exploration | A Short Hike, Lil Gator, Smushi, Little Kitty, Mail Time, Botany Manor | [05 World](./05-world.md), [14 Quests](./14-quests.md), [15 Progression](./15-progression.md) |
| Community sims | ACNH, Stardew Valley, Palia, Fields of Mistria | [12 NPCs](./12-npcs.md), [13 Time](./13-time-and-seasons.md), [18 Community](./18-community-philosophy.md) |
| Cozy quests | Cozy Grove, Spiritfarer, Wylde Flowers, Eastshade, Garden Story, Ooblets | [14 Quests](./14-quests.md), [15 Progression](./15-progression.md), [09 Loop](./09-gameplay-loop.md) |
| Small-scale worlds | Ghost of a Tale, Moss, Tinykin, Grounded, Pikmin 4 | [05 World](./05-world.md), [07 Camera](./07-camera-direction.md), [16 Audio](./16-music-and-audio.md) |
| Neighbours & warnings | Winter Burrow, Tales of the Shire | [01 Title/IP](./01-working-title.md), [19 Tech](./19-technical-direction.md), [20 MVP](./20-mvp.md) |

---

## 4.1 The source: the Brambly Hedge books

**Facts.** Eight picture books by Jill Barklem: four seasonal books (all 1980) plus four expedition/event books (1983–1994); roughly 20 named mice in total. 7M+ copies sold in 20+ languages; deliberately miniature format (17.6 × 14.6 cm). Barklem spent ~5 years on research before publication; each book took ~2 years, single plates up to 3 months. The Sunday Times called them "the most research-crammed fantasy ever set before small children." The community has no money economy — food goes into the shared Store Stump — and every big undertaking (Ice Hall, wedding raft, blanket expedition, cottage refurbishment) is done collectively. Full canon bible: [Brambly Hedge canon research](../research/01-brambly-hedge-canon.md).

**We take.** Everything structural: the cutaway cross-section interior — Barklem's signature image — becomes the dollhouse camera ([D3](./00-decisions.md)); the Store Stump becomes the no-money contribution economy ([D8](./00-decisions.md)); the books' collective undertakings become the five-phase community-project system ([D7](./00-decisions.md)); the four seasonal books become the "same hedge, four books" season structure ([D6](./00-decisions.md), [D4](./00-decisions.md)); Barklem's research discipline becomes our operational art bar — botanical accuracy per season, never generic cottagecore ([D4](./00-decisions.md)). Tone guardrail: peril is weather, fog, and being lost; the worst outcome is "found, cold, and brought home to soup."

**We avoid / constraint.** The IP is actively managed and unlicensed use of the name is plain infringement ([D1](./00-decisions.md)). All canon names live in the quarantined canon layer; the design must survive a rename losing nothing but the name (see [IP research](../research/02-ip-licensing.md)). Canon-fact discipline: no invented foods, festivals, or characters anywhere in this GDD — everything from the [canon research](../research/01-brambly-hedge-canon.md).

---

## 4.2 Storybook visual presentation

*Feeds [06 Art Direction](./06-art-direction.md), [07 Camera](./07-camera-direction.md), [08 Visual Identity](./08-visual-identity.md), [17 UI](./17-ui-philosophy.md). Full analysis: [storybook visual research](../research/05-comps-storybook-visual.md).*

### Snufkin: Melody of Moominvalley (Hyper Games, 2024)

**Facts.** 13-person Oslo studio, ~4 years (concept 2020 → March 2024), Unity, ~$25, published by Raw Fury. 96% positive (~1.8k Steam reviews), 88% critic recommendation. The closest comp in kind: a beloved Nordic picture-book licence, gentle pace, no combat focus. Look achieved with hand-painted watercolour albedo textures on real-time 3D, animation-on-twos, and subtle texture boil — no watercolour shader. A 230-page digital artbook (~$8) documents the pipeline.

**We take.** The painted-albedo Unity pipeline wholesale — it is the baseline of our art doctrine ([D4](./00-decisions.md)). The brand-guardianship framing of their Moomin licence is the model for our Rockpool pitch ([D1](./00-decisions.md)). The artbook is a mandatory standing reference purchase. Animation-on-twos/texture boil as charm, not defect — imperfection tolerance is a budget lever.

**We avoid.** The fixed bird's-eye camera — the game's main visual criticism ("almost a shame" next to its rare layered vistas). Our snap-yaw camera with authored arrival shots ([D3](./00-decisions.md)) exists precisely to not waste a storybook world on one flat angle. Also note the scale warning: 13 people × 4 years — our content volume must be far smaller.

### Tiny Glade (Pounce Light, 2024)

**Facts.** 2 people (both world-class specialists), ~2 years full-time after years of prototyping. $15; 616,528 units in the first month off 1,375,441 launch wishlists; 97% positive; BAFTA Technical Achievement nomination. Custom Rust/Bevy/wgpu engine with ReSTIR-style real-time GI (~11 ms/frame at 1080p on a Radeon 6800 XT). No interiors at all.

**We take.** The *outcomes*, not the tech: soft bounce-lit pastel light via baked GI + light probes; a photo mode with one-click tilt-shift from the first public build ([D13](./00-decisions.md)); "it's alive" micro-reactivity scoped tiny — worn-path decals, birds landing when idle, windows lighting at dusk — at ~1% of their tech cost. Their marketing is the archetype of the one-GIF hook our dollhouse-zoom trailer must be ([D11](./00-decisions.md), [market research](../research/08-market-analysis.md)).

**We avoid.** Attempting custom engines or real-time GI — each is a specialist-years investment ([D2](./00-decisions.md) locks Unity 6.3 + URP). And note what they skipped: interiors. Our dollhouse interiors are unoccupied ground.

### Dordogne (Un Je Ne Sais Quoi / Umanimation, 2023)

**Facts.** 30+ people, ~4–5 years, Unity + Blender. Metacritic 76. Art director Cédric Babouche hand-painted 180+ real watercolour landscapes (2 hours each vs 2 days digital) and camera-mapped them onto low-poly 3D — no 3D lighting except on characters. He explicitly rejected animated watercolour shaders: "the human eye isn't really comfortable with" them.

**We take.** The shader rejection is doctrine: no animated watercolour filters, no Kuwahara ([D4](./00-decisions.md)). The targeted use of painted stills: journal pages, festival memory cards, season title cards, vignettes — high art impact at fixed viewpoints where camera freedom doesn't matter ([D13](./00-decisions.md), [17 UI](./17-ui-philosophy.md)).

**We avoid.** The full camera-mapped pipeline — it needs a master watercolourist and forfeits the rotatable camera that is our flagship. And the reception pattern: "one of the most stunning games" + gameplay called chores = 76 Metacritic. Art awards do not carry thin activities.

### The Plucky Squire (All Possible Futures, 2024)

**Facts.** Founded Feb 2019, development from 2020 (~4.5 years), small remote studio plus outsourcing, Unreal, published by Devolver. Metacritic 83 (PC) / 72 (Switch). Signature feature: jumping between a 2D illustrated storybook and the 3D desk it sits on — enormously expensive engineering.

**We take.** The concept, not the tech: **the book as diegetic frame**. Our journal-as-UI ([D17 terminology](./00-decisions.md), [17 UI](./17-ui-philosophy.md)) is our Plucky Squire moment — genuinely 2D illustrated spreads the 3D game opens into, at ~1% of their cost.

**We avoid.** 2D/3D world-switching tech; minigame abundance diluting the core; shipping on underpowered platforms with performance issues (their Switch build scored 11 points below PC — supports our PC + Steam Deck-only 1.0, [D11](./00-decisions.md)).

### Season: A Letter to the Future (Scavengers Studio, 2023) — compact entry

**Facts.** ~35-person studio cut to 16 after launch; Metacritic 80 (PC); Webby art-direction award; **only 60k units by June 2023**. "Stylized realism": painted albedo + art-directed shadow tint + realistic light behaviour.

**We take.** The shading formula — illustrative albedo with tinted (never black) shadows — is the core of our hero uber-shader's ramp ([D4](./00-decisions.md): violet-grey shadows). It ports to URP Shader Graph in days.

**We avoid.** The business shape: the definitive proof that art-direction awards ≠ sales when the loop is thin. Our depth benchmarks are Mistria and Discounty, not Season ([pitfalls research](../research/09-cozy-pitfalls.md)).

---

## 4.3 Gentle exploration

*Feeds [05 World](./05-world.md), [09 Gameplay Loop](./09-gameplay-loop.md), [14 Quests](./14-quests.md), [15 Progression](./15-progression.md). Full analysis: [gentle exploration research](../research/04-comps-gentle-exploration.md). Genre constants across all six: zero fail states, verticality as the density trick, traversal as the progression system, ~$4–5/hour as the price-complaint threshold.*

### A Short Hike (adamgryu, 2019)

**Facts.** Solo dev + contractors, ~4–7 months, Unity, $7.99. 1.5–2 h main / ~4 h 100%. 22,309 Steam reviews at 99% (roughly 700k–1.1M Steam owners); IGF Grand Prize 2020; Metacritic 82 (PC) / 88 (Switch); sales "much stronger on Switch."

**We take.** Traversal-as-progression: 20 golden feathers, ~7 recommended to summit, completable with fewer — the soft-threshold model behind "about twelve bundles of reeds" ([D7](./00-decisions.md)). Postmortem process: core game + stretch goals (core never treated as an MVP), solo scrum with daily re-estimation, one external deadline — all adopted in [D16](./00-decisions.md) production shape. Yarn Spinner for dialogue (now [D2](./00-decisions.md) stack). It is also the calibration point for our pre-agreed G4 fallback: "an A-Short-Hike-class 4–6 hour exploration game" ([D16](./00-decisions.md)).

**We avoid.** Nothing — but note it defines a different commercial shape (2 h at $8). We are $19.99 / 25–35 h ([D11](./00-decisions.md)); its lessons transfer, its scope does not.

### Lil Gator Game (MegaWobble, 2022)

**Facts.** 3 people, ~3 years, Unity, $19.99. ~3 h main / 5–6 h 100%; ~5,000 Steam reviews at 98–99%; Metacritic 84. Design goal: "there isn't any empty space — everything feels designed." Trees reworked four times chasing charm.

**We take.** The micro-quest grammar: side quests "typically under one minute… with a joke or moral message at the end," only essential quests marked. This is the template for our small-favours track ([14 Quests](./14-quests.md)) and the density bar behind "POI every 5–10 s of walking" ([D14](./00-decisions.md)).

**We avoid.** Its documented wayfinding complaints (players lost with no minimap) — we keep no-minimap ([D14](./00-decisions.md)) but ship the mitigations: landmark discipline, diegetic signposting, journal prose restating goals.

### Smushi Come Home (SomeHumbleOnion, 2023)

**Facts.** Solo dev, ~2–3 years, $19.99. ~3 h / ~5 h; 2,023 reviews at 98%; 10k+ copies first week, est. 50–100k owners. Publisher found *him* via Screenshot Saturday. Features a Mycology Journal documenting 16–20 real mushrooms.

**We take.** Journal-as-collectible-education — real botany in an in-game journal is exactly our botanical-accuracy pillar rendered as content ([D4](./00-decisions.md), [17 UI](./17-ui-philosophy.md)). Screenshot Saturday as a genuine publisher-scouting channel ([market research](../research/08-market-analysis.md)).

**We avoid.** His hardest playtest finding: a 50/50 split between "delightfully lost" and "frustrated" in unmapped areas. That number is why our no-minimap design carries mandatory signposting mitigations rather than confidence.

### Mail Time (appelmoes games, 2023)

**Facts.** 1 lead + ~10 contributors, ~3 years, $19.99. 2.5–3 h total; 1,075 reviews at **86%** — the weakest of the six; Metacritic 74. Went viral on TikTok pre-release; charm got the clicks, thinness got the score.

**We take.** Proof that a pure delivery/errand loop can carry a game at small-community scale — errands are canon-native for us (baskets, invitations, messages along the hedge). And the honest lesson that pre-release virality is not a quality substitute.

**We avoid.** 2.5–3 h at $19.99 with technical roughness. This is the cleanest demonstration of the $4–5/hour complaint threshold that sets our 25–35 h at $19.99 target ([D11](./00-decisions.md)).

### Little Kitty, Big City (Double Dagger Studio, 2024)

**Facts.** Founder ex-Valve; solo for ~half of 5 years, then 3–5 core. $24.99. 2.5–3 h main / ~6 h. 100k copies in 48 hours; ~500k across Steam+Switch by July 2024; 2M+ Game Pass players; **464k wishlists at launch**; 10.2k reviews at 96%. "The game was a game about distractions" — trivial main quest, everything interesting off-path. Fish-gated climbing: 8 fish nominal, 3 technically possible.

**We take.** The distraction structure (trivial spine, dense margins) for our freeform day layer ([09 Loop](./09-gameplay-loop.md)); soft gates with generous thresholds; the channel data — Next Fest as primary discovery, Nintendo showcases huge, "TikTok was not a win" ([market research](../research/08-market-analysis.md)).

**We avoid.** The camera warning: it *started* with locked camera angles and had to abandon them as animation and verticality grew. This is the single strongest argument for our 2-week camera greybox being the first production task ([D3](./00-decisions.md)) — we must prove the snapped camera survives canopy climbing and interiors before art exists.

### Botany Manor (Balloon Studios, 2024)

**Facts.** ~5 core part-time (founder ex-ustwo, Monument Valley), ~3+ years, Unity, $24.99, day one on Game Pass. 3–4 h main; 976 reviews at 94%; Metacritic 84. One handcrafted manor + gardens is the whole game.

**We take.** Three level-design disciplines, adopted verbatim: obsess over **sightlines** to improve views and cut walking; add loops/shortcuts that return players to hubs; and the **saucer rule** — every plant blooms on a saucer with its trigger next to it so the player *witnesses* the reward. Our version: no community project ever completes off-screen; construction is staged and watched ([D7](./00-decisions.md) Construction/Celebration phases).

**We avoid.** The price-length pushback: even at 94% positive, $24.99 for ~4 h produced "would have bought if it was cheaper" threads. Confirms $19.99 and visible content depth ([D11](./00-decisions.md)).

---

## 4.4 Community sims — the giants we invert

*Feeds [12 NPCs](./12-npcs.md), [13 Time & Seasons](./13-time-and-seasons.md), [18 Community Philosophy](./18-community-philosophy.md). Full analysis: [community sims research](../research/03-comps-community-sims.md). The shared finding: all three giants are player-centric to the bone — the town cannot act without you. Inverting that is our differentiator ([D7](./00-decisions.md)).*

### Animal Crossing: New Horizons (Nintendo, 2020)

**Facts.** 49.91M units by March 2026 (#2 best-selling Switch game); Metacritic 90. Real-world 1:1 clock. Hidden 0–255 friendship scale, six levels, deliberately invisible. ~400 villagers sharing **8 personality dialogue archetypes** — repetitive dialogue is the game's most-cited flaw. Jan–Nov 2021 content drought triggered lasting backlash; events repeated "with little to no changes."

**We take.** Seasonal flora/fauna as the return-visit engine (our four seasonal re-dressings, [D6](./00-decisions.md)); and the *original* 2001 game's abandoned philosophy — a village that belongs to the animals, where the world demonstrably doesn't wait for you — as the spiritual ancestor of our community-runs-itself pillar.

**We avoid.** The real-time calendar (retention hook that became a grievance machine and demands a live content pipeline we cannot staff — [D6](./00-decisions.md): no real-world-clock gating, ever); archetype dialogue pools (every one of our 12 NPCs is an individual with a unique pool, [D9](./00-decisions.md)); the island rating (a literal score for decorating — we grade nothing); villagers who cannot move a fence.

### Stardew Valley (ConcernedApe, 2016)

**Facts.** One person, ~4.5 years. 41M copies by Dec 2024, 50M+ by Feb 2026, ~$518M gross; Metacritic 89. One day = 14 m 20 s real; 28-day seasons; a full year ≈ 26.75 real hours. Friendship: 250 pts/heart, talk +20/day, loved gift +80, birthday ×8, 2 gifts/week — and a resented −2/day decay. 2–4 festivals per season; most freeze time until the player arrives. Community Center: 6 rooms, 30 bundles; completion permanently changes the town (minecarts, greenhouse, JojaMart dies, villagers use the hall).

**We take.** The numbers skeleton, minus the resentments: 250 pts/heart, 8–10 hearts, talk +20, loved gift +80, birthday ×8, 2 gifts/week, **no decay** ([D9](./00-decisions.md) adopts these verbatim). Data-driven NPC schedules with priority cascades ([D9](./00-decisions.md)). The Community Center as the single best precedent for community projects — multi-stage restoration with permanent functional town change — and Barone's own 1.6 correction: the added festivals are multi-day and *don't* freeze time. The Luau communal soup and Winter Star assigned gift exchange are our festival contribution formats ([D10](./00-decisions.md)).

**We avoid.** The Community Center's flaw: the player alone fills every bundle; the community never lifts a finger — our projects have scheduled, visible NPC labour and complete (slower) without the player ([D7](./00-decisions.md)). Time-freezing festivals ([D10](./00-decisions.md): festivals start without you). Friendship decay. The endgame money pile with no sinks — we solve it by having no money at all ([D8](./00-decisions.md)). Post-max-heart dialogue loops — thin post-max content stream instead ([D9](./00-decisions.md)).

### Palia (Singularity 6, 2023)

**Facts.** The cautionary giant: $49M of VC funding, ~200+ staff at peak, two 2024 layoff rounds (~85 people), distress sale to Daybreak July 2024. Metacritic ~77. F2P live-service; 1 in-game day = 1 real hour; **no seasons and no weather at all**; real-calendar FOMO events; friendship levels capped early with dialogue that dries up.

**We take.** Its one genuine innovation, single-player-ised: **communal activity magnets** — shared-loot trees and group events that reward being near others. Replace "other players" with NPCs: shared foraging baskets, project work parties, festival activities where NPCs fill the slots. And its best relationship idea: a bespoke quest per friendship level — the direct ancestor of our heart-scenes, the highest-value content in the game ([D9](./00-decisions.md): 3–4 scenes × 12 NPCs ≈ 40–50 scenes).

**We avoid.** Everything else: live-service economics on a niche cozy audience (the standing warning in [D5](./00-decisions.md)/[21 Long-Term](./21-long-term-vision.md) against live cadence, currencies, rotating shops); perpetual-sunshine worldbuilding (seasons are our spine); telling every player they're the special arrival — multiplayer exposed how thin that trick always was.

### Fields of Mistria (2024, Early Access)

**Facts.** $13.99 EA (Aug 2024); entered Early Access with **5,000+ unique dialogue lines and dozens of cutscenes for ~28 NPCs** and 40+ polished hours; best-reviewed farm sim of 2024; 1.0 targeted Aug 2026. Reviewers specifically praised how long it takes for lines to repeat. Everyone gathers at the inn on Fridays — systemic social staging.

**We take.** The dialogue-density benchmark that sets our 4,000–8,000-line budget and per-NPC minimums ([D9](./00-decisions.md)); the weekly social gathering — our hedgerow supper — as the cheapest aliveness multiplier; distinct art as table stakes in a glutted genre.

**We avoid.** Its Early Access route: Mistria proves EA is only survivable at 40-hours-polished entry quality. We will not have that at any pre-1.0 point, hence **no Early Access** ([D11](./00-decisions.md); Coral Island's review-bombing shows the downside — [pitfalls research](../research/09-cozy-pitfalls.md)).

---

## 4.5 Cozy quests & no-combat progression

*Feeds [14 Quests](./14-quests.md), [15 Progression](./15-progression.md), [10 Core Systems](./10-core-systems.md). Full analysis: [cozy quests research](../research/06-comps-cozy-quests.md). The shared finding: no-combat progression is a braid of relationship, story, tool, and area gates — never player levels.*

### Cozy Grove (Spry Fox, 2021)

**Facts.** Real-time clock, no skip: ~20–30 minutes of content per real day; full story ~80–100 real days, ~35–50 h. Two quest classes: timed dailies (no story) vs untimed story quests (bear memories). Island physically regains colour as bears find peace.

**We take.** The two-track quest taxonomy, with the timer removed: untimed story/community quests always carrying narrative + light daily favours from a hand-authored pool ([14 Quests](./14-quests.md)). World-state as progress bar: our returning colour is repaired thatch, relit windows, busier paths ([D7](./00-decisions.md) Function phase). The session promise — "accomplished something today, something to look forward to tomorrow" — without the wall ([D6](./00-decisions.md) session shape).

**We avoid.** Real-time gating. The Steam-forum revolt (demands for a store-page disclaimer, "come back tomorrow" resentment) is the primary evidence behind [D6](./00-decisions.md)'s hard rule: no real-world-clock gating anywhere, no expiring content, never cap daily play.

### Spiritfarer (Thunder Lotus, 2020)

**Facts.** $29.99; 500k copies in ~5 weeks, 1M+ by late 2021. No-combat management with area gates (three mandatory boat upgrades), ability shrines, and emotionally charged materials: boat upgrades require Spirit Flowers given only when a spirit departs — grief literally fuels progression.

**We take.** **Mechanical reciprocity**, the genre's single most powerful trick: spirits made Ecstatic actively work for you (chop, fish, gift, play mood-raising music). Our rule, adopted as binding: every completed favour returns something tangible within one in-game day ([10 Core Systems](./10-core-systems.md)). The Arc quest structure (meet → settle → learn preferences → requests → bespoke events → player-triggered resolution → permanent trace) is the ancestor of our five-phase project template ([D7](./00-decisions.md)). Player agency over emotional climaxes (the Everdoor) is kin to our season valve ([D6](./00-decisions.md)). A dedicated tenderness verb (their hug) and ceremony-only leitmotifs ([16 Audio](./16-music-and-audio.md)).

**We avoid.** Repeated crafting micro-minigames as "texture" (the back half drags); vague late-game progression triggers; dangling visibly-locked objectives many hours before they're actionable ([D7](./00-decisions.md) anti-patterns).

### Wylde Flowers (Studio Drydock, 2022)

**Facts.** ~3 years; initial team ~12, grew roughly fourfold — enabled by Apple as publisher. ~18 hours of dialogue, 350 cutscenes, ~30 voiced characters, 230 names in the credits. Apple Arcade Game of the Year 2022. Main story ≈ one in-game year, ~30 h. Seasons advance **only when the player performs the coven ritual** — praised as reinforcing the relaxed pace.

**We take.** The season valve, hybridised: our seasons turn only when the player triggers the seasonal festival ([D6](./00-decisions.md) — the term "season valve" in [D17](./00-decisions.md) comes from here). Their camera lesson: acted scenes forced the camera closer — validating our authored arrival shots and heart-scene framings ([D3](./00-decisions.md)).

**We avoid.** Full VO ambition without platform money. Their scale (script "longer than War and Peace") required a publisher and 4× team growth. Our baseline is zero VO with expressive vocalisations; partial VO is a funded stretch only ([D12](./00-decisions.md)).

### Eastshade (Eastshade Studios, 2019)

**Facts.** ~2 core people, 6 years, Unity, ~$200k cash budget (~$700k true cost), **~$2M gross / ~$1.1M net in 1.5 years** — the existence proof for our team shape. ~50 voice actors for ~$10k, self-directed remote recording. Survival meters cut early: "constantly depleting bars were entirely at odds with how we wanted the game to feel."

**We take.** Friendship as the key ring: letters of recommendation and being vouched-for as area gates — canon-adaptable as invitations and trust (the Palace cellars open because Mrs Apple vouches for you; [15 Progression](./15-progression.md)). The inspiration economy (curiosity as the resource) is spiritual kin to journal sketching ([D13](./00-decisions.md)). The partial-VO playbook is our funded-stretch spec ([D12](./00-decisions.md)). The optimisation playbook — hex-grid mesh combining, cluster planting, mesh terrain — feeds the draw-call budget ([D2](./00-decisions.md), [19 Tech](./19-technical-direction.md)). The no-meters rule ([D6](./00-decisions.md)).

**We avoid.** Its art-direction failure: anthropomorphic "animal folk" were "a huge turn off for so many people." Our mouse designs get external audience testing early, before content lock ([D16](./00-decisions.md), G1 gate). Also: version-control disasters — Git+LFS from day one ([19 Tech](./19-technical-direction.md)).

### Garden Story (Picogram, 2021)

**Facts.** Village-restoration RPG (light combat). Requests from bulletin boards in three categories earning categorised town XP; main story gated behind town level.

**We take.** Little directly — the town-ledger visualisation is workable only as supporting flavour, never the main loop.

**We avoid.** Its two headline failures, both adopted as binding anti-patterns: (1) requests drawn from a small random pool, so players repeat the identical task 2–3 times in a row — our favour pool is hand-authored, 60+ variants minimum ([14 Quests](./14-quests.md)); (2) rebuilding that is "almost entirely aesthetic" — hence [D7](./00-decisions.md)'s Function phase: every project must change ≥1 NPC schedule + ≥1 service/recipe + ≥1 ambient layer, testable per project.

### Ooblets (Glumberland, 1.0 2022)

**Facts.** 2-person core, Epic-funded, ~2 years in Game Preview; divided reviews at 1.0. Daily-capped currency (~35 wishies/day) feeding large mandatory sinks; Game Informer titled its review "A Cheerful Grind."

**We take.** Only the warning. (Its dance-battles show that replacing combat with a minigame still needs depth — replacement is not exemption.)

**We avoid.** Daily-capped currencies with big sinks (forced multi-day stretching experienced as padding); "busywork that pretends to be gameplay… nothing meaningful to do except wait"; waiting-on-meters as pacing. This comp, with Eastshade's cut meters, is why [D6](./00-decisions.md) bans stamina/hunger bars outright — daylight and season are our only clocks.

---

## 4.6 Small-scale worlds — selling mouse height

*Feeds [05 World](./05-world.md), [07 Camera](./07-camera-direction.md), [16 Audio](./16-music-and-audio.md). Full analysis: [small-scale worlds research](../research/07-comps-small-scale-worlds.md). Key distinction: we are a* mouse-civilisation *world (Ghost of a Tale, Moss), not a shrunken-human world (Grounded, Tinykin) — nature at real size is our giant, not spoons.*

### Ghost of a Tale (SeithCG, 2018)

**Facts.** ~90% made solo by ex-DreamWorks animation director Lionel Gallat (+ ~4 part-time), Unity. Direct proof one person can ship a lush mouse world in Unity.

**We take.** Scale grammar inside a same-species world: contrast comes from other creatures and architecture built to *their* proportions (rats ~2× mouse height). His art economy — "simple models and complex materials," camera post-effects as "director of photography" — is our texture-first budget doctrine ([D4](./00-decisions.md)). Interconnected zones with earnable shortcuts.

**We avoid.** Over-dark interiors (his criticised dungeons) — cozy cannot afford murk; our interiors are candle-warm and separately lit ([06 Art](./06-art-direction.md)). And the stealth/threat framing — no predators on screen is canon and pillar.

### Moss / Moss: Book II (Polyarc, 2018/2022)

**Facts.** VR; the diorama *led to* the mouse — sitting at human height looking into a small world felt empowering. One authored stationary camera per room-diorama; a castle landmark visible from every scene; film-grade ear/whisker/breathing micro-animation made players bond with a 10 cm character; score built from physically small instruments (ukulele, hammered dulcimer, Celtic harp).

**We take.** Authored per-location camera framings ([D3](./00-decisions.md) per-location vcams); the mega-landmark visible from everywhere ([D14](./00-decisions.md)); micro-animation as the bonding budget (whiskers before wardrobe); small-instrument scoring ([D12](./00-decisions.md), [16 Audio](./16-music-and-audio.md)).

**We avoid.** Confusing the two scale illusions: the diorama register makes the player a Reader looking in; the low register makes them small inside the scene. Moss chose one; we deliberately author both — Vista tilt-shift vs Near "pallet moments" ([D3](./00-decisions.md) two scale registers) — and never mix them in one shot.

### Tinykin (Splashteam, 2022)

**Facts.** Six rooms of one house, each a highly vertical insect city; "densely packed" was the universal review note — a bedroom "more expansive and exciting to explore than a map from Skyrim."

**We take.** **Furniture is the terrain**: every shelf, drawer, and stair inside our tree-homes is reachable and hides something small ([D14](./00-decisions.md) interior rule). High-frequency, low-stakes pickups keeping every traversal rewarded. Verticality as the answer to the empty floor.

**We avoid.** Their 2D-sprite character trick (charming, cheap, wrong for our painted-3D cast and dollhouse camera); set-piece-only level logic — our spaces must serve schedules and seasons, not one traversal gag.

### Grounded (Obsidian, 2020/1.0 2022)

**Facts.** The whole backyard ≈ **20 m × 20 m** of real lawn, yet takes ~35 min to creep across (~1:200 effective scale) and yields 30+ hours. Grass is an occluding, navigable biome. Central oak placed mid-map as the always-visible landmark (a Fallout: New Vegas lesson). Sequel scaled the world only because mounts raised movement speed.

**We take.** The density-beats-acreage proof behind our 30–50 m hedgerow strip ([D14](./00-decisions.md)); grass-as-forest → the "no bare ground plane > ~5 character-lengths" rule; one mega-landmark breaking the canopy line from every exterior point; world size derived from movement speed, never ambition.

**We avoid.** Survival/threat framing of wildlife (spiders are their tension; ours is weather and fog); the sparse stretches between POIs that even Grounded's reviewers noticed.

### Pikmin 4 (Nintendo, 2023)

**Facts.** The most quotable primary source on manufacturing smallness. The team only *felt* the scale when a prototype camera passed under wooden pallet slats with light shining through. Zoom-linked audio: camera low = footsteps and voices "as if listening with your face close to the ground"; zoomed out = faint tiny-world noises under broad ambience. Footsteps: half human recordings, half "fingers crushing gravel." Miyamoto refused to show a Pikmin next to a battery — exact size kills the fantasy.

**We take.** All four, wholesale: pallet moments (low pivot, light shafts through stems) as the Near register ([D3](./00-decisions.md)); zoom-linked mixer snapshots ([D12](./00-decisions.md), [16 Audio](./16-music-and-audio.md)); the footstep layering recipe with per-material variants; the size-ambiguity rule — never state exact sizes in fiction ([D14](./00-decisions.md); the 10 cm mouse is a production constant, not lore).

**We avoid.** Nothing — this is a pure technique donor.

---

## 4.7 Closest neighbours & cautionary tales

### Winter Burrow (Pine Creek Games / Noodlecake, Nov 2025)

**Facts.** An openly Brambly-Hedge-flavoured cozy mouse game — mice, burrows, knitting, baking. 91% positive on ~1,400 Steam reviews; mainstream coverage; **no legal trouble**, because it copies the vibe, not the name, characters, or illustrations ([IP research](../research/02-ip-licensing.md)).

**We take.** Two load-bearing proofs: (1) the audience for hedgerow-mice cozy games exists and finds them on aesthetics alone — our Plan B (rename) is commercially viable, which is what makes the whole Option C posture safe ([D1](./00-decisions.md)); (2) the legal line's exact position — mice in waistcoats, burrow cross-sections, and seasonal village life are free; names, characters, text, and artwork are not.

**We avoid.** Competing on its ground. It arrived first with the vibe; we must win on what it doesn't have — the storybook camera with dollhouse interiors and the community-progression system. Vibe alone is now taken.

### Tales of the Shire (Wētā Workshop, 2025)

**Facts.** A beloved licence (The Lord of the Rings), cozy hobbit life sim, rich interiors, stylised look — and **59 Metacritic**, with "terrible technical performance" as a headline criticism despite mid-size studio resources. Reviewed as a Stardew-surface clone shipped at shallow depth ([pitfalls research](../research/09-cozy-pitfalls.md)).

**We take.** Only the mirror: it is precisely our risk profile — licence + watercolour-adjacent charm + interior-heavy cozy sim — executed without depth or performance. It is why risk #4 ("pretty but empty") and risk #7 (buggy launch) rank where they do in the [synthesis risk register](../research/00-synthesis.md).

**We avoid.** The licence as a substitute for a game. Our posture is the deliberate inverse ([D1](./00-decisions.md)): built rename-safe so the licence is upside, never the load-bearing wall. And the performance failure: our 60 fps @ 1080p on GTX 1060-class and Steam Deck gate ([D2](./00-decisions.md)) exists so a dense-interior stylised Unity game does not ship as this one did.

### Technique references (not full comps)

| Title | The one thing we use | Consumed by |
|---|---|---|
| The Sims 4 | Dollhouse cutaway interiors with wall/roof fade — the named model in [D3](./00-decisions.md) | [07 Camera](./07-camera-direction.md) |
| Link's Awakening (2019) | Whole-game tilt-shift diorama grammar: focus band, raised saturation, toy-like materials | [07 Camera](./07-camera-direction.md), photo mode |
| Captain Toad | Non-jumping hero keeps spaces diorama-small; occluders that reward the rotation you allow | [05 World](./05-world.md), [D14](./00-decisions.md) verbs |
| It Takes Two (garden chapter) | Tiling-texture materials as landscape at 10 cm scale | [06 Art](./06-art-direction.md) |
| The Wild at Heart | Illustration-first pipeline selling "small creatures, big forest" without simulation | [06 Art](./06-art-direction.md) |
| Discounty (2025) | 5-person team, one deep loop + real narrative, >8 h median, 100k week one — the "narrow, deep, finished" control case | [D5](./00-decisions.md), [20 MVP](./20-mvp.md) |

---

## 4.8 Lessons ranked — the ten most load-bearing cross-game findings

Ranked by how much of this GDD stands on each. Every lesson names its evidence and the binding rule that consumes it.

1. **The community that acts without the player is unoccupied design space.** ACNH, Stardew, and Palia — the genre's 40M+ sellers — are player-centric to the bone: solo bundle-filling, frozen festivals, villagers who cannot move a fence; the loudest late-game complaints in each are symptoms of it. No shipped comp has NPCs that visibly work, propose, and complete shared projects. → [D7](./00-decisions.md), [18 Community Philosophy](./18-community-philosophy.md).
2. **NPC dialogue volume × state-reactivity is the review killer/saver.** ACNH's 8 archetypes, Stardew's post-max loops, Fae Farm's amnesiac greeters vs Fields of Mistria's 5,000+ lines for ~28 NPCs praised for never repeating. Dialogue is a core system, budgeted from month one. → [D9](./00-decisions.md): 4,000–8,000 reactive lines, Yarn Spinner 3 + saliency.
3. **Real-time gating, FOMO, and live-service economics are radioactive here.** Cozy Grove's disclaimer revolt, ACNH's 2021 drought backlash, Palia's $49M → layoffs → distress sale. In-game time only; the player holds the pacing valve (Wylde Flowers' beloved ritual). → [D6](./00-decisions.md), [D11](./00-decisions.md) (no EA, no FOMO ever).
4. **The look lives in authored surfaces, not shaders.** Snufkin's painted albedo, Season's tinted shadows, Dordogne's explicit rejection of animated watercolour filters — nobody ships a watercolour shader. Texture-authorship hours, not shader features, close the gap to a Barklem plate. → [D4](./00-decisions.md).
5. **Density beats acreage, and verticality is the density trick.** Grounded: 30+ hours from 20 × 20 m; every gentle-exploration comp folds a small footprint into a tall space; Tinykin makes a bedroom outclass Skyrim. One 30–50 m hedgerow strip, stacked roots-to-canopy, re-dressed four times, is the whole game. → [D14](./00-decisions.md).
6. **Traversal is the no-combat progression spine — and ours routes through community projects.** Feathers (A Short Hike), fish (Little Kitty), boat gates (Spiritfarer) prove access-as-progression carries a game without XP; no comp ties it to collective labour. Repaired bridge → far bank; mill wheel → lift. → [D7](./00-decisions.md), [15 Progression](./15-progression.md).
7. **Restored things must function, and rewards must be witnessed.** Garden Story's cosmetic rebuilding read as hollow; Stardew's Community Centre is remembered because the town changes; Botany Manor staged every bloom in view. Binding test: every project changes ≥1 schedule + ≥1 service + ≥1 ambient layer, on-screen. → [D7](./00-decisions.md) Function phase.
8. **Price-to-content honesty: ~$4–5/hour is the complaint threshold.** Mail Time (2.5–3 h, $19.99, 86%) and Botany Manor's "cheaper" threads mark the line; Tales of the Shire shows a licence doesn't move it. $19.99 with an honest 25–35 hours. → [D11](./00-decisions.md).
9. **Small, deep, finished wins; the feature checklist kills.** Scope problems are ~23% of all postmortem failures; every ≤3-person success (A Short Hike, Tiny Glade, Eastshade, Discounty) was narrow and dense; every failed cozy comp shipped Stardew's surface at 20% depth. Quarterly cut reviews; anything below "would be praised in a review" depth becomes a journal micro-feature. → [D5](./00-decisions.md), [D16](./00-decisions.md).
10. **Constrained cameras get abandoned under scope pressure unless proven first.** Little Kitty started locked and gave up; Snufkin's single angle was its main criticism; Moss and Captain Toad show authored framing works when the world is designed for it. Hence the first production task is the 2-week camera greybox — before any art or systems. → [D3](./00-decisions.md), [07 Camera](./07-camera-direction.md).

Two honourable mentions that bind elsewhere: **mechanical reciprocity** (Spiritfarer — every favour returns something tangible within one in-game day; [10 Core Systems](./10-core-systems.md)) and **heart-tier bespoke scenes** (Palia's one great idea — points get you *to* the beat, the beat unlocks the tier; [D9](./00-decisions.md), the highest-value content budget in the game).

---

[← Back to Index](./INDEX.md) | [Previous](./03-design-pillars.md) | [Next: World →](./05-world.md)
