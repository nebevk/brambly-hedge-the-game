# 8. Visual Identity

[← Back to Index](./INDEX.md) | [Previous](./07-camera-direction.md) | [Next: Gameplay Loop →](./09-gameplay-loop.md)

**Status: production doctrine.** This section defines how the game *presents itself* — to the player, frame by frame, and to the world, GIF by GIF. It operationalises the promise made in [Art Direction](./06-art-direction.md) and [Camera Direction](./07-camera-direction.md): the player has stepped into the books themselves. Implements [D3](./00-decisions.md) (screenshot test, scale registers), [D13](./00-decisions.md) (photo mode), and the marketing cadence of [D16](./00-decisions.md).

---

## 8.1 Presentation Philosophy

Most cozy games are *set somewhere pretty*. This game is **composed** — every frame is a candidate book plate, because the semi-fixed Storybook Isometric Camera guarantees a bounded set of viewpoints we can author for ([Camera Direction](./07-camera-direction.md)). We deliberately trade camera freedom for the guarantee that the world always faces the reader the way a Barklem plate faces the reader.

Three consequences run through everything below:

1. **The look is measured, not asserted** — the book-plate test (§8.2) turns "looks like an illustration" into a tracked number.
2. **The shipped look and the shown look are the same look.** No marketing-only shaders, no bullshots (§8.6). What the GIF promises, the player's own screenshot delivers.
3. **The identity extends past the render into every surface the player touches** — journal, menus, photo plates, store page — via one shared visual grammar (§8.7).

## 8.2 The Book-Plate Test (operational)

> *"Every frame of gameplay should be capable of looking like an illustration from a Brambly Hedge book"* — [Camera Direction](./07-camera-direction.md). Here is how that stops being an aspiration:

**Procedure (every weekly build, D3):**

1. A debug command captures **10 screenshots at random**: random zone, random of the 8 yaw steps, zoom band weighted Default 60% / Near 20% / Vista 20%, random clock time between 06:00 and 24:00, random season among those in the build.
2. Captures use **shipped settings only** — storybook pass on, no photo-mode garnish, no debug UI, no hand-picking. If an NPC is mid-yawn in frame, that is the point.
3. Each team member votes each frame yes/no: **"Could this be a book illustration?"** The build's **plate rate** = % yes.
4. Every "no" gets a one-word failure cause: `composition` / `dressing` (density too thin) / `lighting` / `shader` / `wip-asset`. Causes are tallied; the dominant cause sets the following week's art priority.

**Targets, tracked build over build:**

| Milestone | Plate rate target |
|---|---|
| G1 — look-dev slice (M2) | ≥ 40% |
| G2 — vertical slice (M6) | ≥ 60% |
| Demo hardening (M10) | ≥ 75% |
| 1.0 | ≥ 80%, no zone below 70% |

A falling plate rate is treated as a regression, same as a frame-rate drop. The test's random-yaw rule also enforces the D3 interaction rule from the art side: the world must compose — and interactables must read — **at all 8 yaws**.

## 8.3 The Two Scale Registers

The camera authors two opposing illusions and never muddles them (D3; [synthesis §5.9](../research/00-synthesis.md)):

| | **Vista — "what a lovely miniature world"** | **Near — "I am a mouse"** |
|---|---|---|
| Zoom band | Vista (outermost) | Near (innermost) |
| Signature | Diorama tilt-shift: gentle top/bottom focus band, the hedge as a handcrafted model on a table | "Pallet moments": low pivot, sunlight shafting through grass stems, backlit leaves, towering cow parsley |
| Depth | Tilt-shift DoF + tinted distance fog separating miniature foreground from soft background | Shallow intimate DoF; ground mist at eye height |
| Audio (cross-ref [16](./16-music-and-audio.md)) | Wide ambience over faint tiny-world detail | Intimate foley, narrowed ambience (zoom-linked mixer snapshots, D12) |
| Player feeling | Benevolent reader looking into the book | Character inside the plate |

