# Risk Register — Project Hedgerow

**Status: LIVE.** Created 2026-07-04 from the research sweep. This is the working register for the whole project; it is reviewed on the ritual below and updated in place. Where it conflicts with the [Binding Decisions Brief](../gdd/00-decisions.md), the brief wins.

[← Back to GDD Index](../gdd/INDEX.md) | [IP Strategy →](./ip-strategy.md)

---

## How to read this register

**Likelihood** — probability the risk fires before 1.0 if we do nothing beyond current plans:
- **Low** <15% · **Medium** 15–45% · **High** >45%

**Impact** — what happens if it fires:
- **Fatal** — the project cannot ship, or ships as something no one wants.
- **Critical** — the game ships but the core pitch ("you build the community") fails; reviews below the 85% floor.
- **High** — material damage to revenue, schedule, or trust; recoverable at real cost.
- **Medium-High / Medium** — a bad quarter, not a bad project.

**Owner** — who drives mitigation. On a team of ~2 FTE (**⚠ DEFAULT — owner to confirm** team size per [D16](../gdd/00-decisions.md)) the only values are **Owner** (the project owner/lead personally) and **Both** (whole team, in the weekly plan).

**Cadence** — how often the risk is re-scored, in addition to the standing ritual below.

Every risk carries **leading indicators** — observable, checkable signals that fire *before* the risk does. If an indicator fires, the risk gets an out-of-cycle review within 48 hours.

---

## The register review ritual

1. **Monthly (first working Monday):** walk every open risk in ID order. Re-score likelihood/impact, check each leading indicator against reality, update mitigations, retire or add risks, log one line per changed risk in the changelog. Close by naming the **Top 3 live risks** for the month — these get explicit time in the next four weekly plans.
2. **At every gate (G1, G2, G3, G4 per [D16](../gdd/00-decisions.md)):** full register review is part of the gate. A gate cannot pass while any **Fatal**-impact risk has a fired indicator without a written response.
3. **Trigger reviews:** any leading indicator observed mid-month → that risk is reviewed within 48 hours, not parked for the monthly.
4. **Honesty rule:** skipping the monthly review because "too busy" is itself indicator R15-c (burnout). The review takes ≤60 minutes; it is never the thing to cut.

---

## Summary

| ID | Risk | Likelihood | Impact | Owner | Cadence |
|---|---|---|---|---|---|
| R01 | IP infringement / licence refusal | High (unmanaged) → Low (managed) | Fatal | Owner | Monthly + gates; **weekly** during pitch window |
| R02 | Scope death | High | Fatal | Both | Monthly + gates + quarterly scope review |
| R03 | NPC dialogue exhaustion / lifeless community | High | Critical | Both | Monthly + gates |
| R04 | "Pretty but empty" verdict | Medium-High | Critical | Both | Monthly + G2/G3 |
| R05 | Content cliff + price mismatch | Medium-High | High | Owner | Quarterly + G4 |
| R06 | Camera/tech risk (dollhouse, fade, perf) | Medium | High | Both | Weekly during greybox; monthly after |
| R07 | Buggy launch / platform quality | Medium | High | Both | Monthly; weekly in beta |
| R08 | Market invisibility in the cozy glut | Medium | High | Owner | Monthly + G1/G3/G4 |
| R09 | Funding shortfall / runway | Medium | High | Owner | Monthly + gates |
| R10 | Art-direction gap ("toon shader ≠ Barklem plate") | Medium | Medium-High | Both | Monthly + G1 |
| R11 | Unity licensing/pricing change | Low-Medium | Medium-High | Owner | Quarterly |
| R12 | Key-person loss (bus factor 1) | Low | Critical | Both | Quarterly |
| R13 | Licensor approval latency kills marketing cadence | Medium (if licensed) | High | Owner | Monthly once licensed; contract gate before |
| R14 | Playtest recruitment failure | Medium | Medium-High | Owner | Monthly from M3 |
| R15 | Health / burnout | Medium | Critical | Both | **Monthly, never skipped** |
| R16 | Steam algorithm / discovery shifts | Medium | Medium-High | Owner | Quarterly |
| R17 | Localisation QA scope blowout | Medium | Medium-High | Both | Quarterly; monthly from M18 |
| R18 | Save corruption reputation damage | Low-Medium | High | Both | Monthly in beta; every `saveVersion` bump |

---

## R01 — IP infringement / licence refusal

