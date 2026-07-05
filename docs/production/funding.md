# Funding Plan

**Status: production document.** Operationalises the budget frame and funding stack in [D16](../gdd/00-decisions.md) and the licence-cost assumptions in [D1](../gdd/00-decisions.md). Where this document and [00-decisions.md](../gdd/00-decisions.md) disagree, the decisions brief wins. Evidence base: [scoping & production research §6](../research/13-scoping-and-production.md), [market analysis §8](../research/08-market-analysis.md), [IP & licensing](../research/02-ip-licensing.md).

[← Back to GDD Index](../gdd/INDEX.md) | [Previous: Marketing & Release](./marketing-release.md) | [Roadmap](./roadmap.md)

---

## 1. Posture: staged money against staged proof

We never raise (or spend) ahead of evidence. The funding stack is sequenced against the roadmap gates ([D16](../gdd/00-decisions.md)): grant money carries Plan A to the demo; the demo's telemetry and wishlist trajectory earn Plan B's money (publisher advance or Kickstarter); Creative Europe funds the *next* project. No publisher deal is signed before demo telemetry exists — signing early costs ~10 points of revenue share on average and the advance will be small anyway ([scoping research §6](../research/13-scoping-and-production.md)).

**⚠ DEFAULT — owner to confirm:** team size, FTE status and cash runway (all plans below assume ~2 FTE, per [D16](../gdd/00-decisions.md)); and the funding-path preference (grant + publisher vs Kickstarter-post-demo vs self-funded — open question 7 in the decisions brief).

## 2. The budget frame: €140–220k, 2 people × 30 months

Binding frame from [D16](../gdd/00-decisions.md). Comparator: Eastshade shipped on ~$200k across ~5 frugal years for 1–2 people ([scoping research §1](../research/13-scoping-and-production.md)). Bands below are costed for Slovenia (Eastern-EU rates); the 25–30% schedule buffer and the Unpacking 2× rule are carried as *time* inside the 30-month salary band (M26–30 is launch buffer, already priced).

| Band | Lean | Comfortable | Notes |
|---|---|---|---|
| Salaries / founder pay — 2 FTE × 30 months | €96k | €126k | €1,600–2,100/person/month all-in. Below-market founder pay; anything less is a burnout plan, and we do not run a crunch-dependent plan ([D16](../gdd/00-decisions.md)) |
| Contracting: music & audio, animation help, trailer edit, QA | €18k | €32k | Score on physically small instruments ([D12](../gdd/00-decisions.md)); shared-rig animation set; research band ~€25–50k contracting total ([scoping research §6](../research/13-scoping-and-production.md)) |
| Localisation — 60–80k words, EFIGS + zh-Hans + JA | €22k | €34k | See §3 below — the largest non-salary cash item |
| Marketing: $5–10k micro-influencers + festival costs, key mailing, assets | €7k | €11k | Per [marketing-release.md §9](./marketing-release.md); Wholesome Direct submission is free |
| Legal & company: registration, contracts, trademark search | €2k | €5k | UK IPO search ~£170 + solicitor hours ([IP research](../research/02-ip-licensing.md)); licence legal sits in the add-on row below |
| Hardware / software / services: Steam Deck, dev rigs, Unity assets (~$250 cap, [D2](../gdd/00-decisions.md)), Git LFS hosting, CI, Steamworks fee | €5k | €7k | LFS quota costs recur — budget them, don't discover them |
| **Base total** | **≈ €150k** | **≈ €215k** | Inside the €140–220k frame |

**Add-ons outside the base build (enter only with their own funding):**

| Add-on | Cost | Trigger |
|---|---|---|
| Partial VO (Eastshade model, key scenes) | ~$10–15k (≈ €9–14k) | Funded stretch only, per [D12](../gdd/00-decisions.md). **⚠ DEFAULT — owner to confirm** |
| Licence path: option fee + minimum guarantee + contract legal £5–15k | ≈ €20–40k total (option fee low four-to-five figures; MG low five figures, recoupable against ~10–15% royalty) | Only if Rockpool says yes ([D1](../gdd/00-decisions.md)). **⚠ DEFAULT — owner to confirm** budget appetite |
| KO + pt-BR localisation | €7–12k | Post-launch, by wishlist geography ([D15](../gdd/00-decisions.md)) |
| Switch 2 port | €20–50k (outsourced) | Post-recoup only; ideally publisher-funded ([marketing-release.md §12](./marketing-release.md)) |

