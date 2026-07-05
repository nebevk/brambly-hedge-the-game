# 20. MVP (First Playable)

[← Back to Index](./INDEX.md) | [Previous](./19-technical-direction.md) | [Next: Long-Term Vision →](./21-long-term-vision.md)

This section defines the road to the first playable — not as one build, but as **four gated steps**, each of which must pass before money and months are spent on the next. The structure comes from the binding production plan ([D16](./00-decisions.md)) and the scoping research: the design describes a game in the 8–12 person-year class being built by a ~2-person team, so every step below exists to prove something *before* it becomes expensive ([scoping research](../research/13-scoping-and-production.md)).

Two definitions, to prevent the most common confusion:

- **The vertical slice (Step 3) is the real MVP.** It is an internal proof — one polished loop, near-final art on key assets, 20–30 minutes of play — whose purpose is to validate the four goals below and to produce measured per-asset costs.
- **The MVP is not the public demo.** The demo is a separate artifact, built in M7–M10 by hardening the slice to a 30–45-minute median playtime (Gold-tier demos hold players a median 38 minutes; [demo benchmarks](../research/13-scoping-and-production.md)). Nothing in this document promises a public release.

## The Path at a Glance

| Step | Deliverable | When (Plan A) | Gate | On fail |
|---|---|---|---|---|
| **0** | Sprint 0: engine, repo, packages | Week 1 | Exit checklist (below) | Do not start Step 1 until green |
| **1** | Camera greybox MVP | Weeks 2–3 | Greybox acceptance (below) | Iterate ≤2 weeks inside D3 tuning bands; escalate if dollhouse fade fails |
| **2** | Look-dev slice (one postcard corner) | M1–M2 | **G1: GIF traction** | Iterate art direction now — the cheapest moment it will ever be |
| **3** | Vertical slice (the MVP) | M3–M6 | **G2: playtest verdicts + per-asset cost model** | Cut 1.0 scope before production; if camera or loop fails, stop and rework |

Steps are strictly sequential: **no art before the camera is proven, no systems content before the art direction earns traction.** The 2-week camera greybox is the first production task, per [D3](./00-decisions.md).

---

## Step 0 — Sprint 0: Foundations (Week 1)

The project is nearly empty, which makes this the one week in its life when migration is free. Everything here is mandated by [D2](./00-decisions.md) and [technical direction](./19-technical-direction.md).

| # | Task | Done when |
|---|---|---|
| 0.1 | Migrate to **Unity 6.3 LTS (6000.3.x) + URP**: Forward+, Render Graph, SRP Batcher + GPU Resident Drawer on, linear colour | Project opens clean; sample scene renders under URP |
| 0.2 | Install **Cinemachine 3.1.x** (never 2.x), Input System, Unity Localization, `com.unity.ai.navigation`, Yarn Spinner 3, Newtonsoft JSON | Package manifest committed; CM3 namespace (`Unity.Cinemachine`) compiles |
| 0.3 | **Git + LFS**: `.gitattributes` before the first binary asset; UnityYAMLMerge configured as merge tool | A test texture round-trips through LFS; a prefab merge resolves |
| 0.4 | Build automation: one-click Windows + Steam Deck (Linux) build; weekly-build calendar entry | Both builds produced from a clean clone |
| 0.5 | Project skeleton: ~6 asmdefs with inward-only dependencies; two input action maps (Gameplay / UI); Localization string tables initialised — **no player-facing literal strings in code or prefabs, ever** ([D15](./00-decisions.md)) | Compile passes; a sample string renders from a table |
| 0.6 | Performance gate wired: 60 fps @ 1080p target on GTX 1060-class; frame-time HUD in dev builds | Stats overlay visible in the greybox scene |
| 0.7 | Buy **nothing** yet — the ~$250 asset budget (stylised grass, height fog, water) is spent when a step needs it, not before | — |

**Exit criterion:** a colleague can clone the repo and produce both builds in under an hour.

---

