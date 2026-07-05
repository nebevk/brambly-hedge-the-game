# IP Strategy — The Option C Playbook

**Status: OPERATIONAL.** This document turns decision [D1](../gdd/00-decisions.md) (Option C: build quiet, pitch, rename-ready) into dated actions, contract guardrails, and the Plan B procedure. Source of record for all facts: [IP & licensing research](../research/02-ip-licensing.md). Created 2026-07-04.

**The posture in one sentence:** we build the vertical slice in private under the codename **Project Hedgerow**, pitch Rockpool from strength in early Q2 2027, and hold a fully rehearsed rename (Plan B) that loses only the name — so the licence is upside, never a single point of failure.

[← Back to GDD Index](../gdd/INDEX.md) | [Risk Register →](./risks.md)

---

## 1. Position — the facts (as of 2026-07-04)

| Fact | Detail |
|---|---|
| Rights holder | **Four Seasons Licensing and Merchandising Ltd** (UK co. 08917167), directed by Jill Barklem's children Peter Barklem and Elizabeth (Lizzie) Bryer |
| Licensing agent | **Rockpool Licensing**, London — MD **Vickie O'Malley** (vickie@rockpool-licensing.co.uk); estate contact enquiries@bramblyhedge.co.uk |
| Copyright | Runs to **31 December 2087** (Barklem d. 2017; life + 70). Not a grey area |
| Trademark | Asserted by Four Seasons; formal register position unknown until the UK IPO search (§3) |
| TV option | **Lupus Films** optioned screen rights Feb 2020; still listed "in development" mid-2026 — six years without a greenlight |
| Brand momentum | 45th anniversary push (2025): companion book, redesigned line, growing merchandise programme; Rockpool calls the brand at "a tipping point" |
| Games history | **No Brambly Hedge video game has ever existed** (2000s craft CD-ROMs aside). Rockpool's stated categories omit digital/games entirely |
| Best precedent | **Snufkin: Melody of Moominvalley** — small studio, family estate, new visual style permitted, 83 Metacritic, second game followed |
| Unlicensed precedent | **Winter Burrow** — openly Brambly-Hedge-flavoured mouse game, 91% positive, zero legal action, because it copies the vibe, not the name/characters/compositions |

What this adds up to: the estate is active, professional, and will notice us; the category is empty; family estates of exactly this type say yes to small cozy studios; and the legal line between homage and infringement is well mapped. Detection probability of any public use of the name: high, within days.

### The two content layers (D1/D17, restated operationally)

- **Canon layer:** every use of Brambly Hedge names, characters, locations, story beats, and recipes-as-named. Lives only in this private repo and in localisation/data tables. Never leaves team machines except in the pitch build (§4).
- **Rename-safe layer:** everything else — all pillars, systems, the camera, the art doctrine, the economy, the world *shape*. This layer is the game; the canon layer is a skin we hope to keep.

---

## 2. Why Option C (one paragraph)

Option A (pitch first, build after) wastes the strongest card we will ever hold — a playable slice proving the team ships. Option B (original IP from day one) forfeits a licence worth real wishlists, press, and 40 years of nostalgia without ever asking. Option C builds the slice under a codename, pitches with it, and keeps Plan B one week away at all times. Licence odds are ~30–40% ([research](../research/02-ip-licensing.md)); the plan must be excellent in both branches — and it is, because nothing in the [MoSCoW scope](../gdd/00-decisions.md) depends on the name.

---

## 3. Immediate actions (July–August 2026)

