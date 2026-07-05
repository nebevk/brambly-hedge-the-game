# 21. Long-Term Vision

[← Back to Index](./INDEX.md) | [Previous](./20-mvp.md)

The game ships **complete at 1.0** (target Q3 2028, [D11](./00-decisions.md)). Everything in this section is built on that foundation: the long-term plan is not a promise of endless content, it is (1) a second in-game year that keeps surprising people, designed *before* launch; (2) two free festival updates; (3) two candidate paid expansions mapped to the canon expedition books; (4) a possible console port; and (5) a licence relationship — or an owned IP — that outlives the first game. It is explicitly **not** a live service, and the never-list at the end is binding.

One distinction matters throughout: **"year two" means the player's second in-game year** (the calendar loops after the fourth festival), while **"post-launch" means real-world time**. The year-two plan ships inside 1.0; the updates and expansions come after.

## The Shape of the Years Ahead

| When (real-world) | What | Paid? |
|---|---|---|
| Q3 2028 | 1.0 on PC/Steam + Steam Deck Verified, complete, 25–35 hours ([D11](./00-decisions.md)) | $19.99 |
| Launch + ~3–9 months | **Free update 1: the Midsummer wedding festival**, timed to a Wholesome-adjacent Steam sale beat | Free |
| Launch + ~12 months | **Free update 2: the Snow Ball** (snow-conditional) + photo-mode upgrades, timed to a winter sale | Free |
| Launch + 6–12 months | **Switch 2 port decision** — only after PC recoups; outsourced, not built in-house (Eastshade's porting lesson, [scoping research](../research/13-scoping-and-production.md)) | Port |
| 2029–2030 | **Expansion candidate A: the Salt Voyage** (Sea Story) — season-sized, decided on 1.0 telemetry | Paid |
| Later | **Expansion candidate B: the Vole Expedition** (The High Hills) | Paid |

---

## Year-Two Novelty: The Anti-Content-Cliff Plan (ships inside 1.0)

The content cliff is risk #5 in the [risk register](../research/00-synthesis.md): a finite handcrafted world, and reviewers who publish the hour they ran out. The countermeasure is bought before launch: **≥20% of the game's reactive material only ever fires in in-game year two or later**, so the review sentence we are buying is "it was still surprising me in year two". This is not DLC — it is base-game content behind simulation state, and it is a design budget, not a hope.

**The rule, operationalised:** every Yarn node, festival variant, and scene carries condition tags; a `year2plus` tag marks content that requires `gameYear >= 2` (or a state only reachable then). At the content-complete milestone (Plan B M21), an automated audit counts tagged vs total content; **the build does not go to beta below 20%.**

### Year-two budget (what the 20% is made of)

| Category | 1.0 total | Year-2+ reserved | Notes |
|---|---|---|---|
| Reactive dialogue lines | 4,000–8,000 ([D9](./00-decisions.md)) | **≥800–1,600 (≥20%)** | A "second time through" axis added to the existing reactivity axes (season × weather × friendship × project × festival): NPCs remember last year's picnic weather, the first bridge crossing, who moved in when |
| Festival variants | 2–3 state-reactive variants per festival ([D10](./00-decisions.md)) | **≥1 variant per festival is year-2-only** | e.g. the second spring picnic toasts the previous year's project; Midwinter's Eve recalls the player's first winter |
| Second-year NPC micro-arcs | — | **6–8 arcs, 2–3 beats each** | Cheap formats by design: letters, supper toasts at the weekly hedgerow supper, a returning expedition visitor, an anniversary walk — *not* new heart-scene-class bespoke scenes (that budget is protected for 1.0's 40–50 scenes, [D9](./00-decisions.md)) |
| Post-max friendship stream | — | Seasonal letters + standing invitations | So maxed friendships feel settled, not dead ([synthesis](../research/00-synthesis.md)) |
| Relationship milestone chain | Engagement → wedding → Naming Day ([canon calendar](../research/01-brambly-hedge-canon.md)) | Chain begins in year one, pays off in year two | The wedding beat completes with free update 1 if the wedding festival ships post-launch per the D10 default |
| Journal | Mrs Apple's matrilineal diary pages ([canon](../research/01-brambly-hedge-canon.md)) | Year-2 diary pages unlock | The journal itself records that a year has passed — the world's memory made visible |

### The Snow Ball: rarity from weather, never from the clock

The Snow Ball is canon-conditional: it happens only when snow lies deep enough to carve an Ice Hall "in the time-honoured way" ([canon](../research/01-brambly-hedge-canon.md)). In game terms: a deep-snow winter is a weather roll, deliberately uncommon, so most players meet the Snow Ball in their second or third winter — a genuine surprise that costs nothing at review time and pays out for years. It arrives with free update 2. **Its rarity comes from simulated weather, never from the real-world calendar** — that is the whole difference between a delight and a FOMO mechanic.

---

## Free Post-Launch Festival Updates

Per [D10](./00-decisions.md), 1.0 ships two full festivals (default: spring picnic + Midwinter's Eve) and two more follow as **free updates**:

1. **The Midsummer wedding** — raft on the stream, flower-decked; cold watercress soup, honey creams, syllabubs and wild strawberries; Lord Woodmouse officiating with Old Vole ([canon](../research/01-brambly-hedge-canon.md)). The strongest emotional set-piece in the books; as an update it doubles as the year-one re-engagement beat and completes the engagement→wedding→Naming Day chain.
2. **The Snow Ball** — as above, snow-conditional.

⚠ DEFAULT — owner to confirm: which two festivals ship at 1.0 (mirrors [D10](./00-decisions.md)). If the owner swaps the wedding into 1.0, the update slate reshuffles (picnic or Snow Ball moves post-launch) and 1.0 cost rises; this section follows the default until then.

**Update discipline:**

- Each update is timed to a **Wholesome/seasonal Steam sale beat** — the update is the reason the algorithm and the press look again; this is where year-two revenue lives (the Tiny Glade / Cozy Grove update-tail pattern, [scoping research](../research/13-scoping-and-production.md), [synthesis](../research/00-synthesis.md)).
- Updates carry a small bundle: the festival, photo-mode/"storybook plate" upgrades ([D13](./00-decisions.md)), a handful of journal pages, QoL fixes. Small, dense, free.
- Updates are **never** time-limited in game. The sale timing is a marketing beat; the content is permanent from the moment it installs.

---

## Paid Expansion Candidates (post-1.0, decided on telemetry)

The books hand us the expansion format: two of the eight are **expedition stories** — the community leaves the hedge, and the structure is exactly our five-phase community project ([D7](./00-decisions.md)) stretched over a journey. That means expansions are *content, not new systems*: one new zone, 3–5 new scheduled NPCs, one expedition-shaped project, one celebration, roughly **5–8 hours** — "season-sized". Pricing and order are decided on 1.0 sales/telemetry, not now.

### Expansion A — the Salt Voyage (*Sea Story*, 1990)

- **Canon spine:** salt runs scarce; Dusty's boat *Periwinkle* sails downstream to **Sandy Bay and Seagull Rock**, where the **Saltapple sea mice** gather salt from the rocks ([canon](../research/01-brambly-hedge-canon.md)).
- **Why it is canon-native design:** the Store Stump economy already makes scarce imports the quest driver ([D8](./00-decisions.md)); salt is the named canonical scarce good. The expansion turns an existing economic fact into a journey.
- **Shape:** fit out the Periwinkle (Contribution) → the voyage (staged Construction-equivalent, with the TV adaptation's storm as the gentle-jeopardy beat — worst outcome remains "found, cold, and brought home to soup") → salt harvest with the Saltapples → homecoming celebration → Function: salt stores full, new recipes, a standing trade route and letters from Sandy Bay.
- **New content:** Sandy Bay zone (coastal palette — a fifth "book" for the art system), Saltapple household (3–5 scheduled NPCs), boat traversal set-piece.

### Expansion B — the Vole Expedition (*The High Hills*, 1986)

- **Canon spine:** the hedge supports the poorer upland **voles** with woven blankets; **Mr Apple leads the expedition**; **Flax and Lily** weave; the hills hold mist, rock faces and legendary gold ([canon](../research/01-brambly-hedge-canon.md)).
- **Why it fits:** 1.0's autumn project is already the blanket drive ([D7](./00-decisions.md)); the expansion extends it from "gather and weave" to "carry them up and meet the people you wove them for" — mutual aid made walkable.
- **Shape:** weaving push → the climb (mist and getting-lost as the tension model) → the vole settlement (a visibly different, sparser community — class-without-conflict handled with canon's gentleness) → return. Function: voles appear at hedge festivals thereafter; wool trade opens.
- **New content:** upland zone (mist, crags — the art system's moody register), vole settlement, 3–4 scheduled NPCs, Wilfred's "intrepid explorer" thread for returning players.

**Licence dependency, stated plainly ([D1](./00-decisions.md)):** on the licensed path these are book adaptations and need licensor approval — which is also their press hook ("the game adapts *Sea Story*"). On Plan B they become original expeditions — a coast voyage for a scarce good, an upland trek to a neighbouring community — same zones, same shapes, same systems, different names. The rename-safe layer means the expansion plan survives either future without losing a design pillar.

---

## Two Futures: the Licensed Trust Arc vs Plan-B Ownership

**If the licence is signed:** the model is Hyper Games with the Moomins — ship *Snufkin* well, be a careful guardian of the brand, and earn the second project on the same IP ([synthesis](../research/00-synthesis.md)). For us the arc is: 1.0 faithful and polished → free festival updates demonstrate stewardship → expansions adapt further books with the estate's blessing → the studio becomes *the* Brambly Hedge games partner, with the UK and Japan nostalgia markets ([D15](./00-decisions.md) makes JA a 1.0 language for exactly this reason). Costs of this future: royalties (~10–15% band, [D1](./00-decisions.md)) and approval latency — streaming/content rights and approval turnaround must be confirmed before signing, or the weekly-clip marketing cadence dies ([synthesis](../research/00-synthesis.md)).

**If Plan B:** the original hedgerow IP is **ours**. No royalty, no approvals, sequel and merchandise freedom, and every hour invested in world, cast and tone compounds into an owned asset instead of a licensed one. The expansions above ship under our names; the "trust arc" becomes a straightforward franchise. Plan B loses the licence's press hook and the nostalgic audience — and nothing else, by construction ([D1](./00-decisions.md)).

**If G4 sends us to the fallback** (the A-Short-Hike-class 4–6 hour exploration game, [D16](./00-decisions.md)): the long-term vision shrinks honourably rather than dying. The fallback is a complete, sellable game in the same world; its success re-opens the road to the full life-sim as "the next game" — and the expansion designs above become that pitch.

---

## The Never-List (binding)

These are permanent, in every future above, and they are marketing claims as much as design rules — the cosy audience has been burned and rewards studios that keep this contract:

- **No live service.** No content treadmill obligations; updates are gifts, not schedules. Tiny Glade's developers refused to publish a roadmap at 500k players — that restraint is the model ([scoping research](../research/13-scoping-and-production.md)).
- **No real-world-time calendars, daily logins, or expiring content** — ever, in any update or expansion ([D6](./00-decisions.md); Cozy Grove's real-time gating provoked its audience, [synthesis](../research/00-synthesis.md)).
- **No premium currency. No rotating shops. No battle passes, reward tracks, paid cosmetic drip, or any FOMO mechanic** ([D11](./00-decisions.md)).
- **No Early Access** ([D11](./00-decisions.md)) and no paid beta by another name.
- **No multiplayer, no procgen content filler** ([D5](./00-decisions.md)) — the game's value is that every corner was composed by hand.
- The standing warning is **Palia**: $49M raised, live-service cosy MMO, two rounds of layoffs and a distress sale ([synthesis](../research/00-synthesis.md)). The genre's economics reward small, finished, and honest — not persistent and extractive.

The test for any future feature proposal: *would Mrs Apple recognise it as neighbourly?* Deposits into a shared larder, yes; a rotating shop with a countdown timer, never.

---

## End State

What all of this is for — the description we should still recognise in 2030:

- **A small, finished, handcrafted world** — one hedgerow, four seasons, perhaps a coastline and a hill country beyond it — where every path leads somewhere composed, and the camera makes every arrival look like a page from a book.
- **A community that demonstrably runs without you**: mice who work, celebrate, marry, and name their babies whether or not you attended — and who remember, in their second year, that you were there in their first.
- **A player relationship built on trust**: the game you bought was complete; everything that arrived later was a gift; nothing you loved was ever taken away or put on a timer.
- **A world worth returning to** — not to grind, not to keep up, but because it is warm in there: players come back the way readers take the books down off the shelf, to live in Brambly Hedge for a while.
- **A studio reputation** — as the careful guardians of a beloved licence, or as the makers of their own beloved hedge — that makes the *next* game easier to fund, announce, and sell than this one was.

This GDD grows with the project (the set is intended to reach roughly 80–120 pages of implementable detail); this section is its fixed point. Whatever changes between here and 2030, the never-list does not.

[← Back to Index](./INDEX.md)