## Step 1 — Camera Greybox MVP (Weeks 2–3)

Purpose: **validate the flagship before any art exists.** The Storybook Isometric Camera ([D3](./00-decisions.md), [07-camera-direction](./07-camera-direction.md)) is the game's one-GIF hook and its biggest interacting-systems risk (dollhouse fade + occlusion + snap rotation + min-spec performance, unproven together). The full plan and citations live in the [camera research MVP test plan](../research/11-tech-camera.md).

**Greybox scene (no art, grey primitives only):** a ~40 m hedge corridor, one two-room cottage with a door, one "mill" landmark with an arrival trigger, 6 large occluder plants, a slope, and a stream crossing.

### Week 2 build list

- One `CinemachineBrain` + player follow rig: perspective, FOV 28° (tuning band 22–35°), pitch 38° (band 35–45°).
- Yaw: 8 × 45° snap steps, 0.35 s smoothstep tween, **input latching** through tweens (camera-relative movement basis frozen while input is held).
- 3 discrete zoom bands (Near / Default / Vista) as follow-distance + FOV pairs; pivot on the player, never the cursor.
- Trigger-volume vcam at the mill with a spline-dolly arrival shot (translation-dominant, 1.5–2.5 s, EaseInOut).

### Week 3 build list

- `Lit-DitherFade` shader (8×8 Bayer, alpha-clip in the opaque queue) + `CameraOcclusionFader` (SphereCast camera→player on an `Occluder` layer; fade in 0.2 s / out 0.4 s).
- Cottage interior vcam (closer, ~45–50° pitch, yaw clamped, `CinemachineConfiner3D`) + roof/upper-wall group fade — the Sims-4-Cutaway dollhouse behaviour.
- Hysteresis colliders + 2 s minimum live time on all camera triggers.
- Tilt-shift toggle (Vista band only, subtle) + Near DoF profile.

### Greybox pass/fail (all rows must be green)

| # | Test | Pass condition |
|---|---|---|
| C1 | Walk the corridor at all 8 yaws | Zero control reversals; latching holds direction through every snap tween |
| C2 | Mill arrival shot | Blend ≤2.5 s, cancellable by any movement input, never clips geometry |
| C3 | Occlusion on the planted path | Player never fully hidden >0.5 s anywhere on the path |
| C4 | Exterior → interior | Reads as one continuous move (no cut) at 0.6–0.8 s; roof fade and vcam blend arrive together |
| C5 | Trigger boundaries | Standing on any boundary produces zero camera ping-pong over 60 s |
| C6 | Comfort | 3+ external testers; zero reports of discomfort on the arrival reframe or yaw snapping; tested at 60 and 120+ fps |
| C7 | Performance | 60 fps @ 1080p on GTX 1060-class and Steam Deck in the greybox scene |

**Rituals that start here and never stop:** capture 10 random-timing screenshots per playtest; team-votes "could this be a book illustration?" — the count is tracked build over build ([D3](./00-decisions.md)).

**On fail:** iterate up to 2 additional weeks inside the D3 tuning bands (FOV 22–35°, pitch 35–45°, blend times). If the dollhouse fade or comfort cannot be made green, that is a flagship-level problem — stop, and revisit the camera spec before a single art asset is commissioned.

---

## Step 2 — Look-Dev Slice → Gate G1 (Months 1–2)

Purpose: prove the *art direction* the way Step 1 proved the camera — one postcard corner of the hedge at **target ship quality**, because the GIF is the marketing engine and art direction is cheapest to change now (Tiny Glade precedent: GIF-first marketing → 800k+ pre-launch wishlists; [scoping research](../research/13-scoping-and-production.md)).

**Contents (quality bar: ship-quality; quantity bar: minimal):**