The structural point: **the base game must close at €150–215k with zero add-ons.** VO, the licence MG, and the port are all upside spent from upside.

## 3. Localisation is a budget line, not an afterthought

Seven launch languages (EFIGS + Simplified Chinese + Japanese, [D15](../gdd/00-decisions.md)); English is the source, so six paid target passes at 1.0, and KO + pt-BR post-launch make **eight passes over every word** — which is exactly why the 60–80k word cap is enforced in the GDD. At market per-word rates (≈ €0.07–0.10 FIGS/ES, €0.09–0.12 zh/JA, plus LQA), 60–80k words cost roughly €22–34k for the launch set. Two levers move this number: the word cap itself (every 10k words cut saves ~€3–5k), and a publisher — Whitethorn does localisation in-house and Future Friends recoups localisation as an itemised cost ([market analysis §8](../research/08-market-analysis.md)). Localisation is the single strongest *financial* argument for taking a publisher deal.

## 4. The funding stack, in order

1. **Founder savings / part-time income** — bridges M1 until the first grant tranche. Size honestly at kickoff (owner input, §1).
2. **SEF P2 startup grant, €54k non-refundable** (§5) — the Plan A engine.
3. **SEF SK convertible instruments** — follow-on equity/convertible options from the same fund family if we want them; not planned, noted as available ([scoping research §6](../research/13-scoping-and-production.md)).
4. **Publisher advance (€60–150k realistic band)** or **Kickstarter (€60–150k target)** — Plan B's money, unlocked by the demo + wishlist evidence at G3/G4 (§6, §7).
5. **Creative Europe MEDIA (CREA-MEDIA-DEVVGIM)** — up to €200k at a 60% funding rate for *development/pre-production*, but the applicant must have a commercially distributed game shipped since 1 Jan 2023. We do not qualify today; this is **the fund for the next project** (or unlockable by shipping a small commercial micro-title first — see §5). Slovenia is a MEDIA country; applications go with support from CED Slovenia (Motovila).
6. **Launch revenue** — the year-2 tail (free seasonal update, Switch 2 port) is financed from sales, not new raises (§8).

**Non-options, stated so nobody wastes a week:** Epic MegaGrants is effectively Unreal/UEFN-ecosystem-only now ($5–75k typical) — we are Unity and do not switch engines for a grant. The Slovenian Film Centre funds film/AV, not games. Slovenia has no dedicated national game fund (~400-person industry) ([scoping research §6](../research/13-scoping-and-production.md)).

## 5. SEF P2 — the Slovene Enterprise Fund startup grant

