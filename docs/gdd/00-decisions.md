# 0. Binding Decisions Brief

**Status: BINDING.** This document locks the decisions that every other GDD section, production doc, and implementation task must follow. It was produced from the 2026-07-04 research sweep ([research index](../research/00-synthesis.md)). Where a decision is a research-recommended default that the project owner has not yet personally confirmed, it is marked **⚠ DEFAULT — owner to confirm**. Everything else is settled unless the owner overrules it here first.

If any other document contradicts this one, this one wins and the other document is wrong.

> **Project context (owner, 2026-07-05):** This is a personal *vibecoding* project. The priority is **a working MVP first**, not workload/funding/team planning. The production, funding, and marketing documents under `docs/production/` are **reference-only** — useful if the project ever grows, but not commitments. Team-size and budget figures below are the research's framing, not a plan the owner has signed up to. When in doubt, favour "get something playable running" over process.

[← Back to Index](./INDEX.md)

---

## D1. IP Strategy — Option C (build quiet, pitch, rename-ready)

- Brambly Hedge is owned by **Four Seasons Licensing and Merchandising Ltd** (Jill Barklem's children), agented by **Rockpool Licensing** (Vickie O'Malley). Copyright to 2087; trademarks asserted. Unlicensed public use of the name is plain infringement. See [IP research](../research/02-ip-licensing.md).
- **No public use of "Brambly Hedge" anywhere** — no Steam page, devlog, trailer, social post, or store metadata — until a license is signed. The repo and these docs are private and may use canon names freely.
- Public/external codename: **Project Hedgerow**.
- **Rename-ready data layer:** every character name, location name, and story string lives in localization/data assets, never hardcoded — a rename to original IP (Plan B) must be a ~one-week content swap that loses only the name, not one design pillar.
- **OWNER DECISION (2026-07-05): decide the licence question *after* the prototype exists.** Build the greybox/MVP first under the codename; once there is something playable to look at, choose between (a) pitching Rockpool for the licence or (b) reskinning to an original hedgerow-mice IP. Until then, the rename-ready data layer keeps both doors open at ~zero cost. No public use of the name in the meantime, regardless.

## D2. Engine & Core Stack

- **Unity 6.3 LTS (6000.3.x) + URP**, Forward+, Render Graph, SRP Batcher + GPU Resident Drawer, linear color. Migrate off 2022.3/built-in RP **immediately** (sprint 0), while the project is empty and migration cost is near zero.
- Packages: **Cinemachine 3.1.x** (never 2.x), **Input System**, **Unity Localization**, **com.unity.ai.navigation** (NavMesh), **Yarn Spinner 3** (dialogue), **Newtonsoft JSON** (saves). Asset purchases capped ~$250 total (stylized grass, height fog, stylized water — buy when needed, not before).
- Performance gate: **60 fps @ 1080p on GTX 1060-class and Steam Deck**. Draw calls are the budget, not polygons.
- Save system: versioned JSON (`saveVersion` + sequential migrations), atomic writes, rotating backups, **save-on-sleep only**.

## D3. Camera (flagship feature)

- **Perspective projection** (never orthographic). FOV **28°** (tuning band 22–35°). Pitch **38°** default (band 35–45°).
- Yaw: **8 × 45° snap steps**, 0.35 s smoothstep tween, input latching through tweens. No free orbit at MVP.
- **3 discrete zoom bands** (Near / Default / Vista). Pivot on player, never cursor.
- One Cinemachine Brain + priority-driven per-location cameras with trigger volumes; spline-dolly arrival shots 1.5–2.5 s, translation-dominant, always interruptible.
- Interiors: Sims-4-style dollhouse cutaway via **dithered (screen-door) fade** — occluder fade primary, screen-space cutout circle secondary.
- Two authored scale registers: diorama tilt-shift at Vista; low "pallet moments" (light through stems) at Near.
- Rules: interactables must work at all 8 yaws; every frame should compose like a book plate (10-random-screenshots team vote each build).
- **The 2-week camera greybox is the first production task** — before any art or systems.

## D4. Art Direction Doctrine

- **The watercolor lives in hand-painted albedo textures, not shaders.** One hero uber-shader (soft 2–3 stop ramp, tinted violet-grey shadows — never black, triplanar granulation, noise-wobbled shadow rims, Fresnel edge darkening) + one subtle full-screen storybook pass (warm edge darkening, 5–15% paper overlay, white paper vignette, LUT grading). **No animated watercolor filters, no Kuwahara.**
- Seasons are a data problem: 4–5 LUTs per season + foliage colormap swaps + dressing sets. "Same hedge, four books."
- Calibrate against scanned Barklem plates side-by-side. Botanical accuracy per season, not generic cottagecore.
- Cost levers: shared mouse base-mesh + costume variants, one modular burrow kit, prop families, trim sheets.

## D5. Scope — Binding MoSCoW (1.0)

