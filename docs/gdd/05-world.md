# 5. World

[← Back to Index](./INDEX.md) | [Previous](./04-inspirations.md) | [Next: Art Direction →](./06-art-direction.md)

The whole game is one English hedgerow. Not a valley, not an island, not a region: a single strip of hedge between a cornfield and a stream, roughly the length of a garden — and at mouse height, an entire world. This document is the level-design bible for that strip: its zones, its map, its scale rules, its verticality, its density budgets, its interiors, and the way community projects and seasons unfold it into four worlds' worth of content. Everything here is bound by [D14 (World & Scale)](./00-decisions.md) and drawn from the [canon bible](../research/01-brambly-hedge-canon.md), the [small-scale-worlds comps](../research/07-comps-small-scale-worlds.md), and the [gentle-exploration comps](../research/04-comps-gentle-exploration.md).

---

## 5.1 The World in Numbers

| Parameter | Value | Source / rationale |
|---|---|---|
| Real-world footprint | **~40 m of hedgerow** (band: 30–50 m), × ~15 m deep including stream corridor and field margin | [D14](./00-decisions.md); Grounded proves 20 × 20 m of lawn carries 30+ hours ([comps 07](../research/07-comps-small-scale-worlds.md)) |
| Perceived scale | ≈ 3–5 km of mouse-scale walking | [comps 07](../research/07-comps-small-scale-worlds.md), implication 10 |
| Player character height | **10 cm, canonical** — every asset derives from this | [D14](./00-decisions.md) |
| Build scale convention | **World authored at 10× real scale: mouse = 1.0 Unity units tall; the strip ≈ 400 × 150 units** | Keeps character controller, physics and Cinemachine in their stable ~1-unit sweet spot; float precision is a non-issue at 400 units |
| Zones | **4** (band: 3–4) — the Hedge, the Stream & Mill Bank, the Field Margin, the Chestnut Woods Edge | [D14](./00-decisions.md) |
| Working scamper speed | 4–6 units/s (0.4–0.6 m/s real scale) — locked during the camera greybox, then frozen | World size must follow movement speed, not ambition (Grounded 2 lesson, [comps 07](../research/07-comps-small-scale-worlds.md)) |
| End-to-end walk | Hedge-bank path, signpost to signpost, ~2.5–3.5 min undistracted (path length ≈ 1.5–2× straight-line) | Comps: each major area crossable in ~3–5 min is the proven scale ([comps 04](../research/04-comps-gentle-exploration.md)) |
| Dollhouse interiors at 1.0 | **10** (band 6–10, at the ceiling); heroes: Store Stump, Old Oak Palace, Mill | [D14](./00-decisions.md) |
| Seasonal variants | Every zone fully re-dressed **× 4 seasons** | "Same hedge, four books" ([D4](./00-decisions.md)) |

The world is small and we say so proudly. At mouse scale, small **is** the wonder — the pitch is not acreage but that the mice have made a civilisation inside something we walk past ([comps 07](../research/07-comps-small-scale-worlds.md)).

Two scale registers must coexist in every frame: **mouse-made things at mouse ergonomics** (dressers, stair rails, the mill machinery, jam jars) and **nature at true macro scale** (stems, roots, seed heads, the oak). We are a *mouse-civilisation* world in the Ghost of a Tale/Moss family, not a shrunken-human world — the giants are grass and cow parsley, never spoons and hot dogs.

---

## 5.2 The Four Zones

Each zone has: a **purpose** (what the player does there), a **landmark** (what orients them), a **hero interior** (its dollhouse), a **traversal gate** (opened by a community project, per [D7](./00-decisions.md)), and a **season-by-season identity** (how its re-dressing reads). Zone IDs are data-layer strings; display names live in localisation (rename-safe, [D1](./00-decisions.md)).

### Z1 — The Hedge (`zone_hedge`) · the village

The social heart: the band of hedge trunks and bank where every household lives. This is where community meetings happen, where NPC schedules intersect, and where the player's day starts and ends.