- **What:** €54,000 non-refundable grant for young innovative companies from the Slovene Enterprise Fund (Slovenski podjetniški sklad); the practical Slovenian instrument for a games micro-studio ([scoping research §6](../research/13-scoping-and-production.md), [startup.si](https://www.startup.si/)).
- **Eligibility & timing (confirm against the live call before acting):** calls run annually (historically opening early in the year); eligibility historically favours companies registered within a narrow recent window and scored on innovation criteria (product novelty, development stage, team). **Two operational warnings:** (a) registering the d.o.o. too early can age the company out of eligibility — check the current call's incorporation-date window *before* registering; (b) disbursement is typically tranched against milestones over ~two years, so P2 cash arrives progressively, not as a lump sum. Verify both on podjetniskisklad.si when the 2027 call text publishes.
- **Fit to our plan:** given today is July 2026, the realistic application lands in the **Q1 2027 call** — mid-Plan-A, first tranche arriving around M9–14. Founder savings bridge M1–M9. The P2 pitch itself is strong: a differentiated product (storybook camera + community progression), a two-gate de-risked plan, and demo telemetry arriving within the grant period.
- **What P2 covers:** essentially the lean year-one burn (§8). It is not enough for Plan B — that is what the demo-earned raise is for.

## 6. Publisher landscape and the terms floor

Pitch with the vertical slice from ~Q1–Q2 2027 (warm-up), decide only with demo telemetry in hand (M10+). Realistic advance band for an unproven micro-team: **<€50k–€300k**, and taking an advance costs ~10 points of revenue share on average — so the deal must buy things we cannot buy ourselves (marketing reach, localisation, porting, festival access) ([scoping research §6](../research/13-scoping-and-production.md), [market analysis §8](../research/08-market-analysis.md)).

| Publisher | Why them | Known deal shape / notes |
|---|---|---|
| **Future Friends Games** | Organic-marketing specialists; the published benchmark deal | **80/20 dev-favour after recoup with no funding, or 70/30 with up to £100k funding**; recoup covers only loc/QA/key art/ports; their in-house marketing spend is **not** recouped — this shape *is* our terms floor |
| **Whitethorn Games** | Cozy + accessibility-first; in-house QA, accessibility assessment, localisation (EN/FR/IT/DE/LatAm-ES/JA/ZH/KO) | No recoup multiplier; recoupables itemised in contract; their time never billed as an "expense" — solves our two biggest cash lines (loc + QA) |
| **Raw Fury** | Published Snufkin — the closest structural comp (licensed storybook IP, no combat); licensor-experienced | Strongest fit if the Brambly Hedge licence signs; comfortable managing estate relationships |
| **Wholesome Games Presents** | Label of the Wholesome Direct team | "Sustainability for both sides" framing; direct pipeline into the genre's biggest showcase — marketing reach in kind |
| **Secret Mode** | Self-branded cozy publisher (Sumo Group); took A Little to the Left past 1M units; runs Cozy Quest | Strong console/retail reach; good Switch 2 port partner |
| **Fellow Traveller** | Narrative-innovation label, not cozy-core | Pitch only on the storybook/community-narrative angle; secondary |
| Secondary list | Chucklefish, Playtonic Friends, Mooneye, Armor Games Studios, Team17 | Per [scoping research §6](../research/13-scoping-and-production.md); Team17 = bigger advance, bigger recoup, less bespoke attention |

**The terms floor (binding, [D16](../gdd/00-decisions.md)):** ≥70/30 in our favour **after itemised recoup**, with the publisher's own marketing spend excluded from recoup. Funded ports are negotiated as a separate line, never blended into the main share. No signature before demo telemetry exists. A licensed-IP game needs the licence chain resolved in writing before any publisher conversation gets serious — publishers will not paper over an unresolved estate ([IP research](../research/02-ip-licensing.md)).

## 7. Kickstarter — conditions, not plans

Kickstarter is a conditional instrument, exercised only when **all three** hold ([D16](../gdd/00-decisions.md)):

1. A public playable demo exists (post-M10);
2. **≥10k wishlists** — the audience must pre-exist; Kickstarter converts communities, it doesn't create them;
3. **Licensor consent to crowdfund** if the licence has signed (or the campaign runs rename-safe under the codename/Plan-B identity).

Evidence base ([scoping research §6](../research/13-scoping-and-production.md)): 2024 was Kickstarter's best video-game year since 2015 ($26M across 463 projects); cozy comparables — Loftia raised $1.2M (later +$5M VC), Solarpunk $306k against a $32k goal. The cautionary tale is PuffPals: $2.6M raised, imploded without shipping — the cozy backer audience is now warier and punishes overpromise. Consequences for us: **target €60–150k** (survival money, not PuffPals money), campaign material shows only in-engine footage, and the pitch is the demo people can already play. A beloved 40-year book IP is genuinely strong Kickstarter material *if* the licence permits it; otherwise the campaign runs on the camera hook alone, which Tiny Glade proved is enough.

## 8. Cashflow phasing against the roadmap gates

Lean-case burn (2 FTE): ~€5.0–6.5k/month blended (salaries + prorated non-salary bands).

| Period | Phase & gates | Est. cash out | Funded by |
|---|---|---|---|
| M0 (Jul 2026) | Company setup, P2 call monitoring | €1–2k | Founder savings |
| M1–6 (Jul–Dec 2026) | Look-dev slice + vertical slice; **G1** (M2, GIF traction), **G2** (M6, playtest + per-asset costs) | €29–40k | Founder savings (P2 application window pending) |
| M7–12 (Jan–Jun 2027) | Demo hardening, quiet page live earlier at M4–5, publisher + Rockpool pitching; **G3** (≥2k WL pre-fest); announce beat + Next Fest Jun 2027 ([D16](../gdd/00-decisions.md)) | €29–40k | **P2 first tranche** (Q1 2027 call) + savings |
| **M12 — G4 hard go/no-go** | Proceed to Plan B only with **≥7–10k WL trajectory OR ≥€100k secured** ([D16](../gdd/00-decisions.md)) | — | Decision point: publisher advance vs Kickstarter vs fallback |
| M13–21 (Jul 2027–Mar 2028) | Production to content-complete; festival circuit | €45–63k | Publisher advance **or** Kickstarter (€60–150k) + P2 tranches |
| M22–26 (Apr–Aug 2028) | Beta/polish, localisation spend peaks (~€22–34k lands here) | €30–46k | Same + remaining grant tranches |
| M27–30 (Sep–Dec 2028) | Launch buffer (the budgeted 2× rule) + launch | €16–24k | Same; week-1 revenue arrives ~30–60 days post-launch (Valve payment terms) |
| **Total M0–30** | — | **≈ €150–215k** | Matches the §2 base bands |

**Launch revenue planning (median maths, [market analysis §5](../research/08-market-analysis.md)):** at the 25k-wishlist floor, expect ~2,500–3,750 week-1 units ≈ $45–65k gross; at the 50k goal, ~5,000–7,500 units ≈ $85–130k gross. Net to the company ≈ 50–60% of gross after Valve's 30%, VAT and refunds. Read plainly: **at the floor, launch is survival, not riches** — year-2 revenue lives in the update tail and the Switch 2 port, which is why neither is pre-spent (§2 add-ons).

**If G4 fails both tests:** the fallback game (A-Short-Hike-class, 4–6 h) re-budgets to roughly €60–100k total with a ≤12-month remaining timeline — shippable on P2 + savings alone, no publisher required. The fallback is a real game with a real P&L, not a consolation prize ([D16](../gdd/00-decisions.md); **⚠ DEFAULT — owner to confirm the fallback pre-commitment**).

## 9. Solo vs 2 FTE — what actually changes

The plans assume ~2 FTE (**⚠ DEFAULT — owner to confirm**, [D16](../gdd/00-decisions.md)). If the honest answer is solo:

| Dimension | 2 FTE (planned) | Solo (1 FTE) |
|---|---|---|
| Person-years available | ~5 over 30 months | ~2.5 — below the life-sim class threshold ([scoping research §1](../research/13-scoping-and-production.md)) |
| Viable 1.0 scope | Plan B life-sim (with the binding MoSCoW cuts) | **The G4 fallback becomes the plan, not the fallback** — 4–6 h exploration game, one community project spine. The alternative (Stardew's 4.5 years at ~70 h/week; Smushi's collapse) is explicitly rejected — no crunch-dependent plan |
| Cash need | €150–215k | ~€75–110k (one salary band + higher contracting: €15–25k to buy the missing discipline, art or code) |
| Funding stack | P2 → demo → publisher/Kickstarter | P2 + savings can carry the whole build; publisher optional (take only for marketing/port reach) |
| Marketing cadence | 1–2 clips/week, split roles | Floor of 1 clip/week; the cadence owner problem is acute — marketing hours compete directly with content hours ([marketing-release.md §6](./marketing-release.md)) |
| Biggest new risk | — | Single point of failure: illness/burnout = project stall; mitigate with the shorter scope and the 25–30% buffer kept sacred |

The decision is the owner's, but the arithmetic is not negotiable: **team size selects the game.** Choose the team size first, then hold the matching scope; the expensive failure mode is running 2-FTE scope on 1-FTE hands.

## 10. Open items for the owner

1. Team size / FTE status / personal runway (drives §2, §8, §9) — [D16 marker](../gdd/00-decisions.md).
2. Funding-path preference: grant + publisher, Kickstarter post-demo, or self-funded (decisions brief open question 7).
3. Licence budget appetite: option fee + MG + £5–15k legal (§2 add-on) — [D1 marker](../gdd/00-decisions.md).
4. VO stretch tier (§2 add-on) — [D12 marker](../gdd/00-decisions.md).
5. Fallback pre-commitment at G4 (§8) — [D16 marker](../gdd/00-decisions.md).
6. P2 call verification: current incorporation-window and tranche terms on podjetniskisklad.si before registering the company (§5).

---

[← Back to GDD Index](../gdd/INDEX.md) | [Previous: Marketing & Release](./marketing-release.md) | [Roadmap](./roadmap.md)