- **Must:** storybook camera + dollhouse interiors, exploration/traversal, gathering, cooking, community projects, simple NPC schedules, journal-as-UI, 4 seasons as presentation + calendar.
- **Should:** gardening (reuses gather + time), 2 festivals, light relationship system (hearts, gifts, heart-scenes).
- **Could:** fishing (only if it reuses the gathering interaction), journal sketching (see D13), house customization.
- **Won't (1.0):** romance, full VO, money economy, deep crafting trees, mining, multiplayer, procgen, >12 scheduled NPCs, console at launch, Early Access.
- Quarterly scope review: any system below "would be praised in a review" depth at its milestone gets cut to a journal micro-feature.

## D6. Time & Calendar

- **1 game minute = 1 real second → ~20-minute in-game day** (clock runs ~06:00–24:00). 10-minute display ticks. Time pauses in dialogue, journal, and cutscenes. Speed lives in one constant; an "unhurried mode" (slower clock) ships as an option.
- **Seasons: 14 in-game days** each. **A season advances only when the player triggers its seasonal festival** (unlocked once that season's community project + story beat complete). Target 6–10 hours per season; year one ≈ 25–35 hours.
- **No real-world-clock gating. No expiring content. No fail states. No stamina/hunger meters.** Daylight and season are the only clocks.

## D7. Community Projects (the differentiator)

- **4 seasonal major projects at 1.0** + the *Poppy's Babies*-style secret cottage refurbishment as the year-one emotional climax (reuses the same system): spring picnic logistics, Midsummer wedding raft, autumn blanket drive/expedition, winter Ice Hall.
- Five-phase template, binding: **Proposal** (NPC-initiated at a community meeting; player seconds, never commands) → **Contribution** (2–4 in-game days; NPCs visibly work shifts) → **Construction** (2–3 days, staged, witnessed) → **Celebration** (festival set-piece) → **Function** (next morning: ≥1 NPC schedule change + ≥1 service/recipe change + ≥1 ambient/visual change). 5–8 in-game days total.
- Soft thresholds ("about twelve bundles of reeds"), **no fill-bars**, no material-dump grind, no real-time waits. Projects complete slightly slower without the player — **but they complete**.
- Projects gate traversal (repaired bridge → far bank; mill-wheel lift; NPC-rigged ropes). This replaces player-level progression.
- Credit is diffused: completion moments name NPCs alongside the player.

## D8. Economy

- **No money. No shops.** Canon-accurate **Store Stump contribution economy**: deposits of foraged/cooked goods gate festivals and winter comfort; scarce imports (salt) justify expedition quests.

## D9. NPCs, Dialogue, Relationships

- **12 scheduled NPCs at 1.0** (from ~5 canon households: Woodmouse, Toadflax, Apple, Eyebright/Dogwood, elders). Others appear as festival/expedition extras. **MVP: 3 NPCs.**
- Schedules: Stardew-style data-driven priority cascade (season × day × weather × **community-project flags**), named points-of-interest not coordinates, FSM runtime (no utility AI). Build the schedule debug visualizer before the third schedule exists.
- Dialogue budget at 1.0: **4,000–8,000 reactive lines; ≥200 per major NPC, ≥80 per minor.** Reactivity axes: season × weather × friendship tier × active project × recent festival. Every completed project adds ≥3 permanent lines per involved NPC. Tooling: Yarn Spinner 3 Line Groups + saliency, integrated with Unity Localization from month one.
- Friendship numbers: **250 pts/heart, 8–10 hearts, talk +20/day, loved gift +80, birthday ×8, 2 gifts/week cap, NO decay.** Each heart tier gated by a small bespoke scene: 3–4 per NPC ≈ 40–50 scenes at 1.0 — the highest-value content in the game; protect this budget first.
- A weekly hedgerow supper concentrates NPC-to-NPC social life where the player can watch it.
- Player character: **a newcomer mouse who moves into the hedge** and must find their place. **⚠ DEFAULT — owner to confirm** (alternative: canon-adjacent resident child).

## D10. Festivals

- **OWNER DECISION (2026-07-05): the two full festivals at 1.0 are the spring Picnic at Bluebell Bank and Midwinter's Eve.** The Midsummer wedding and the snow-conditional Snow Ball ship as lighter set-pieces, upgraded to full festivals in free post-launch updates.
- Festivals **start without the player and never freeze time**. Contribution formats (communal dishes, assigned gift exchange) over contests. Each festival needs 2–3 state-reactive variants so year two isn't a music box. ≥1 festival per year is pure spectacle with zero mechanics.

## D11. Commercial Parameters

- **$19.99** (launch −10%), **25–35 hours**, PC/Steam + **Steam Deck Verified** only at 1.0. Launch target **Q3 2028** (slip a quarter rather than launch under 25k wishlists).
- Wishlist gates: ≥2k before the (single) Next Fest; 25k floor / 50k goal at launch. Demo tuned to 30–45 min median. Announce beat: **Wholesome Direct, June 2027**. Steam-page-live-to-launch ≤ 18 months.
- **No Early Access** (closed playtest instead). No FOMO or monetization mechanics, ever.

## D12. Voice & Audio Stance

- **Zero VO at 1.0 baseline**: expressive vocalizations + SFX-as-charm; writing must work unvoiced. Partial VO (Eastshade model, ~$10–15k, key scenes only) is a funded stretch goal. **⚠ DEFAULT — owner to confirm.**
- Score: physically small instruments (harp, dulcimer, recorder, celeste); zoom-linked mixer snapshots (Near = intimate foley; Vista = wide ambience); per-material footsteps.

## D13. Photography → Journal Sketching

- The photography system is **demoted to journal "sketching"** (canon: Lady Daisy paints) — capturing a view fills an illustrated journal page. A marketing-grade **photo mode with tilt-shift ("storybook plate" render)** ships from the first public build regardless. **⚠ DEFAULT — owner to confirm.**

## D14. World & Scale

- **One hedgerow strip, 30–50 real meters** + stream + field margin. **3–4 zones**, each postcard-dense (POI every 5–10 s of walking), heavily vertical (roots → floor → stems → canopy). **6–10 dollhouse interiors** at 1.0 (Store Stump, Old Oak Palace, Mill as heroes).
- **Player mouse = 10 cm canonical height.** Scale ratios: doors 1.2–1.4×, grass 3–6×, cow parsley 15–20×, gameplay props exaggerated 1.2–1.5×. Never state exact sizes in fiction.
- **No minimap.** One mega-landmark visible from everywhere; from any exterior point at default zoom ≥1 landmark breaks the canopy line. Diegetic signposting + journal prose restating goals.
- Verbs: climb, squeeze, scamper, balance-run. De-emphasize jumping. No bare ground plane > ~5 character-lengths.

## D15. Localization & Accessibility

- **EFIGS + Simplified Chinese + Japanese at 1.0** (JA is IP-strategic). Word budget **60–80k, enforced** (we pay per word eight times). No player-facing literal strings in code/prefabs from month one; pseudo-localization stress test early.
- Day-one accessibility: scalable text, full remapping (hold/toggle), reduced-motion camera option, colorblind-safe forage highlighting, single-hand controller play, Steam accessibility metadata filled.

## D16. Production Shape & Gates

- **Plan A (12 months):** M1–2 look-dev slice + camera greybox (**G1:** GIF traction); M3–6 vertical slice — summer, 5 NPCs, one compressed project arc (**G2:** playtest + measured per-asset costs); M4–5 Steam page (codename or licensed name only); M7–10 demo hardening; M10–12 Next Fest + funding push (**G3:** ≥2k wishlists pre-fest).
- **G4 at M12 — hard go/no-go:** proceed to Plan B (24–30 months to 1.0, Q3 2028) only with ≥7–10k wishlist trajectory OR ≥€100k funding. Otherwise pivot to the **pre-agreed fallback: an A-Short-Hike-class 4–6 hour exploration game in the same world**, one big community project as its spine. **⚠ DEFAULT — owner to confirm the fallback pre-commitment.**
- Budget frame: ~€140–220k for 2 people × 30 months. Funding stack (Slovenia): SEF P2 (€54k) → demo → publisher advance or Kickstarter (only with demo + 10k wishlists). **⚠ DEFAULT — owner to confirm** team size/runway (plans assume ~2 FTE).
- Publisher terms floor: ≥70/30 after itemized recoup with marketing excluded; never sign before demo telemetry exists.
- Schedule buffer 25–30%; the Unpacking 2× rule budgeted explicitly.

## D17. Naming & Terminology (use everywhere)

| Term | Meaning |
|---|---|
| **Project Hedgerow** | Public/external codename until license resolution |
| **Storybook Isometric Camera** | The camera system (D3) |
| **Community project** | The five-phase shared undertaking system (D7) |
| **Store Stump economy** | The no-money contribution economy (D8) |
| **The Journal** | The diegetic UI (map, recipes, notes, sketches, save) |
| **Heart-scene** | Bespoke friendship-tier scene (D9) |
| **Season valve** | Player-triggered season advance via festival (D6) |
| **Canon layer / rename-safe layer** | License-dependent vs. license-independent content tiers (D1) |

## Open Questions for the Owner (rolled up)

**Resolved 2026-07-05:**
- ~~**D1** — licence path~~ → **decide after the prototype** (build first, choose licence-or-reskin later).
- ~~**D10** — which two festivals~~ → **Picnic + Midwinter's Eve**.
- ~~**D16** — team/funding/workload~~ → **out of scope**: personal vibecoding project, MVP-first (see project-context note at the top). Production docs are reference-only.

**Still open (safe to defer — sensible defaults are in effect and cost nothing to change later):**
1. **D12** — VO tier (default in effect: zero-VO baseline; writing works unvoiced anyway).
2. **D13** — photography → sketching demotion (default in effect: yes).
3. **D9** — player identity: newcomer vs. resident child (default in effect: newcomer).

None of these block building the MVP.

---

*Sources: [research/00-synthesis.md](../research/00-synthesis.md) and research docs 01–13 in [docs/research/](../research/). Decisions here resolve all conflicts among them.*