- One hedgerow exterior pocket (~one postcard: bank, stems, flowers, a door in the roots) with the full [D4](./00-decisions.md) pipeline: hand-painted albedo textures, the hero uber-shader (2–3 stop ramp, tinted violet-grey shadows, triplanar granulation, wobbled shadow rims, Fresnel edge darkening), and the full-screen storybook pass (warm edge darkening, 5–15% paper overlay, vignette, LUT).
- One dollhouse interior room with working roof-fade, dressed to plate density.
- One player mouse (10 cm canonical scale) with locomotion + one interact animation.
- **Zero NPCs.** Character-cast art is Step 3 risk; this step is environment + one mouse.
- Calibration ritual: every review happens with scanned Barklem plates side-by-side on the second monitor ([D4](./00-decisions.md)).

### Gate G1 — GIF traction (end of M2)

Post 3–5 short clips (the camera pulling from Vista into the lit interior is clip #1) on 2+ channels. **Licence discipline ([D1](./00-decisions.md)): all public clips go out under the codename Project Hedgerow, using rename-safe content only — no canon names in captions, signage, or file names.** The canon-named layer stays in the private repo.

- **Pass:** at least one clip earns clearly organic traction — as an operational floor, ≥10× the posting account's baseline engagement, or a front-page run on one relevant community (r/cozygames-class). Meaningful inbound ("wishlist where?" comments) counts double.
- **Fail:** no clip outperforms baseline → iterate the art direction *now*, not the plan. The delta between "toon shader + paper texture" and "Barklem plate" is texture-authorship hours (risk #10 in the [synthesis](../research/00-synthesis.md)); G1 exists to force that truth early.

---

## Step 3 — Vertical Slice: The Real MVP (Months 3–6)

One zone, one season, one compressed community-project arc, 20–30 minutes of play. This is the build that answers "is this a game?" and "can we afford the rest of it?".

### Scope table (binding for the slice)

| Feature | In the slice |
|---|---|
| Playable area | **One zone**: the village core — hedge bank around the **Store Stump**, down to the stream edge and a broken footbridge ([canon](../research/01-brambly-hedge-canon.md)) |
| Interiors | 3 dollhouse interiors: Store Stump (hero), Crabapple Cottage kitchen (cooking venue), Flour Mill ground floor |
| Player home | One small burrow room (bed = save point; sleep-only saves per [D2](./00-decisions.md)) |
| Season | **Summer** — not spring. Earlier drafts said spring; the production plan's slice is summer ([D16](./00-decisions.md)), and the demo grows directly out of this build, so the slice follows the plan |
| NPCs | **3–5 on screen, 3 fully scheduled** — see the resolution note below |
| Gathering | Full loop: 6–8 summer forageables (wild strawberries, watercress, dandelion, elderflower among them — all canon-botanical, [canon](../research/01-brambly-hedge-canon.md)) with colourblind-safe highlighting |
| Cooking | Full loop: 4–6 summer recipes drawn from the canon feast list (cold watercress soup, honey creams, wild-strawberry dishes); cooked goods deposit into the Store Stump ([D8](./00-decisions.md)) |
| Crafting | **None.** No crafting station in the slice (deep crafting is a 1.0 Won't per [D5](./00-decisions.md); the old draft's "one crafting station" is removed) |
| Community project | **One, compressed to a ~3-in-game-day arc**: repair the footbridge. All five phases present ([D7](./00-decisions.md)): Proposal at a Store Stump meeting → Contribution (1 day, NPCs visibly working) → Construction (1 day, staged) → Celebration (a shared supper on the bank — the golden-moment capstone) → Function (next morning: bridge open → far-bank pocket reachable; ≥1 schedule change; ≥1 new recipe taught; ≥1 ambient change) |
| Time | Full day/night: ~20-minute day, clock ~06:00–24:00, 10-minute ticks, time pauses in dialogue/journal ([D6](./00-decisions.md)) |
| Journal | Skeleton: map page, recipe page, prose goal restatement (no checklists, no percentages — [D17 terminology](./00-decisions.md), [17-ui-philosophy](./17-ui-philosophy.md)); d-pad navigable |
| Input | Controller + KBM, both complete; rebinding stub |
| Camera | Everything from Steps 1–2, now in dressed environments |
| Playtime target | **20–30 minutes** median for a first run |

### NPC count — the resolution (read this, it settles a contradiction)

The old draft of this file said **3 NPCs**; the decisions brief records "**MVP: 3 NPCs**" ([D9](./00-decisions.md)); the production plan's vertical slice says **5** ([D16](./00-decisions.md)). These reconcile as follows, and this is the binding reading:

- **Camera greybox (Step 1): 0 NPCs.**
- **Look-dev slice (Step 2): 0 NPCs** — one player mouse only.
- **Vertical slice (Step 3): 3–5 NPCs on screen, of which exactly 3 are fully scheduled** — full data-driven daily schedule, dialogue pool (~40–60 lines each in the slice), and a role in the project arc. The suggested three: **Mr Apple** (Store Stump warden, proposes the project — canon problem-solver), **Mrs Apple** (cooking teacher; her journal seeds the journal fiction), **Dusty Dogwood** (miller; his schedule visibly changes when the bridge opens). Up to 2 more are lightweight *presence* NPCs (e.g. **Wilfred Toadflax**, **Poppy Eyebright**): fixed-location or two-block schedules, small bark pools, no project role.

D9's "3" counts full schedule builds; Plan A's "5" counts heads on screen. Both are satisfied. All names live in the localisation/data layer and are rename-safe ([D1](./00-decisions.md)).

### The four validation goals — with pass metrics

The slice exists to validate four things. Each has an explicit test; "feels right" is not a metric.

**Goal 1 — The Storybook Isometric Camera feels right indoors and outdoors.**
- All greybox acceptance rows C1–C7 remain green in the dressed environment.
- Screenshot ritual: ≥6 of 10 random screenshots pass the "could be a book illustration" team vote, and the count is not declining build over build.
- Comfort: 0 of the external playtesters report motion discomfort (arrival reframes and yaw snaps asked about explicitly).

**Goal 2 — The core loop (explore → meet → gather → cook → contribute) is satisfying.**
- Median unguided session ≥20 minutes across the playtest cohort.
- ≥70% of testers complete at least one full in-game day (wake → sleep) without prompting.
- Exit interview, the "tomorrow question": ≥70% can name something specific they intended to do next. ("Accomplished something today, something to look forward to tomorrow" is the session contract — [09-gameplay-loop](./09-gameplay-loop.md).)

**Goal 3 — The community philosophy is legible even at small scope.**
- Exit interview: "Who repaired the footbridge?" — ≥60% answer with NPC names (alone or alongside themselves), not "I did". Credit diffusion is the design ([D7](./00-decisions.md), [18-community-philosophy](./18-community-philosophy.md)).
- ≥50% of testers notice, unprompted, at least one of the three Function-phase changes (schedule, service/recipe, ambient) the morning after the celebration.
- During Contribution/Construction days, testers report seeing NPCs physically working (observation question, not memory test).

**Goal 4 — The world reads as cosy, detailed, and faithful.**
- ≥50% of testers use "cosy", "charming", or an equivalent unprompted in exit interviews (the G2 wording from the [production plan](../research/13-scoping-and-production.md)).
- G1-style clip check repeated with slice footage: traction holds or improves.
- Botanical spot-check: every plant in frame is a real summer hedgerow species ([D4](./00-decisions.md)).

### Gate G2 — what we measure (end of M6)

G2 has two halves. **Both** must pass.

**Half 1 — playtest verdicts.** 10–15 external playtesters (not friends-of-team only), standard protocol: unguided play, think-aloud optional, instrumented session length, structured exit interview covering the four goals above. Verdict is per-goal green/red against the metrics listed.

**Half 2 — the per-asset cost model.** Every asset class built for the slice gets its actual hours logged as it is made (not reconstructed afterwards). At G2 the measured costs are extrapolated to the 1.0 counts from [D5](./00-decisions.md)/[D9](./00-decisions.md)/[D14](./00-decisions.md) and must fit Plan B.

| Asset class | Slice sample | Measured hrs (fill at G2) | 1.0 count | Extrapolated |
|---|---|---|---|---|
| Simple prop | — | — | ~400–600 total props | — |
| Hero prop | — | — | (subset above) | — |
| Occluder plant (shader-ready) | — | — | per zone | — |
| Dollhouse interior room, dressed | — | — | 6–10 interiors | — |
| Exterior postcard pocket | — | — | 3–4 zones × pockets | — |
| Rigged mouse + costume variant | — | — | 12 scheduled NPCs | — |
| NPC schedule (one seasonal variant) | — | — | 12 NPCs × 4 seasons | — |
| Dialogue, per 100 implemented lines | — | — | 4,000–8,000 lines | — |
| Bespoke scene (heart-scene class) | — | — | 40–50 scenes | — |
| Spline arrival shot | — | — | per key location | — |
| Recipe (data + icon + strings) | — | — | launch recipe set | — |
| Seasonal foliage/dressing variant set | — | — | 4 seasons | — |

**Fit test:** extrapolated content total ≤ ~24–30 person-months of content labour (2 FTE × 24–30 months × ~50% content share, per the [planning ratios](../research/13-scoping-and-production.md)), *including* the 25–30% schedule buffer from [D16](./00-decisions.md).

**G2 outcomes:**

- **Pass** (four goals green + cost model fits) → proceed: Steam page (M4–5 track), demo hardening M7–M10.
- **Conditional** (goals green, costs over) → cut 1.0 scope *before* production — the quarterly scope rule ([D5](./00-decisions.md)) applied early; the slice's whole purpose is that this cut happens on paper, not in month 20.
- **Fail** (camera or loop red) → do not proceed to demo content. Rework the failing pillar; if it cannot be fixed, the G4 fallback conversation ([D16](./00-decisions.md)) happens early rather than at M12.

---

## Out of Scope for the MVP (all steps)

Explicitly not in the greybox, look-dev slice, or vertical slice:

- **Fishing** (1.0 Could, reuse-only — [D5](./00-decisions.md))
- **Journal sketching / photography system** (the marketing photo mode with tilt-shift ships from the first *public* build per [D13](./00-decisions.md) — that is demo hardening, not slice)
- **Gardening** (1.0 Should; reuses gather + time systems later)
- **Crafting stations or trees** (removed from the old draft's scope table)
- **3 of the 4 seasons** — summer only; seasonal LUT/dressing pipeline is proven in look-dev, not populated
- **Festivals beyond the arc's Celebration phase** — no spring picnic, no Midwinter's Eve; the shared supper capstone is the only celebratory set-piece
- **Relationship hearts / gifts / heart-scenes** (system lands in production; the slice's NPCs react through project state only)
- **Full journal** — skeleton pages only
- **Full save pipeline** — sleep-save stub; versioned migrations and rotating backups are demo-hardening work
- **VO** (zero VO baseline anyway — [D12](./00-decisions.md)), **localisation beyond pipeline-readiness**, **house customisation**, **Steam page assets** (parallel M4–5 track, not this build)
- Forever-outs regardless of step: money, shops, minimap, fail states, stamina meters, real-time gating ([D5](./00-decisions.md), [D6](./00-decisions.md), [D8](./00-decisions.md))

## After G2

The slice becomes the seed of the public demo (M7–M10: content to a 30–45-minute median, save system, options/accessibility, performance pass), then the single Next Fest entry with ≥2,000 wishlists banked (**G3**), then the M12 go/no-go (**G4**). Those beats belong to the production plan ([D16](./00-decisions.md), [scoping research](../research/13-scoping-and-production.md)); this document's job ends when G2 is green.

[← Back to Index](./INDEX.md) | [Previous](./19-technical-direction.md) | [Next: Long-Term Vision →](./21-long-term-vision.md)
