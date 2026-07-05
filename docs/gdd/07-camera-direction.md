# 7. Camera Direction

[← Back to Index](./INDEX.md) | [Previous](./06-art-direction.md) | [Next: Visual Identity →](./08-visual-identity.md)

> **Status: flagship feature, binding.** This section implements decision [D3](./00-decisions.md) and is the single most important technical-creative system in the game. The **2-week camera greybox is the first production task** — before any art, before any other system ([D3](./00-decisions.md), [MVP](./20-mvp.md)). Terminology per [D17](./00-decisions.md): this system is the **Storybook Isometric Camera**.

The camera is entirely rename-safe (no licence dependency, [D1](./00-decisions.md)); only the location names used in examples below belong to the canon layer.

---

## 7.1 Philosophy

The camera makes the player feel they are exploring a living illustration from the Brambly Hedge books. It is **neither** a traditional top-down isometric camera **nor** a free third-person camera. It combines the handcrafted diorama feeling of *Tiny Glade* with the intimate, illustrated atmosphere of *Snufkin: Melody of Moominvalley* — and answers Snufkin's most-repeated criticism, that its single bird's-eye angle wasted a storybook world ([comps research](../research/05-comps-storybook-visual.md)).

The core design rule is unchanged and binding:

> **The camera should never exist solely to show gameplay. It should exist to showcase the beauty of Brambly Hedge.**

If a player pauses on a bridge for a few seconds to admire the autumn leaves, the movement of grass, and smoke from the mill chimney, the camera has done its job. Every frame of gameplay should be capable of looking like a book plate — and we measure that claim, every build (§7.8.3).

The cutaway interior is Jill Barklem's signature image — tree-trunk homes drawn in vertical cross-section, dozens of rooms and staircases ([canon research](../research/01-brambly-hedge-canon.md)). Our dollhouse camera is not a feature bolted onto the licence; it *is* the licence's visual identity, playable.

---

## 7.2 Hard Specification

**Units convention (binding):** every distance in this chapter is a **real-world metre**. The world is authored at 10× real scale — 1 Unity unit ≈ 10 cm real, the player mouse ≈ 1 unit tall ([World §5.1](./05-world.md), [Technical Direction §19.4](./19-technical-direction.md)) — so **multiply by 10 for build units**: the follow distances 0.8 / 1.8 / 5.0 m are **8 / 18 / 50 units**, the near/far clip 0.05 / 100 m is 0.5 / 1,000 units, and the occlusion SphereCast radius 0.1 m is 1 unit. The greybox (§7.9) is authored under this same convention.

### 7.2.1 Projection and lens

| Property | Value | Binding source |
|---|---|---|
| Projection | **Perspective — never orthographic** | [D3](./00-decisions.md) |
| Field of view (Default band) | **28° vertical** | D3; tuning band **22–35°** |
| Pitch (Default band) | **38°** | D3; tuning band **35–45°** |
| Roll | **0°, always. No camera roll, ever.** | motion comfort, §7.8.2 |
| Near/far clip | 0.05 m / 100 m (greybox starting values) | tuning |

Why perspective: Tiny Glade is fully perspective and gets its diorama feel from lighting and depth of field, not projection; orthographic buys nothing in a full-3D scene and produces vertex/pixel jitter under rotation ([camera research §3](../research/11-tech-camera.md)). A narrow FOV at distance gives the long-lens "miniature" compression while keeping parallax, DoF, and natural fade raycasts.

### 7.2.2 Yaw — 8 snap steps

| Property | Value |
|---|---|
| Snap positions | **8 × 45°** (0°, 45°, 90° … 315°) |
| Tween | **0.35 s, smoothstep** ease; no overshoot |
| Input | Q/E (keyboard), LB/RB (gamepad); one press = one step; presses queue (max 1 queued) |
| During tween | **Input latching** — while movement input magnitude > 0.2, the player keeps translating along the previously computed world direction; the camera-relative movement basis is recomputed only when input is released or its direction changes materially |
| Free orbit | **None at MVP.** A narrow free range (±10° drag, spring back to snap) may be evaluated post-greybox only if playtests demand it |
| Pivot | **The player character (framing target), never the cursor** |

