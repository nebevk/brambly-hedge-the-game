# 6. Art Direction

[← Back to Index](./INDEX.md) | [Previous](./05-world.md) | [Next: Camera Direction →](./07-camera-direction.md)

**Status: production doctrine.** Implements [D4](./00-decisions.md) and inherits the pipeline decisions of [D2](./00-decisions.md). Where this document gives a numeric default, it is a calibration starting point to be tuned against scanned Barklem plates — not a canon fact. Rendering stack details live in [Technical Direction](./19-technical-direction.md); presentation and marketing rules live in [Visual Identity](./08-visual-identity.md).

---

## 6.1 The Doctrine

> **The watercolour lives in hand-painted albedo textures. The shader whispers.**

Every shipped storybook game reached its look through *authored surfaces* — hand-painted textures, curated palettes, painted lighting cues — never through a screen-space paint filter ([comps research](../research/05-comps-storybook-visual.md)). Dordogne's art director, who painted 180+ real watercolours for his game, explicitly rejected watercolour shaders because "most of the watercolor shaders are animated" and the eye "isn't really comfortable" with that; they "usually look fake" ([watercolour rendering research](../research/10-tech-watercolor-rendering.md)).

Jill Barklem's plates are the good news here: they are **dense, dry-brush, cross-hatched watercolour** — closer to Eastshade's "painted detail everywhere" than to loose wet washes. We need *painterly texture*, not simulated fluid. Consequences:

1. **Albedo is where the art budget goes.** Textures are painted with watercolour brush sets (Procreate/Krita for iteration speed; real scanned swatches for paper grain and pigment reference). Lighting information stays out of albedo except soft ambient occlusion.
2. **Exactly two pieces of rendering own the look:** one hero uber-shader (§6.3) and one full-screen storybook pass (§6.4). Their feature sets lock at the end of look-dev (M2, gate G1). After that, art problems are solved with paint, dressing, and lighting — never with new shader features.
3. **The gap between "toon shader + paper texture" and "Barklem plate" is closed by texture-authorship hours, not shader features** (risk #10 in the [synthesis](../research/00-synthesis.md)). The production plan budgets those hours explicitly.

### What "watercolour" decomposes into — and what we adopt

Real-time watercolour research names six separable effects ([research §2](../research/10-tech-watercolor-rendering.md)). We cherry-pick, subtly:

| Effect | What it is | Our verdict |
|---|---|---|
| Edge darkening | Pigment migrates to stroke edges as water dries | **Adopt** — highest-impact effect; warm darkened rims in the full-screen pass (§6.4) |
| Granulation | Pigment settling into paper tooth | **Adopt** — triplanar paper texture multiplied into shadow regions (§6.3) |
| Pigment turbulence | Blotchy uneven wash density | **Adopt in paint** — painted into albedo by the artist, not computed |
| Paper distortion | Wobbly contours from wet paper | **Adopt, edges only** — noise-wobbled shadow rims and edge-pass UVs; never full-frame warping |
| Colour bleeding | Wet-in-wet colours flowing together | **Reject** — most expensive, least necessary |
| Gaps & overlaps | Paint missing or crossing boundaries | **Reject at runtime** — painted into textures where wanted |

---

## 6.2 Reference Canon

- **Primary:** scanned plates from the eight Barklem books — the calibration standard (§6.10). Barklem spent ~5 years on botanical and rural-craft research; the Sunday Times called the books "the most research-crammed fantasy ever set before small children" ([canon bible](../research/01-brambly-hedge-canon.md)).
- **Pipeline references:** Snufkin: Melody of Moominvalley (Unity, hand-painted watercolour textures on real-time 3D — the most replicable full comp) and Season: A Letter to the Future (painted albedo + art-directed shadow tint + real light behaviour) ([comps research](../research/05-comps-storybook-visual.md)).
- **Standing purchases:** the Snufkin digital artbook (~$8) and the Dordogne artbook — reference-library purchases, outside the D2 Unity-asset cap.
- **Lighting outcome reference (not tech):** Tiny Glade's soft bounced pastel light. Its real-time GI is not replicable by this team; we approximate the *result* with baked GI (§6.10).

---

## 6.3 The Hero Uber-Shader

One Shader Graph family — environment / foliage / prop / character as variants of the **same graph** — so SRP batching survives and the look stays unified. Built on the Cyanilux custom-lighting sub-graphs (free, Unity 6 / URP 17.1+ maintained); recipes per feature in the [watercolour rendering research §4](../research/10-tech-watercolor-rendering.md).

| # | Feature | Spec | Default / range |
|---|---|---|---|
| 1 | **Soft 2–3 stop ramp** | Ramp-texture main light via Custom Function; wide soft transitions, *not* hard cel steps. Ramp sampled with **Sample Texture 2D LOD** (fixed mip) or distant objects shade wrongly | Transition smoothness 0.20 (band 0.15–0.25); 2 stops on props/characters, 3 on large terrain forms |
| 2 | **Tinted shadows — violet-grey, never black** | Shadow colour is a per-season global (`_ShadowTint`, set by the season palette asset §6.6), multiplied as a tint, not a black multiply | Starting tints: spring `#7C7594`, summer `#8A7A93`, autumn `#7D6A78`, winter `#6B7495`; strength 0.35 (0.25–0.5) |
| 3 | **Triplanar granulation** | Scanned cold-press paper texture, triplanar-projected (no UV seams), multiplied in — strongest inside shadow regions | Strength 0.30 (0–1); world-space scale one paper "tooth" ≈ 2–4 mm at mouse scale |
| 4 | **Noise-wobbled shadow rims** | Shadow map sampled at a noise-offset position, attenuation `step()`ed — shadow boundaries get painterly dark rims and hand-wobbled edges | Offset amplitude 0.8 cm world-space (0–2 cm); rim darkening +15% over shadow tint |
| 5 | **Fresnel edge darkening** | Subtle darkening on curved silhouettes — the pigment-pooling read on rounded forms (teapots, mouse cheeks, pumpkins) | Power 4 (3–5); strength 0.10 (≤0.15). Deliberately faint: the full-screen pass owns edges |
| 6 | **Mip paint-mask (Eastshade trick)** | Black-and-white paint-splat mask baked into the mipmap chain of environment albedos as alpha in low mips — distant surfaces dissolve into loose paint blobs and detail "paints itself in" as the camera dollies closer. Zero runtime cost | On for all environment/foliage textures; off for characters and hero props |
| 7 | **Wind vertex sway** | Height-masked object-space sway, scrolling noise, per-instance phase. At mouse scale wind is slow heavy swaying of *individual* oversized stems — low frequency, high amplitude — never lawn shimmer | Frequency ≤0.4 Hz on hero stems; grass handled by the Stylized Grass Shader (D2 buy list) |
| 8 | **Leaf/petal wrap** | Simple subsurface wrap term on foliage and petals (`saturate(dot(N,L) + 0.7)` class) so backlit leaves glow at Near zoom | Wrap 0.7; foliage variant only |

**Rules of the shader:**
- Every effect gets a **0–1 art-direction slider**, exposed on one material inspector, so the calibration ritual (§6.10) can toggle each independently.
- Minimal PBR: roughness mostly uniform, **no metallics anywhere** (pewter and brass are painted, not shaded).
- Feature set **locks at G1 (end of M2)**. New feature requests after lock require an owner decision and a measured cost.

---

## 6.4 The Full-Screen Storybook Pass

One Render Graph pass stack (written natively against Render Graph — no compatibility mode, per D2), applied always — this is the shipped look, not a photo filter:

| Stage | Spec |
|---|---|
| **Warm edge darkening** | Roberts-cross depth + normal discontinuity detection; edges rendered as **darkened warm pigment a few shades deeper than the local colour — never black ink lines**; edge UVs displaced by paper noise for hand-drawn wobble; screen-space edge width compensated by distance so it holds at all three zoom bands (D3) |
| **Paper overlay** | One scanned cold-press sheet, multiply/soft-light, **5–15% opacity** (default 8%), strongest in midtones and shadows; **world-anchored** (sample position offset by a world-locked anchor) to kill the "shower-door" artifact under camera dollies. The mostly-static Storybook Camera makes this artifact far milder than in free-camera games — a genuine advantage |
| **White paper vignette** | Corners and frame edges lift *toward paper white*, never darken — the unpainted-margin read of a book plate. Shares the single project paper swatch (see [Visual Identity §8.7](./08-visual-identity.md)) |
| **LUT grading** | 32³ 3D LUTs blended by game clock via URP Volumes; one shared LUT size project-wide (URP requirement). Season × time-of-day sets per §6.6 |

**Performance budget:** edge pass + paper overlay + LUT grading + height fog ≈ four cheap full-screen passes, inside the D2 gate of **60 fps @ 1080p on GTX 1060-class and Steam Deck**. Anything added here must displace something.

**Interaction warning (budget real time):** the edge pass must fade correctly with the dollhouse roof-fade dither ([Camera Direction](./07-camera-direction.md)) — faded roofs must not leave ghost edges. This is a known integration cost, scheduled in the camera greybox fortnight.

---

## 6.5 Explicit Rejections

These are decided (D4). They are written here so nobody relitigates them in month eight:

| Rejected | Why |
|---|---|
| **Animated watercolour filters / boiling paper** | Dordogne's warning, validated by every comp: none ships one. Animated paper reads as fake and tires the eye ([comps research](../research/05-comps-storybook-visual.md)). A *static* world-anchored grain at low opacity is the safe version |
| **Kuwahara / anisotropic painterly filtering** | It destroys exactly the miniature detail (stitching, jam jars, embroidery) that is the Detail pillar, and shimmers under camera motion. At most: one prototype for the record, expected outcome is the bin ([research §4](../research/10-tech-watercolor-rendering.md)) |
| **Camera-mapped painted world (full Dordogne pipeline)** | Locks the viewpoint; fundamentally incompatible with the rotatable Storybook Camera. Permitted **only** for fixed 2D art: journal spreads, festival memory stills, season title cards, loading vignettes |
| **Real-time GI, custom engines** | Tiny Glade's GI is a rendering-specialist-years investment. We bake (§6.10) |
| **Hard cel bands and black outlines** | Ni no Kuni's discipline we keep is *unified deep colours*, not its cel look. Barklem is soft ramps and warm pigment lines |
| **Twenty bespoke shaders** | One uber-shader family or SRP batching (and the look's unity) dies |

---

## 6.6 Seasons as Data — "Same Hedge, Four Books"

Seasons are an asset-swap problem, not a systems problem (D4). Each season ships as one data package:

```
SeasonPaletteSO (ScriptableObject — one per season, 4 at 1.0)
├─ seasonId          : string          // "spring" | "summer" | "autumn" | "winter"
├─ luts[5]           : Texture3D       // dawn, day, golden-hour, dusk, night — 32³, one shared format
├─ lutBlendCurve     : AnimationCurve  // game clock → LUT weights (golden hour has its OWN LUT;
│                                      //   a day↔night lerp skips it — known failure mode)
├─ shadowTint        : Color           // feeds uber-shader global _ShadowTint (§6.3 #2)
├─ sunGradient       : Gradient        // real-time sun colour across the 06:00–24:00 clock
├─ ambientTrilight   : Color[3]        // sky / equator / ground ambient
├─ foliageColormap   : Texture2D       // meadow-wide grass & foliage recolour (one texture swap)
├─ dressingSet       : PrefabSetSO     // seasonal prop dressing (see below)
└─ fogProfile        : FogSettingsSO   // ground-mist height, density, tint (Atmospheric Height Fog)
```

- **4–5 LUTs per season** (dawn/day/golden/dusk/night), blended by the game clock through URP Volumes.
- LUTs alone cannot turn green leaves auburn without wrecking every other hue — hence the **foliage colormap swap** plus a global season lerp parameter on vegetation materials.
- **Dressing sets** re-dress the same geometry per season: blossom and nest props (spring), produce baskets and swags (harvest), snow caps, icicles and lit windows (winter). Dressing points are authored once per zone; the set swaps.

**Acceptance test (from the look-dev checklist):** re-dressing the calibration scene from summer to autumn — LUT set + colormap + dressing set — takes **under one day of asset work**. If it takes more, the data model is wrong; fix the pipeline, not the deadline.

### Seasonal palette anchors (calibration starting points)

| Season | Light | Palette anchors | Shadow character |
|---|---|---|---|
| Spring | Cool clear mornings, fresh high light | Fresh leaf greens, bluebell violet, primrose yellow, blackthorn white | Cool violet-grey, light |
| Summer | Warm, long golden hours | Deep foliage green, meadowsweet cream, dog-rose pink, hot cornfield gold | Warm violet, soft |
| Autumn | Low amber sun, mist | Russet, crabapple amber, blackberry purple, stubble gold | Warm plum-grey, longer |
| Winter | Blue-grey daylight, firelit interiors | Snow whites, bare-twig umber, holly green, hearth amber through windows | Cold blue-violet, strongest tint |

---

## 6.7 The Botanical-Accuracy Bar

Barklem's world is botanically real, and reviewers of the books noticed ([canon bible §8](../research/01-brambly-hedge-canon.md)). Our bar is **botanical accuracy per season, not generic cottagecore** (D4). Operational rules:

1. **Every plant is identifiable to species** by a reader who knows English hedgerows, and appears **only in the months it genuinely flowers or fruits** in southern England. A bluebell in autumn is a bug, filed and fixed like any other bug.
2. Each season has a **botanical dressing list** derived from canon food, drink and story content — the plants the mice demonstrably use ([canon bible §5–6](../research/01-brambly-hedge-canon.md)):
   - **Spring:** bluebell (Bluebell Bank is the canonical picnic meadow), primrose, cowslip (Basil's spring wine), blackthorn blossom, young hawthorn leaf.
   - **Summer:** meadowsweet (wedding wine), elderflower, dog rose / sweet briar, clover, wild strawberry, watercress by the stream, cow parsley at its canonical 15–20× scale (D14).
   - **Autumn:** blackberry, rosehip (Mrs Apple's jam), elderberry, crabapple, sweet chestnut, corn stubble, seedheads.
   - **Winter:** hips and haws on bare twigs, old-man's-beard, holly and ivy, snowdrops at the season's very end as the turn signal toward spring.
3. **Gameplay props may exaggerate scale 1.2–1.5× (D14) but never species truth** — a blackberry may be plumper than life; it may not fruit in May.
4. The art bible carries a **per-species reference card** (photo, silhouette, season window, canon usage) before any artist paints it. Budget: ~10–14 hero species per season, reusing cross-season perennials.

---

## 6.8 Character Design Direction

### The Barklem mouse

Canon mice are **clothed, upright, working mice in period rural dress** — aprons, shawls, waistcoats, bonnets, breeches; Victorian-pastoral England in miniature ([canon bible §8](../research/01-brambly-hedge-canon.md)). Design rules:

- **Silhouette first:** every scheduled NPC must be identifiable at Default zoom by silhouette and costume colour alone — the camera spends most of its life too far away for faces.
- **Ears, whiskers, paws and posture do the acting.** Facial rigs stay simple; expressive body language over FACS. Snufkin's animation-on-twos / hand-animated charm is an accepted (and cheap) stylistic register ([comps research](../research/05-comps-storybook-visual.md)).
- **Player mouse = 10 cm canonical height (D14);** children ~0.8×, elders slightly stooped. Never state sizes in fiction.
- Fur is painted, not groomed: painterly albedo + the uber-shader — **no fur shells, no strand systems**.

### Cost model: shared base mesh + costume variants (D4)

| Asset | Count at 1.0 | Notes |
|---|---|---|
| Base mouse meshes | **3 builds** (child / adult / elder) | One rig family, shared animation set |
| Scheduled NPCs | 12 (D9) | Each = base build + head/ear/tail tweaks + costume |
| Costumes per scheduled NPC | **3**: everyday, winter over-layer, festival outfit | Costume = separate mesh layers over the base; fabric from the shared trim sheets (§6.9) |
| Festival/expedition extras | From the same 3 builds + recoloured costume pool | Never bespoke meshes |

### De-risk the designs early — the Eastshade warning

Eastshade's anthropomorphic "animal folk" were "a huge turn off for so many people" per its own postmortem — character design is a real commercial risk for an animal-protagonist game ([comps research](../research/05-comps-storybook-visual.md)). Therefore:

- **External audience-testing of mouse key art before anything is public**: at G1 (M2), show character boards to ≥100 respondents from cozy-game communities (codename only, and tier-(b) original/rename-safe boards only, per D1 and [ip-strategy §8](../production/ip-strategy.md) — Barklem-faithful tier-(a) sheets never leave team machines except inside the private pitch deck); revise any design that polls clearly negative. Repeat before the Wholesome Direct announce.
- **Canon layer / rename-safe layer (D1) materially applies here.** If licensed, character likenesses follow estate-approved Barklem model sheets. The rename-safe fallback needs **original designs that evoke the register without copying the likenesses** — so character sheets are maintained in two tiers from the start: (a) Barklem-faithful, (b) original silhouettes/costumes of equal charm. The base meshes, rigs and costume system are identical in both tiers; only the sheets differ.

---

## 6.9 Environment Cost Levers

The world is one hedgerow strip with 6–10 dollhouse interiors (D14). It is affordable only through aggressive reuse (D4):

| Lever | Spec |
|---|---|
| **One modular burrow kit** | All 6–10 interiors built from one kit: curved wall/root segments (3 radii), floor discs and landings, spiral stair + ladder, round-top doorframes (1.2–1.4× mouse scale, D14), round windows, hearth/range unit, shelving/dresser units, beam and joist set. Target **40–60 unique kit pieces**. Store Stump, Old Oak Palace and the Mill are "hero assemblies" of the same kit plus ≤10 bespoke pieces each |
| **Prop families** | One master prop begets material/scale variants sharing a texture sheet (teapot → cups, jug, tureen). Target ~30 families × 4–8 variants ≈ **150–250 props**; bespoke one-off hero props (the wedding raft, the midwinter log, Mrs Apple's diary) capped at **≤20% of total prop count** |
| **Trim sheets & atlases** | One 2048² wood trim (mouldings, shelf edges, stair noses), one 2048² fabric/quilt sheet, one crockery/glaze sheet, one 2048² foliage atlas (Eastshade's single-atlas discipline). New trim sheets require an art-lead sign-off |
| **Vegetation** | Bought, not built: Stylized Grass Shader for wind + player-bend + colormap blending (D2 buy list). Hero stems (cow parsley, foxglove) are the exception: modelled, wind-swayed via §6.3 #7 |

Draw calls are the budget, not polygons (D2): the uber-shader family keeps SRP batching intact, GPU Resident Drawer collapses the thousands of static plants, and the foliage atlas keeps materials few ([research §7](../research/10-tech-watercolor-rendering.md)).

---

## 6.10 Lighting Direction

Softness is a lighting decision. Tiny Glade proves players read *soft bounced light* as "storybook" before they notice any texture ([comps research](../research/05-comps-storybook-visual.md)). Our approximation:

- **One real-time directional sun** (the only real-time shadow caster), colour driven by the season's `sunGradient` across the 06:00–24:00 clock (D6).
- **Baked GI everywhere else.** Exteriors: one bake per season (bounce + AO under a canonical mid-morning sun) + light probes; Light Probe Proxy Volumes give canopies their vertical light gradient (Eastshade's trick). **4 seasonal bake sets are budgeted; time-of-day is carried by the sun + LUTs, never by re-baking.**
- **Interiors: their own baked lightmap volume**, warm candle/range/firelight tones, so a cutaway interior reads as a warm illustrated cross-section against the cooler exterior — the signature Barklem contrast. Interior bakes are time-invariant except an emissive-window/lamp state that switches at dusk.
- **Nothing pure black, ever.** Shadow floor lifted: after grading, the frame's black point sits at ≥8–10% luminance (checked by histogram in the calibration ritual). Night is *blue-violet*, not black; winter-interior contrast comes from warmth, not darkness.
- **Time-of-day is gradient tinting, not light choreography:** LUT blends (§6.6) + sun gradient + fog tint. No moving interior lights, no per-hour lighting states.
- **Fog sells the diorama:** low ground mist at mouse height + gentle distance fog tinted to the sky LUT separates foreground miniature detail from soft background (Atmospheric Height Fog, D2 buy list).

---

## 6.11 The Calibration Ritual

The only defence against "asset-store toon shader" drift is ritualised comparison against the source (D4).

**Fixtures:**
- A private reference board of **12 scanned Barklem plates** — per season: one cutaway interior, one exterior vista, one character close-up. (Internal reference use, private repo, per D1.)
- **The calibration scene:** one hedge-bank exterior + the Crabapple Cottage kitchen interior, with **3 fixed camera bookmarks** (Vista exterior / Default mixed / Near interior) — the same scene used for the MVP camera-shader checklist ([research §7 checklist](../research/10-tech-watercolor-rendering.md)).

**The ritual (weekly through M1–2 look-dev, monthly thereafter):**
1. Render the calibration scene from the 3 bookmarks at current build settings.
2. Place side-by-side with the matched plate, plus one Snufkin and one Tiny Glade still as secondary comps.
3. Toggle each uber-shader effect and each storybook-pass stage **independently** (the 0–1 sliders exist for this).
4. Team scores five questions, 1–5, logged in the art bible: *warmth / detail density / paper feel / shadow colour / edge & silhouette hand-wobble*.
5. Any score ≤2 generates a named action item; three consecutive flat scores on the same question triggers an art-direction review, not more shader work.

The ritual's output feeds the book-plate screenshot test ([Visual Identity §8.2](./08-visual-identity.md)) — the ritual calibrates the *look*, the screenshot test measures whether the *game* achieves it.

---

## 6.12 Art-Direction Acceptance Summary

The art direction is succeeding when all of these are true:

- [ ] A scanned plate and a calibration render sit side-by-side and a stranger hesitates before saying which is which at thumbnail size.
- [ ] Every effect in §6.3/§6.4 can be toggled independently and each visibly earns its place.
- [ ] A season re-dress of the calibration scene costs < 1 day (§6.6 test).
- [ ] No plant is out of season; each has a species card (§6.7).
- [ ] All 12 scheduled NPCs read by silhouette at Default zoom; external audience testing shows no Eastshade-pattern rejection (§6.8).
- [ ] 60 fps @ 1080p on GTX 1060-class and Steam Deck with the full pass stack on (D2).
- [ ] Frame histogram black point ≥8–10% luminance in all graded scenes (§6.10).

---

[← Back to Index](./INDEX.md) | [Previous](./05-world.md) | [Next: Camera Direction →](./07-camera-direction.md)
