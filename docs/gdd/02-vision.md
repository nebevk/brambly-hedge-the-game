# 2. Vision

[← Back to Index](./INDEX.md) | [Previous](./01-working-title.md) | [Next: Design Pillars →](./03-design-pillars.md)

---

## 2.1 High Concept

A storybook life sim at mouse scale. You are a newcomer mouse who moves into a hedgerow (**⚠ DEFAULT — owner to confirm** player identity, per [D9](./00-decisions.md)) — one strip of English hedge, 30–50 real metres of bank, stream, and field margin that at 10 cm tall is an entire world. You explore, gather, cook, and help; the camera glides from a tilt-shift diorama of the whole hedge down into fully furnished cutaway interiors inside trees and stumps; and the community around you proposes, builds, and celebrates its own seasonal undertakings — a spring picnic, a summer wedding raft, an autumn expedition, a winter hall of ice — whether you are there or not. Your reward for joining in is not gold or experience points. It is a place at the table.

**Elevator line:** *A watercolour hedgerow life sim where the camera zooms from the canopy into a cutaway mouse kitchen mid-feast — and the community runs, works, and celebrates with or without you.*

## 2.2 Core Identity (locked)

> **"The first cozy sim where the community demonstrably runs, works, and celebrates with or without you — your reward is belonging, not credit."**

This sentence is locked ([synthesis §3.01](../research/00-synthesis.md)). Every feature must be defensible against it. If a proposed system makes the player the indispensable hero of a town that cannot act — the default shape of every 40M+ seller in the genre — it is off-vision, no matter how proven it is elsewhere.

## 2.3 The Two Marketable Hooks (priority order)

### Hook 1 — The dollhouse camera (the one-GIF hook)

A 5-second clip, no text needed: the camera zooms from the hedgerow exterior through the canopy into a fully furnished cutaway mouse kitchen mid-feast — or the same framed shot flips through four seasons. This is the **Storybook Isometric Camera** with dithered-fade dollhouse interiors ([D3](./00-decisions.md)), and it is canon-native: Barklem's signature image *is* the cutaway cross-section ([canon research](../research/01-brambly-hedge-canon.md)).

Every top-decile cozy hit is explainable in one wordless GIF — Tiny Glade rode exactly this to 1.37M wishlists and 616k copies in a month with zero paid marketing ([market analysis §3](../research/08-market-analysis.md)). Operational consequences:

- Every trailer and vertical clip **opens** on the zoom-into-interior shot or a season-flip.
- 1–2 WIP clips per week from vertical-slice stage onward, with a named owner ([D16](./00-decisions.md), [synthesis §3.20](../research/00-synthesis.md)).
- Gate G1 (month 2) explicitly tests GIF traction of the camera greybox before art or systems investment continues.

### Hook 2 — "You don't build your empire. You build the community."

The Steam short-description line and the design thesis. Progression is community state, relationships, and traversal opened by **community projects** ([D7](./00-decisions.md)) — no XP, no levels, no money, no island rating. Multi-day shared projects give creators episodic arcs to stream; the loop description differentiates on the store page in a market where ~62% of cozy releases share near-identical farming/decorating loops ([cozy pitfalls §1](../research/09-cozy-pitfalls.md)).

Hook order matters: the camera earns the click; the community earns the review.

## 2.4 Positioning — Mechanics-Forward, Never Vibe-Only

"Cozy" is a baseline, not a niche: ~375 cozy-tagged Steam releases in 2024 (2.5× the year before), median 2025 Steam release revenue ~$249 ([market analysis §§1–2](../research/08-market-analysis.md)). Vibe-only cozy dies; mechanics-forward cozy is the second-healthiest genre on Steam (farming/life-sim: 8.3% of 2025 releases reached 1,000+ reviews).

- **Pitch frame:** Life Sim / Exploration + Cozy. Steam tags: Life Sim, Exploration, Cozy, Relaxing, Cute, Farming Sim (adjacent).
- **Store copy leads with verbs** — gather, cook, climb, restore the mill together — the way Stardew and Mistria do, never with adjectives alone.
- We pass the cozy audience's unwritten rules exactly as written (familiar domestic setting, no "shoot" verb, no fail-state pressure) and we never deviate from them — deviation is punished hard in this genre ([market analysis §2](../research/08-market-analysis.md)).

## 2.5 Target Audience

**Primary — cozy/life-sim players on PC + Steam Deck.** The Stardew Valley / Fields of Mistria / Animal Crossing audience, female-majority skew (per the Hozy campaign data — paid social targeting a female-majority cozy audience sold 100k copies in 4 days; [market analysis §3](../research/08-market-analysis.md)). What they demand, operationally:

| Expectation | Our commitment |
|---|---|
| Visible content depth for the price | $19.99 → 25–35 hours across four full seasons ([D11](./00-decisions.md)); $4–5/hour is the complaint threshold |
| Polish over scope | Review quality is the entire multiplier: week-1 top sellers average 91% positive vs 67% for underperformers |
| NPCs that feel alive | 4,000–8,000 reactive lines, ≥200 per major NPC ([D9](./00-decisions.md)) — lifeless NPCs are the genre's #1 review killer ([cozy pitfalls §5](../research/09-cozy-pitfalls.md)) |
| Handheld play | Steam Deck Verified is a hard 1.0 gate ([D2](./00-decisions.md)) |
| No dark patterns | No FOMO, no real-time gating, no monetization mechanics, ever ([D11](./00-decisions.md)) |

**Secondary — Brambly Hedge book nostalgics, UK + Japan strongest.** 7M+ copies sold in 20+ languages; the books' UK and Japanese followings make Japanese localization IP-strategic at 1.0 ([D15](./00-decisions.md), [market analysis §9](../research/08-market-analysis.md)). Canon-layer note ([D1](./00-decisions.md)): this audience is addressable *by name* only after a licence. Pre-licence — and under Plan B — they are reachable on aesthetics alone: Winter Burrow, an openly Brambly-Hedge-flavoured mouse game, hit 91% positive and mainstream coverage with no licence ([IP research §3](../research/02-ip-licensing.md)).

## 2.6 Comparable Set (what each comp proves)

| Comp | What it proves for us | We take | We leave |
|---|---|---|---|
| **Snufkin: Melody of Moominvalley** | Family literary estates licence to small cozy studios; storybook art + no combat carries a press cycle (83 Metacritic) | The brand-guardianship pitch; licensed-IP posture | Its flat top-down camera — its most-cited visual criticism |
| **Tiny Glade** | A one-GIF visual hook can be the whole marketing budget (1.37M wishlists, 616k month-one, 2 devs, $0 spend) | Weekly WIP-clip cadence; "it's alive" micro-reactivity | Sandbox-without-goals shape; no interiors |
| **Stardew Valley** | The numbers skeleton of the genre: day length, schedules, friendship points, festival cadence | The skeleton (recalibrated in [D6](./00-decisions.md)/[D9](./00-decisions.md)) | Farming grind, money endgame, player-as-indispensable-hero |
| **Winter Burrow** | The audience for cozy hedgerow mice exists *right now* (91% positive, ~1,400 reviews, Nov 2025) | Proof for the Plan B market; storybook mouse fantasy sells | Survival meters and pressure — our anti-pillars |

Secondary references — Fields of Mistria (dialogue density benchmark), Discounty (narrow-and-deep at 5 people, 100k week one), A Short Hike (the pre-agreed fallback's shape, [D16](./00-decisions.md)). Cautionary comp: Tales of the Shire — a licence plus shallow loops equals Metacritic 59; the licence is upside only on top of depth ([cozy pitfalls §2](../research/09-cozy-pitfalls.md)).

## 2.7 Emotional Target

**Belonging, not achievement.** The session-end feeling is "I accomplished something today, and something is waiting for me tomorrow" — without a wall, a meter, or a debt ([synthesis §3.09](../research/00-synthesis.md)). The year-one arc is the newcomer becoming a neighbour: first you are invited, then you are expected, then the hedge would feel wrong without you — and its climax reuses the books' own gesture, a community that organises a secret kindness ([D7](./00-decisions.md)).

Tension exists, but it is **gentle jeopardy**: weather, fog, a drifting raft, a child lost in the chestnut woods. The worst outcome anywhere in the game is being *found, cold, and brought home to soup* ([synthesis §3.05](../research/00-synthesis.md), from the canon tone model). The player's biggest worry should be whether the blackberries will ripen before the festival — that is the feeling the books capture, and it is the feeling we ship.

## 2.8 Commercial Frame (summary — binding numbers in D11)

$19.99 (launch −10%) · 25–35 hours · PC/Steam + Steam Deck Verified at 1.0 · announce at Wholesome Direct June 2027 · one Next Fest, late · 25k wishlist floor / 50k goal · launch target Q3 2028, slip a quarter rather than launch under the floor · no Early Access, closed playtest instead ([D11](./00-decisions.md), [D16](./00-decisions.md)).

## 2.9 What This Game Is Not

No combat, no money, no fail states, no meters, no minimap, no real-time gating, no FOMO. These are hard constraints, not marketing copy — the full anti-pillar block with rationale lives in [Design Pillars §3.7](./03-design-pillars.md).

---

[← Back to Index](./INDEX.md) | [Previous](./01-working-title.md) | [Next: Design Pillars →](./03-design-pillars.md)