- **Description:** Brambly Hedge is family-owned (Four Seasons Licensing), agent-managed (Rockpool), copyrighted to 2087, trademark-asserted, and mid-relaunch. Unlicensed public use of the name is certain detection, C&D, and store takedowns; licence odds are only ~30–40% ([IP research](../research/02-ip-licensing.md)). This is the #1 project risk and it is resolvable.
- **Likelihood / Impact:** High if unmanaged, Low under Option C discipline / **Fatal**.
- **Leading indicators:** (a) any public artefact — repo leak, stream frame, build metadata, store page — containing the name or canon assets; (b) unsolicited contact from Rockpool or Four Seasons; (c) a Lupus Films broadcaster announcement (changes pitch economics both ways); (d) UK IPO search confirming class 9/41 registrations; (e) the 3-month pitch decision window opening.
- **Mitigations:** the full [Option C playbook](./ip-strategy.md) — codename hygiene, rename-ready data layer, canon-layer quarantine, £170 trademark search + solicitor hour now, pitch ~Q2 2027, hard 3-month window, then Plan B irrevocably ([D1](../gdd/00-decisions.md)).
- **Contingency:** C&D received → comply within 24 hours (take down everything named), engage the solicitor, and execute the [Plan B rename playbook](./ip-strategy.md#7-plan-b--the-rename-playbook) the same week.
- **Owner / cadence:** Owner. Monthly + every gate; weekly during the pitch window.

## R02 — Scope death

- **Description:** The design as originally dreamed is an 8–12 person-year game; we have ~2.5–5 person-years. Every ≤3-person/≤3-year success had one mechanic or was short; scope/feature-creep is ~23% of all postmortem problems ([scoping research](../research/13-scoping-and-production.md)).
- **Likelihood / Impact:** High / **Fatal**.
- **Leading indicators:** (a) weekly re-estimation shows remaining Must-scope > 75% of remaining person-months; (b) G2 per-asset cost extrapolation exceeds the Plan B budget; (c) any Must system below "would be praised in a review" depth at its milestone; (d) stretch-tier tasks appearing in the core tier of the backlog; (e) a new system idea entering the plan without a MoSCoW ruling.
- **Mitigations:** binding MoSCoW ([D5](../gdd/00-decisions.md)); community projects prototyped first; A-Short-Hike-style tiered backlog + weekly re-estimation + one external deadline per quarter; per-asset costs measured in the slice *before* committing to 1.0 scope; quarterly scope review with the cut-to-journal-micro-feature rule.
- **Contingency:** G4 fail → pivot to the pre-agreed fallback: an A-Short-Hike-class 4–6 hour exploration game in the same world, one big community project as its spine. **⚠ DEFAULT — owner to confirm** the fallback pre-commitment ([D16](../gdd/00-decisions.md)).
- **Owner / cadence:** Both. Monthly + gates + the quarterly scope review.

## R03 — NPC dialogue exhaustion / lifeless community

- **Description:** Repetitive or wooden NPCs are the single most repeated criticism across failed cozy games (Fae Farm, Hokko Life, Kynseed, ACNH); a 150-line pool is exhausted in under a season of daily chat. Our pitch *is* the community — this kills it faster than any other quality failure ([pitfalls research](../research/09-cozy-pitfalls.md)).
- **Likelihood / Impact:** High / **Critical**.
- **Leading indicators:** (a) a playtester hears a repeated line within one 30–45 min demo session; (b) written line count below trajectory — ≥150 implemented lines in the G2 slice (3 scheduled NPCs × ~40–60 lines + presence bark pools, per the [slice spec](../gdd/20-mvp.md)), ≥50% of the 4,000-line floor by M18; (c) any NPC still using placeholder greeting pools two milestones after introduction; (d) dialogue schema (season × weather × friendship × project flags) not implemented in Yarn Spinner by end of month one.
- **Mitigations:** dialogue treated as a core system per [D9](../gdd/00-decisions.md): 4,000–8,000 reactive lines, ≥200/major and ≥80/minor NPC, Yarn Spinner 3 Line Groups + saliency from month one, ≤12 deep NPCs rather than 20 shallow, ≥3 permanent post-project lines per involved NPC, weekly hedgerow supper concentrating visible NPC social life.
- **Contingency:** cut NPC count before cutting lines-per-NPC; Fields of Mistria's density (~180 lines/NPC at EA) is the survival floor.
- **Owner / cadence:** Both. Monthly + gates.

## R04 — "Pretty but empty" verdict

- **Description:** Watercolour raises expectations; every failed comp shipped the genre checklist gorgeous and hollow (Tales of the Shire: LotR licence + Metacritic 59). Cozy players forgive small scope but not thin execution ([pitfalls research](../research/09-cozy-pitfalls.md)).
- **Likelihood / Impact:** Medium-High / **Critical**.
- **Leading indicators:** (a) G2 median playtest session <20 min; (b) demo median <30 min at M10; (c) playtest verbatims containing "pretty but…", "nothing to do", "shallow"; (d) a completed favour that returns nothing tangible within one in-game day (reciprocity-rule violation); (e) any restoration/project that is cosmetic-only.
- **Mitigations:** 2–3 interlocking deep loops instead of the checklist; the reciprocity rule; every project's Function phase forced to change ≥1 schedule + ≥1 service + ≥1 ambient layer ([D7](../gdd/00-decisions.md)); Discounty/Mistria as depth benchmarks; external playtests from M6.
- **Contingency:** depth sprint on the weakest loop, funded by cutting a Could-tier system to a journal micro-feature.
- **Owner / cadence:** Both. Monthly + G2/G3.

## R05 — Content cliff + price mismatch

- **Description:** A finite handcrafted world with no procgen empties out; reviewers publish the hour it happened (10 h Everdream, 13.5 h Paralives). $4–5/hour is the complaint threshold ([pitfalls research](../research/09-cozy-pitfalls.md)).
- **Likelihood / Impact:** Medium-High / High.
- **Leading indicators:** (a) internal full playthroughs projecting <25 hours through four seasons; (b) any season completing in <6 hours of normal play; (c) year-2 novelty content (<20% novel) unstarted by content-complete; (d) price discussion drifting above $24.99.
- **Mitigations:** honest 25–35 h target at $19.99 ([D11](../gdd/00-decisions.md)); year-2 design ≥20% novel (festival variants, second-year arcs, snow-conditional Snow Ball) built pre-launch; state-reactive festivals; "we say the game is small in every trailer."
- **Contingency:** slip a quarter to add depth, or lower price — never pad with grind.
- **Owner / cadence:** Owner. Quarterly + G4.

## R06 — Camera/tech risk

- **Description:** Dollhouse cutaway, occluder fade, snap rotation, and min-spec performance are individually proven but unproven *together*; comps abandoned locked cameras as scope grew ([camera research](../research/11-tech-camera.md)).
- **Likelihood / Impact:** Medium / High.
- **Leading indicators:** (a) any greybox checklist item failing (interactables at all 8 yaws, fade artefacts, tween interrupts); (b) frame time >16.6 ms at 1080p on GTX 1060-class or Steam Deck in target scenes; (c) occlusion edge-case bugs accumulating faster than they close; (d) the 10-random-screenshots vote trending down two builds running.
- **Mitigations:** the 2-week camera greybox is the **first production task** ([D3](../gdd/00-decisions.md)); dither-fade not alpha; perf budget + Deck gate from pre-production; Unity 6.3/URP migration in sprint 0 while it is free ([D2](../gdd/00-decisions.md)).
- **Contingency:** reduce zoom bands or interior count before ever compromising the 8-yaw rule or the 60 fps gate.
- **Owner / cadence:** Both. Weekly during greybox; monthly after.

## R07 — Buggy launch / platform quality

- **Description:** Cozy audiences punish jank as hard as anyone (Mineko's apology patches, Tales of the Shire "unplayable" Switch). The 91%-vs-67% first-week review gap is the entire conversion business case ([pitfalls research](../research/09-cozy-pitfalls.md)).
- **Likelihood / Impact:** Medium / High.
- **Leading indicators:** (a) blocker/crash bugs per weekly full playthrough not trending to zero in beta; (b) beta quest-blocker reports >1/week in the final two months; (c) console-at-launch pressure reappearing in planning; (d) no weekly build for two consecutive weeks.
- **Mitigations:** PC + Steam Deck only at 1.0 ([D11](../gdd/00-decisions.md)); 3–6 month closed beta focused on save corruption and quest blockers; weekly full-playthrough tests in beta; weekly build discipline from month one; consoles only post-recoup.
- **Contingency:** slip the launch quarter — [D11](../gdd/00-decisions.md) explicitly prefers slipping to launching under-baked.
- **Owner / cadence:** Both. Monthly; weekly in beta.

## R08 — Market invisibility in the cozy glut

- **Description:** ~375 cozy releases in 2024, ~62% sharing near-identical loops, organic discovery falling; "cozy mouse life sim" is not a hook ([pitfalls research](../research/09-cozy-pitfalls.md), [market research](../research/08-market-analysis.md)).
- **Likelihood / Impact:** Medium / High.
- **Leading indicators:** (a) G1 GIFs earn no meaningful organic traction; (b) <1,000 wishlists before demo release, <2,000 before Next Fest; (c) wishlist velocity flat for two consecutive months with active marketing; (d) 25k floor not on trajectory at launch-minus-two-quarters.
- **Mitigations:** lead with the two unclonable hooks — the dollhouse-camera GIF and community-progression (plus the licence if secured); wishlist gates per [D11](../gdd/00-decisions.md); one Next Fest, late; Wholesome Direct June 2027 anchor; weekly clip cadence with a named owner.
- **Contingency:** slip a quarter rather than launch under 25k wishlists (binding, [D11](../gdd/00-decisions.md)).
- **Owner / cadence:** Owner. Monthly + G1/G3/G4.

## R09 — Funding shortfall / runway

- **Description:** Cash need ≈ €140–220k for 2 people × 30 months; estimates run 2× (Unpacking); publisher advances for unproven micro-teams are small and cost ~10 points of revenue share ([scoping research](../research/13-scoping-and-production.md)).
- **Likelihood / Impact:** Medium / High.
- **Leading indicators:** (a) runway <9 months with no committed next tranche; (b) SEF P2 application rejected or delayed a cycle; (c) publisher conversations stalling after demo telemetry exists; (d) burn rate >10% over plan for two months.
- **Mitigations:** staged funding stack (P2 €54k → demo → publisher advance or Kickstarter only with demo + 10k wishlists) per [D16](../gdd/00-decisions.md); 25–30% schedule buffer budgeted; publisher floor ≥70/30 after itemised recoup, marketing excluded; the fallback scope is itself a shippable, sellable game. **⚠ DEFAULT — owner to confirm** team size, FTE status, and cash runway ([D16](../gdd/00-decisions.md)).
- **Contingency:** drop to fallback scope at G4; bridge with part-time contract work rather than debt or crunch.
- **Owner / cadence:** Owner. Monthly + gates.

## R10 — Art-direction gap

- **Description:** "Toon shader + paper overlay" ≠ "Barklem plate"; the delta is texture-authorship hours. PuffPals-style art overpromise erodes trust if the game underdelivers the art ([pitfalls research](../research/09-cozy-pitfalls.md), [watercolour rendering research](../research/10-tech-watercolor-rendering.md)).
- **Likelihood / Impact:** Medium / Medium-High.
- **Leading indicators:** (a) G1 GIF-traction gate fails; (b) side-by-side plate comparison votes low twice running; (c) hero-asset texture time exceeding the measured slice cost by >2×; (d) shader feature list still growing after look-dev lock.
- **Mitigations:** the D4 doctrine — watercolour in hand-painted albedo, one uber-shader, one full-screen pass, no animated filters; calibrate against scanned plates; G1 at M2 forces early truth; pre-release window ≤18 months; monthly devlogs once public.
- **Contingency:** iterate art direction at M2 while it is cheap — never later than G2.
- **Owner / cadence:** Both. Monthly + G1.

## R11 — Unity licensing/pricing change

- **Description:** Unity's 2023 Runtime Fee episode proved engine terms can change abruptly and retroactively-in-spirit. We are committed to Unity 6.3 LTS + URP ([D2](../gdd/00-decisions.md)); a hostile pricing change mid-production would hit margins or force plan changes at the worst time.
- **Likelihood / Impact:** Low-Medium / Medium-High.
- **Leading indicators:** (a) any Unity pricing/licensing announcement affecting our seat tier or per-install/revenue terms; (b) Unity 6.3 LTS support window ending before Q3 2028 + one year of patches; (c) required packages (Cinemachine, Localization, Yarn Spinner compatibility) losing LTS support.
- **Mitigations:** stay pinned to the LTS with locked package versions; keep all design data in engine-agnostic formats (JSON, localisation tables, ScriptableObject definitions exportable); accept the terms in force at 6.3 LTS in writing (Unity's post-2023 policy locks terms to editor version); budget line for seat-price increases.
- **Contingency:** the game ships on the pinned LTS regardless; engine migration is a post-1.0 question only.
- **Owner / cadence:** Owner. Quarterly.

## R12 — Key-person loss (bus factor 1)

- **Description:** On a 1–2 person team, one illness, accident, or family emergency stalls the whole project; solo-dev collapse precedents are real (Smushi's developer "physically collapsed"; Eastshade lost weeks to a ransomware incident) ([scoping research](../research/13-scoping-and-production.md)).
- **Likelihood / Impact:** Low / **Critical**.
- **Leading indicators:** (a) credentials/vault review older than 3 months; (b) a repo restore never actually tested; (c) any system only one person can build or deploy with no written runbook; (d) insurance/contract paperwork unresolved.
- **Mitigations:** shared credentials vault (Steam, Unity, domains, banking, licensor contacts); Git + LFS with off-site backup and a **tested** restore; weekly builds so any machine can produce a shippable build; this docs set kept current (it is the runbook); both members able to run the build + release pipeline.
- **Contingency:** pre-agreed pause protocol — the project hibernates cleanly (docs + repo + backlog current) rather than dying messily.
- **Owner / cadence:** Both. Quarterly.

## R13 — Licensor approval latency kills marketing cadence

- **Description:** A signed licence brings approval gates on concept/art/builds/marketing ([IP research](../research/02-ip-licensing.md)). Our marketing engine is a **weekly** GIF/clip cadence ([D16](../gdd/00-decisions.md)); an approval loop measured in weeks would strangle it — this must be solved in the contract, not discovered after.
- **Likelihood / Impact:** Medium (only if licensed) / High.
- **Leading indicators:** (pre-signature) draft contract lacking an approval SLA or deemed-approval clause; (post-signature) turnaround exceeding SLA twice in a quarter; the clip calendar slipping ≥2 weeks for approvals.
- **Mitigations:** negotiate the SLA as a guardrail, not a nice-to-have — see [negotiation guardrails](./ip-strategy.md#5-negotiation-guardrails); batch pre-approvals (style-guide-compliant asset classes approved as a category); keep a parallel queue of rename-safe/tech clips that need no approval.
- **Contingency:** fall back to the rename-safe clip queue while escalating via Rockpool; the cadence never stops.
- **Owner / cadence:** Owner. Contract gate before signing; monthly once licensed.

## R14 — Playtest recruitment failure

- **Description:** G2 needs 10–15 external playtesters; the closed beta needs dozens. The codename constraint (no public callout under the real name) and NDA friction shrink the pool. Tiny Glade ran five external playtests as a core practice ([scoping research](../research/13-scoping-and-production.md)).
- **Likelihood / Impact:** Medium / Medium-High.
- **Leading indicators:** (a) <10 qualified testers confirmed 4 weeks before G2; (b) codename Discord <50 engaged members by demo hardening; (c) playtest completion rate <60%; (d) feedback demographics missing the core audience (cozy/life-sim players, Deck owners).
- **Mitigations:** build the codename Discord from M3; recruit via cozy playtest communities, Slovenia Games network, and Steam Playtest under the codename; short NDAs (one page); a paid-testing line item (~€1–2k) as backstop; schedule playtests on the calendar at M1 so recruitment starts early.
- **Contingency:** paid recruitment service; slip G2 by two weeks rather than pass it on thin data.
- **Owner / cadence:** Owner. Monthly from M3.

## R15 — Health / burnout

- **Description:** The genre's founding myths are crunch stories (Barone's ~70-hour weeks for 4.5 years; Smushi's collapse). A 2-person plan that only works with sustained overwork is a plan that fails ([scoping research](../research/13-scoping-and-production.md)).
- **Likelihood / Impact:** Medium / **Critical**.
- **Leading indicators:** (a) >45-hour weeks for 3+ consecutive weeks; (b) skipped holidays two quarters running; (c) the monthly risk review skipped "because busy" (meta-indicator — this line firing counts); (d) either member reporting sleep/health degradation; (e) schedule recovered by adding hours instead of cutting scope.
- **Mitigations:** the 25–30% schedule buffer exists precisely so recovery comes from the buffer and the cut list, never from hours; no-crunch plan is binding ([D16](../gdd/00-decisions.md)); external deadlines capped at one per quarter; scope cuts are pre-agreed (MoSCoW) so cutting is administrative, not emotional.
- **Contingency:** immediate one-week full stop, then re-plan at fallback scope. A shipped smaller game beats an abandoned bigger one.
- **Owner / cadence:** Both. Monthly, never skipped.

## R16 — Steam algorithm / discovery shifts

- **Description:** Organic Steam discovery is estimated down ~18% year-on-year, wishlist→sale conversion medians are drifting down (~0.15× at 25k+), and Valve changes surfacing rules without notice ([pitfalls research](../research/09-cozy-pitfalls.md)). Our gates are calibrated to today's funnel.
- **Likelihood / Impact:** Medium / Medium-High.
- **Leading indicators:** (a) published Next Fest / conversion benchmarks moving >25% from the numbers in [D11](../gdd/00-decisions.md); (b) our page traffic decoupling from clip engagement; (c) festival acceptances no longer moving wishlists.
- **Mitigations:** never single-channel — owned mailing list + Discord from the first public beat; the wishlist gates are trajectory gates (re-derivable), not superstition; re-benchmark against GameDiscoverCo/Zukowski data at every gate; cozy festival circuit (Wholesome, Tiny Teams, Cozy Quest) spreads exposure.
- **Contingency:** re-derive the gate numbers at the next gate review and re-plan the beat calendar; the decision *structure* (floor-or-slip) survives any algorithm.
- **Owner / cadence:** Owner. Quarterly.

## R17 — Localisation QA scope blowout

- **Description:** Eight languages ([D15](../gdd/00-decisions.md): EFIGS + zh-Hans + JA) × 60–80k words is a per-word cost we pay eight times, plus LQA passes, font/layout work for CJK, and re-testing after every text change. Left until the end, it becomes a schedule bomb in the beta window.
- **Likelihood / Impact:** Medium / Medium-High.
- **Leading indicators:** (a) word count trending past 70k before content-complete; (b) pseudo-localisation pass failing (clipped/overlapping text) later than M12; (c) any player-facing literal string found in code/prefabs after month one; (d) CJK LQA reviewers not contracted by M22; (e) no per-language budget line by G4.
- **Mitigations:** the 60–80k word budget is **enforced**, tracked monthly like a perf budget; Unity Localization + Yarn Spinner integration from month one; pseudo-loc stress test early; string freeze milestone before beta; LQA budgeted per language with native review for zh-Hans/JA (JA is IP-strategic).
- **Contingency:** drop to EFIGS + JA at 1.0 and ship zh-Hans in the first update — never ship an unreviewed language.
- **Owner / cadence:** Both. Quarterly; monthly from M18.

## R18 — Save corruption reputation damage

- **Description:** Cozy players invest tens of hours of emotional progress; a lost save is the genre's unforgivable bug and a review-bomb trigger (quest blockers and corrupted progress headlined Coral Island's and Mineko's worst coverage — [pitfalls research](../research/09-cozy-pitfalls.md)).
- **Likelihood / Impact:** Low-Medium / High.
- **Leading indicators:** (a) any corruption report in closed beta; (b) a `saveVersion` migration test failing; (c) atomic-write or backup-rotation code paths lacking tests; (d) save/load round-trip not in the weekly full-playthrough script.
- **Mitigations:** the [D2](../gdd/00-decisions.md) save spec is binding — versioned JSON, sequential migrations, atomic writes, rotating backups, save-on-sleep only; save inspector tool from month one; a migration test per `saveVersion` bump; corruption telemetry (opt-in) in beta builds; beta bug bounty prioritising save/blocker bugs.
- **Contingency:** rotating backups mean a corruption is a support ticket, not a catastrophe: document the restore path in-game (help screen) and in the Steam FAQ from the first beta.
- **Owner / cadence:** Both. Monthly in beta; review at every `saveVersion` bump.

---

## Changelog

| Date | Change |
|---|---|
| 2026-07-04 | Register created from research sweep: R01–R10 from the [synthesis top-10](../research/00-synthesis.md), R11–R18 added from [IP](../research/02-ip-licensing.md), [pitfalls](../research/09-cozy-pitfalls.md), and [scoping](../research/13-scoping-and-production.md) research. |

---

[← Back to GDD Index](../gdd/INDEX.md) | [Decisions Brief](../gdd/00-decisions.md) | [IP Strategy →](./ip-strategy.md)
