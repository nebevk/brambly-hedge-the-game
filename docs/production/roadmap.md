# Production Roadmap — Project Hedgerow

**Status: working plan, revised at every gate.** This document turns the binding production shape ([D16](../gdd/00-decisions.md)) into a dated, month-by-month plan with entry/exit criteria per gate. Where this document and the [decisions brief](../gdd/00-decisions.md) disagree, the brief wins. Step-level detail for Sprint 0 → vertical slice lives in [GDD 20 — MVP](../gdd/20-mvp.md) and the [backlog](./backlog.md); engineering doctrine in [GDD 19 — Technical Direction](../gdd/19-technical-direction.md). Evidence base: [scoping research](../research/13-scoping-and-production.md), [systems architecture research](../research/12-tech-systems-architecture.md), [camera research](../research/11-tech-camera.md).

[← GDD Index](../gdd/INDEX.md) | [Decisions Brief](../gdd/00-decisions.md) | [Backlog →](./backlog.md)

---

## 1. The Shape at a Glance

Two plans, four gates, one pre-agreed fallback. The reasoning: the full design is an 8–12 person-year game and we have ~5 person-years at 2 FTE, so full production is only entered on market proof ([scoping research §1](../research/13-scoping-and-production.md)).

| Phase | Months | Calendar | Deliverable | Gate |
|---|---|---|---|---|
| **Plan A** — camera greybox + look-dev slice | M1–M2 | Jul–Aug 2026 | Proven camera, one ship-quality postcard corner | **G1** GIF traction (end M2) |
| **Plan A** — vertical slice | M3–M6 | Sep–Dec 2026 | Summer village core, 5 NPCs, one compressed project arc, 20–30 min | **G2** playtest + per-asset cost model (end M6) |
| **Plan A** — Steam page (parallel track) | M4–M5 | Oct–Nov 2026 | Page live under **codename or licensed name only** ([D1](../gdd/00-decisions.md)) | — |
| **Plan A** — demo hardening | M7–M10 | Jan–Apr 2027 | Public demo, 30–45 min median playtime | **G3** ≥2,000 wishlists pre-fest |
| **Plan A** — Next Fest + funding push | M10–M12 | Apr–Jun 2027 | One Next Fest entry (June 2027; Oct 2027 fallback), publisher/grant push | **G4** go/no-go (M12) |
| **Plan B** — full production | M13–M21 | Jul 2027–Mar 2028 | Four seasons content-complete, 12 NPCs, 4 projects, 2 festivals | Alpha (content-complete) M21 |
| **Plan B** — beta, localisation, cert | M21–M26 | Mar–Aug 2028 | Localised (EFIGS + zh-Hans + JA), Steam Deck Verified, RC | Beta exit M26 |
| **Plan B** — launch window + buffer | M26–M30 | Aug–Dec 2028 | **1.0 launch, target Q3 2028** (Sep); slip a quarter rather than launch under 25k WL ([D11](../gdd/00-decisions.md)) | Launch |
| **Fallback** (if G4 fails) | M13–M24 | Jul 2027–Jun 2028 | 4–6 h A-Short-Hike-class exploration game, same world/art/camera (§5) | Ships on the same Steam page |

Month numbering: **M1 = July 2026** (now). The IP track (§7) and marketing/funding track (§8) run in parallel throughout.

---

## 2. Plan A, Month by Month (Jul 2026 → Jun 2027)

### M1 — July 2026: Sprint 0, then the camera greybox