- **Purpose:** homes, neighbours, meetings, the Store Stump economy ([D8](./00-decisions.md)); the densest dialogue and errand space.
- **Landmark:** the **Old Oak** — the mega-landmark whose crown breaks the canopy from every exterior point in the world (§5.9).
- **Hero interior:** **Old Oak Palace** (flagship) and the **Store Stump** — both hero dollhouses (§5.10).
- **Also here:** Crabapple Cottage, the Hornbeam Tree, Elderberry Lodge, the player's burrow, the signpost crossroads (the wayfinding hub), the root-cellar layer beneath the whole zone.
- **Traversal gate:** NPC-rigged canopy ropes, strung during the **summer wedding-raft project** (the same rigging effort that runs Dusty's mill-wheel lift — [14-quests](./14-quests.md) §14.7), open the branch-walkway (L2 canopy) layer between the great trees.
- **Seasonal identity:** *Spring* — primroses and violets on the bank, doors flung open, spring-cleaning bustle. *Summer* — deep green shade, dappled light shafts through the stem lattice, bees. *Autumn* — hips and haws stud the hedge red, baskets and barrows everywhere, the Store Stump's chimney smoking. *Winter* — snow buries the doors; the **snow-tunnel network** becomes the zone's street plan (canon: *Winter Story*).

### Z2 — The Stream & Mill Bank (`zone_stream`) · industry and water

The working edge of the world: the stream slides along the south side, turning the mill wheel and cooling the dairy slabs.

- **Purpose:** the mill and dairy production loops, watercress and reed foraging, the wedding-raft festival stage, fishing if it ships ([D5](./00-decisions.md) Could).
- **Landmark:** the **Mill chimney with smoke** — secondary silhouette, readable against the stream's bright ribbon.
- **Hero interior:** the **Flour Mill** (hero dollhouse: living quarters stacked over clattering machinery).
- **Also here:** the Dairy, Mayblossom Cottage (revealed by the year-one climax project), stepping stones, the raft mooring, the weir where the stream slips off-map towards the sea, the reed-bed **far bank**.
- **Traversal gate:** the **repaired twig bridge** (community project) opens the far bank; the **mill-wheel lift** (project) carries the player from waterline to mill roof — the zone's earned vantage.
- **Seasonal identity:** *Spring* — high, quick water; marsh marigolds; the mooring rebuilt after winter. *Summer* — the heatwave zone: mossy shade under the wheel (canon: Poppy keeping cool), the wedding raft dressed in flowers. *Autumn* — mist on the water at dawn, the wheel busy with harvest milling. *Winter* — frozen margins become slides; the wheel locked and iced; the stream a black ribbon through white.

### Z3 — The Field Margin (`zone_field`) · the breadbasket

The sunlit north strip between hedge and cornfield: open, golden, and the only place the sky feels wide.

- **Purpose:** primary foraging ground (seeds, berries, flowers by season), the festival green (spring picnic), the harvest set-piece.
- **Landmark:** the **cornfield itself** — a gold (green in spring, stubble-pale in autumn) wall of stalks along the whole northern horizon; plus the flint pile and field gate post at the east end.
- **Hero interior:** none — this zone is deliberately the exterior-spectacle zone; its "interior" is **Bluebell Bank**, the picnic meadow at the west end (canon: *Spring Story*).
- **Traversal gate:** the **spring picnic project** clears the overgrown grassy track to Bluebell Bank; the **autumn harvest** opens cut-stubble lanes a few mouse-metres into the field (the cornfield interior is otherwise an impassable stalk wall — a natural, fiction-true boundary).
- **Seasonal identity:** *Spring* — bluebells, cowslips, the picnic on the bank. *Summer* — towering green corn, poppies in the verge, skylark song. *Autumn* — the harvest: all mice in the rows, seed heads bowing, the harvest-mouse camp visible in the stubble (canon: *Autumn Story*). *Winter* — bare stubble under snow, long blue shadows, rosehips as the last colour.

### Z4 — The Chestnut Woods Edge (`zone_woods_edge`) · the threshold of adventure

The east end of the strip, where the hedge dissolves into wood-shadow. Our gentle-jeopardy space: fog, bramble thickets, being briefly and safely lost (tone guardrail: the worst outcome is being found, cold, and brought home to soup — [canon](../research/01-brambly-hedge-canon.md) §8).

- **Purpose:** deeper foraging (chestnuts, blackberries, mushrooms), the *Autumn Story* lost-in-the-woods narrative beat, the departure/return stage for expeditions.
- **Landmark:** the **great chestnut's dark canopy** closing the eastern skyline; a lantern hung at the wood's edge after the autumn project (a lit, warm "way home" cue).
- **Hero interior:** none at 1.0 — a **vole door** in the bank and the **High Hills trailhead signpost** are set dressing that points at post-1.0 content (§5.13).
- **Traversal gate:** the **autumn blanket-drive project** establishes the waymarked trail through the thicket (and the lantern); before it, the zone's deep end is passable but disorienting by design.
- **Seasonal identity:** *Spring* — wood anemones, wild garlic smell, birdsong depth. *Summer* — cool green dark, the world's best "pallet moments" (light shafts through stems, [comps 07](../research/07-comps-small-scale-worlds.md)). *Autumn* — the zone's headline season: blackberrying, chestnut fall, fog banks rolling in at dusk. *Winter* — hushed, grey-violet, snow-laden brambles; the trail lantern glowing.

---

## 5.3 The Map (ASCII sketch)

Layout for greybox; not to scale. North = the cornfield. The strip runs west–east.

```
        N ↑  the cornfield — a wall of stalks, off-limits (stubble lanes open in autumn)
 ┌───────────────────────────────────────────────────────────────────────────────────────────┐
 │ Z3 FIELD MARGIN                                                                            │
 │  Bluebell Bank ◄── grassy track ──── verge · seed heads · poppies ────► field gate · flints│
 │  (spring picnic)                     (harvest-mouse camp, autumn)                          │
 ├───────────┬────────────────────────────────────────────────────────────────┬──────────────┤
 │ Z1 THE HEDGE                                                                │ Z4 CHESTNUT  │
 │  Crabapple   Store    ★ OLD OAK ★    Hornbeam   Elderberry   player's       │  WOODS EDGE  │
 │  Cottage     Stump      PALACE        Tree       Lodge       burrow         │  brambles ·  │
 │  ●═ signpost crossroads ═── hedge-bank path ───────────────────●────────────┼─ fog · vole  │
 │  └────────── root-cellar & burrow layer beneath the whole hedge ──────┘     │  door · trail│
 ├───────────┴───────────────────────────────────────────────────┬────────────┤  lantern ·   │
 │ Z2 STREAM & MILL BANK                                          │            │  High Hills  │
 │   Dairy ── mill pool ── ▓ MILL ▓ (wheel·lift) ── Mayblossom    │            │  trailhead → │
 │ ~~ stepping stones ~~~ raft mooring ~~~~~~~ weir ~~~~~~~~~~~~~~~~~~~~~~~~~~►│ (off-map)    │
 │   far bank: reed beds · watercress · willow root   (twig-bridge project)    │              │
 └─────────────────────────────────────────────────────────────────────────────┴─────────────┘
        S ↓  over the weir and away downstream — to Sandy Bay and the sea (off-map)
   W ◄ Bluebell Bank                                       E ► Chestnut Woods · the High Hills
```

Readability notes: the hedge-bank path is the spine; the signpost crossroads (Z1, west of the Palace) is the hub every zone loops back to within ~30 seconds of walking (Botany Manor's loop-shortcut discipline, [comps 04](../research/04-comps-gentle-exploration.md)). The stream and the cornfield are fiction-true world boundaries — no invisible walls anywhere; every edge is water, stalk wall, thicket, or an inviting off-map horizon.

---

## 5.4 Canon Locations Roster → Game Zones

Every named place in the eight books, mapped. "Status at 1.0": **Interior** = walkable dollhouse; **Exterior** = built exterior/POI only; **Set-piece** = appears during its story beat; **Off-map** = horizon/reference only. Canon sources: [canon bible §4](../research/01-brambly-hedge-canon.md).

| Canon location | Zone | Status at 1.0 | Notes |
|---|---|---|---|
| Old Oak Palace | Z1 | Interior (hero) | Ceremonial heart; secret staircase apartment as exploration reward |
| The Store Stump | Z1 | Interior (hero) | Economy hub ([D8](./00-decisions.md)); Mr Apple's domain |
| Crabapple Cottage | Z1 | Interior | The Apples; modelled on a real Epping Forest tree |
| The Hornbeam Tree | Z1 | Interior | The Toadflax family — canonically next door to the Apples |
| Elderberry Lodge | Z1 | Interior | Basil's cellar of cordials and wines |
| Weavers' Cottage | Z1 | Interior | Flax & Lily's home (game-original name, [12-npcs](./12-npcs.md) §12.2); holds the Loom station ([10-core-systems](./10-core-systems.md) §10.3) and the autumn blanket-drive weaving vignette |
| Old Vole's hole | Z1 | Exterior (door + porch) | Interior is a Could; verify the name against book endpapers before final naming |
| Player's burrow | Z1 | Interior | Newcomer's home ([D9](./00-decisions.md)); see [11-home.md](./11-home.md) |
| The Flour Mill | Z2 | Interior (hero) | Dusty's mill; wheel drives the lift gate |
| The Dairy | Z2 | Interior | Poppy's domain; scrubbed slabs by the mill pool |
| Mayblossom Cottage | Z2 | Set-piece → Interior | Boarded until the *Poppy's Babies* climax project; then a walkable home — the world visibly changes (interior committed at 1.0, §5.10) |
| Old Mrs Eyebright's cottage | Z2 | Exterior (door + porch + bench) | Poppy's grandmother, the retired dairymouse; three favours target it (tea, warm-loaves delivery, walking-home) and she teaches butter & cheese ([10-core-systems](./10-core-systems.md)). **Exterior-only** — the tea favour plays on the porch/dooryard — to hold the walkable-interior count at 10 (§5.10); placement provisional pending endpaper check (§5.5) |
| Raft mooring / wedding raft | Z2 | Set-piece | Midsummer wedding stage (post-1.0 festival, [D10](./00-decisions.md)); mooring exists from 1.0 |
| Bluebell Bank | Z3 | Exterior | Spring picnic meadow; opened by the spring project |
| The cornfield | Z3 | Exterior boundary | Stubble lanes open in autumn; harvest-mouse camp cameo |
| The Chestnut Woods | Z4 | Exterior (edge only) | *Autumn Story* beat; deep woods stay off-map darkness |
| The High Hills | Off-map (E horizon) | Off-map | Trailhead + expedition set-piece at 1.0; walkable in a post-1.0 expansion (§5.13) |
| Sandy Bay & Seagull Rock | Off-map (downstream) | Off-map | The weir + Periwinkle mooring point at it; *Sea Story* expansion candidate (§5.13) |

**Canon-layer note ([D1](./00-decisions.md)):** every name in this table is canon-layer content. Location IDs, not names, are referenced by code and schedule data; display names live in localisation tables so a rename to original IP is a content swap, not a redesign. The *geography* — hedge, stream, field, wood — is rename-safe and survives any outcome.

---

## 5.5 Canonical-Map Fidelity Rule

The books carry endpaper maps charting the homes along the hedge ([canon bible §4](../research/01-brambly-hedge-canon.md)). Our rule, testable:

> **A reader holding a book's endpaper map open next to the game must find every canon location in the same relative order and adjacency along the hedge.** Deviations are allowed only where the endpapers are silent, and must be invisible to that reader.

Binding adjacencies from canon: the Hornbeam Tree is **next door to** Crabapple Cottage; the Dairy is **by the stream near the mill wheel**; Mayblossom Cottage is **near the Dairy**; the Palace and Store Stump anchor the community's centre. Before final naming and placement of minor elder dwellings (Old Vole's hole, Old Mrs Eyebright's cottage), verify against the endpapers — secondary sources conflict and the canon bible flags this. Owner of this check: design lead, during Z1 greybox review.

---

## 5.6 Scale Doctrine

The mouse is 10 cm. Everything else derives. Gameplay-relevant props are exaggerated **1.2–1.5×** over botanical truth for readability (the Grounded/Tinykin practice); pure scenery stays botanically honest ([comps 07](../research/07-comps-small-scale-worlds.md), rule 1).

| Element | Ratio to mouse height | Real size | Build units (10×) |
|---|---|---|---|
| Player mouse | 1.0× | 10 cm | 1.0 |
| Doors of mouse homes | **1.2–1.4×** | 12–14 cm | 1.2–1.4 |
| Mouse table | ~0.5× | ~5 cm | 0.5 |
| Grass blades | **3–6×** | 30–60 cm | 3–6 |
| Bramble canes (arching overhead) | 8–12× | 0.8–1.2 m | 8–12 |
| Cow parsley / hogweed | **15–20×** | 1.5–2 m | 15–20 |
| Hedge canopy top | 20–40× | 2–4 m | 20–40 |
| The Old Oak | effectively skybox-scale | — | landmark, not level geometry |
| Blackberry | slightly larger than the mouse's head | ~4 cm | 0.4 |
| Daisy bloom | parasol-sized | ~8 cm | 0.8 |
| Gameplay props (baskets, jars, tools) | **1.2–1.5× botanical/practical truth** | — | — |

**The Miyamoto rule, binding:** never state an exact size in fiction — no ruler moments, no "ten centimetres tall" dialogue, no human artefacts placed as yardsticks. Scale must read emotionally, not metrically ([comps 07](../research/07-comps-small-scale-worlds.md)). Human presence in the world is limited to what canon allows: a distant ploughed field, a cart rut used as a ravine — never a person, never litter-as-landmark (we are not Grounded).

Material detail is the landscape at this scale: bark ridges are terrain, moss is sponge-forest, wood grain is contour. Budget high-frequency tiling textures over dense geometry — "simple models and complex materials" (Ghost of a Tale's formula, [comps 07](../research/07-comps-small-scale-worlds.md)); full doctrine in [06-art-direction.md](./06-art-direction.md).

---

## 5.7 Verticality Doctrine

A hedgerow is a layer cake, and **every hedge block is a stacked column of content** — the universal density trick of every successful small-world comp ([comps 04](../research/04-comps-gentle-exploration.md), takeaway 2).

| Layer | Real elevation | Build units | Content |
|---|---|---|---|
| **L−1 Roots & burrows** | −0.5–0 m | −5–0 | Root cellars, the burrow layer linking Z1 homes, winter snow tunnels' warm counterpart; storerooms, secrets, diary pages |
| **L0 Field floor** | 0–0.3 m | 0–3 | Paths, doors, forage nodes, the ditch and cart rut (chasms crossed by community-built bridges) |
| **L1 Stem lattice** | 0.3–2 m | 3–20 | Climbing ramps (stems and thorn spirals as stairs, not platforming), balance-run branches, mid-level doors and windows |
| **L2 Canopy** | 2–4 m | 20–40 | Rope walkways (project-gated), vantage points, birds, weather |

Rules:

1. **Traversal verbs are climb, squeeze, scamper, balance-run. Jumping is de-emphasised** ([D14](./00-decisions.md)) — a non-jumping hero keeps spaces small, dense and readable, and spares us the third-person platforming camera (Captain Toad's lesson, [comps 07](../research/07-comps-small-scale-worlds.md)). No fall damage, ever ([comps 04](../research/04-comps-gentle-exploration.md), pattern 6).
2. **One earnable vantage point per zone**, each with a framed storybook vista authored per season (16 vistas total) — the reward for climbing is the view, and each vista doubles as journal-sketching content ([D13](./00-decisions.md)). Vantages: Palace attic balcony (Z1), mill roof via wheel-lift (Z2), field-gate post (Z3), the great chestnut's first bough (Z4).
3. **"I can see somewhere I can't reach yet"** must be true from every vantage — visible destinations are the exploration motor.
4. Vertical routes must read at all 8 camera yaws ([D3](./00-decisions.md)); hedge columns are designed to compose from our fixed pitch band, per [07-camera-direction.md](./07-camera-direction.md).

---

## 5.8 Density & POI Rules

Postcard-dense is a budgeted number, not a mood ([D14](./00-decisions.md)).

- **A POI every 5–10 seconds of walking** on any main path — at working scamper speed, that is one POI per **2.5–6 m of path** (25–60 build units).
- **No bare walkable exterior surface longer than ~5 character-lengths (~0.5 m real / 5 units) without micro-cover** — grass clumps, a fallen leaf (each leaf is a rug), pebbles, roots, seed heads, a snail shell. The one exception: mouse-maintained open spaces (the festival green at Bluebell Bank, swept paths) — justified in fiction as mown and swept, and ringed with dense verge ([comps 07](../research/07-comps-small-scale-worlds.md), rule 4).
- **POI taxonomy** (each placed instance is one of): `forage` (seasonal node), `vignette` (non-interactive charm: a beetle, washing on a line), `errand_anchor` (micro-quest giver/target), `vista` (sketchable framing), `collectible` (ancestor diary page, per [14-quests.md](./14-quests.md)), `shortcut` (squeeze-gap or climb loop), `social` (NPC schedule point).
- **Zone POI budgets at 1.0** (excluding interiors): Z1 ≈ 40–50, Z2 ≈ 30–40, Z3 ≈ 25–35, Z4 ≈ 20–30 → **world total ≈ 120–155**, of which ≥ 30% swap or re-dress per season.
- Every POI exists in data (§5.14) so density can be audited per zone per season with a one-click editor report — the density rule is checked at every milestone, not felt.

Lil Gator's bar is the target: *"there isn't any empty space — everything feels designed"* ([comps 04](../research/04-comps-gentle-exploration.md)).

---

## 5.9 Landmarks & Wayfinding (no minimap)

The Journal is the only map-like surface, and it holds prose and sketches, never a live position marker ([17-ui-philosophy.md](./17-ui-philosophy.md)). No-minimap has a known 50/50 "delightfully lost vs. frustrated" failure mode (Smushi's playtest split, [comps 04](../research/04-comps-gentle-exploration.md)) — so wayfinding is engineered, not hoped for:

1. **The mega-landmark:** the Old Oak's crown is visible from every exterior point in the world. **Binding test ([D14](./00-decisions.md)): from any exterior point at default zoom, at least one landmark breaks the canopy line.** Secondary silhouettes: the mill chimney with smoke (Z2), the cornfield's gold wall (Z3), the great chestnut's dark canopy (Z4) — one unique silhouette per compass direction.
2. **Diegetic signposting:** carved wooden signposts at every path junction (the crossroads hub carries all four zone directions); worn-path decals thicken along routes players actually use; lit windows and chimney smoke mark "home" after dusk; the Z4 trail lantern is the way-home cue in the fog zone.
3. **NPC directions:** direction-giving lines are part of every NPC's dialogue pool ("past the flax field, dear, and left at the big stone") — written as world knowledge, not quest UI.
4. **Journal prose restates the current goal in words** — the safety net, per [D14](./00-decisions.md).
5. **Loop shortcuts:** every zone connects back to the signpost crossroads within ~30 s of walking; squeeze-gap shortcuts open one-way from the far side (Botany Manor sightline-and-loop discipline, [comps 04](../research/04-comps-gentle-exploration.md)).

**Playtest gate:** in every milestone playtest, first-session players asked to reach a named location must succeed unaided ≥ 80% of the time within ~90 seconds; below that, we add signposting, we do not add a minimap.

---

## 5.10 Interiors — the Dollhouse List

Barklem's signature image is the cutaway interior; our dollhouse camera is canon-native ([canon bible](../research/01-brambly-hedge-canon.md), key takeaways). Interiors open via the dithered-fade cutaway ([D3](./00-decisions.md); system spec in [07-camera-direction.md](./07-camera-direction.md)). **10 interiors at 1.0** (band 6–10, at the ceiling):

| # | Interior | Zone | Floors | Tier | Role & signature |
|---|---|---|---|---|---|
| 1 | **Old Oak Palace** | Z1 | 5–6 + attics + hidden apartment | **Hero (flagship)** | Ceremonial heart; Midwinter's Eve venue; *The Secret Staircase* hidden-apartment beat is the game's marquee exploration reward — a key found in an attic dresser, a hidden door, a dusty winding stair, a forgotten apartment of old finery |
| 2 | **The Store Stump** | Z1 | 3–4 | **Hero** | Central hall radiating into passages, stairs and storerooms of pickles, jams, honey, nuts; shelf stock visibly reflects the contribution economy's state ([D8](./00-decisions.md)) |
| 3 | **The Flour Mill** | Z2 | 3 + wheel machinery | **Hero** | Living quarters stacked over working machinery; clatter, flour dust, sacks as terrain; the wheel-lift docks here |
| 4 | Crabapple Cottage | Z1 | 2–3 | Standard | The Apples: kitchen-as-shrine (preserves, the matrilineal diaries that canonise the Journal) |
| 5 | The Hornbeam Tree | Z1 | 3 | Standard | Toadflax family of six: bunks, clutter, Wilfred's expedition kit |
| 6 | Elderberry Lodge | Z1 | 1–2 (cellar-heavy) | Standard | Basil's cordial cellar: barrels, bottles, seasonal drink stock |
| 7 | Weavers' Cottage | Z1 | 2 | Standard | Flax & Lily's home (game-original name, [12-npcs](./12-npcs.md) §12.2): paw-driven **looms** (the Loom station, [10-core-systems](./10-core-systems.md) §10.3), dye-pots and hanging skeins; the autumn blanket-drive weaving vignette plays here — the year's best interior vignette |
| 8 | The Dairy | Z2 | 1–2 | Standard | Slabs, churns, pans; cool blue light off the water |
| 9 | Player's burrow | Z1 | 1–2 rooms | Standard | The newcomer's home; grows with light customisation ([11-home.md](./11-home.md)) |
| 10 | Mayblossom Cottage | Z2 | 2 | **Climax payoff — 1.0** | Built by the *Poppy's Babies* refurbishment climax ([D7](./00-decisions.md)); interior authored as the year-one climax payoff, then persists as a lived-in home |
| 11 | Old Vole's hole | Z1 | 1 | Could ([D5](./00-decisions.md)) | Cut first if the interiors budget tightens — the sole Could-tier interior |

**Count (against the D14 6–10 band):** ten walkable interiors are committed at 1.0 — the three heroes plus seven standards, now including the newly-added **Weavers' Cottage** and **Mayblossom Cottage** (promoted from stretch to a firm 1.0 commitment, since [D7](./00-decisions.md) binds the *Poppy's Babies* refurbishment climax at 1.0). That sits at the ceiling of the 6–10 band, so **Old Vole's hole** stays the sole Could-tier cut, and **Old Mrs Eyebright's cottage** is authored **Exterior-only** (its tea favour plays on the porch/dooryard, §5.4) — both keep the walkable-interior count at 10, not 11+.

**Interior design rules (binding):**

- **Hero interiors are true vertical dollhouses** — 3–6 floors of small rooms joined by stairs and passages, readable in cutaway as a single cross-section plate (the Barklem shot).
- **Furniture is terrain** (Tinykin's rule): every shelf, dresser top and stair rail is reachable, and drawers/cupboards hide something small ([comps 07](../research/07-comps-small-scale-worlds.md), rule 4).
- **All interiors read at all 8 camera yaws**; room depth is authored against the fixed pitch band so no furniture hides the walkable floor.
- **Never over-dark.** Candle- and firelight palettes, but lit to cosy legibility — Ghost of a Tale's murk criticism is the standing warning ([comps 07](../research/07-comps-small-scale-worlds.md) §1).
- Interiors load as additive scenes keyed by `LocationDefinition.interiorScene` (§5.14), so a hero interior's dressing can iterate without touching the exterior strip.

---

## 5.11 Traversal Gates — Community Projects Open the World

There is no player-level progression; **access is the progression, and the community grants it** ([D7](./00-decisions.md), [15-progression.md](./15-progression.md)). Feather-logic from the exploration comps, routed through our differentiator ([comps 04](../research/04-comps-gentle-exploration.md), implication 2):

| Gate | Opens | Project (season) | Staging rule |
|---|---|---|---|
| Grassy track cleared to Bluebell Bank | West meadow, picnic green (Z3) | Spring picnic logistics | NPCs visibly scything/sweeping across 2–3 days before the festival |
| Twig bridge repaired | The far bank: reed beds, watercress, willow root (Z2) | Summer wedding-raft project | Mr Toadflax mends the storm-broken bridge on Day 4 so the reed-cutting teams can cross ([14-quests](./14-quests.md) §14.7); first crossing is a small community moment |
| Raft & mooring rebuilt | Stream crossing point; wedding stage | Summer wedding-raft project (Midsummer; festival ships post-1.0, [D10](./00-decisions.md); mooring functions from 1.0) | Raft later moonlights as a punt-ferry |
| Mill-wheel lift | Waterline → mill roof vantage; the mill's upper floors (Z2) | Summer wedding-raft project (Function: wheel-lift rigged) | The wheel's first turn is watched by the gathered hedge |
| Canopy walk | The L2 branch-walkways between the great trees (Z1) | Summer wedding-raft project (Function: the rigging Dusty runs) | NPCs rig the ropes during the raft build; the player follows, never builds alone |
| Waymarked trail + lantern | Deep Z4 without disorientation; High Hills trailhead | Autumn blanket drive & High Hills expedition | Expedition departs and returns as set-pieces (§5.13) |
| Upland ropes (fixed ropes on the rock face) | The upland ledge and vantage — the High Hills *margin*, the game's highest framed vista (Z4 / off-map edge) | Autumn blanket drive & High Hills expedition (Function: fixed ropes stay) | Mr Apple's party rigs them on the climb ([14-quests](./14-quests.md) §14.7, `gate.uplandRopes`); the Hills themselves stay off-map |
| Snow tunnels | Winter street plan connecting Z1 doors | Winter Ice Hall (winter digging) | Dug over days as snow deepens; seasonal — they melt in spring |

Gate rules, binding per [D7](./00-decisions.md): soft thresholds ("about twelve bundles of reeds"), no fill-bars, construction visible and witnessed, **payoffs staged in view** (never let the mill wheel first turn while the player is elsewhere — Botany Manor's saucer rule, [comps 04](../research/04-comps-gentle-exploration.md)), and gates never re-lock once opened (except the fiction-true seasonal snow tunnels). Clever climbing may shortcut a gate early where it doesn't break a story beat — thresholds respect player agency ([comps 04](../research/04-comps-gentle-exploration.md), takeaway 4).

---

## 5.12 Seasonal Re-dressing — One World × Four

Seasons quadruple the world without new geography ([synthesis](../research/00-synthesis.md) §1.7). The geometry is built once; each season applies a **dressing set** per zone ([D4](./00-decisions.md): LUTs + foliage colormap swaps + dressing sets — "same hedge, four books"):

A dressing set contains, per zone:

1. **Ground-cover swap** — the seasonal carpet (bluebells → summer grass → leaf-fall → snow), including collision-relevant drifts and puddles.
2. **Forage-node set** — what grows where ([10-core-systems.md](./10-core-systems.md)); seasonal availability is the game's only soft timer.
3. **≥1 traversal affordance change per zone per season** (binding): snow tunnels open (Z1 winter); frozen stream margins walkable (Z2 winter); stubble lanes open (Z3 autumn); summer growth closes one sightline and opens one shaded path (Z4); spring flood raises stepping-stone difficulty for a few days.
4. **Festival dressing** — the season's celebration set (bunting, lanterns, the Ice Hall) staged in its zone.
5. **Ambience & audio set** — birdsong/insect/weather beds per [16-music-and-audio.md](./16-music-and-audio.md).
6. **LUT + colormap set** — per [06-art-direction.md](./06-art-direction.md).

**Botanical accuracy per season is the art bar, not generic cottagecore** ([D4](./00-decisions.md); the books are "the most research-crammed fantasy," [canon bible](../research/01-brambly-hedge-canon.md)): bluebells and primroses in spring, meadowsweet and poppies at midsummer, blackberries, hips and chestnuts in autumn, snow-laden brambles in winter. Each zone's four identities are specified in §5.2; the art team paints from those lines plus scanned-plate calibration.

Season state is presentation + calendar data ([D6](./00-decisions.md)); the world never changes season mid-day, only through the festival "season valve."

---

## 5.13 Off-Map & Expedition Destinations

The world honestly ends where the books' map ends — and points beyond itself:

- **The High Hills** (east horizon, beyond Z4): misty uplands, vole country, legendary gold (*The High Hills*; Lake District reference landscape). At 1.0: the trailhead signpost, the vole door, and the **autumn blanket-drive expedition staged as departure and return set-pieces** — the player helps pack, sees the party off into the mist, and greets the weary, triumphant return (with a night-of-worry beat between). The walkable High Hills map is a **post-1.0 expansion candidate** ([21-long-term-vision.md](./21-long-term-vision.md)).
- **Sandy Bay & Seagull Rock** (downstream, past the weir): the sea-mouse settlement and the salt voyage of the *Periwinkle* (*Sea Story*; Norfolk coast reference). At 1.0: the weir, the mooring point, and salt-scarcity lines in the economy ([D8](./00-decisions.md)) that make the voyage feel needed. The voyage itself is a **post-1.0 expansion candidate**.
- **The deep Chestnut Woods and the cornfield interior** stay unwalkable darkness and stalk-wall respectively — fiction-true boundaries, never invisible walls.

Rule: off-map destinations must be *present* at 1.0 — visible horizons, signposts, NPC talk, journal marginalia — so the world feels continuous with the books' larger geography, and post-1.0 content lands in prepared soil. No visibly locked door taunts the player for dozens of hours ([D7](./00-decisions.md) anti-pattern): the trailhead and weir read as "the world continues," not "content locked."

---

## 5.14 Data Model Sketch

World content is data-driven and rename-safe from day one ([D1](./00-decisions.md), [19-technical-direction.md](./19-technical-direction.md)). ScriptableObject definitions + string-ID registry:

```
ZoneDefinition            (SO)
  zoneId: "zone_hedge" | "zone_stream" | "zone_field" | "zone_woods_edge"
  displayNameKey          → Unity Localization (rename-safe)
  cameraZoneIds[]         → 07-camera-direction volumes
  ambienceSetId (per season)

LocationDefinition        (SO)
  locationId: e.g. "loc.village_store"
  zoneId
  displayNameKey
  exteriorAnchor          (scene transform ref)
  interiorScene?          (additive scene, dollhouse)
  landmarkSilhouette?     (bool + LOD asset — feeds the §5.9 canopy-line test)

POIDefinition             (SO)
  poiId
  type: forage | vignette | errand_anchor | vista | collectible | shortcut | social
  locationId | zoneId
  seasonMask              (Sp/Su/Au/Wi availability)
  payloadId               (forageTableId, vistaId, diaryPageId, …)

TraversalGateDefinition   (SO)
  gateId: e.g. "gate_twig_bridge"
  openedByProjectId       → community-project system (18-community-philosophy)
  affectedNavLinks[]      (NavMesh links toggled)
  stagingCutsceneId       (the witnessed payoff)
```

NPC schedules reference **named POIs, never coordinates** ([D9](./00-decisions.md)), so world layout can shift during greybox without breaking a single schedule. Editor tooling from month one: a POI-density auditor (per zone, per season, against §5.8 budgets) and the landmark canopy-line checker (automated camera sweep at default zoom).

---

## 5.15 World Acceptance Checklist (run every milestone)

- [ ] From any exterior point at default zoom, ≥1 landmark breaks the canopy line.
- [ ] No walkable exterior bare stretch > 5 character-lengths outside justified mouse-maintained spaces.
- [ ] Main-path POI spacing within 5–10 s of walking; zone budgets within §5.8 bands.
- [ ] Every zone loops to the signpost crossroads within ~30 s.
- [ ] Every interior readable at all 8 yaws; no interior below cosy-legibility lighting bar.
- [ ] Every open traversal gate's payoff was witnessable in view.
- [ ] Endpaper-map fidelity: canon location order and adjacency intact.
- [ ] No exact size stated anywhere in fiction; no human yardstick objects.
- [ ] Each zone's current season shows its §5.2 identity line and ≥1 seasonal traversal change.
- [ ] Wayfinding playtest: ≥80% of first-session players reach a named destination unaided.

---

[← Back to Index](./INDEX.md) | [Previous](./04-inspirations.md) | [Next: Art Direction →](./06-art-direction.md)
