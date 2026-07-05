# 00 — Master Synthesis: Research Sweep → GDD Direction

Synthesized 2026-07-04 from research docs 01–13. This is the binding input for the GDD. Where research documents conflict, this document resolves the conflict and says so. Opinionated by design.

---

## 1. Executive Summary

1. **The IP is the #1 project risk, and it is resolvable.** Brambly Hedge is actively managed (Four Seasons Licensing, agent: Rockpool), copyrighted to 2087, trademark-asserted. Shipping under this name unlicensed is plain infringement. Adopt the Option C hybrid now: neutral codename, rename-ready data layer, build the slice, pitch Rockpool (~Q2 2027), Snufkin-style brand-guardianship framing; Plan B (original hedgerow-mice IP) loses only the name, not one design pillar. (Doc 02)
2. **Our two differentiators are validated and unoccupied:** (a) the Storybook Isometric Camera with dollhouse cutaway interiors — canon-native (Barklem's signature image IS the cutaway) and unsolved by any comp; (b) community-progression — every 40M+ seller in the genre makes the player the indispensable hero of a town that cannot act; a community that demonstrably works with-or-without you is genuinely new. (Docs 01, 03, 05)
3. **Scope is the existential threat.** The current systems list is an 8–12 person-year game; we have ~2.5–5 person-years. Every ≤3-person/≤3-year success had one mechanic or was short. Protect camera + community projects; gut the genre checklist (fishing/photography demoted, romance/full-VO/economy cut). (Doc 13)
4. **NPC dialogue is a core system, not polish.** Lifeless/repetitive NPCs are the single most repeated criticism across failed cozy games; our pitch dies with it. Budget 4,000–8,000 reactive lines at 1.0, schema (season × weather × friendship × project-state) built in month one via Yarn Spinner 3 Line Groups. (Docs 03, 09, 12)
5. **Tech decisions are effectively made for us:** Unity 6.3 LTS + URP (built-in RP deprecated June 2026; 2022.3 is EOL), Forward+, Render Graph, Cinemachine 3.1.x, perspective camera ~28° FOV at ~38° pitch with 45° yaw snaps, dither-fade roofs. Migrate this month while migration cost is near zero. (Docs 10, 11, 12)
6. **The look lives in hand-painted textures, not shaders.** No animated watercolor filters (Dordogne's warning); Snufkin's painted-albedo Unity pipeline + Season's tinted-shadow ramp + baked GI + subtle paper/edge full-screen pass. Seasons are a data problem: LUT sets + palette/dressing swaps. (Docs 05, 10)
7. **Mouse scale is our density engine.** A 30–50 m hedgerow strip is a whole game world; verticality (roots→floor→stems→canopy) plus four seasonal re-dressings quadruple one handcrafted space. Grounded gets 30+ hours from a 20×20 m yard. (Docs 04, 07)
8. **Time and pacing rules are proven:** in-game days (~20 real minutes), never real-time gating (Cozy Grove's revolt), seasons advance only when the player holds the festival (Wylde Flowers' valve), no fail states, no depleting meters, save-on-sleep. (Docs 03, 06)
9. **Commercially: $19.99, 25–35 hours, PC/Steam + Steam Deck first, launch Q3 2028**, one Next Fest close to launch, Wholesome Direct as the anchor beat, 25k wishlist floor / 50k goal, review quality (≥90% positive) is the entire multiplier. Cozy is glutted (~375 releases/2024); "cozy" is a baseline, the camera + license are the hook. (Docs 08, 09, 13)
10. **The production shape is gated:** 12 months to a marketable 30–45-minute demo, hard go/no-go at month 12 (≥7–10k wishlists trajectory OR ≥€100k funding), then 24–30 months to 1.0 — with a pre-agreed fallback to an "A Short Hike-class" 4–6 hour exploration game in the same world. (Doc 13)

---

## 2. Decisions the Research Supports (concrete, numeric)

**Engine & pipeline**
- Unity **6.3 LTS** (6000.3.x), **URP**, Forward+, Render Graph native, SRP Batcher + GPU Resident Drawer on, linear color. Migrate off 2022.3/built-in **this month**.
- Cinemachine **3.1.x** (never 2.x), Input System, Unity Localization 1.5.x, `com.unity.ai.navigation` NavMesh, Newtonsoft JSON saves (versioned, sleep-only, atomic writes), **Yarn Spinner 3** for dialogue. Asset buys ≤ ~$250 (Stylized Grass, Atmospheric Height Fog, Stylized Water 3 later).
- Performance gate: **60 fps @ 1080p on GTX 1060-class and Steam Deck**; draw calls are the budget, not polys.

**Camera (the flagship feature)**
- **Perspective projection** (never orthographic), FOV **28°** (test 22–35°), pitch **38°** default (band 35–45°), **8 × 45° yaw snap steps** (0.35 s smoothstep tween, input latching through tweens), **3 discrete zoom bands** (Near/Default/Vista), pivot on player never cursor.
- One Brain + priority-driven per-location CinemachineCameras with trigger volumes; spline-dolly arrival shots 1.5–2.5 s, translation-dominant, always interruptible. Sims-4-Cutaway dollhouse interiors via **dithered (screen-door) fade**; occluder fade primary, screen-space cutout circle secondary. No Deoccluder, no free orbit at MVP.
- Subtle tilt-shift focus band at Near zoom + photo mode with one-click "storybook plate" render from the first public build.

**World & scale**
- Player mouse = **10 cm canonical height**; world = **one hedgerow strip ~30–50 real meters** + stream + field margin, **3–4 zones**, each postcard-dense (POI every 5–10 s of walking), heavily vertical. **6–10 dollhouse interiors** at 1.0. No bare ground plane > ~5 character-lengths. One mega-landmark (Old Oak / mill chimney) visible from everywhere — no minimap.
- De-emphasize jumping; verbs = climb, squeeze, scamper, balance-run; traversal unlocks come from **community projects** (repaired bridge, mill-wheel lift, NPC-rigged ropes), not player levels.

**Time, seasons, calendar**
- **1 game minute = 1 real second → ~20-minute in-game day** (6:00–24:00-ish), 10-minute display ticks, pause on dialogue/journal/cutscene, save-on-sleep. Expose speed as one constant; consider an "unhurried mode."
- **Seasons: 14–21 in-game days** (not Stardew's 28 — we have no farming loop to fill them). **Season advances only when the player triggers the seasonal festival** (available once the season's community project + story beat are done). Target **6–10 hours per season**; year one ≈ 25–35 hours.
- **No real-world-clock gating anywhere. No expiring content.**

**NPCs, dialogue, relationships**
- **10–12 scheduled NPCs at 1.0** (canon cast ~20–24; the rest appear as festival/expedition extras). Stardew-style data-driven schedules (priority key cascade incl. **community-project flags**, e.g. `mill_restored_summer`), named points-of-interest not coordinates, FSM runtime (no utility AI — dependable rhythms are the point). Build the schedule debug visualizer before the third schedule.
- Dialogue at 1.0: **4,000–8,000 lines; ≥200 per major NPC, ≥80 per minor**; every completed project adds ≥3 permanent reactive lines per involved NPC. Reactivity axes: season × weather × friendship tier × active project × recent festival.
- Friendship: **~250 pts/heart, 8–10 hearts, talk +20/day, loved gift +80, birthday ×8, 2 gifts/week cap, NO decay**; each heart tier gated by a small bespoke scene (Palia's best idea): 3–4 beats × 10–12 NPCs ≈ **40–50 small scenes**. Preferences auto-recorded in the journal. Thin post-max content stream (seasonal letters, standing invitations) so maxed friendships feel settled, not dead.
- VO: **partial, Eastshade model** (~$10–15k, 30–50 self-directed remote actors, key scenes only) — full VO is publisher-scale.

**Community projects (the differentiator)**
- **3–4 major projects at 1.0**, one per season, lifted from canon: spring picnic logistics, Midsummer wedding raft, autumn blanket drive/expedition, winter Ice Hall; *Poppy's Babies* cottage refurbishment as the year-one emotional climax.
- Template: **Proposal (NPC-initiated, at a meeting) → Contribution (2–4 in-game days, NPCs visibly work shifts) → Construction (2–3 days, staged, witnessed) → Celebration (festival set-piece) → Function (next morning: ≥1 NPC schedule change + ≥1 service/recipe change + ≥1 ambient/visual change).** 5–8 in-game days total. Soft thresholds ("about 12 bundles of reeds"), no fill-bars, no real-time waits. Projects complete slightly slower without the player — but they complete.
- **No money economy.** Store Stump contribution economy (canon): deposits of foraged/cooked goods gate festivals and winter comfort; scarce imports (salt) justify expedition quests.

**Festivals**
- **2 full festivals at 1.0** (Spring picnic + Midwinter's Eve recommended), 2 more (wedding, Snow Ball — snow-conditional rare event) as free post-launch updates. Contribution formats (communal soup, assigned gift exchange) over contests. **Festivals start without you; time never freezes.** Each needs 2–3 state-reactive variants so year 2 isn't a music box.

**Business**
- **Price $19.99** (launch −10%), content **25–35 hours**, year-2 design ≥20% novel.
- Steam page live at key-art quality; page-to-launch window **≤ 12–18 months**; **one Next Fest**, ≤6 months pre-launch, entered with ≥2,000 (ideally 10k+) wishlists; demo tuned to **30–45 min median playtime**; Wholesome Direct June 2027 = announce beat; **launch Q3 2028**; wishlists 25k floor / 50k goal.
- **No Early Access** unless Mistria-grade (all four seasons, 20+ polished hours) — default is Stardew-model complete 1.0. No FOMO/monetization mechanics ever.
- Localization: **EFIGS + Simplified Chinese + Japanese** at 1.0 (JA is IP-strategic), word budget **60–80k**; localization-ready text pipeline from month one. Accessibility (text scaling, remapping, reduced-motion camera, no fail states) as day-one, filterable Steam metadata.
- Funding stack (Slovenia): SEF P2 €54k → demo → publisher advance or Kickstarter (only with demo + 10k WL) → Creative Europe for the next project. Cash need ≈ €140–220k for 2 people × 30 months.

---

## 3. Per-GDD-Section Implications

**01 — Working Title & Identity**
- The document title stays aspirational; the *project* adopts a neutral codename immediately (repo, Discord, builds). No public use of "Brambly Hedge" pre-license — no Steam page, devlog, or trailer under the name.
- All character/location names and story text behind one localization/data layer so a rename is a one-week content swap (Option B insurance).
- Identity sentence to lock: "the first cozy sim where the community demonstrably runs, works, and celebrates with or without you — your reward is belonging, not credit."

**02 — High Concept & Hooks**
- Two marketable hooks, in order: (1) storybook camera zooming from hedgerow into a fully furnished cutaway mouse kitchen (the one-GIF hook); (2) "You don't build your empire. You build the community."
- Pitch genre frame: Life Sim / Exploration + Cozy — mechanics-forward, never vibe-only ("cozy" alone is a saturated baseline).
- Comparable-set to cite: Snufkin (licensed storybook IP, no combat), Tiny Glade (visual-hook marketing), Stardew (numbers skeleton), Winter Burrow (proof the audience exists for hedgerow mice).

**03 — Design Pillars**
- Keep the five pillars; add explicit anti-pillars: no combat, no money, no fail states, no depleting meters, no minimap/HUD, no real-time gating, no FOMO.
- "Detail" pillar gets an operational bar: botanical accuracy per season (Barklem was "the most research-crammed fantasy"), not generic cottagecore.
- "Community" pillar gets a testable rule: every community change must alter ≥1 NPC schedule + ≥1 function + ≥1 ambient layer.

**04 — Target Audience & Market**
- Primary: cozy/life-sim PC+Steam Deck players (Stardew/Mistria/ACNH audience, female-majority skew per Hozy data); secondary: Brambly Hedge book nostalgics (UK + Japan strong).
- Market facts to state: ~375 cozy releases/2024, farming/life-sim 8.3% hit rate (healthiest adjacent niche), review quality (91% vs 67%) is the conversion driver.
- Playtime/price expectations table: $19.99 demands ~20+ visible hours; $4–5/hour is the complaint threshold.

**05 — Setting, Story & IP**
- Canon bible (doc 01) is the source of truth: 8 books, ~20 named mice, no predators on screen, peril = weather/fog/lost, class-without-conflict.
- Year-one narrative spine = the four canon community projects + Poppy's-Babies-style secret refurbishment as climax; The Secret Staircase hidden-apartment beat as the exploration reward inside Old Oak Palace.
- License status defines two content tiers: canon-named layer (quarantined, private) and rename-safe layer. GDD written so a find-and-replace produces a legally distinct game.
- Tone guardrails: worst outcome is "found, cold, and brought home to soup"; TV series' gentle-jeopardy trick (drifting raft, snow tunnels) is the tension model.

**06 — Characters / NPC Cast**
- 10–12 scheduled residents at 1.0, drawn from 5 canon households (Woodmouse, Toadflax, Apple, Eyebright/Dogwood, elders Basil/Old Vole/Flax/Lily); off-map communities (voles, sea mice, harvest mice) are expedition destinations, not residents.
- Every NPC is a named individual with a unique dialogue pool — the ACNH archetype-pool model is the documented anti-pattern.
- Per-NPC content budget: schedule (seasonal variants), ≥200 lines, 3–4 friendship scenes, gift table, festival role, ≥1 community-project role.
- De-risk mouse character designs with external audience testing early (Eastshade's animal-folk backlash precedent).

**07 — World & Level Design**
- One hedgerow strip 30–50 real meters, 3–4 zones, layer-cake verticality; every hedge "block" a stacked column of content; earnable vantage points with framed vistas per season.
- Scale ratio table (mouse 10 cm; doors 1.2–1.4×; grass 3–6×; cow parsley 15–20×; gameplay props exaggerated 1.2–1.5×); never state exact size in fiction (Miyamoto rule).
- Landmark discipline: from any exterior point at default zoom, ≥1 landmark breaks the canopy line. Diegetic signposting (signs, NPC directions, journal prose) because no-minimap has a known 50/50 lost-vs-frustrated failure mode.
- Interiors are the differentiator no comp solved: 6–10 true vertical dollhouses (Store Stump, Palace, Mill as heroes); furniture-is-terrain (Tinykin rule); loop shortcuts back to hubs (Botany Manor sightline discipline).

**08 — Camera & Presentation**
- Full spec in §2 above; this section of the GDD should carry the vcam architecture (Brain + zones + spline arrivals), rotation UX (snap + latch), roof-fade system, and the two scale registers (diorama at Vista, "pallet moments" — low pivot, light shafts through stems — at Near).
- Interactables valid at all 8 yaws (Monument Valley rule: never require a camera angle).
- Operational pillar metric: 10 random screenshots per playtest, team-vote "could be a book illustration," tracked build over build.
- MVP camera greybox test is the first two weeks of production (doc 11 checklist).

**09 — Core Loop & Session Shape**
- One in-game day = one 20–40 min session: 1 story/community beat + 2–3 small favors + 1 project contribution + unlimited freeform. "Accomplished something today, something to look forward to tomorrow" — without a wall.
- Verbs at 1.0: explore/climb, gather, cook, contribute/help, chat/gift, attend. Gardening reuses gather+time systems (Should); fishing only if it reuses the gathering interaction (Could); photography ships as journal "sketching" (Lady Daisy canon), not a system.
- Progression = community state + relationships + traversal access + journal completion. No XP, no player levels, no island-rating equivalents.

**10 — Game Systems (gathering, cooking, crafting, gardening)**
- Content lists come free from canon: Basil's seasonal drinks + documented dishes (primrose pudding, seed cake, chestnut soup, clover bread, rosehip jam…) = launch recipe set, all forageable, all botanically real.
- Seasonal availability is the soft timer ("blackberries only in autumn") — the only acceptable form of time pressure.
- Reciprocity rule (Spiritfarer): every completed favor returns something tangible within one in-game day (doorstep gift, taught recipe, shortcut opened, NPC gathers alongside you).
- No stamina/hunger bars (Eastshade cut them; Ooblets died by meters). Daylight and season are the only clocks.

**11 — Community Projects (differentiator system)**
- Five-phase template and per-phase rules from §2. NPC-initiated proposals at community meetings; the player seconds/votes, doesn't command.
- NPC labor is visible and scheduled (walk past the sawing, thatching, scaffolding); recognition diffused (completion toast names three NPCs and you).
- Anti-patterns to write into the spec: no fill-bars, no material-dump grind (cap raw requirements low), no cosmetic-only restoration (Garden Story's failure), no dangling visibly-locked objectives many hours early.
- Projects gate traversal (bridge → far bank; mill wheel → lift) — this replaces the feather/stamina progression of exploration comps.

**12 — Time, Seasons & Festivals**
- Numbers from §2 (20-min day; 14–21-day seasons; player-triggered season turn; 2 festivals at 1.0 + 2 post-launch).
- Calendar from canon: spring picnic, Midsummer wedding, harvest/blackberrying, Midwinter's Eve, Snow Ball (rare, deep-snow-conditional), plus floating birthdays and engagement→wedding→Naming Day chains.
- Festivals never freeze time and start without the player; ≥1 per year is pure spectacle with zero mechanics (Moonlight Jellies pattern).
- Time architecture: single TimeService, `totalMinutesSinceStart` int, event-driven ticks, sleep = simulated fast-forward + autosave.

**13 — NPC Behavior, Relationships & Dialogue**
- Schedule data model, FSM, off-screen abstraction (`location + route-progress` records), NavMesh + links, travel-leg budgeting — per §2 and doc 12.
- Dialogue tooling: Yarn Spinner 3 Line Groups + saliency replaces hand-rolled bark tables; integrated with Unity Localization from day one.
- Friendship numbers per §2; heart-tier bespoke scenes are the highest-value content in the game — protect their budget first.
- NPC-to-NPC visible life (saloon-equivalent: a weekly hedgerow supper that concentrates socializing where the player can watch) is the cheapest aliveness multiplier; NPCs gift/quarrel/reconcile via overheard lines and journal gossip.

**14 — Journal-as-UI & UX**
- The journal is canon (Mrs Apple's matrilineal diaries) and is our Plucky Squire moment: genuinely 2D illustrated spreads the 3D game opens into; ancestors' diary pages as lore collectibles.
- Hard rule: prose and sketches that record what happened — never to-do lists, progress bars, or completion percentages (the checklist-UI trap recreates FarmVille's second job).
- Journal restates current goals in words (wayfinding safety net); auto-records gift preferences and recipes (no wiki required).
- Every screen fully d-pad navigable with visible selection from the first prototype; two input action maps (Gameplay/UI); rebinding shipped.

**15 — Art Direction**
- Doctrine: watercolor lives in hand-painted albedo textures; the shader whispers. One hero uber-shader (soft 2–3 stop ramp, tinted violet-grey shadows never black, triplanar granulation, noise-wobbled shadow rims, Fresnel edge darkening, mip paint-mask) + one full-screen storybook pass (warm edge darkening, 5–15% paper overlay, white paper vignette, LUT grading). Reject full-screen Kuwahara and animated watercolor filters.
- Calibrate against scanned Barklem plates side-by-side; buy the Snufkin (~$8) and Dordogne artbooks as standing references.
- Seasons = 4–5 LUTs per season + foliage colormap swaps + dressing sets — "same hedge, four books" as an asset-swap problem.
- Cost levers: shared mouse base-mesh with costume variants, one modular burrow kit, prop families, trim sheets; texture authorship hours (not shader features) close the gap to "Barklem plate" — budget accordingly.
- Micro-reactivity scoped tiny (worn-path decals, birds landing, dusk windows lighting) delivers Tiny Glade's "it's alive" at 1% of its tech.

**16 — Audio & Music**
- Zoom-linked mixer snapshots (Pikmin 4 wholesale): Near = intimate foley, narrowed ambience; Vista = wide ambience over faint tiny-world detail.
- Footsteps: crisp transient + micro-texture tail ("fingers crushing gravel"), per-material variants (leaf litter, bark, flagstone, moss).
- Score with physically small instruments (harp, dulcimer, recorder, celeste — Moss playbook); Ernie Wood's TV scoring as tonal reference; leitmotifs that swell only at ceremonies.
- SFX-as-charm over VO (Unpacking's lesson); partial VO for key scenes only (~$10–15k).

**17 — Technology & Architecture**
- Full stack per §2. Additional: ~6 asmdefs with inward-only dependencies, SO event channels for ~10 cross-system seams only, composition root not DI, SO definitions + plain-C# runtime state + string-ID registry, Git+LFS (.gitattributes before first binary; Azure DevOps-class LFS quotas), UnityYAMLMerge, weekly builds.
- Editor tooling from month one: schedule visualizer, save inspector, ID validator.
- Save: Newtonsoft JSON, `saveVersion` + sequential migrations, atomic writes, rotating backups, sleep-only.

**18 — Accessibility & Localization**
- Day one: scalable text, full remapping + hold/toggle, reduced-motion camera option, colorblind-safe forage highlighting, single-hand controller play, zero fail states/time pressure (already design), Steam accessibility metadata filled.
- EFIGS + zh-Hans + JA at 1.0; KO/pt-BR post-launch by wishlist geography; 60–80k word cap enforced because we pay per word eight times.
- No player-facing literal strings in code/prefabs from month one; pseudo-localization stress test early.

**19 — Production Plan & Scope**
- Plan A (12 months): M1–2 look-dev slice + camera greybox (Gate G1: GIF traction); M3–6 vertical slice, summer only, 5 NPCs, one compressed project arc (Gate G2: playtest + measured per-asset costs fit Plan B); M4–5 Steam page; M7–10 demo hardening (30–45 min median); M10–12 Next Fest + funding push (Gate G3: 2k WL pre-fest).
- Plan B (to ~Q3 2028 1.0): Gate G4 at M12 — proceed only with ≥7–10k WL trajectory OR ≥€100k; else pivot to the pre-agreed A-Short-Hike-class fallback (4–6 h exploration game, one big community project as spine).
- MoSCoW is binding: Must = camera/interiors, exploration, gathering, cooking, community projects, simple schedules, journal, 4 seasons as presentation+calendar. Should = gardening, 2 festivals, light relationships. Could = fishing (reuse-only), sketchbook photography, house customization. Won't = romance, full VO, economy sim, deep crafting, mining, multiplayer, procgen, >12 scheduled NPCs, console at launch.
- Process: tiered backlog (shippable core + stretch), weekly re-estimation, one external deadline per quarter, quarterly scope review — any system below "would be praised in a review" depth at its milestone gets cut to a journal micro-feature.
- Budget the Unpacking 2x rule explicitly (M26–30 buffer).

**20 — Marketing, Business & Release**
- Numbers per §2. Sequence: quiet Steam page → Wholesome Direct June 2027 announce (dollhouse-camera trailer; 20–25k WL goal) → weekly GIF cadence (assign an owner: 1–2 clips/week from slice onward) → cozy festival circuit (Tiny Teams Aug, Cozy Quest Nov) → closed playtest (not EA) → single Next Fest ≤6 months pre-launch with $5–10k micro-influencer support → launch Sept–Oct 2028 only if ≥25k WL, else slip a quarter.
- Publisher gate: only ≥70/30 after itemized recoup with marketing excluded (Future Friends' published shape), or a funded Switch-2 port; pitch Raw Fury/Whitethorn/Future Friends/Wholesome Games Presents with the slice. Never sign before demo telemetry exists.
- Confirm licensor streaming/content rights and approval turnaround before signing — slow approvals would kill the weekly-clip cadence.
- Switch 2 port +6–12 months post-launch; free seasonal update (festival #3/#4, photo mode upgrades) timed to a Wholesome sale for the year-2 tail.

**21 — Long-Term Vision**
- Year-2 content designed pre-launch: ≥20% novel second-year material (festival variants, second-year NPC arcs, snow-conditional Snow Ball) so reviews say "still surprising me in year 2" — this is the anti-content-cliff plan, not DLC.
- Post-1.0 expansion candidates map to canon expedition books: Sea Story (Sandy Bay salt voyage) and The High Hills (vole expedition) are natural paid season-sized expansions; wedding/Naming Day chains extend relationship content.
- If licensed: earn the Hyper-Games trust arc (second game on the same IP). If Plan B: the original hedgerow IP becomes ours to grow.
- Never: live-service cadence, real-time calendars, premium currency, rotating shops. The Palia/$49M/two-layoffs/distress-sale case is the standing warning.

---

## 4. Risk Register Seed (top 10)

| # | Risk | Likelihood | Impact | Mitigation |
|---|---|---|---|---|
| 1 | **IP infringement / license refusal.** Estate is active, agent-managed, mid-relaunch; unlicensed "Brambly Hedge" is certain detection, C&D, store takedowns. License odds only ~30–40%. | High (if unmanaged) | Fatal | Option C now: codename, no public use of the name, rename-ready data layer, quarantined canon layer; UK IPO trademark search (~£170) + IP solicitor hour; pitch Rockpool with the slice ~Q2 2027; hard 3-month decision window, then Option B irrevocably. |
| 2 | **Scope death** — design doc is 8–12 person-years vs ~2.5–5 available; ~23% of postmortem problems are scope. | High | Fatal | Binding MoSCoW (§3.19); prototype community projects first; gates G1–G4 with a pre-agreed smaller fallback game; quarterly cut reviews; measure per-asset costs in the slice before committing. |
| 3 | **NPC dialogue exhaustion / lifeless community.** #1 review killer genre-wide; our pitch is the community. | High | Critical | Dialogue as core system: 4–8k reactive lines, schema + Yarn Spinner saliency from month one, ≤12 deep NPCs not 20 shallow, permanent post-project lines, weekly social gathering scene. |
| 4 | **"Pretty but empty" verdict.** Watercolor raises expectations (Tales of the Shire: license + 59 Metacritic). | Medium-High | Critical | 2–3 interlocking deep loops instead of the checklist; reciprocity rule; every restoration functional; Discounty/Mistria as depth benchmarks; external playtests from M6. |
| 5 | **Content cliff + price mismatch.** Finite handcrafted world; reviewers publish the hour they ran out. | Medium-High | High | Honest 25–35 h target at $19.99; year-2 novelty ≥20%; festivals state-reactive; never price above content ($24.99 ceiling). |
| 6 | **Camera/tech risk:** dollhouse fade, occlusion, snap rotation, min-spec perf — unproven together; comps abandoned locked cameras as scope grew. | Medium | High | 2-week greybox camera MVP first (doc 11 plan); dither-fade not alpha; perf budget + Steam Deck gate from pre-production; Unity 6/URP migration now while free. |
| 7 | **Buggy launch / platform quality.** Cozy audiences punish jank (91% vs 67% review gap is the business case); console cert delays fixes weeks. | Medium | High | PC + Steam Deck only at 1.0; 3–6 month closed beta focused on save corruption/quest blockers; weekly full-playthrough tests in beta; consoles only post-recoup. |
| 8 | **Market invisibility in the cozy glut.** ~375 cozy releases/2024; median revenue ~$249; showcase exposure ≠ conversion. | Medium | High | Lead with the two unclonable hooks (camera GIF, community progression; license if secured); wishlist gates (2k pre-fest, 25k pre-launch, else slip); one Next Fest, late; Wholesome Direct anchor. |
| 9 | **Funding shortfall / burnout.** €140–220k need; solo-dev collapse precedents (Smushi, Barone's 70-h weeks); estimates run 2x. | Medium | High | Staged funding (P2 €54k → advance/Kickstarter post-demo); 25–30% schedule buffer budgeted; fallback scope is also a shippable, sellable game; no crunch-dependent plan. |
| 10 | **Art-direction gap:** "toon shader + paper texture" ≠ "Barklem plate"; the delta is texture-authorship hours; PuffPals-style overpromise erodes trust if the game underdelivers the art. | Medium | Medium-High | Lock shader feature set early; calibrate against scanned plates; G1 GIF-traction gate at M2 forces early truth; keep pre-release window ≤18 months; monthly devlogs once public. |

---

## 5. What We Deliberately Do Differently (and why it is defensible)

1. **The community acts without the player.** NPCs propose, schedule, and physically work on projects; festivals start on time whether you're there or not; credit is shared. Every 40M+ genre seller does the opposite — this is unoccupied design space validated by the loudest criticisms of ACNH/Stardew/Palia, and it is canon-accurate (the books' undertakings are collective). Defensible because it's a *content-shape* choice, cheap-ish to build, impossible to patch into a player-hero game.
2. **No money, no shops.** Store Stump contribution economy instead. Canon has no currency; Stardew's endgame drowns in meaningless millions. Removing money removes the genre's most common late-game failure and differentiates the loop description on the store page.
3. **No player progression axis.** No XP, levels, or ratings; progression is community state, relationships, and traversal access opened by projects. Exploration comps (A Short Hike, Little Kitty) prove traversal-as-progression carries a game; routing it through community projects is our twist.
4. **Semi-fixed, composed camera in a genre of free orbits or flat top-downs.** Snapped 45° yaws + authored arrival shots + dollhouse cutaways. Snufkin's top-down was its main visual criticism; Tiny Glade has no interiors at all. We accept less camera freedom to guarantee every frame composes like a book plate — and we operationalize it (screenshot test).
5. **Journal instead of HUD, prose instead of checklists.** Canon-native (Mrs Apple's diaries), differentiating on screenshots, and a deliberate rejection of the quest-log/percentage UI that makes cozy games feel like second jobs. Risk (wayfinding) is known and mitigated, not ignored.
6. **In-game time only; the player holds the pacing valve.** No real-time clock, no daily caps, no expiring content; seasons turn when the player holds the festival. Cozy Grove and Dreamlight prove real-time and FOMO are radioactive here; Wylde Flowers proves the valve is loved.
7. **No fail states, no meters, no combat — as hard constraints, not marketing.** Tension comes from weather, fog, and "can I reach that?"; the worst outcome is being brought home to soup. This is both the license's identity and the genre's enforced expectation.
8. **Small, finite, honest.** One hedgerow, ~30–50 real meters, four seasonal re-dressings, 25–35 hours, complete at 1.0, no procgen, no live service, no Early Access by default. The glut's failures are shallow-broad games and broken trust contracts; the survivors are narrow, deep, finished. We say the game is small in every trailer — at mouse scale, small **is** the wonder.
9. **Two scale registers in one camera.** Diorama tilt-shift at Vista ("what a lovely miniature world") and low "pallet moments" through sunlit stems at Near ("I am a mouse") — scripted per scene. No comp consciously switches registers; the research (Pikmin vs Moss) shows they're opposing illusions worth authoring separately.
10. **Licensed-IP posture without licensed-IP dependency.** Everything is built rename-safe from day one, so the license is upside (press hook, Snufkin-style credibility) rather than a single point of failure — the inverse of Tales of the Shire, which had the license and nothing else.