1. **UK IPO trademark search — ~£170.** Search "BRAMBLY HEDGE" word marks and figurative marks across all classes, specifically **class 9** (software/games) and **class 41** (entertainment services), plus 16/28 for completeness ([gov.uk/search-for-trademark](https://www.gov.uk/search-for-trademark)). Output: a one-page memo of exactly which classes are registered. This sharpens both the pitch (we know what we are licensing) and the Plan B boundary (we know what the rename must clear).
2. **One hour with a UK IP solicitor (budget £200–400).** Agenda, in order: (a) confirm the passing-off exposure of any "hedge"-adjacent title; (b) review the Plan B legally-distinct checklist in §7 and amend it; (c) sanity-check the option-agreement ask in §4; (d) confirm that pitch-deck use of book imagery, clearly marked as rights-holder property, is defensible fair-dealing for a private pitch.
3. **Codename hygiene — apply this week, audit monthly** (folded into the [risk register ritual](./risks.md), risk R01):
   - Repo, Discord server, cloud folders, build pipelines: named **Project Hedgerow** or neutral. The repo may *contain* canon names in data files (it is private, per D1) but its name, URL, and any CI badges must not.
   - Build metadata: executable name, window title, Steam internal app name, crash-reporter strings, company/product fields — codename only. Canon names live in localisation tables, never in identifiers a stack trace or file dialog can leak.
   - Streams/screenshots/devlogs: nothing canon on screen — check OBS scenes, editor hierarchy panels, file paths, browser tabs. Rule of thumb: before any capture, load the **codename content flavour** (below).
   - Two content flavours from the data layer, buildable from day one: **Canon flavour** (canon names/text; pitch use only; watermarked "Concept — Brambly Hedge © Four Seasons Licensing; unlicensed pitch material") and **Codename flavour** (placeholder original names; used for playtests, festivals, captures, and any build that leaves team machines).
   - Domains/socials: register neutral codename handles now; do **not** register anything containing "brambly" (that itself signals intent and could be read as bad faith).
4. **Open a licensor-watch note** in this file's changelog: track Lupus Films status, Rockpool trade-press items, and anniversary-programme news quarterly. A broadcaster announcement changes pitch timing (§4) and price.

---

## 4. The pitch plan

### Timing

- **Preconditions:** G2 passed (vertical slice playable end-to-end), the deck below finished, trademark memo + solicitor consult done.
- **First contact no later than 2027-03-15.** [D1](../gdd/00-decisions.md) targets "~Q2 2027"; we read that as the *start* of Q2, because the hard 3-month window (§6) must close before the **Wholesome Direct June 2027** announce beat ([D11/D16](../gdd/00-decisions.md)) so we announce under whichever identity we actually own. Materials freeze: end of February 2027.
- **Lupus Films clause:** if a broadcaster greenlight is announced before we pitch, pitch immediately regardless of slice polish — a show in production is the estate's strongest-ever motive to want a game, and the price only rises from there.

### The approach

Email Vickie O'Malley (vickie@rockpool-licensing.co.uk), cc enquiries@bramblyhedge.co.uk. One page: who we are, one embedded clip of the dollhouse-camera slice (canon flavour, watermarked), the brand-guardianship thesis, and a request for a 30-minute call. Deck and build on request — never attached cold.

### The deck (10 pages, in this order)

1. **The image the books own:** Barklem's signature cutaway interiors — and our camera doing it live. One page, mostly one picture.
2. **Brand guardianship:** no combat, no fail states, no monetisation gimmicks, botanical accuracy per season, festivals and shared work as the loop. The game is the books' values, playable.
3. **The Snufkin precedent:** family estate + small studio + new-visual-style permission → 83 Metacritic → a second game. Hyper Games' trust arc is the relationship we are proposing ([research](../research/02-ip-licensing.md)).
4. **The slice, playable:** storybook camera, one community project end-to-end, seasonal look-dev. Proof the team ships.
5. **Canon fidelity:** the community-project system is lifted from the books' own undertakings; the Store Stump economy; the journal. Page of receipts.
6. **Market:** the empty category (no BH game ever), Winter Burrow proving the audience, cozy-market sizing, JA/UK nostalgia geography.
7. **The team** and how a 2-person studio de-risks: gated production, PC-first, closed playtests.
8. **Business terms sketch** (below) — the ask, framed small and platform-sliced.
9. **Approvals & style-guide workflow** we *propose* (shows we understand licensing; pre-negotiates the SLA of §5).
10. **Timeline:** option now → licence at demo → launch Q3 2028, alongside (not ahead of) the TV project's windowing.

### The ask and the expected shape

- **Ask:** a **12–18 month option** (low fee) to develop under the name, converting to a full licence on milestone approval; **PC/console only, worldwide, 5-year term** + 12-month sell-off; first option on mobile ports and sequels. The Rovio/Moomin mobile carve-out is the precedent that platform slicing is normal and keeps the ask small.
- **Expected terms:** ~**10–15% royalty on net receipts**, a **low-five-figure minimum guarantee** (recoupable), staged approvals (concept/art/builds/marketing), **£5–15k** contract legal. Open at 10% and platform-sliced; the passion-project framing has room to negotiate down.
- **⚠ DEFAULT — owner to confirm:** budget appetite for the pitch — option fee, royalty band, MG ceiling, and legal spend ([D1](../gdd/00-decisions.md)). No number above is committed until the owner signs it off.

---

## 5. Negotiation guardrails

Targets vs walk-away lines. Crossing a walk-away means Plan B is the better business, whatever the sentiment.

| Clause | Target | Walk-away line |
|---|---|---|
| **Approval SLA** | ≤5 working days for marketing assets (clips/GIFs/screenshots), ≤15 for milestone builds; silence = deemed approved after 10 working days; asset-*class* pre-approval for style-guide-compliant material | No SLA at all, or marketing turnaround >10 working days with no deemed-approval clause — this kills the weekly clip cadence ([D16](../gdd/00-decisions.md); risk [R13](./risks.md)) |
| **Streaming / content** | Written confirmation that player streaming, our devlogs, and press keys need no per-item approval | Per-video licensor approval of third-party content |
| **Royalty / MG** | ≤12% net, MG low five figures spread over the term | >15% net, or an MG that consumes >10% of the production budget (**⚠ DEFAULT — owner to confirm** the exact ceiling, D1) |
| **Term** | 5 years + 12-month sell-off, renewal option | <3 years, or no sell-off period |
| **Platform scope** | PC/console worldwide; mobile excluded is acceptable (Rovio precedent) | Steam excluded, or territory carve-outs that break EFIGS+CJK launch ([D15](../gdd/00-decisions.md)) |
| **Sequels / DLC** | Season-sized expansions covered under the same licence; first option on a second game | Every content update requiring a renegotiation |
| **Art authority** | "Distil the essence" mandate per the Snufkin precedent — style-guide compliance, not plate-tracing; our look-dev is the reference | Obligation to match the TV series' look, or approval authority over game *design* (vs presentation) |
| **Crowdfunding** | Explicit permission to crowdfund the licensed game if the Kickstarter path fires ([D16](../gdd/00-decisions.md)) | Silence — an ambiguous clause discovered mid-campaign is fatal |
| **Game-original assets** | Merchandising of game-original designs reserved to licensor: acceptable. Our code, systems, and engine assets remain ours unambiguously | Any claim on the rename-safe layer or on our technology |

---

## 6. The 3-month decision window — mechanics

Two clocks, both hard. The point of the window ([D1](../gdd/00-decisions.md)) is that indecision is the one outcome we cannot afford: every week in limbo is a week the announce beat, Steam page, and marketing identity stay frozen.

**Clock 1 — contact.** T0 = pitch email sent (by 2027-03-15).
- T0 + 3 weeks: follow-up 1 (add one new proof point — a fresh clip).
- T0 + 6 weeks: follow-up 2, flagged final ("we're timetabling our announcement and need to know whether to hold the door").
- T0 + 8 weeks with no substantive reply: **Plan B triggers.** An auto-acknowledgement is not substantive; substantive = a human engaging with the materials.

**Clock 2 — decision.** From first substantive contact: **13 weeks** to a signed option (or full licence). Only a signature stops the clock — enthusiasm, meetings, and "circling back" do not. At 13 weeks without signature: **Plan B triggers.**

**Irrevocability.** Once Plan B triggers, the rename executes (§7) and is never undone for 1.0 — re-renaming mid-production is a second swap cost plus a marketing identity reset. A late yes from the estate is welcome news *for a future product* (sequel, expansion, second game), and we say exactly that in the polite close-out email, which keeps the relationship warm.

**Logging.** Every contact, date, and clock state is logged in the changelog below and reviewed weekly under risk [R01](./risks.md) during the window.

---

## 7. Plan B — the rename playbook

**Trigger:** either clock in §6 expiring; a refusal; a C&D; or terms crossing a §5 walk-away with negotiation exhausted.

### What must change (with the legal test each item must pass)

| Item | Requirement | Pass test |
|---|---|---|
| Title | No "Brambly"; no "Hedge" paired in a way that echoes the mark | Solicitor sign-off vs the IPO search memo; no passing-off likelihood |
| Character names & designs | All original; no Barklem lookalikes (Wilfred Toadflax, Poppy Eyebright, Primrose, Mr Apple et al. gone entirely) | Side-by-side vs book plates: no character recognisable to a fan |
| Location names | Old Oak Palace, Store Stump, the dairy/mill *names* replaced | Zero canon strings anywhere player-visible |
| Map likeness | The recognisable *ensemble* (palace-oak + store-stump + dairy + mill arrangement) recomposed; generic elements (an oak, a stump, a mill) individually fine | Our map and the endpaper map are not mistakable; landmark silhouettes differ |
| Text | No sentences, rhymes, or recipe wording lifted from the books; food *facts* (blackberries in autumn) are free | Full-text audit of the 60–80k word corpus vs canon quotes file |
| Marketing | Never names Brambly Hedge in store copy, tags, or press notes; "inspired by classic British picture books" is safe — press and players will make the connection for free, as with Winter Burrow | Store page + press kit review before publishing |

### What survives — untouched

Every pillar and every system: the storybook camera and dollhouse interiors, community projects, the Store-Stump-style contribution economy (renamed), the journal, seasons and festivals, the art doctrine, the world shape, all code, all tooling, the schedule. Mice in waistcoats, hedgerow burrows, cutaway interiors as a device, and cozy foraging are unprotected style — **Winter Burrow is the live proof** (91% positive, zero legal action — [research](../research/02-ip-licensing.md)). The pitch loses one word: the name.

### The one-week content swap (rehearsed, not improvised)

Prerequisite (standing, from month one): the rename-ready data layer of [D1/D2/D15](../gdd/00-decisions.md) — every name and story string in localisation/data tables, zero literal strings in code or prefabs, and a **replacement-name table** maintained in parallel (each canon name has a pre-chosen original counterpart, drafted by the owner well before it is ever needed).

| Day | Work |
|---|---|
| 1 | Freeze content; branch `plan-b`; swap localisation tables to the replacement-name set; run the ID validator + full-text scan for canon terms across code, prefabs, and scenes (must return zero — it has been zero since month one if D15 held) |
| 2 | Map-likeness pass: rename zones, recompose the hero-landmark ensemble, adjust 2–3 silhouettes (the palace-oak analogue foremost) |
| 3 | Character audit vs plates: costume/palette/silhouette deltas on any borderline design; regenerate portraits and journal sketches affected |
| 4 | Text pass: audit story strings and recipe wording against the canon-quotes file; re-read journal prose for lifted phrasing |
| 5 | Identity assets: final title (pre-cleared with the solicitor from a shortlist prepared in advance), logo/wordmark, build metadata, store page copy, press kit |
| 6–7 | Buffer + sign-off: run the full legally-distinct checklist above; solicitor spot-check on title and map; team plays one full in-game day in the renamed build |

Output: a legally distinct game with identical review scores waiting inside it. Cost: one week + a pre-cleared title shortlist + the discipline we were keeping anyway.

---

## 8. Communication rules until resolution

**Absolute (any breach = risk R01 trigger review within 48 h):**
- Nothing public under the name "Brambly Hedge" — no Steam page, devlog, trailer, social post, store metadata, festival submission, or playtest callout ([D1](../gdd/00-decisions.md)).
- No Barklem artwork in any build or in any distributed/captured material; book imagery is limited to (a) the private pitch deck, marked as rights-holder property, and (b) internal reference/calibration boards inside the private repo per [D4](../gdd/00-decisions.md) — never on stream, in builds, or in anything that leaves team machines.
- No canon names/designs in anything captured or distributed: external builds, streams, screenshots, GIFs all use the **codename flavour** (§3).

**Freely allowed under Project Hedgerow (and encouraged — the marketing engine must run):**
- Camera greybox and tech clips with zero canon assets — the dollhouse cutaway, snap rotation, and zoom bands are our technology and read gorgeously even in greybox.
- Watercolour look-dev of generic hedgerow botany, original mouse designs (non-lookalike), music sketches, tooling devlogs.
- The M4–5 Steam page ([D16](../gdd/00-decisions.md)) goes live under the codename or a licensed name only — never as a bet on the licence.

**If asked directly** ("is this Brambly Hedge?") — by press, players, or community: "We're big fans of classic British picture books, and we're not announcing the game's final identity yet." Never confirm, never wink with canon material. If the licence lands, the reveal is a gift; if Plan B lands, nothing was promised.

**If it leaks:** no comment, no denial, take down anything we control that names the brand, and notify Rockpool proactively if we are already in contact — being the ones who report our own leak is a trust move, not a confession.

---

## 9. If the licence signs — first fortnight

1. Announce plan locked to **Wholesome Direct, June 2027** ([D11](../gdd/00-decisions.md)): dollhouse-camera trailer under the real name.
2. Style-guide intake session with Rockpool; convert §5's approval SLA into a shared approvals calendar aligned to the weekly clip cadence.
3. Swap the Steam page to the licensed identity; canon flavour becomes the shipping flavour (the data layer stays — it is also the localisation system).
4. Japanese market plan brief (JA localisation is IP-strategic, [D15](../gdd/00-decisions.md)); coordinate with the estate's Asia sub-agent history.
5. Begin the Hyper Games trust arc deliberately: hit the first three approval milestones early. The second game on this IP is won in the first year of the first.

---

## Changelog / licensor watch

| Date | Entry |
|---|---|
| 2026-07-04 | Document created. Lupus Films option: still "in development", no broadcaster. No games licensee exists. Next check: 2026-10 (quarterly). |

---

[← Back to GDD Index](../gdd/INDEX.md) | [Decisions Brief](../gdd/00-decisions.md) | [Risk Register →](./risks.md)