- **Week 1 — Sprint 0** ([backlog §2](./backlog.md)): fresh Unity 6.3 LTS + URP project, pinned packages, Git + LFS before the first binary, six `Hedgerow.*` asmdefs, Boot scene + TimeService stub, save-system walking skeleton, localisation bootstrap, ID registry + validator, weekly-build script producing build #1. Exit = [GDD 19.14 checklist](../gdd/19-technical-direction.md) green.
- **Weeks 2–3 — camera greybox, the first production task ([D3](../gdd/00-decisions.md))**: the full [GDD 20 Step 1](../gdd/20-mvp.md) build; acceptance rows C1–C7 all green, including 60 fps on GTX 1060-class and Steam Deck with the grass stress test.
- **Week 4** — comfort playtest (3+ external testers), fix pass, or begin the ≤2-week iteration loop inside the D3 tuning bands. **If the dollhouse fade or comfort cannot go green, stop: no art is commissioned until the flagship works.**
- Parallel (art seat): Barklem plate studies, texture-authorship tests — reference work only, zero production assets.
- IP track starts this month (§7): UK IPO trademark search + one solicitor hour.

### M2 — August 2026: Look-dev slice → Gate G1

- One hedgerow exterior pocket at **target ship quality** (full [D4](../gdd/00-decisions.md) pipeline: hand-painted albedo, hero uber-shader, storybook full-screen pass), one dressed dollhouse interior with working roof fade, one player mouse with locomotion. Zero NPCs.
- Buy the first asset-cap purchases as needed (stylised grass ~$35, height fog ~$20 — [GDD 19.3](../gdd/19-technical-direction.md)).
- Season LUT proof: the same pocket under two seasonal gradings ("same hedge, two books").
- Capture 3–5 clips (clip #1: the camera pulling from Vista into the lit interior) and post under **Project Hedgerow**, rename-safe content only. **→ G1 (§4).**

### M3–M6 — September–December 2026: Vertical slice → Gate G2

The slice scope is binding in [GDD 20 Step 3](../gdd/20-mvp.md): summer village core (Store Stump + stream + broken footbridge), 3 dollhouse interiors, 3 fully scheduled NPCs + 2 presence NPCs, full gather→cook→deposit loop, one community project compressed to a ~3-in-game-day arc, journal skeleton, full day/night, controller + KBM, 20–30 minutes median. Month-level sequencing:

| Month | Systems seat | Content seat |
|---|---|---|
| **M3** (Sep) | TimeService full, schedule interpreter + FSM, gathering + inventory, dialogue pipeline (Yarn Spinner 3 + Localization) | Village-core layout greybox, Store Stump interior begun, forage set |
| **M4** (Oct) | Cooking + Store Stump deposits, journal shell, **schedule visualizer (due before the 3rd schedule — [D9](../gdd/00-decisions.md))**, Mr & Mrs Apple schedules | Crabapple kitchen, Mill ground floor, prop families; **Steam page assets** (key art, 6–8 screenshots, 45–60 s trailer) |
| **M5** (Nov) | Project state machine + footbridge arc, Dusty schedule + presence NPCs, sleep-save integration | Zone dressing complete, celebration supper set-piece, costume variants; **Steam page live** (see below) |
| **M6** (Dec) | Slice polish, save inspector in use, playtest instrumentation | Far-bank pocket (post-project reward), dialogue pools complete; **external playtest, 10–15 testers → G2 (§4)** |

- **Per-asset cost logging is a daily ritual from M3**, not a reconstruction at G2 — every asset class gets actual hours logged as it is made ([GDD 20 G2 table](../gdd/20-mvp.md)).
- **M4–M5 — Steam page track**: page goes live *quiet* (no PR beat) under the codename, at key-art quality, to start the wishlist clock and enable playtest distribution. Weekly GIF cadence (1–2 clips/week) starts at page-live with a named owner. The *loud* announce is Wholesome Direct, June 2027 ([D11](../gdd/00-decisions.md)); the ≤18-month page-to-launch discipline is measured from that loud announce (June 2027 → Sep 2028 = 15 months), while the quiet page merely accrues early wishlists.

### M7–M10 — January–April 2027: Demo hardening

Target: a public demo holding a **30–45 minute median** (Gold-tier demos hold a median 38 minutes; [demo benchmarks](../research/13-scoping-and-production.md)).

- **M7–M8**: demo content pacing (one full in-game day + the complete project arc + the shared-supper golden moment as the capstone); full save pipeline (versioned migrations, rotating backups, corrupt-file fallback); options + day-one accessibility set ([D15](../gdd/00-decisions.md)); rebinding complete; **photo mode with the storybook-plate tilt-shift render — ships from the first public build ([D13](../gdd/00-decisions.md))**.
- **M9**: **Rockpool pitch goes out — first contact no later than 15 March 2027** (§7; pitch materials frozen end of February per [ip-strategy §4](./ip-strategy.md), so the hard 3-month decision window closes before the June announce). Performance pass to the [GDD 19.4 budgets](../gdd/19-technical-direction.md) on GTX 1060 + Steam Deck; pseudo-localisation stress test; telemetry (opt-in): median session length, day completions, demo→wishlist notes. Demo build to cozy streamers/curators **2–4 weeks before the fest**. Wholesome Direct June 2027 submission confirmed (submission windows close in early spring — verify by February 2027).
- **M10**: **G3 check (§4)**. Publisher pitch deck v1 built on demo telemetry. Slovene Enterprise Fund P2 application prepared (§8).

### M10–M12 — April–June 2027: Next Fest + funding push

- **M10–M11**: Rockpool decision window running (§7 — pitch went out by 15 March at M9; follow-up clocks per [ip-strategy §6](./ip-strategy.md)). Next Fest build submitted; micro-influencer support ($5–10k envelope) arranged only if funded.
- **M12 (June 2027)**: **Wholesome Direct announce** (dollhouse-camera trailer) + **Steam Next Fest June 2027** — entered only with ≥2,000 wishlists banked (G3); otherwise the entry moves to **October 2027** (a game gets one Next Fest, ever — spend it well; games entering with <1,000 WL gained a median of 462; [funnel numbers](../research/13-scoping-and-production.md)). The Rockpool decision window closes by mid-June, before the announce — we announce under whichever identity we actually own (§7).
- Funding push: publisher conversations open **only after demo telemetry exists**; terms floor ≥70/30 after itemised recoup with marketing excluded ([D16](../gdd/00-decisions.md)). Kickstarter is considered only with demo + ~10k wishlists.
- **→ G4 (§4), the hard go/no-go, at M12** (decision meeting mid-July 2027, two weeks after fest data lands).

---

## 3. Quarterly External Deadlines (the A Short Hike rule: exactly one per quarter)

| Quarter | External deadline |
|---|---|
| Q3 2026 | G1 GIF drop (end August) |
| Q4 2026 | G2 external playtest (December) |
| Q1 2027 | Demo to streamers/curators + Wholesome Direct submission + Rockpool pitch (first contact by 15 March — §7) |
| Q2 2027 | Wholesome Direct announce + Next Fest (June); Rockpool decision window closes by mid-June, before the announce |
| Q3 2027 | G4 executed; funding closed |
| Q4 2027 | Autumn season package content-complete (Plan B) |
| Q1 2028 | Winter + Spring packages; alpha (M21, March) |
| Q2 2028 | Localisation delivered; Steam Deck Verified submission |
| Q3 2028 | **1.0 launch (September target)** |

---

## 4. Gates — Entry and Exit Criteria

Gate verdicts are written down the day they are decided, with the numbers that produced them. No gate is passed "in spirit".

### G1 — GIF traction (end M2, 31 Aug 2026)

| | Criteria |
|---|---|
| **Entry** | Camera greybox rows C1–C7 green; look-dev pocket + interior at ship quality; 3–5 clips captured; rename-safe audit passed (no canon names in captions, signage, file names, metadata — [D1](../gdd/00-decisions.md)) |
| **Exit (pass)** | Per [GDD 20 G1](../gdd/20-mvp.md): ≥1 clip earns clearly organic traction — operational floor: **≥10× the posting account's baseline engagement, or a front-page run on one relevant community** (r/cozygames-class). Inbound "wishlist where?" comments count double |
| **On fail** | Iterate the *art direction*, 2–4 weeks per loop, maximum two loops; then an owner-level conversation about the art bar before any slice art is made. The delta between "toon shader + paper texture" and "Barklem plate" is texture-authorship hours (risk #10, [synthesis](../research/00-synthesis.md)) — G1 forces that truth at its cheapest |

### G2 — Playtest verdicts + per-asset cost model (end M6, 31 Dec 2026)

| | Criteria |
|---|---|
| **Entry** | Internal slice build, 20–30 min; 10–15 external playtesters recruited (not friends-of-team only); asset-hours log complete for every class built |
| **Exit (pass)** | Both halves per [GDD 20](../gdd/20-mvp.md): **(1)** all four validation goals green (camera C1–C7 + screenshot vote ≥6/10; median unguided session ≥20 min; ≥60% name NPCs for "who repaired the footbridge?"; ≥50% say "cosy/charming" unprompted); **(2)** measured per-asset hours extrapolated to 1.0 counts fit ≤ ~24–30 person-months of content labour *including* the 25–30% buffer |
| **Conditional** | Goals green, costs over → **cut 1.0 scope on paper now** (quarterly scope rule [D5](../gdd/00-decisions.md) applied early), then proceed |
| **On fail** | Camera or loop red → no demo content; rework the failing pillar or hold the G4 fallback conversation early |

### G3 — Wishlist floor before the fest (checked M10, re-checked at fest lock)

| | Criteria |
|---|---|
| **Entry** | Steam page live ≥5 months; weekly GIF cadence running; demo in streamer/curator hands |
| **Exit (pass)** | **≥1,000 wishlists before the public demo releases; ≥2,000 before Next Fest entry** ([D11](../gdd/00-decisions.md)) |
| **On fail** | Defer the (single) Next Fest to October 2027; spend the summer on demo quality + creator outreach. G4 still executes at M12 on trajectory evidence — a deferred fest is itself a data point |

### G4 — Hard go/no-go (M12; decision meeting mid-July 2027)

| | Criteria |
|---|---|
| **Entry** | Next Fest data (or deferral decision) in hand; demo telemetry ≥4 weeks; funding conversations concluded to offers-or-silence; Rockpool window status known |
| **Exit → Plan B** | **≥7–10k wishlist trajectory OR ≥€100k funding secured** ([D16](../gdd/00-decisions.md)). Operational reading of "trajectory" (this document's implementation): ≥7,000 WL at the meeting, **or** ≥4,000 WL with trailing 4-week net adds averaging ≥250/week post-fest. "Funding secured" means signed — grant award letter, executed advance, or escrowed crowdfunding, not a warm meeting |
| **Exit → Fallback** | Anything less → pivot to the pre-agreed fallback game (§5), **irrevocably**. ⚠ DEFAULT — owner to confirm the fallback pre-commitment ([D16](../gdd/00-decisions.md)) |
| **Inputs on the table** | WL count + velocity; demo median playtime vs the 38-min Gold tier; fest performance; per-asset cost actuals; cash runway; licence state (§7) |

---

## 5. The Fallback Game (pre-agreed at G4-fail — defined now, so the pivot is a decision, not a design project)

**Shape:** a 4–6 hour A-Short-Hike-class cosy exploration game in the same world, with the same art pipeline and the same Storybook Isometric Camera — the two proven differentiators — and **one big community project as its narrative spine**. This shape is itself proven and award-winning (A Short Hike: ~1 person-year, IGF Grand Prize; [scoping research §1](../research/13-scoping-and-production.md)).

| Element | Fallback specification |
|---|---|
| Length / price | 4–6 hours; $9.99–14.99 band (working assumption, priced to content per [D11](../gdd/00-decisions.md)'s never-price-above-content principle; set at G4) |
| World | The demo's village core + far bank, plus 1–2 new pockets (upper hedge via the mill, stream source); no new zones beyond that |
| Spine | Act 1 = the footbridge arc (exists, from the demo). Acts 2–3 = **one big project: restoring the Flour Mill** — full five-phase template ([D7](../gdd/00-decisions.md)), traversal unlock (mill-wheel lift → upper hedge), finale celebration as the single festival set-piece |
| Seasons | **Scripted story moments, not a calendar**: 3–4 authored season turns (LUT + dressing swaps) at story beats; no season valve, no 14-day calendar |
| NPCs | 5–6 named NPCs on **two-block time-of-day placements** (morning/evening posts), not full schedule simulation; dialogue pools ~80–120 lines each; no hearts/gifts system — friendship advances through story beats |
| Kept systems | Gathering, cooking (~12 recipes), journal-as-UI, photo mode, Store Stump deposits (simplified) |
| Cut | Gardening, fishing, relationship hearts, 12-NPC schedules, festival calendar, second/third/fourth community projects |
| Timeline | G4-fail (Jul 2027) → content-complete ~M20 (Feb 2028) → polish + localisation (language set reviewed at G4; default keeps [D15](../gdd/00-decisions.md)) → **launch Q2–Q3 2028** |
| Steam | Ships on the **same Steam app** — every accrued wishlist carries over |
| IP | Identical rename posture; if the licence somehow lands late, the fallback benefits equally |

Everything built in Plan A is reused; nothing is wasted. This is why the fallback is credible: at G4 roughly 80% of the fallback's systems and 50% of its content already exist.

---

## 6. Plan B — Months 13–30 (Jul 2027 → Dec 2028, 1.0 in Q3 2028)

### Phase B0 — production foundation (M13–M14, Jul–Aug 2027, overlapping B1)

- Re-baseline the whole plan from **measured** G2 per-asset costs (not estimates); lock the 1.0 asset counts.
- IP fork executed (§7): licensed rename beat, or the ~one-week original-IP rename sprint.
- Funding closed and banked; audio/music contract signed (budgeted contracting envelope **€18–32k** total across production — [funding.md §2](./funding.md); the ~€25–50k band in [scoping research §6](../research/13-scoping-and-production.md) is the research reference, not our budget).
- Pipeline hardening: seasonal re-dress workflow batched (LUT sets + colormap swaps + dressing sets — seasons are a data problem, [D4](../gdd/00-decisions.md)); dialogue authoring cadence established (~100–160 implemented lines/week toward the 4,000–8,000 line budget, [D9](../gdd/00-decisions.md)).

### Phase B1 — content production by season package (M13–M21)

Each season ships as a complete **content package**; the package checklist is identical each time (this is the repeatable unit the whole schedule hangs on):

> zone re-dress (4–5 LUTs, foliage colormaps, dressing set) · botanical forage set + recipes · seasonal schedule variants for all live NPCs · seasonal dialogue pass (season × weather × friendship × project axes) · the season's community project, all five phases · festival or lighter celebration set-piece · ambient audio set.

| Months | Package | Contents beyond the checklist | NPC roster ramp |
|---|---|---|---|
| M13–M15 (Jul–Sep 2027) | **Summer** completed to 1.0 | Slice zone → full zone; Midsummer wedding-raft project ([D7](../gdd/00-decisions.md)); its Celebration is a lighter set-piece at 1.0 — the full wedding festival ships post-launch ([D10](../gdd/00-decisions.md)) | 5 → 8 scheduled |
| M15–M17 (Sep–Nov 2027) | **Autumn** | Blanket drive/expedition project; salt-import expedition quest ([D8](../gdd/00-decisions.md)); gardening system lands here (Should — reuses gather + time) | 8 → 10 |
| M17–M19 (Nov 2027–Jan 2028) | **Winter** | Ice Hall project; **Midwinter's Eve — full festival #1** | 10 → 12 |
| M19–M21 (Jan–Mar 2028) | **Spring** | Picnic-logistics project; **spring picnic — full festival #2**; Secret Staircase exploration reward in Old Oak Palace; **secret cottage refurbishment as the year-one climax** ([D7](../gdd/00-decisions.md)) | 12 (complete) |

Running threads across B1, protected in this order ([D9](../gdd/00-decisions.md) — heart-scenes are the highest-value content in the game):

1. **Heart-scenes**: 40–50 bespoke scenes ≈ 5/month from M13 — this budget is cut last, after everything else.
2. Relationship system (hearts, gifts, journal auto-preferences) lands M13–M14; weekly hedgerow supper scene M14.
3. Dialogue to 4,000–8,000 lines; ≥3 permanent lines per involved NPC per completed project; word budget 60–80k **enforced** by the word-count reporter ([GDD 19.11](../gdd/19-technical-direction.md)).
4. Marketing cadence continues: weekly clips, monthly devlog, Tiny Teams (Aug 2027) and Cozy Quest (Nov 2027) showcases.

**Alpha = content-complete at end M21 (March 2028).** Anything not in by M21 is cut to a journal micro-feature per [D5](../gdd/00-decisions.md) — the quarterly scope reviews (end of M15, M18, M21) exist to make those cuts early and on purpose.

### Phase B2 — beta, localisation, cert (M21–M26, Mar–Aug 2028)

- **M22: text lock + string freeze** (word budget verified ≤80k *before* freeze — we pay per word eight times, [D15](../gdd/00-decisions.md)). Translation EFIGS + zh-Hans + JA M22–M24; LQA M24–M25.
- **Closed beta (not Early Access — [D11](../gdd/00-decisions.md))** M21–M26: weekly full-playthrough tests; the #1 targets are save corruption and project/quest blockers ([GDD 19.6](../gdd/19-technical-direction.md)); accessibility completion + Steam accessibility metadata.
- Performance to gate on GTX 1060 + Steam Deck at every weekly build; **Steam Deck Verified submission M24, with a planned re-submission round M26** — Verified is a 1.0 commercial requirement ([D11](../gdd/00-decisions.md)). "Cert" for this game = Steam pre-release review + Deck verification; there is no console cert at 1.0.
- Music completion, launch trailer, press/creator kit; year-2 content plan finalised pre-launch (≥20% novel second-year material — [GDD 21](../gdd/21-long-term-vision.md)).

### Phase B3 — launch window + buffer (M26–M30, Aug–Dec 2028)

- Release candidate at M26. **Launch September 2028 (M27) if wishlists ≥25k; otherwise slip a quarter** (Dec 2028) rather than launch under the floor ([D11](../gdd/00-decisions.md)). 50k is the goal; at the median 0.15× WL→week-1 conversion, 25k ≈ ~3.7k week-1 sales — survival, with year-2 revenue living in the free-update tail (festival #3/#4, timed to a Wholesome sale).
- M26–M30 is **the explicitly budgeted Unpacking 2× buffer** (§9) — it absorbs slip, day-0 patching, and the launch-quarter support load. It is not a content phase.

---

## 7. The IP Track (parallel, month one onward)

Full strategy: [D1](../gdd/00-decisions.md), the [IP strategy playbook](./ip-strategy.md), and the [IP research](../research/02-ip-licensing.md). Hard rule throughout: **no public use of "Brambly Hedge" anywhere until a licence is signed** — public identity is **Project Hedgerow**; canon names live only in the private repo's localisation/data layer.

| When | Action |
|---|---|
| **M1 (Jul 2026)** | £170 UK IPO trademark search (word mark "BRAMBLY HEDGE", especially classes 9/41) + one-hour IP solicitor consult; codename hygiene audit (build metadata, asmdef names, file names — [GDD 19.5](../gdd/19-technical-direction.md) already mandates `Hedgerow.*`) |
| M2–M8 | 10-page brand-fit deck built alongside the slice: visual target vs scanned plates, no-combat community design, Snufkin/Hyper-Games brand-guardianship framing; refreshed with slice/demo footage as it lands; **materials freeze end of February 2027** ([ip-strategy §4](./ip-strategy.md)) |
| **M9 — first contact by 2027-03-15** | **Pitch Rockpool Licensing** (Vickie O'Malley), copying the estate: playable slice/demo build + deck; timed so the hard 3-month window closes before the June 2027 announce ([ip-strategy §4](./ip-strategy.md)); initial ask = a **12–18 month option** converting to a full PC licence. ⚠ DEFAULT — owner to confirm budget appetite (option fee, ~10–15% royalty, low-five-figure MG, £5–15k legal — [D1](../gdd/00-decisions.md)) |
| Pitch + 3 months | **Hard decision window**: 3 months from first substantive contact, closing by mid-June 2027; silence after 2 follow-ups = No. Before signing anything: confirm streaming/content-creation rights and approval turnaround — slow approvals would kill the weekly-clip cadence ([synthesis §3.20](../research/00-synthesis.md)) |
| **Fork point (by M13, Jul 2027 latest)** | **Licensed** → rename the Steam page to the licensed name as a second PR beat ("Project Hedgerow *is* Brambly Hedge"), lean into JA localisation strategically. **Not licensed** → the ~one-week rename sprint: string tables, key art, Steam metadata — no code, no IDs, no save formats change ([GDD 19.5](../gdd/19-technical-direction.md)); commit to the original IP irrevocably |

The licence is upside, never a dependency: every plan in this document works identically under either name.

---

## 8. Marketing & Funding Track (summary — numbers from [D11](../gdd/00-decisions.md)/[D16](../gdd/00-decisions.md))

- **Sequence**: quiet Steam page (M4–5) → weekly GIF cadence with a named owner → Wholesome Direct June 2027 announce (20–25k WL goal for the beat) → cozy festival circuit → closed playtest → single Next Fest → launch Sep 2028 at ≥25k WL.
- **Funding stack (Slovenia)**: SEF **P2 startup grant (€54k)** — application prepared M10, submitted at the first open call with the demo in hand; → **publisher advance or Kickstarter** post-demo (Kickstarter only with demo + ~10k WL; €60–150k target); Creative Europe DEVVGIM requires a commercially shipped title since Jan 2023 — not eligible for this project, but the fallback game or 1.0 unlocks it **for the next project** ([scoping research §6](../research/13-scoping-and-production.md)). ⚠ DEFAULT — owner to confirm funding path preference ([D16](../gdd/00-decisions.md)).
- **Publisher floor**: ≥70/30 after itemised recoup, marketing excluded; never sign before demo telemetry exists (an advance costs ~10 points of revenue share on average).
- **Budget frame**: ~€140–220k cash for 2 people × 30 months, including €18–32k contracting (music, animation help, trailer, LQA — [funding.md §2](./funding.md)) and the ~$250 asset cap; partial VO ($10–15k) only as a funded stretch ([D12](../gdd/00-decisions.md)).

---

## 9. Buffer Policy (binding practice)

1. **Every plan-level estimate carries a 25–30% buffer** ([D16](../gdd/00-decisions.md)). The month-by-month tables above already include it; a "green" month means green *with* buffer intact.
2. **The Unpacking 2× rule is budgeted explicitly as M26–M30** (5 months ≈ 26% of Plan B's 19 months) — teams that plan 1.5 years take ~3 ([scoping research §2](../research/13-scoping-and-production.md)). That buffer absorbs slip and launch support; it never funds features.
3. **Buffer is spent only by decision, never by drift**: consuming buffer requires a named call at a weekly build review or quarterly scope review, recorded with the reason.
4. **Cost overruns are answered with scope, not schedule**: if G2's measured costs exceed plan by >30%, or any quarterly review finds a system below "would be praised in a review" depth, the cut list runs Could → Should → journal micro-feature ([D5](../gdd/00-decisions.md)). The content-complete date (M21) and the launch quarter move only as the very last resort — and launch slips by quarters, not weeks.
5. **Weekly re-estimation** (A Short Hike's discipline): every open backlog story is re-estimated weekly; trend lines, not single misses, trigger scope conversations.
6. **No crunch-dependent plan**: any schedule that only works at >40 h/week is treated as red at the next review (Barone's 70-hour weeks and Smushi's collapse are the cautionary precedents, [scoping research](../research/13-scoping-and-production.md)).

---

## 10. Team Assumptions (~2 FTE) — and what changes at 1 or 3

**Base plan: ~2 FTE.** ⚠ DEFAULT — owner to confirm team size, FTE status and cash runway ([D16](../gdd/00-decisions.md)).

- Seat A — systems/code, camera, tech-art, build/tooling. Seat B — art (texture authorship is the single biggest quality lever — [D4](../gdd/00-decisions.md)), modelling, dressing. Design and writing are shared; music/audio, animation help, trailer and LQA are contracted (Eastshade model: <€50k of contractors, [scoping research §1](../research/13-scoping-and-production.md)).
- Arithmetic sanity: 2 FTE × 30 months = 60 person-months ≈ 5 person-years — roughly half of Stardew's system count, which is exactly what the [D5 MoSCoW](../gdd/00-decisions.md) buys.

**At 1 FTE** (solo, art contracted or the bar dropped):

- Plan A stretches ~1.5–2×: greybox + look-dev M1–M4, slice M5–M10, demo M11–M15; the single Next Fest moves to Feb or Jun 2028; G4 moves to ~M16–18.
- Full Plan B scope stops being honest (1.0 would land ~2030): **the fallback shape (§5) becomes the default plan**, with G4 asking whether the *full* game is earnable rather than whether to retreat from it.
- Contracted character/environment art becomes a budget line (~$800–3,500 per rigged character, $100–1,500 per prop at 2025 outsourcing rates — [scoping research §3](../research/13-scoping-and-production.md)); G1 becomes even more decisive because art hours are now cash.

**At 3 FTE** (third seat = artist/tech-artist):

- Content-complete pulls in from M21 to ~M18–19; the Should tier is secured rather than hoped for (gardening early, both festivals rich, the 40–50 heart-scenes comfortable) and the [D10](../gdd/00-decisions.md) wedding-festival swap becomes affordable to reconsider.
- Cash need rises to roughly €210–330k on the same per-person frame. Gates and their thresholds **do not change** — market evidence does not scale with headcount.
- The third person is spent on **content depth, never new systems** (Ooblets: 2 people, many systems, 6.5 years — the standing warning, [scoping research §1](../research/13-scoping-and-production.md)).

---

## 11. Standing Rituals (start in M1, never stop)

| Ritual | Cadence | Source |
|---|---|---|
| Weekly build: Windows + Deck, smoke test, GTX 1060 + Deck profile | Weekly | [GDD 19.12](../gdd/19-technical-direction.md) |
| 10-random-screenshots "book plate" vote, tracked build over build | Weekly build | [D3](../gdd/00-decisions.md) |
| Backlog re-estimation | Weekly | [scoping research §2](../research/13-scoping-and-production.md) |
| Asset-hours logging into the G2 cost model | Continuous | [GDD 20](../gdd/20-mvp.md) |
| GIF/clip published (post page-live) | 1–2 per week | [D11](../gdd/00-decisions.md) |
| Scope review: every system tested against "would be praised in a review" | Quarterly | [D5](../gdd/00-decisions.md) |
| Gate verdict written with its numbers | G1–G4 | this document |

---

[← GDD Index](../gdd/INDEX.md) | [Decisions Brief](../gdd/00-decisions.md) | [Backlog →](./backlog.md)