**Authoring rules:**
- Registers are **scripted per location, not emergent**: each of the 3–4 zones must author **≥1 composed Vista per season** (≤16 vista compositions at 1.0) and **≥2 Near "pallet moment" spots** (a light shaft, a stem colonnade, an under-leaf hollow) that the camera's Near band naturally finds.
- The subtle tilt-shift band is **on by default at Vista** — it reinforces the miniature fantasy and it is the marketing look; a reduced-motion/effects accessibility toggle exists (D15).
- Transitions between registers ride the D3 zoom-band tweens; a register change may never require a camera angle the player can't reach (Monument Valley rule).

## 8.4 Micro-Reactivity — Alive at 1% of the Tech

Tiny Glade's pillar "it's alive" (paths wear in, birds land, sheep get petted) is what players *perceive* as its magic — and it is approximable with decals, triggers and schedule data rather than a custom engine ([comps research](../research/05-comps-storybook-visual.md)). Scope, binding at 1.0:

| # | Feature | Trigger | Tech | Cap |
|---|---|---|---|---|
| 1 | **Worn-path decals** | Route walked repeatedly by player + NPCs; wear deepens over in-game days, grass regrows if unused for a season | Spline decals, 3 wear states | ≤12 tracked routes |
| 2 | **Birds & butterflies** | Player idle >8 s → perch/land nearby; flee on movement. Species rotate by season (butterflies spring/summer; robin in winter) | Simple FSM + 3–4 ambient species per season | ≤2 active per screen |
| 3 | **Dusk windows** | 18:00–19:30: windows warm up in a staggered sequence (2–10 min apart), chimney smoke starts | TimeService events → emissive state (see [06 §6.10](./06-art-direction.md)) | All homes; zero per-frame cost |
| 4 | **Grass parting & bend trails** | Player/NPCs pushing through grass | Stylized Grass Shader bend (bought, D2) | — |
| 5 | **Project weathering** | Community-project structures visibly weather and are visibly restored across project phases (D7's ambient-change rule) | Material state swaps on the uber-shader | Per project |
| 6 | **Doors & routines** | NPCs visibly leave/enter homes on schedule | Free with D9 schedules | — |

**Budget rule:** each item must land in **≤1 week of implementation**; the whole list in **≤6 weeks total**. Anything that busts its week is cut or demoted to post-launch. This list *is* the 1.0 aliveness scope — additions require an owner decision.

Micro-reactivity is also continuity: item 5 is how the world testifies that the community acts (D7), and item 1 quietly maps the player's own year into the ground.

## 8.5 Photo Mode & the Storybook Plate

A marketing-grade photo mode ships **from the first public build** (D13) — Tiny Glade's 1.37M launch wishlists were built on shareable images ([comps research](../research/05-comps-storybook-visual.md)).

**Controls (bounded, so every photo stays on-identity):**
- Free yaw; pitch within 20–60°; FOV 22–35°; dolly across the full zoom range; focus point + aperture; tilt-shift slider; hide-player toggle. NPCs are never hidden — they are the life in the frame.
- Time pauses in photo mode (journal-class pause, D6). No time-of-day scrubbing: the light you photograph is the light you were living in.

**The one-click "Storybook Plate" render:**
- Applies: heavier paper overlay, white deckled-edge vignette margin, a slight warm plate grade, optional caption in the journal display lettering. Saved as 4K PNG.
- The plate garnish is the **only** delta from the shipped look — photo mode must never look better than the game (anti-bullshot rule, §8.6).
- A captured plate also fills an illustrated **journal sketch page** — canon-native, since Lady Daisy paints ([canon bible](../research/01-brambly-hedge-canon.md)); the photography-to-sketching demotion is per D13. **⚠ DEFAULT — owner to confirm** (D13).

**Acceptance test:** a first-time player produces a frame they voluntarily share within their first session; the "journal illustration" render doubles as the marketing screenshot fixture in the look-dev checklist ([watercolour research §7](../research/10-tech-watercolor-rendering.md)).

## 8.6 Marketing-Look Consistency — the GIF Hook

The game's single most marketable image is **one continuous camera move: Vista hedgerow → Default approach → Near cutaway kitchen, fully furnished, kettle steaming** — the dollhouse-camera hook (D3, [synthesis §3.02](../research/00-synthesis.md)). Every public beat is built around variations of it.

**Binding rules for every public asset:**

1. **In-engine capture at shipped settings only.** No exclusive shaders, no post-capture colour edits beyond crop and loop trim. Any look shown publicly must be reproducible by a player in the shipped build — the anti-PuffPals rule; overpromised art erodes exactly the trust a cozy audience runs on ([synthesis risk #10](../research/00-synthesis.md)).
2. **Clip spec:** 3–8 s seamless loops, captured at 1440p/60 and downscaled; storybook pass on; no debug UI; no unshipped content.
3. **Cadence:** 1–2 clips/week from the look-dev slice onward, with a named owner (D16). The book-plate test's best frames are the default clip-hunting ground.
4. **Naming discipline (D1):** public assets use **Project Hedgerow** and zero canon names, locations or story strings until a licence is signed. Rename-safe capture rule: clips avoid framing text signage or name cards, so no asset is invalidated by a rename.
5. **One look everywhere:** Steam capsules, GIFs, screenshots, trailer and the eventual store page all pass through the same plate grammar — paper white, warm edge pigment, tilt-shift miniature framing — so the store page reads as a shelf of plates from one book.

## 8.7 UI & Visual Continuity with the Journal

The Journal (D17 terminology) is the UI — a diegetic continuation of Mrs Apple's matrilineal diaries ([canon bible §6](../research/01-brambly-hedge-canon.md)), and the identity must hold when the 3D world opens into it ([UI Philosophy](./17-ui-philosophy.md)).

**Continuity rules:**

| Surface | Rule |
|---|---|
| **Paper** | One scanned cold-press sheet is the project's **single paper swatch** — used by the full-screen vignette, journal pages, storybook plates, marketing frames and store capsule backgrounds. Tone starting point `#F5EEDF` (calibration default, tuned in the [06 §6.11 ritual](./06-art-direction.md)). If the vignette paper and the journal paper ever differ, one of them is wrong |
| **In-world screen furniture** | No HUD by default (D14: no minimap). Interaction prompts are small painted labels on paper chips; subtitles sit on the same paper. Nothing floats that couldn't be painted |
| **Menus** | Every menu is a journal spread — genuinely 2D illustrated pages the 3D game opens into (our Plucky Squire moment at ~1% of its cost, [comps research](../research/05-comps-storybook-visual.md)). Page-turn transitions 0.3–0.4 s; time pauses (D6) |
| **Fixed 2D art** | Dordogne-style painted stills live *here* — festival memories, recipe pages, season title cards — where a fixed viewpoint costs nothing (per the [06 §6.5](./06-art-direction.md) rejection of camera-mapping in the world) |
| **Typography** | Body text: a humanist serif with full EFIGS coverage and CJK companion fonts selected with Unity Localization in month one (D15). Display lettering: hand-painted, limited to ~20 strings per language (titles, season cards) so the 60–80k word budget and eight languages stay affordable. Scalable text is a day-one requirement (D15) |
| **Iconography** | Painted watercolour miniatures on paper — small still-lifes of the real object (a rosehip, a reel of thread) — never flat vector glyphs. Forage highlighting remains colourblind-safe (D15): shape + outline redundancy, not hue alone |
| **Colour discipline** | UI introduces no hues outside the active season's palette (see [06 §6.6](./06-art-direction.md)) except the journal's own constants: leather cover, ink, paper |

## 8.8 Identity Acceptance Summary

The visual identity holds when all of these are true:

- [ ] The weekly plate rate meets its milestone target and no zone lags >10 points behind the average (§8.2).
- [ ] Both scale registers are demonstrably authored in every zone: the Vista composition list and Near-spot list exist and are walkable (§8.3).
- [ ] All six micro-reactivity features are live within their caps; nothing on the list slipped past its one-week budget (§8.4).
- [ ] A first-session player can produce and share a Storybook Plate; the plate garnish is the only delta from gameplay (§8.5).
- [ ] Every public asset to date is reproducible in-build, uses the codename only, and frames no canon text (§8.6).
- [ ] One paper swatch, one plate grammar, from full-screen vignette to Steam capsule (§8.7).
- [ ] Opening the journal feels like turning the game over to see the book it came from — and closing it feels like the plate coming back to life (§8.7).

---

[← Back to Index](./INDEX.md) | [Previous](./07-camera-direction.md) | [Next: Gameplay Loop →](./09-gameplay-loop.md)