Rationale: Monument Valley only made interaction decisions valid at snap positions; Tunic ships a fixed camera and is praised for readability; Tiny Glade had to patch in centre-pivot because cursor-pivot disoriented players ([camera research §6](../research/11-tech-camera.md)). Movement input is always camera-relative, built from the camera's ground-projected forward/right vectors — this fixes the classic 45°-off drift problem.

### 7.2.3 Zoom — 3 discrete bands, not analogue zoom

Bands, not a zoom axis: every band is an art-directed composition. Transition between neighbouring bands is a 0.4 s smoothstep lerp of the full preset (distance + FOV + pitch + focus profile). Mouse wheel steps one band per notch; gamepad d-pad up/down. All values below are greybox starting points; the Default-band FOV/pitch are the D3-locked defaults, and Near/Vista variants must stay inside the D3 tuning bands (FOV 22–35°, pitch 35–45°).

| Band | Follow distance (build units) | FOV | Pitch | Approx. frame height at player | Player screen height | Intended use |
|---|---|---|---|---|---|---|
| **Near** | 0.8 m (8 u) | 32° | 35° | ~0.45 m | ~20–25% | Intimacy: "I am a mouse." Conversations, interiors, gathering close work, **pallet moments** (§7.7). Depth-of-field focused at the player plane. Audio: intimate foley snapshot ([D12](./00-decisions.md), [Audio](./16-music-and-audio.md)) |
| **Default** | 1.8 m (18 u) | 28° | 38° | ~0.9 m | ~10–12% | The travelling/postcard band; 90% of play. Grass (3–6× mouse) fully in frame; ≥1 landmark breaks the canopy line from any exterior point at this band ([D14](./00-decisions.md), [World](./05-world.md)) |
| **Vista** | 5.0 m (50 u) | 24° | 42° | ~2.1 m | ~4–5% | Orientation (we ship **no minimap**) and the diorama register: cow parsley (15–20×) fits in frame, subtle **tilt-shift** (§7.7). Audio: wide ambience snapshot |

Scale context: the player mouse is 10 cm canonical height and the whole world is a 30–50 m hedgerow strip ([D14](./00-decisions.md)) — camera distances are correspondingly small.

### 7.2.4 Framing and follow behaviour

