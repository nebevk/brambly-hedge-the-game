# 17. UI Philosophy

[← Back to Index](./INDEX.md) | [Previous](./16-music-and-audio.md) | [Next: Community Philosophy →](./18-community-philosophy.md)

**One sentence:** the game has almost no HUD; its interface is **the Journal** — a genuinely 2D illustrated book the 3D world opens into, which records what happened in prose and sketches and never once asks the player to complete a checklist.

This section is binding on UI implementation and UI art. It agrees with [00-decisions.md](./00-decisions.md) (D2 save rules, D3 camera, D5 scope, D6 time, D13 sketching, D14 no-minimap, D15 accessibility/localisation, D17 terminology). Related sections: [07 — Camera](./07-camera-direction.md), [14 — Quests](./14-quests.md), [19 — Technical Direction](./19-technical-direction.md).

---

## 1. Principles — restated as testable rules

"Players should look at the world instead of menus" is the spirit; below is the letter. Each rule has a pass/fail test a developer or QA can run on any build. Rationale is drawn from the [cozy pitfalls study](../research/09-cozy-pitfalls.md) (pitfall #11: journal-as-checklist) and the [no-combat quest comps](../research/06-comps-cozy-quests.md).

| # | Principle | Testable rule | Test procedure |
|---|---|---|---|
| P1 | **Minimal HUD** | During free play (no interactable in range, no event in the last 3 s, no held Peek input), the frame contains **zero UI pixels**. | Take 10 random free-play screenshots per build (same batch as the D3 book-plate vote); count UI pixels. Any non-zero frame fails. |
| P2 | **No minimap** | No screen-corner map, compass, or radar exists in any build, ever. The Journal's map page is a drawn illustration, not a live overlay (§3.3). | Grep the UI prefab set for map-render components; visual audit each milestone. |
| P3 | **No quest markers** | No world-space icons above NPCs or objects (no `!`, no arrows, no floating diamonds), no objective text on the HUD, no breadcrumb trails. Wayfinding = landmarks + diegetic signposts + Journal prose (§3.8, per D14). | Walk every active quest state; any floating marker fails the build. |
| P4 | **No damage numbers — and no numbers at all** | No floating numerals of any kind: no "+20 friendship", no XP, no currency (there is none, D8). Feedback for social/gathering actions is animation, vocalisation, and SFX ([audio](./16-music-and-audio.md)). Exception: stack counts inside container UIs (satchel, Store Stump shelves) — counting what you hold is not scorekeeping. | Trigger gift-giving, gathering, cooking; screen-record; any floating numeral fails. |
| P5 | **No progress bars or percentages** | Zero player-facing fill bars, checkbox glyphs, `x/y` counters, or `%` strings anywhere — HUD, Journal, menus, save slots. Internally the sims use ints/fractions freely; display always passes through fuzzy prose (§3.6). | String-table audit: no `%` or `{x}/{y}` patterns in player-facing tables; UI asset audit for bar sprites. |
| P6 | **No modal interruptions** | Nothing steals control to congratulate the player. Recorded events show a 2 s quill flourish (§4); tutorials are contextual prompts, never pop-up windows. | Play the first hour; any control-stealing non-cutscene window fails. |
| P7 | **Diegetic first** | Every persistent piece of game information must have a diegetic home (the Journal, a signpost, an NPC line, the world's light) before any overlay is considered. | Design review gate on every new UI request: "where does this live in the world?" must be answered first. |

**The clock corollary (P1 + D6):** there is **no ambient HUD clock**. Time of day is read from light, shadows, and NPC behaviour. The exact clock (10-minute ticks, per D6) appears in exactly two places: the **Peek overlay** (§4.3) and the Journal's diary header. Playtests of the camera greybox must verify players can estimate time-of-day within ±2 in-game hours from light alone; if not, the lighting rig is wrong — we fix the sky, not the HUD.

---

## 2. The Journal — canon grounding and the one-line pitch

**The Journal** (D17 terminology) is the game's primary interface: map, recipes, neighbours, projects, calendar, sketches, diary, save.

**Canon grounding.** Mrs Apple "keeps a journal of each day's events and each season's recipes, and owns the diaries of her mother, grandmother and great-grandmother" — recipes and daily records are handed down **matrilineally** in Brambly Hedge ([canon bible §4, §6](../research/01-brambly-hedge-canon.md)). The player's journal is framed in-fiction as a continuation of this tradition: a blank book given to the newcomer (D9) in the first hour, "so you'll remember your first year in the hedge." Lady Daisy's painting and sketching canonises the sketchbook pages; Wilfred's explorer backpack canonises the satchel/inventory. **Canon-layer note (D1):** the *tradition* of matrilineal diaries and the giver's identity are canon-layer; the Journal mechanic itself is rename-safe and survives Plan B untouched.

**The Plucky Squire moment.** The Plucky Squire's unclonable 2D↔3D switching tech is out of reach, but its *conceptual* steal is ours at ~1% of the cost: **the book as diegetic frame** ([storybook visual comps §4](../research/05-comps-storybook-visual.md)). Journal pages are **genuinely 2D illustrated spreads** — Barklem-style decorated borders, painted vignettes, paper texture — that the 3D game literally opens into and out of. Dordogne-style hand-painted stills live here (festival memories, recipe cards, season title pages): high art impact, fixed viewpoint, zero conflict with the Storybook Isometric Camera. Season: A Letter to the Future proves a diegetic journal can carry a game's entire information layer.

**Opening transition spec (implementable):**

- Input: one dedicated button (default `J` / `Tab` / gamepad `Y`). Opens to the Diary tab; double-tap opens the Map tab directly.
- Time pauses (D6). Input switches from `Gameplay` to `UI` action map (§5).
- Animation: the 3D frame desaturates and softens over 0.25 s as the book rises and opens across the screen, 0.5 s total, ease-out. Closing reverses in 0.35 s. **Reduced-motion variant (D15): straight 0.2 s crossfade, no book movement.**
- While open, the 3D scene is not simulated and its render is frozen to a texture — a deliberate Steam Deck battery courtesy (perf gate, D2).
- Page turns within the Journal: 0.3 s turn animation with paper SFX; reduced-motion: instant with crossfade.

---

## 3. The Journal — full spec

### 3.1 Tab/spread structure

The Journal is a set of thumb-tabbed sections, each a series of two-page spreads. Eight tabs at 1.0; MVP ships the four marked ●.

| # | Tab (thumb-tab motif) | Contents | Auto-record trigger | Never shows |
|---|---|---|---|---|
| 1 ● | **Diary** (quill) | One prose entry per played day, auto-composed from templates + hand-authored fragments; ends with the wayfinding paragraph (§3.8). The most recent entry is the load-screen page (§3.7). | Written progressively through the day; sealed on sleep. | To-do lists; imperative bullets. |
| 2 ● | **Map** (oak leaf) | Hand-drawn map in the style of the books' endpapers. Locations are inked in as first visited; signposts and named landmarks labelled. **No live player dot, no live NPC positions** — it is an illustration, not an instrument. | First visit to each named POI inks its vignette. | Real-time anything; fog-of-war rectangles; markers. |
| 3 ● | **Neighbours** (pawprint) | One spread per scheduled NPC (12 at 1.0, D9). Portrait sketch that warms/gains detail per heart tier; **auto-recorded gift preferences as prose** ("Wilfred was delighted with the blackberry buns — 3rd May"); birthday inked into their page and the Calendar once learned; heart-scene mementoes as small sketches. Friendship tier shown as a row of **discrete pressed-flower motifs** (whole tiers only, per D9's 8–10 hearts — never a partial fill, never points). | First meeting; each gift reaction; each heart-scene; overheard facts. | Friendship point values; "next reward at X" hints; loved/hated tables the player hasn't discovered. |
| 4 ● | **Recipes** (mixing spoon) | Recipe cards in Mrs Apple's tradition: ingredients with seasonal notes in prose ("blackberries — ripe in autumn along the far bank"), the teacher's name, a painted vignette of the dish. Launch set from canon ([canon bible §6](../research/01-brambly-hedge-canon.md)). | Learning a recipe (taught, festival, experiment). | Uncooked-recipe silhouettes; "42/60 recipes" counts. |
| 5 | **Undertakings** (rope coil) | Community-project pages (D7). Each phase adds an illustrated vignette + a dated prose entry — story-so-far, in the order it happened. Contribution state renders as fuzzy prose (§3.6). Completed projects keep their spread forever: this tab becomes the hedge's chronicle. | Proposal seconded; each contribution day; each construction stage; celebration; function change. | Fill bars; material tallies ("7/12 reeds"); phase checklists. |
| 6 | **Calendar** (holly sprig) | The season's 14 days (D6) as a hand-drawn strip; festival page per season showing what the festival *will be like* (painted) and, in prose, what the hedge is waiting on (season valve, D6/D7). Learned birthdays and standing events (weekly hedgerow supper, D9) inked in. | Season start; festival unlock; birthday learned. | Countdown timers; expiring-content warnings (none exist, D6); locked-festival silhouettes for future years. |
| 7 | **Sketchbook** (pencil) | Journal sketching per D13: capturing a view fills a bordered sketch page with location + date caption. Sits beside, not instead of, the system-level photo mode (§4.5). **⚠ DEFAULT — owner to confirm** (D13: photography demoted to sketching). | Player-initiated sketch action. | Sketch quotas, "spots remaining" counters. |
| 8 | **Ancestors' pages** (faded ribbon) | Lore collectibles: pages from the diaries of earlier generations of hedge cooks and record-keepers, found in the world (Secret-Staircase-style discoveries in Old Oak Palace and elsewhere). Older paper stock, different handwriting per generation. **Canon-layer note (D1):** attribution to Mrs Apple's line is canon-layer; "found ancestors' diary pages" is rename-safe. | Finding a page in the world. | "12 of 30 pages found." Found pages slot into gaps whose existence is only visible once adjacent pages exist. |

### 3.2 The hard rule (binding)

> **The Journal records what happened, in prose and sketches. It never instructs, never tallies, never scores.**

Operationally: **zero checkbox glyphs, fill bars, `x/y` counters, percentage strings, or imperative bullet lists anywhere in the Journal.** This is the direct counter to the checklist-UI trap — "worlds that feel like checklists" recreate FarmVille's second job in prettier clothes, and journal-as-checklist is ranked pitfall #11 for this project specifically ([cozy pitfalls](../research/09-cozy-pitfalls.md)). Garden Story's town ledger shows contribution-points UI reads as a spreadsheet; Cozy Grove shows players tolerate structure only when story is visibly the reward track ([quest comps §5, §8](../research/06-comps-cozy-quests.md)).

Enforcement: the string-table lint (§7) plus a design-review gate — any feature request that "just needs a small progress indicator" is answered with a prose band (§3.6) or is cut.

### 3.3 The Map page

- Authored as one 2D illustration per zone (3–4 zones, D14) in endpaper style; locations begin as blank paper and are inked in (0.4 s ink-spread animation; reduced-motion: instant) on first visit.
- Labels are **live localised text layered over the art** — never painted into the illustration (§7).
- The map may be annotated by story: after an NPC gives directions, a dotted hand-drawn line or note may appear ("past the crab-apple, over the new bridge — Mr A."). These are authored per-thread, not systemic, and they are *records of advice received*, not markers.
- Test: open the map while an NPC walks past the depicted location — nothing on the page moves. Ever.

### 3.4 Neighbours' pages — auto-recording spec

Gift preferences, birthdays, and facts enter the Journal **only when discovered in play** (gift given, line overheard, scene watched). Each discovery appends a dated prose fragment from a hand-authored pool (≥3 variants per reaction tier per NPC to avoid Garden-Story-style visible repetition, [quest comps §5](../research/06-comps-cozy-quests.md)). The page is the anti-wiki: a player who gifts attentively never needs an external site, which is the actual function of "auto-recorded preferences" — respect for the player's memory without a spreadsheet.

### 3.5 Undertakings pages — community projects in prose

Each of the five phases (D7: Proposal → Contribution → Construction → Celebration → Function) appends to the project's spread:

- **Proposal:** who proposed it at the meeting, what was decided, the soft target *as spoken* ("Mr Apple reckons about twelve bundles of reeds").
- **Contribution days:** one dated line per day naming NPCs seen working ("Dusty and Mrs Toadflax were at the reed bed all morning") — reinforcing that the hedge works with or without you (D7).
- **Construction stages:** vignette sketches of the staged build the player witnessed.
- **Celebration:** a full painted spread — the Dordogne-style hero still for that season.
- **Function:** the next morning's entry records the ≥3 mandated changes (schedule, service, ambient — D7) as observations, e.g. "the mill turns; Dusty grinds flour on Tuesdays now."

### 3.6 Fuzzy quantifier bands (the only progress display in the game)

Contribution state is stored as exact ints internally and rendered exclusively through prose bands via Smart Strings ([tech architecture §8](../research/12-tech-systems-architecture.md)):

| Internal fraction | Band key | English rendering (example) |
|---|---|---|
| 0 | `not_begun` | "we've not yet begun" |
| (0, ⅓] | `a_start` | "we've made a start" |
| (⅓, ⅔] | `under_way` | "well under way" |
| (⅔, 1) | `nearly` | "nearly there — a few more should do it" |
| ≥ 1 | `ready` | "ready and waiting" |

Rules: bands are localised whole phrases (never concatenated numerals); band thresholds live in one config asset; NPC dialogue about the project draws on the same band keys so the Journal and the neighbours never disagree.

### 3.7 The save ritual — journal at bedside

Per D2, the game saves **on sleep only**, and the fiction is exact: the Journal sits at the player's bedside; going to bed *is* writing up the day.

- Choosing "to bed" plays the write-up beat (~3 s, skippable after first week): the day's Diary entry seals with the date, the quill rests, the candle goes out. The autosave (atomic write + rotating backup, D2) completes **behind** this animation — the ritual is honest, not decorative.
- **The load screen is the Journal**: continuing a game opens the book to the last sealed entry, re-reading yesterday before today begins. Save-slot metadata (day, season, in-game date) renders as the entry's header — no percentages, no playtime clock on the slot (P5).
- There is no manual save UI. Quitting mid-day warns plainly: "The journal is written at bedtime — today's doings will be lost." (Exact string localised; no ambiguity, no dark pattern.)

### 3.8 Goal restating in prose — the wayfinding safety net

No minimap and no markers has a known ~50/50 lost-vs-frustrated failure mode (D14); the Journal is the designed mitigation. **Every active thread (quest, project phase, invitation) must maintain a current two-sentence prose state**, auto-composed as *what happened last* + *a directional hint referencing a named landmark*:

> "We spent the morning cutting reeds by the stream. Mr Apple thought twelve bundles would do — we're well under way, and the best reeds grow past the crab-apple tree on the far bank."

Rules (testable):

- Hint fragments are hand-authored per thread stage (not procedurally assembled beyond template slots), reference **only named landmarks/POIs that exist on the Map page**, and never give compass directions or distances.
- The Diary's most recent entry always ends with the wayfinding paragraph for the most recently advanced thread; the Undertakings/Neighbours page for each thread carries its own.
- QA gate: a fresh playtester, handed any mid-game save, must be able to resume the active thread within 5 minutes using the Journal alone. Run this test at every milestone (it is the no-minimap decision's continuing licence to exist).

---

## 4. Moment-to-moment HUD — context prompts only

### 4.1 Interaction prompts

- One prompt maximum on screen, nearest-interactable priority; appears when the player is within the interactable's radius and roughly facing it.
- Content: input glyph (matching active control scheme, §5) + localised verb from a finite verb list (~12 at 1.0: Gather, Talk, Knock, Give, Climb, Squeeze, Sit, Read, Cook, Contribute, Sketch, Sleep). New verbs require design sign-off.
- Style: small hand-lettered label on a soft paper chip — art-directed as a pencilled note, not a widget.

### 4.2 Fade rules (binding defaults, tuning band ±50%)

| Element | Trigger | Fade in | Hold | Fade out |
|---|---|---|---|---|
| Interaction prompt | Enter radius + facing | 0.15 s | while valid | 0.20 s |
| Item name chip (on pickup) | Pickup | 0.10 s | 1.5 s | 0.30 s |
| Journal quill flourish (§4.4) | Auto-record event | 0.20 s | 2.0 s | 0.40 s |
| Peek overlay (§4.3) | Hold Peek input | 0.10 s | while held | 0.15 s |
| Dialogue bubble | Line start | per dialogue system | — | 0.25 s |

### 4.3 The Peek overlay

Hold (or toggle, D15) a shoulder input to fade in the only "HUD" the game has: a small pocket-watch face (clock at 10-minute ticks, D6), season + day, and the current wayfinding sentence (§3.8) in one line. Release, and it fades. This satisfies "I just need the time" without violating P1 — held UI is player-summoned, so it never appears in the screenshot test.

### 4.4 Notifications

When the Journal auto-records something (recipe learned, preference noted, project phase advanced), a small quill flourish plays in the lower corner for 2 s with a one-line label ("The journal remembers — Wilfred loves blackberry buns"). Non-modal, never stacks: events within 3 s coalesce into one flourish. No other toast/achievement/popup system exists in gameplay (Steam achievements surface only through Steam's own overlay).

### 4.5 Dialogue and photo mode

- Dialogue renders as **speech bubbles in the world** (Yarn Spinner presenters; buy Yarn Spinner+ for the bubble presenters that match the storybook look — [tech architecture §6](../research/12-tech-systems-architecture.md)). Time pauses (D6). Choices are d-pad navigable with visible selection.
- **Photo mode** (D13: marketing-grade, tilt-shift "storybook plate" render, ships from the first public build) is a *system-level* pause feature, deliberately outside the diegesis — it may use conventional sliders and icons because it is the player-as-photographer, not the mouse-as-diarist. It is the one screen exempt from P7.

---

## 5. Input

Per [tech architecture §9](../research/12-tech-systems-architecture.md), binding:

- **Two action maps: `Gameplay` and `UI`** (Unity Input System). Opening the Journal, a dialogue choice, or any container swaps maps — this *is* the input isolation for pause states. No third map without design sign-off.
- **`InputSystemUIInputModule`** (never StandaloneInputModule). Controller/keyboard UI navigation drives Unity's selection system.
- **Full d-pad/stick navigability with a visible selection highlight on every screen, from the first Journal prototype.** Enforced invariant: *there is always exactly one selected Selectable* while the `UI` map is active. A build where focus can be lost (mouse click then gamepad) is a failed build. The selection visual is art-directed (soft graphite ring), not the default Unity outline.
- Journal navigation model: bumpers/`Q`/`E` switch thumb tabs; stick/d-pad or mouse moves selection within a spread; triggers turn pages within a tab. Mouse is fully supported but nothing requires a free cursor.
- **Rebinding ships at 1.0** (D15): `InputActionRebindingExtensions.RebindingOperation`, starting from the package's Rebinding UI sample; mouse position/delta excluded from listening; per-scheme bindings saved in options (not in the game save).
- Control-scheme detection swaps button glyphs everywhere (prompts, Journal hints, rebinding screen) on the frame the scheme changes.

---

## 6. Accessibility (D15 — day one, not post-launch)

| Requirement (D15) | Implementation spec | Acceptance test |
|---|---|---|
| **Scalable text** | Three presets: 100 / 125 / 150%. All player-facing text is TextMeshPro bound to one scaling setting; layouts reflow (no fixed-size text boxes in the Journal — spreads reserve text regions with overflow-to-next-page). Body text ≥ 24 px at 1080p at 100%. | At 150% + pseudo-loc, zero clipped/overlapping strings on every screen; readable on Steam Deck at 1280×800 from couch distance. |
| **Full remapping, hold/toggle** | §5 rebinding; every hold input (Peek, sprint-scamper) has a toggle alternative in options. | Rebind every action to a nonsense layout and complete the demo loop. |
| **Reduced-motion** | One master toggle: camera easing changes per [07](./07-camera-direction.md); Journal book-open and page turns become crossfades (§2); prompt animations lose bounce; paper-grain wobble and ink-spread animations disabled. | Motion-sensitive tester session each milestone; no per-feature exceptions. |
| **Colourblind-safe forage highlighting** | Interactable/forage highlight = **shape + outline + sparkle SFX cue**, never hue alone; highlight outline luminance-contrasts ≥ 3:1 against foliage in all four seasonal palettes. | Screenshot audit through deuteranopia/protanopia/tritanopia simulation each season; forage test with simulation enabled. |
| **Single-hand play** | All core verbs mappable to one hand (gamepad: everything reachable on right side + one shoulder; KB: full remap). No simultaneous multi-button chords anywhere; no mash inputs; no timed inputs (nothing in the design needs them — D6 no fail states). | Complete one full in-game day one-handed, both hands tested. |
| **Steam accessibility metadata** | Filled completely before the Steam page goes live (M4–5, D16), and re-audited at demo and 1.0. | Checklist owned by production; page review gate. |
| **Readable type** | Hand-lettered display faces for headers only; body text in a high-legibility serif; options toggle to swap body text to a plain sans (dyslexia-friendly). Locale font fallbacks per §7. | Reading test at minimum size on Deck; JA/zh-Hans render audit. |

No fail states, no time pressure, no meters (D6) are accessibility features we get for free from design — say so in the Steam metadata.

---

## 7. Localisation implications for UI (D15)

- **Text expansion room:** German and French run +30–35% over English; every UI text region (prompt chips, thumb-tab labels, Journal text areas, options) must tolerate **+40% string growth** without clipping — Journal spreads handle overflow by flowing to the next page, prompts by chip auto-width with a max + ellipsis-free rewrite rule (strings that would ellipsise get rewritten shorter, logged by the lint).
- **No text in textures. Absolute.** Journal headers, map labels, recipe titles, sketch captions, decorated capitals — all are live localised text layers composited over the 2D art. Illustration files contain zero glyphs. This is the single most expensive rule to retrofit ([tech architecture §8](../research/12-tech-systems-architecture.md)) and materially cheaper for us because it also serves the rename-safe layer (D1): names appear only in string tables.
- **Pipeline:** Unity Localization 1.5.x string tables + Smart Strings (plurals, gender) for all UI; Yarn Spinner 3 generates/maintains dialogue tables ([tech architecture §6, §8](../research/12-tech-systems-architecture.md)). **No player-facing literal strings in code or prefabs from month one** (D15); CI lint fails the build on any raw string assigned to a text component, and on `%` / `{x}/{y}` patterns in player-facing tables (§3.2 enforcement).
- **Pseudo-localisation stress test runs on the Journal first** — it is the densest text surface in the game — before the first external playtest.
- **Fonts per locale:** zh-Hans and JA fallback fonts selected and tested in month one (they constrain the hand-lettered art direction; a "hand-written" JA face must be chosen deliberately, not defaulted).
- **Word budget:** Journal templates, fragments, and band phrases count against the 60–80k word cap (D15). Template reuse (band keys, verb list, fragment pools) is how the Journal stays rich without blowing the budget — production tracks Journal words as their own line item.

---

## 8. Data-model sketch

The Journal renders from **state, not stored prose** — entries re-render correctly in any language and survive save migrations ([tech architecture §5, §7](../research/12-tech-systems-architecture.md)).

```
// Saved (plain C#, Newtonsoft JSON, in SaveData):
JournalRecord {
  string   id;           // stable string ID
  RecordType type;       // DayEntry | RecipeLearned | NeighbourFact | ProjectPhase
                         //  | SketchCaptured | AncestorPageFound | MapLocationInked
  int      gameDay;      // derived from totalMinutesSinceStart at record time
  string   templateId;   // -> localised Smart String template / fragment-pool key
  string[] args;         // stable IDs only: npcId, itemId, projectId, poiId, bandKey
}

// Not saved: rendered strings, layout, page assignments — all derived at display time.
```

- Journal UI lives in the `Hedgerow.UI` assembly ([technical direction §19.5](./19-technical-direction.md) — the naming authority; asmdef names use the codename, never the licensed name, per D1) and subscribes to the SO event channels (`ItemAdded`, `GiftGiven`, `RecipeLearned`, `ProjectPhaseChanged`, `DayEnded`…) — no hard references into gameplay systems ([tech architecture §10](../research/12-tech-systems-architecture.md)).
- 2D spread art: authored ≥ 2560 px wide per spread (full-screen at 1440p, acceptable at 4K with paper grain masking), text regions defined as layout data alongside the art, never in it.
- Sketch captures (D13) store the camera pose + a rendered thumbnail; the bordered page frame is applied at display time so border art can change without invalidating saves.

---

## 9. What we never ship (standing anti-pattern list)

Minimaps or compasses; quest markers or objective HUDs; progress bars, percentages, checkboxes, or `x/y` counters in any player-facing surface; floating numbers; XP or level displays (no XP exists); achievement toasts in-world; daily-task lists or login-style prompts; countdown timers or expiring-content warnings (nothing expires, D6); modal congratulation windows; a manual save menu; UI sounds louder than the world. Each of these has a named failure precedent in the [pitfalls study](../research/09-cozy-pitfalls.md) and [quest comps](../research/06-comps-cozy-quests.md); any proposal to add one goes through the owner with this section open.

---

## 10. Build order & open items

**Build order:** the Journal shell (tabs, navigation invariant, one Diary template, save ritual) is part of the vertical slice (M3–6, D16) because the demo's wayfinding depends on §3.8; the four ● tabs ship in the demo; Undertakings + Calendar arrive with the first full project arc; Sketchbook and Ancestors' pages are Could-tier (D5) and slot in post-G2 if per-asset costs measured in the slice allow.

**Open items:**

1. Sketchbook tab depends on D13 acceptance — **⚠ DEFAULT — owner to confirm** (photography → journal sketching demotion).
2. Exact Journal open/Peek default bindings to be settled in the first controller playtest (not an owner decision; a playtest decision).
3. Whether map annotations (§3.3) ship at 1.0 or post-launch is a scope call at the quarterly review (D5) — the wayfinding QA gate (§3.8) decides if they are needed at all.

---

[← Back to Index](./INDEX.md) | [Previous](./16-music-and-audio.md) | [Next: Community Philosophy →](./18-community-philosophy.md)