- `CinemachinePositionComposer`: player slightly below centre (~0.1 screen-Y bias), dead zone ~0.1 × 0.1 screen so the frame *breathes* rather than glues to the character, position damping 0.8–1.2 s.
- The camera follows position with damping but **never auto-rotates yaw** while the player has control; yaw changes only via the snap input or an authored arrival/interior camera.
- The camera never intersects geometry and never dips below the ground plane; interiors use a confiner (§7.5), exteriors rely on authored zone bounds (`CinemachineConfiner3D` on the play-space volume, matching Tiny Glade's "bounded by the glade" restraint).

---

## 7.3 Per-Situation Behaviour

The spirit of the original table, now with numbers. Each scene should feel like an illustration that has come alive, not a view of a game map.

| Situation | Camera behaviour | Numbers |
|---|---|---|
| **Walking the hedgerow (forest walk)** | Default band, player-follow rig; frame breathes inside dead zone; large plants and terrain dominate the frame, reinforcing mouse scale | Distance 1.8 m, FOV 28°, pitch 38°, damping 0.8–1.2 s, yaw free to snap in 8 steps |
| **Arriving at a key location (Mill, Old Oak Palace, bridge)** | Priority-boosted arrival camera blends in; a short spline dolly gently reframes the landmark; gameplay never pauses | Blend + dolly **1.5–2.5 s**, EaseInOut, **translation-dominant** (yaw/pitch change ≤ 15° total), spline length 1–3 m, **cancelled by any movement input ≥ 0.2 within 1 frame**; hysteresis + 2 s minimum live time |
| **Indoors (dollhouse)** | Roof and camera-side walls dither-fade; interior camera takes over, closer and steeper, yaw clamped so the open dollhouse face always fronts the camera | Blend **0.6–0.8 s**, distance ≈ 0.5 m (≈ 60% of exterior Near), pitch 45–50°, yaw clamp ±45° or locked per room, confined to room bounds; shell fade-out 0.2 s |
| **Player behind vegetation** | Occluding hollyhock/teasel/trunk fades to a ghost, restores when clear | Fade to alpha 0.25 in 0.2 s, restore in 0.4 s; player never fully hidden > 0.5 s (§7.6) |
| **Photo mode** (from first public build, [D13](./00-decisions.md)) | Separate Cinemachine channel; free framing within zone bounds; one-click **"storybook plate"** render (tilt-shift + paper border) | Not a gameplay camera; its freedom does not leak back into play |

---

## 7.4 Architecture — Cinemachine 3.1.x

**Package rule: Cinemachine 3.1.x, never 2.x** ([D2](./00-decisions.md)). New project, no legacy content, all current documentation targets 3.x; the 2→3 migration is a breaking-API cost we simply never pay ([camera research §1](../research/11-tech-camera.md)). Unity 6.3 LTS + URP per [D2](./00-decisions.md) — every shader this camera needs (dither fade, cutout, tilt-shift feature) is URP-first ([Technical Direction](./19-technical-direction.md)).

### 7.4.1 Global setup

- **One `Camera` + one `CinemachineBrain`.** Default blend 0.5 s EaseInOut; a **Custom Blends asset** overrides specific pairs (e.g. `CM_PlayerFollow → CM_Arrival_Mill` = 2.0 s EaseInOut; `CM_PlayerFollow → CM_Interior_*` = 0.7 s).
- All gameplay cameras on one **Cinemachine Channel**; a second channel is reserved for photo mode.
- Camera *modes* (Exterior / Arrival / Interior) are a small explicit C# state machine that enables camera sets — not Cinemachine's State-Driven Camera, which is built around Animator states we don't have.

### 7.4.2 The camera set

| Camera | Components | Role |
|---|---|---|
| `CM_PlayerFollow` | `CinemachineCamera` + `CinemachinePositionComposer` + `CinemachineRotationComposer`; custom `CameraYawController` + `CameraZoomBands` | The default rig: 8-yaw snaps, 3 zoom bands, framing per §7.2.4 |
| `CM_Arrival_<Location>` | `CinemachineCamera` + `CinemachineSplineDolly` on a short authored `SplineContainer` (or fixed composition where a dolly adds nothing) | One per key location; hand-composed "book plate" reveal; activated by trigger volume priority bump |
| `CM_Interior_<Name>` | `CinemachineCamera` + `CinemachinePositionComposer` + `CinemachineConfiner3D` (room bounds) | One per interior room or floor; §7.5 |

**Priority discipline:** `CM_PlayerFollow` = 10; arrival cameras idle at 5, boosted to 20 on trigger enter; interior cameras 30 while the player is inside their room volume. The Brain always blends to the most recently activated camera of equal/higher priority — the whole system is priorities plus trigger volumes; no manager cameras (ClearShot deferred until a real two-composition interior demands it, post-MVP).

### 7.4.3 Trigger volumes and arrival shots

- Each key location gets an **enter collider** and a larger **exit collider** (exit ≥ 1.25× enter) — hysteresis so a player standing on the boundary cannot ping-pong cameras — plus a **2 s minimum live time** before another blend may start.
- Arrival shots are **1.5–2.5 s, translation-dominant** (dolly/track moves; total rotation change ≤ 15°), EaseInOut, and **always interruptible**: any movement input ≥ 0.2 cancels the arrival within 1 frame and blends back to `CM_PlayerFollow` over 0.5 s. Gameplay and the game clock never pause for an arrival.
- Blend paths must not clip geometry: keep zone-camera positions near line-of-sight of each other; the exterior↔interior pair uses the choreographed transition in §7.5.3, never a raw Brain blend through a wall.

### 7.4.4 Data-model sketch

```text
CameraBandSettings : ScriptableObject          // one asset per band
  bandId            Near | Default | Vista
  followDistance    float   // real m: 0.8 / 1.8 / 5.0 → build units: 8 / 18 / 50 (§7.2 units convention)
  fovDegrees        float   // 32 / 28 / 24
  pitchDegrees      float   // 35 / 38 / 42
  focusProfile      VolumeProfile              // DoF at Near, tilt-shift at Vista, none at Default
  audioSnapshotId   string                     // zoom-linked mixer snapshot (D12)

CameraYawController : MonoBehaviour
  snapCount = 8, snapDegrees = 45
  tweenSeconds = 0.35 (smoothstep)
  latchInputThreshold = 0.2
  reducedMotion       bool                     // §7.8.2

CameraZoneTrigger : MonoBehaviour
  targetCamera     CinemachineCamera
  priorityBoost    int   = 10
  minLiveSeconds   float = 2.0
  interruptible    bool  = true                // always true for arrivals
  enterCollider / exitCollider                 // exit ≥ 1.25× enter

BuildingShellController : MonoBehaviour        // §7.5
  roofShell / upperWalls / interior            Renderer groups
  fadeOutSeconds = 0.2, fadeInSeconds = 0.4
  hideFloorsAbove  bool                        // multi-storey dollhouses

CameraOcclusionFader : MonoBehaviour           // §7.6
  castRadius = 0.1 m (1 build unit), castEveryNFrames = 3
  occluderLayer, fadeToAlpha = 0.25
  fadeOutSeconds = 0.2, restoreSeconds = 0.4
```

All tunables live in serialized assets, not code, so the greybox fortnight is a tuning exercise rather than a programming one.

---

## 7.5 Interiors — the Dollhouse Cutaway

Entering a home must feel like the page-turn into one of Barklem's cross-sections. No comp solved interiors well — Tiny Glade has none, Snufkin's are sparse ([comps research](../research/05-comps-storybook-visual.md)) — which makes this our clearest differentiation opportunity, alongside the biggest technical risk (hence the greybox, §7.9).

### 7.5.1 Building construction rule (for artists and the burrow kit)

Every enterable building is authored as **separate renderer groups**: `RoofShell`, `UpperWalls` (the walls between camera and room), and `Interior`. The modular burrow kit ([D4](./00-decisions.md), [Art Direction](./06-art-direction.md)) must respect this split from its first module. Multi-storey dollhouses (Store Stump, Old Oak Palace, the Mill — the hero interiors, [D14](./00-decisions.md)) additionally group renderers **per floor** so floors above the player's current floor hide entirely.

### 7.5.2 The fade — dithered, never alpha-blended

- Shader: `Lit-DitherFade` — URP Shader Graph lit graph + **8×8 Bayer dither → alpha clip**, driven by a per-group `_FadeAlpha` via `MaterialPropertyBlock`.
- Why dither (screen-door): objects stay in the opaque queue, keep writing depth, keep casting shadows, and never Z-sort against foliage — the whole class of transparency-sorting bugs disappears, and it is cheaper than alpha blending. 8×8 (64 levels) rather than 4×4 kills visible banding ([camera research §4](../research/11-tech-camera.md)).
- Timing: shell fades **out in 0.2 s, back in 0.4 s**. A hard renderer toggle is acceptable only as a greybox-week-1 placeholder; it pops and must not survive week 2.

### 7.5.3 Exterior → interior transition choreography

The transition must read as **one continuous move — no cut**:

1. Player crosses the door trigger (trigger sits just inside the threshold; exit trigger 1.25× larger).
2. Same frame, two things start together: (a) the Brain blends `CM_PlayerFollow → CM_Interior_<Room>` over **0.6–0.8 s**; (b) `BuildingShellController` fades `RoofShell` + `UpperWalls` over 0.2 s and hides floors above.
3. The interior camera: follow distance ≈ **0.5 m** (≈ 60% of exterior Near), pitch **45–50°**, **yaw clamped** (±45°, or locked per room) so the open dollhouse face always fronts the camera, `CinemachineConfiner3D` to room bounds. Interiors are lit by their own baked lighting volume so stepping inside reads as a warm illustrated cross-section.
4. Leaving reverses the same choreography; the shell restores over 0.4 s.

Yaw snapping indoors: rooms authored for the clamp. Where a room supports multiple yaws, snaps work as outdoors within the clamp; where it doesn't, the yaw input is ignored (with the same soft "nudge" feedback as a blocked move, no error sound).

### 7.5.4 The Sims 4 reference — bounded

We take exactly one thing from The Sims 4: the **Cutaway semantics** — hide the walls between the current view and the back wall, and reveal the active character if behind them; hide floors above the current level ([camera research §4](../research/11-tech-camera.md)). We do **not** take its free camera, wall-mode UI, or player-controlled wall states. Our interior camera stays composed; the cutaway is automatic and invisible as a system.

---

## 7.6 Occlusion — the Player Behind Vegetation

Strategy ranking is binding ([D3](./00-decisions.md), [camera research §5](../research/11-tech-camera.md)):

1. **Occluder fade (primary).** `CameraOcclusionFader` runs `Physics.SphereCastAll` (radius **0.1 m**, every 3 frames) from camera to player against an `Occluder` layer — hedge banks, large flowers, tree trunks, teasels. Hit renderers tween their `Lit-DitherFade` alpha to **0.25 over 0.2 s** and restore over **0.4 s** when clear. This suits *large discrete* occluders: fading a whole hollyhock keeps the illustration honest.
2. **Screen-space cutout circle (secondary, phase 2).** For *continuous* hedge walls where fading a 10-metre bank would wreck the frame: `Lit-CutoutCircle` draws a soft-edged dithered hole around the player's screen position (`_CutoutPos`, `_CutoutSize`, `_FalloffSize`, driven by `WorldToViewportPoint` + SphereCast). Ship the fade first; add the cutout **only if** greybox playtests show readability failures in hedge corridors.
3. **Never** fade small props — the clutter is the charm. Only renderers on the `Occluder` layer ever fade; set-dressing lives elsewhere.

**Operational rule: the player is never fully hidden for more than 0.5 s anywhere on a walkable path.** This is a level-design acceptance test as much as a camera one — level layouts are validated against it at all 8 yaws (§7.8.1).

**Banned:** Cinemachine's Deoccluder/Collider. Its only strategy is *moving the camera* to regain line of sight, which destroys a composed frame — camera dodging reads as glitching ([camera research §5](../research/11-tech-camera.md)).

---

## 7.7 The Two Scale Registers

Binding per [D3](./00-decisions.md): one camera, two authored illusions — no comp consciously switches between them, and the research (Pikmin vs Moss) shows they are *opposing* illusions worth authoring separately ([synthesis §5.9](../research/00-synthesis.md)).

| Register | Band | What sells it | Implementation |
|---|---|---|---|
| **Diorama** — "what a lovely miniature world" | Vista | Long lens (24°), steeper pitch, **subtle tilt-shift** focus band | Screen-band tilt-shift as a URP Renderer Feature: gentle blur in the top/bottom ~12% of frame, low intensity. **Whisper it** — strong tilt-shift turns mice into toys ([camera research §3](../research/11-tech-camera.md)). Off at Default |
| **Pallet moments** — "I am a mouse" | Near | Low framing, light through stems, shallow depth of field | Per-scene authored: pivot height dropped toward player eye-line, depth-aware DoF focused at the player plane, sun shafts through grass authored in the scene ([Art Direction](./06-art-direction.md)). Scripted per location, not global |

Default band carries **no** focus effects — it is the honest reading band. The full-screen storybook pass (paper grain, edge darkening, LUT) from [D4](./00-decisions.md) applies at all bands and is specified in [Art Direction](./06-art-direction.md).

---

## 7.8 Rules

### 7.8.1 The Monument Valley rule — interactables valid at all 8 yaws

**No interaction in the game may ever require a specific camera angle.** Every interactable must be discoverable, readable, and usable at all 8 yaw snaps and all 3 zoom bands.

Operational tests (run per zone, per build):
- Walk the zone at each of the 8 yaws; every interactable's prompt must appear at its normal trigger distance at every yaw.
- No interactable may be occluded at some yaws without the occluder participating in the fade system (§7.6).
- Interaction prompts render in screen space (no world-space signage that only reads from one side carries *required* information — decorative signage may, duplicate its content in the [Journal](./17-ui-philosophy.md)).

### 7.8.2 Motion comfort

Motion sickness is triggered by camera **rotation**, not translation ([camera research §7](../research/11-tech-camera.md)). Binding rules:

- **Translate freely, rotate carefully.** Arrival reframes are translation-dominant (≤ 15° total rotation), 1.5–2.5 s, EaseInOut.
- **Every cinematic reframe is interruptible** by movement input, within 1 frame.
- **Never animate yaw while the player is actively steering** except via the player's own snap input — and then latch the movement basis through the tween (§7.2.2).
- **No roll, ever. No camera shake.**
- **Reduced-motion option** (day-one accessibility, [D15](./00-decisions.md)): replaces the 0.35 s yaw tween with a 0.12 s fade-through-cut (brief dip to ~85% brightness, instant reposition); replaces arrival dollies with a cut to the composed end-frame (or skips them entirely); zoom-band transitions become cuts. Exposed in settings from the greybox build onward.
- Comfort is instrumented, not assumed: greybox exit criteria include external-tester comfort checks at both 60 and 120+ fps (blend feel differs with framerate).

### 7.8.3 The book-plate screenshot metric

The pillar, operationalised ([D3](./00-decisions.md)): every playtest, capture **10 random-timing screenshots**; the team votes each one "could be a book illustration — yes/no"; the score is tracked build over build in the build log.

- Greybox variant (no art yet): vote on *composition only* — clear subject, layered fore/mid/background, no dead framing. Target ≥ 5/10 at greybox exit.
- Look-dev slice onward: full criterion. Target ≥ 6/10 at G1, ≥ 8/10 at vertical slice (G2). A falling score across two consecutive builds is a camera bug — file it as one.

### 7.8.4 Anti-scope — what this camera is not

Binding "won'ts" for 1.0 unless a playtest-driven decision reverses them through [D3](./00-decisions.md):

- **No free orbit at MVP** (±10° spring-back drag is the only candidate concession, post-greybox).
- **No Cinemachine Deoccluder / camera-push occlusion handling.**
- **No orthographic projection.** No pixel-perfect / rendered-at-angle sprite tricks.
- **No cursor-pivot** rotation or zoom.
- **No alpha-blended fades** on foliage or shells — dither only.
- **No heavy tilt-shift** (toys, not mice) and no animated watercolour post filters ([D4](./00-decisions.md)).
- **No State-Driven Camera, no ClearShot at MVP** — priorities + triggers + one small FSM.
- **No camera control taken from the player without an interrupt path** (arrivals cancellable; the only hard camera locks are inside authored cutscenes, which pause time per [D6](./00-decisions.md)).

---

## 7.9 The 2-Week Greybox — First Production Task

Scope: prove the entire camera feature set on greybox geometry before any art or systems work ([D3](./00-decisions.md); plan from [camera research, MVP test plan](../research/11-tech-camera.md)). Deliverable: a build + a filled-in pass/fail sheet + a go/no-go note.

**Test scene:** greybox hedge corridor (~40 m), one two-room cottage with a door, one "mill" landmark with arrival trigger, 6 large occluder plants, a slope, and a stream crossing.

### Week 1 — rig and movement

| # | Task | Pass criterion |
|---|---|---|
| 1.1 | Brain + `CM_PlayerFollow` (composer per §7.2.4) | Frame breathes; player never leaves dead zone during normal walking |
| 1.2 | 8 × 45° yaw snaps, 0.35 s smoothstep, queueing | Rapid double-tap queues exactly one extra step; no spin-past |
| 1.3 | Camera-relative movement + input latching | Walk the full corridor at **all 8 yaws with zero control reversals**; held stick through a snap never changes the character's world direction |
| 1.4 | 3 zoom bands (presets per §7.2.3), 0.4 s transitions | Band steps feel composed, not zoomy; no clipping at Near in the corridor |
| 1.5 | Mill trigger volume + spline-dolly arrival | Arrival ≤ 2.5 s; **cancelled within 1 frame** by movement input; blend path never clips geometry |

### Week 2 — fades, interiors, comfort

| # | Task | Pass criterion |
|---|---|---|
| 2.1 | `Lit-DitherFade` shader + `CameraOcclusionFader` | Player never fully hidden > 0.5 s anywhere on the walkable path, at all 8 yaws; no sorting artefacts against foliage |
| 2.2 | Cottage interior camera + shell fade + confiner (§7.5.3) | Exterior→interior reads as **one continuous move, no cut**, 0.6–0.8 s; roof fade completes in 0.2 s; floors-above hidden |
| 2.3 | Hysteresis + 2 s min-live-time on all triggers | Standing on any trigger boundary produces **zero camera ping-pong in 60 s** |
| 2.4 | Vista tilt-shift toggle + Near DoF profile | Effects readable but subtle; team agrees mice do not read as toys at Vista |
| 2.5 | Reduced-motion mode (§7.8.2) | All rotations become fade-cuts; a motion-sensitive tester can play 10 minutes comfortably |
| 2.6 | Performance instrumentation | 60 fps at 1080p on GTX 1060-class and Steam Deck with all fades active ([D2](./00-decisions.md)) — trivial on greybox, but the harness exists from day one |

### Evaluation ritual (both weeks)

- **Comfort:** 3+ external testers; ask specifically about the arrival reframe and yaw snapping (the two motion-sickness candidates); test at 60 **and** 120+ fps. Pass = zero discomfort reports attributable to camera rotation.
- **Book-plate metric:** 10 random screenshots per playtest, composition-only vote (§7.8.3). Pass = ≥ 5/10.
- **Monument Valley audit:** every greybox interactable prompt fires at all 8 yaws (§7.8.1). Pass = 100%.

### Go/no-go outcomes

- **All pass →** camera architecture is locked; art production may begin against the building-construction rule (§7.5.1) and occluder-layer rule (§7.6).
- **Yaw/latching fails →** fall back to 4 × 90° snaps (same code, different constant) and re-test in 2 days before considering a locked yaw.
- **Interior transition fails →** try a 0.3 s fade-through-cut at the door as the fallback transition; the dollhouse *fade* itself is non-negotiable.
- **Comfort fails →** lengthen tweens toward 0.5 s, reduce arrival rotation budget to ≤ 8°, re-test; if still failing, reduced-motion behaviour becomes the default and the tweened version becomes the option.

---

## 7.10 Camera References

| Reference | What we take | What we refuse |
|---|---|---|
| **Tiny Glade** | The living-diorama feel; bounded camera; centre pivot; restrained tilt-shift photo mode as a marketing engine | Free orbit; cursor pivot; its custom-engine GI (not replicable — we bake, [Art Direction](./06-art-direction.md)) |
| **Snufkin: Melody of Moominvalley** | Storybook atmosphere; painted-texture pipeline; proof the audience exists | Its single bird's-eye angle — the exact criticism our arrival shots answer |
| **The Sims 4** | Cutaway semantics for interiors (§7.5.4) | Free camera, wall-mode UI, player-managed wall states |
| **Monument Valley** | Decisions valid only at snap positions → interactables valid at all 8 yaws | — |
| **Tunic** | Confidence that composed, restricted cameras read beautifully | Full immutability — we keep 8 yaws and 3 bands |
| **Fabledom** | Low camera angle that keeps a 3D feel without full top-down | Free rotation |
| **Divinity: Original Sin 2 / BG3** | Fade-the-first-occluding-layer behaviour for roofs and vegetation | Camera-dodge occlusion handling |

---

## 7.11 Evolution Note

An earlier concept considered relaxed third-person exploration in the style of *A Short Hike*. That approach was set aside: the storybook isometric direction better serves the illustrated world, the cutaway interiors, and the diorama presentation of the books. (A Short Hike-class scope remains the pre-agreed *fallback game shape* at gate G4 — a production decision, not a camera one; see [D16](./00-decisions.md) and the [Production roadmap](../production/roadmap.md) §5.)

---

[← Back to Index](./INDEX.md) | [Previous](./06-art-direction.md) | [Next: Visual Identity →](./08-visual-identity.md)
