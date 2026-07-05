# Comps Research: Storybook / Illustrated Visual Presentation in Games

Research for *Brambly Hedge: The Game* — how six reference titles actually achieve their "living illustration" look, what their cameras do, how they handle interiors, how the art was received, and what a 1–3 person Unity team can realistically steal. Compiled July 2026.

Games covered: **Tiny Glade**, **Snufkin: Melody of Moominvalley**, **Dordogne**, **The Plucky Squire**, **Season: A Letter to the Future**, **Eastshade**.

## Key Takeaways

- **Nobody ships a "watercolor shader."** Every successful storybook game gets the look primarily from *authored surfaces* (hand-painted albedo textures, painted lighting, curated palettes), not from screen-space paint filters. Dordogne's art director explicitly rejected watercolor shaders because "most of the watercolor shaders are animated" and "the human eye isn't really comfortable with" that ([Game Developer](https://www.gamedeveloper.com/design/q-a-hand-painting-the-watercolor-world-of-i-dordogne-i-)).
- **Tiny Glade's tech is NOT replicable** (custom Rust/wgpu engine, real-time GI written by an ex-Embark rendering specialist), but its *outcomes* are: soft bounced pastel light, tilt-shift miniature framing, and reactive procedural micro-detail — all approximable in Unity with baked GI, post-processing DoF, and modest spline/decal tooling.
- **The most replicable full pipeline is Snufkin's**: Unity, 13-person studio, real-time 3D with hand-painted watercolor textures, deliberately low-framerate "hand-animated" feel, bird's-eye camera. It shipped in ~4 years and reviewers called it a storybook come to life ([Adventure Game Hotspot](https://adventuregamehotspot.com/review/1472/snufkin-melody-of-moominvalley)).
- **Fully painted backdrops lock your camera.** Dordogne's camera-mapping (projecting real watercolors onto low-poly 3D in Blender) is gorgeous but only works from fixed viewpoints — fundamentally incompatible with a rotatable isometric camera. Usable only for vignettes/cutscenes/journal art.
- **Painted-albedo + tinted-shadow shading is the sweet spot.** Season's "stylized realism" (illustrative albedo, art-directed shadow tint, realistic light behavior, custom Unreal shaders) is the closest AAA-adjacent formula to what Brambly Hedge needs, and its core idea ports to Unity Shader Graph in days, not months ([Season art direction blog](https://www.play-season.com/post/january-2022-the-art-direction-of-season)).
- **Small handcrafted world = baked lighting wins.** Eastshade proved a 1–2 person Unity team can ship a painterly open world (2013–2019, ~$200k budget, ~$2M gross) through art direction + brutal optimization (hex-grid draw-call batching, deferred foliage, custom mesh terrain), not fancy shaders ([Eastshade postmortem](https://www.gamedeveloper.com/business/postmortem-eastshade)).
- **A photo/tilt-shift mode is a marketing engine.** Tiny Glade sold 616k copies in a month at $15 off 1.37M wishlists, driven largely by shareable screenshots; one click adds tilt-shift that makes builds look "like an actual toy" ([GameDiscoverCo](https://newsletter.gamediscover.co/p/how-tiny-glade-built-its-way-to-600k), [Shacknews](https://www.shacknews.com/article/141431/tiny-glade-review-score)).
- **Fixed bird's-eye cameras waste storybook worlds.** Snufkin's reviewer lamented that the top-down view was "almost a shame" versus its rare layered vistas — direct validation of Brambly Hedge's "cinematic framing at key locations" pillar.
- **Team-size reality check:** the only comps at 1–3 people are Tiny Glade (2, both world-class specialists, ~2 yrs full-time after years of prototyping) and Eastshade (~2 core, 6 years). Snufkin: 13. Dordogne: 30+. Plucky Squire: small-but-multi-disciplinary studio + outsourcing, ~4.5 years. Season: ~35+ (post-launch cut to 16). Scope discipline is the real differentiator.

---

## 1. Tiny Glade (Pounce Light, Sept 2024)

**What it is:** A castle/garden "diorama doodling" toy with no goals; the entire product is the visual pleasure of building.

### How the look is achieved
- **Custom engine:** Built in **Rust** on a modified **Bevy** (ECS for game logic) with a fully custom rendering pipeline on **wgpu/Vulkan** (OpenGL 3.3 fallback), chosen for Linux/cross-platform support and compute-shader freedom Bevy lacked at the time: "we could control pretty much the whole pipeline, all the way from authoring textures and assets to how you ultimately see them" ([80.lv interview](https://80.lv/articles/exclusive-tiny-glade-developers-discuss-bevy-proceduralism-publishers-cozy-games)).
- **Real-time global illumination:** widely described as one of the most advanced GI systems in any shipping game — developer posts describe a revamped GI using **ReSTIR-style sampling with a meshless irradiance cache at ~11 ms/frame on a Radeon 6800 XT at 1080p** ([HN discussion](https://news.ycombinator.com/item?id=42191172), [dev's Mastodon](https://mastodon.gamedev.place/@h3r2tic)). Stachowiak previously built the open-source experimental GI renderer **kajiya** at Embark (volumetric temporally-recurrent irradiance cache, ray-traced final gather) ([GitHub](https://github.com/EmbarkStudios/kajiya)). The soft, bounce-lit pastel look that everyone praises is *lighting tech*, not a paint filter.
- **Procedural detailing:** dozens of hand-authored generators, each tailored to one element (walls auto-arch over paths, ivy, brick edge wear, lanterns): "I create every single rule that goes into the system… we curate exactly the experience you will get out of it" — explicitly curated proceduralism, not ML ([80.lv](https://80.lv/articles/exclusive-tiny-glade-developers-discuss-bevy-proceduralism-publishers-cozy-games)).
- **Design pillars** stated by the devs: *"a lot from little effort," "no wrong answers," "it's alive"* (reactivity — sheep get petted, birds land on sheep, paths wear into the grass) ([GameDiscoverCo](https://newsletter.gamediscover.co/p/how-tiny-glade-built-its-way-to-600k)).

### Camera
- Free orbit camera: rotate, zoom, height change; **cursor-based or center-based pivot** modes for rotation/zoom ([GameRant camera guide](https://gamerant.com/how-to-control-the-camera-in-tiny-glade/)).
- **Photo mode** (P key): extensive settings, one-click **tilt-shift** for a miniature/toy look, and a **first-person walk mode** to stroll through your own build ([Shacknews](https://www.shacknews.com/article/141431/tiny-glade-review-score), [PC Gamer](https://www.pcgamer.com/games/city-builder/tiny-glade-review/)).

### Interiors
- None. Buildings are shells; windows glow. Interior play was out of scope even for this team — a useful warning about interior cost.

### Reception / business
- 616,528 units in the first month at $15; 1,375,441 wishlists at launch; 97% positive; demo was 4th most-played of June 2024 Next Fest; ~2 years of full-time development by exactly **2 people** (plus years of nights-and-weekends prototyping; "6 or 7 fully fleshed out prototypes" for some tools); BAFTA 2025 Technical Achievement nomination ([GameDiscoverCo](https://newsletter.gamediscover.co/p/how-tiny-glade-built-its-way-to-600k), [Wikipedia](https://en.wikipedia.org/wiki/Tiny_Glade)).

**Replicability verdict:** engine/GI — **no** (requires a dedicated rendering veteran). Pastel palette, baked soft lighting, tilt-shift photo mode, small-scale reactive detail (paths wearing, critters reacting) — **yes**, and these are what players actually perceive.

---

## 2. Snufkin: Melody of Moominvalley (Hyper Games, March 2024)

**What it is:** Story-rich musical adventure; the closest comp to Brambly Hedge in tone (beloved Nordic picture-book IP, gentle pace, no combat focus).

### How the look is achieved
- **Unity engine** ([PCGamingWiki](https://www.pcgamingwiki.com/wiki/Snufkin:_Melody_of_Moominvalley)); real-time 3D environments with **hand-painted watercolor-style textures** faithful to Tove Jansson's illustrations; presented as 2.5D/top-down ([Adventure Game Hotspot](https://adventuregamehotspot.com/review/1472/snufkin-melody-of-moominvalley)).
- Deliberate **"low-framerate, hand-animated style, with its slightly flickering textures"** — animation-on-twos plus subtle texture boil sells "hand-made" far more cheaply than any shader ([Adventure Game Hotspot](https://adventuregamehotspot.com/review/1472/snufkin-melody-of-moominvalley)).
- A 230-page digital artbook documents the "techniques, philosophy and styles to make this game a storybook come-to-life" — worth buying (~$8 on Steam) as a direct art-pipeline reference ([Steam artbook](https://store.steampowered.com/app/2782690/Snufkin_Melody_of_Moominvalley__Digital_Artbook/)).

### Camera
- Bird's-eye/top-down for exploration; shifts to closer top-down in stealth; scripted **layered vista shots over cliffs** and cutscenes are where the art shines. Reviewer criticism: "The bird's-eye perspective is almost a shame" compared to those vistas ([Adventure Game Hotspot](https://adventuregamehotspot.com/review/1472/snufkin-melody-of-moominvalley)). Lesson: don't imprison a storybook world in one dull angle.

### Interiors
- Sparse; the game is overwhelmingly exteriors, with interiors treated as small discrete scenes — consistent with keeping a 13-person scope.

### Team / time / reception
- Hyper Games (Oslo): **13 employees**; concept started 2020 after reading Jansson's *Who Will Comfort Toffle?*, released 7 March 2024 (~4 years); published by Raw Fury; Sigur Rós on the soundtrack ([moomin.com](https://www.moomin.com/en/blog/snufkin-melody-of-moominvalley/), [Hyper Games presskit](https://hypergames.no/presskit/index.php)). Art direction universally praised — "vibrant and colorful enough to belong in a children's picture book"; players used screenshots as desktop wallpapers ([LadiesGamers](https://ladiesgamers.com/snufkin-melody-of-moominvalley-review/)).

**Replicability verdict:** **highest of all comps.** Same engine, painterly-texture pipeline, and IP-adaptation problem. The 13-person/4-year scale still warns that Brambly Hedge must be much smaller in content or longer in schedule.

---

## 3. Dordogne (Un Je Ne Sais Quoi / Umanimation, June 2023)

**What it is:** Narrative adventure rendered in genuine watercolor.

### How the look is achieved
- Art director **Cédric Babouche hand-painted 180+ landscapes** in real watercolor (Indian-ink sketch first, then straight to paint); "Any digital scene would take us two days, whereas if I do it myself in watercolour, it takes me two hours" ([CNC](https://www.cnc.fr/web/en/news/dordogne-the-story-behind-a-watercolour-video-game_1905450), [Connexion France](https://www.connexionfrance.com/news/french-video-game-in-watercolour-plays-like-a-love-letter-to-dordogne/165136)).
- **Camera mapping in Blender**: scanned paintings projected onto rough low-poly 3D, **no 3D lighting or shading except on characters** — "lighting and shadows are painted directly in the illustration I'm camera mapping." Complex scenes need "four to five camera mapping rounds"; up to seven for finale sequences. Edges between painted and 3D elements blended with "tiny shaders and particles" and glow. Characters get "a very simple shader… simply textured with watercolor and white rim light" ([Game Developer Q&A](https://www.gamedeveloper.com/design/q-a-hand-painting-the-watercolor-world-of-i-dordogne-i-)).
- Explicit rejection of animated watercolor shaders (eye discomfort; fake look) — the whole pipeline exists to preserve untouched painted paper ([Automaton interview](https://automaton-media.com/en/interviews/20230621-19630/)).
- Engine: **Unity** ([Babouche's #madewithunity post](https://www.linkedin.com/posts/cedric-babouche-b85b815_madewithunity-ugcPost-7032240375759089664-Fyys)).

### Camera / interiors
- Consequence of camera mapping: **fixed, pre-composed viewpoints** with parallax depth; the player never freely rotates. Interiors and exteriors are both just "the next painting." This is the antithesis of Brambly Hedge's rotatable isometric camera.

### Team / time / reception
- **30+ people** across the two merged studios; CNC-funded; concept started nearly solo by Babouche (a 17-year animation-industry art director) around 2018–2019, released 13 June 2023 ([CNC](https://www.cnc.fr/web/en/news/dordogne-the-story-behind-a-watercolour-video-game_1905450)). Metacritic **76** — visuals called "one of the most stunning games… for a while," gameplay/mini-games criticized as chores with imprecise controls ([Metacritic](https://www.metacritic.com/game/dordogne/), [Slant](https://www.slantmagazine.com/games/dordogne-review/)).

**Replicability verdict:** the *full* pipeline — **no** (requires a master watercolorist producing hundreds of paintings, and it kills camera freedom). The *targeted* use — **yes**: painted journal pages, festival cutscene stills, loading vignettes, painted skybox/backdrop planes beyond the playable hedge.

---

## 4. The Plucky Squire (All Possible Futures, Sept 2024)

**What it is:** Zelda-like that jumps between a 2D illustrated storybook and the 3D desk it sits on.

### How the look is achieved
- **Unreal Engine**; chosen so the small team could spend effort on the unique 2D↔3D feature set: "whenever they need something, Unreal's developers have already got there first" ([Unreal Engine interview](https://www.unrealengine.com/en-US/developer-interviews/the-plucky-squire-blends-2d-and-3d-visuals-in-aesthetically-pleasing-and-mechanically-interesting-ways)).
- 2D pages: co-director James Turner's own "minimalist and colorful" illustration style — flat bold-outline art laid out as actual book pages; 3D world: warm Pixar/Toy Story-inspired miniature realism of a child's desk ([Unreal interview](https://www.unrealengine.com/en-US/developer-interviews/the-plucky-squire-blends-2d-and-3d-visuals-in-aesthetically-pleasing-and-mechanically-interesting-ways), [DualShockers](https://www.dualshockers.com/the-plucky-squire-art-style-impressions-gamescom/)).
- Founded Feb 2019 by James Turner (ex-Game Freak art director, directed HarmoKnight) and Jonathan Biddle (ex-Curve, *The Swords of Ditto*); development began 2020; released 17 Sept 2024 (~4.5 years); "small, remote team" with undisclosed headcount plus outsourcing; published by Devolver ([Wikipedia](https://en.wikipedia.org/wiki/The_Plucky_Squire)).

### Camera
- 2D pages: fixed top-down page view (the book itself is the frame). 3D desk: constrained third-person/isometric-ish follow camera. Transitions between the two are the signature moment and consumed enormous engineering effort.

### Reception
- Metacritic **83 (PC) / 77 (PS5) / 80 (XSX) / 72 (Switch)**, OpenCritic 85% recommended; art direction and the 2D/3D interplay widely praised; criticism aimed at low difficulty, minigame abundance, and Switch performance ([Wikipedia](https://en.wikipedia.org/wiki/The_Plucky_Squire)).

**Replicability verdict:** the 2D/3D switching tech — **no** (multi-year, multi-discipline effort, wrong engine besides). The steal is *conceptual*: **the book as diegetic frame**. Brambly Hedge's journal-as-UI can deliver the same "living picture book" fantasy with 2D illustrated pages over the 3D world at ~1% of the cost.

---

## 5. Season: A Letter to the Future (Scavengers Studio, Jan 2023)

**What it is:** Meditative bicycle road-trip; you document a valley before it disappears (photography + audio + journal — mechanically the closest comp to Brambly Hedge's photography/journal systems).

### How the look is achieved
- **Unreal Engine** with custom shaders; self-described **"stylized realism"**: "a balance between an illustrative approach, and a more grounded approach" — realistic modeling and light behavior, but **"highly stylized, illustrative and graphic"** texture work ([official art direction post](https://www.play-season.com/post/january-2022-the-art-direction-of-season)).
- Key shader idea: art-direct the **albedo and the shadow tint "in the way that they are done in illustrations"** instead of cel-shading; retain PBR-ish sky lighting and subsurface scattering so scenes stay believable across lighting conditions ([art direction post](https://www.play-season.com/post/january-2022-the-art-direction-of-season)).
- Influences: Japanese woodblock prints (Hiroshi Yoshida), poster artist Norman Wilkinson, plein-air painters, natural-light cinematography; "voluntary simplicity" — silhouettes over detail. Goal: "every frame… look[s] like it belongs in a frame on a wall."

### Camera
- Third-person on foot and on the bicycle, plus a first-person camera/recorder mode feeding a freeform scrapbook journal. Critics praised the camera/journal; bicycle controls were a common complaint ([Wikipedia](https://en.wikipedia.org/wiki/Season:_A_Letter_to_the_Future)).

### Team / time / reception
- Scavengers Studio (Montreal, founded 2015), a mid-size indie; development troubled by studio-conduct controversy and a delay from Autumn 2022 to 31 Jan 2023. Metacritic **80 (PC) / 76 (PS5)**; Webby People's Voice winner for art direction; commercially it failed — **only 60,000 units by June 2023, layoffs cut the studio to 16 people** ([Wikipedia](https://en.wikipedia.org/wiki/Season:_A_Letter_to_the_Future), [Scavengers](https://www.scavengers.ca/games/season)).

**Replicability verdict:** the shading *formula* — **yes** (painted-albedo + controlled shadow tint + real lighting is straightforward in Unity URP/Shader Graph); the asset volume of a full valley — no. Season is also the cautionary business tale: art-direction awards do not sell a game whose activities feel thin.

---

## 6. Eastshade (Eastshade Studios, Feb 2019)

**What it is:** First-person open world where you *are* a painter; the painterly feel comes from subject matter, color scripting, and dense hand-placed vegetation — not stylized shaders.

### How the look is achieved / tech
- **Unity, built-in pipeline era**; 2013–2019 (~6 years); Danny Weinbaum (ex-environment artist, *Infamous: Second Son*) solo at first, partner Jaclyn full-time from year ~4, plus contractors (composer, character artist, 2 quest scripters, 1 programmer) ([postmortem](https://www.gamedeveloper.com/business/postmortem-eastshade)).
- Optimization was the real "tech": **deferred rendering for foliage (~30% render-time saving), a custom hex-grid script combining meshes to slash draw calls, regular meshes instead of Unity terrain** for controlled polygon distribution, clustered planting, canopy-less trunks inside dense forests ([Foliage Optimization in Unity](https://80.lv/articles/foliage-optimization-in-unity), [Eastshade devblog](https://eastshade.com/foliage-optimization-in-unity/)).
- Painting mechanic = screenshot + metadata (objects, place, time of day) gated by an "inspiration" resource earned by exploring, reading, drinking tea — designed to "reward going slow and smelling the roses" ([Game Developer](https://www.gamedeveloper.com/design/turning-painting-into-a-game-mechanic-in-the-gorgeous-i-eastshade-i-)).

### Business
- ~$200k cash budget (~$700k true cost with living expenses), +$60k post-launch porting; **~$2M gross / ~$1.1M net** across platforms in 1.5 years; console launch initially hit only 10% of expectations until Microsoft featured it ([postmortem](https://www.gamedeveloper.com/business/postmortem-eastshade)).
- Notable art-direction failure: anthropomorphic "animal folk" characters were "a huge turn off for so many people" — character design is a real commercial risk for an animal-protagonist game and deserves early external testing ([postmortem](https://www.gamedeveloper.com/business/postmortem-eastshade)).

**Replicability verdict:** **yes, wholesale** — same engine class, same team size, published playbook. Its warnings (version control disasters, console-port drag, character-design reception) are as valuable as its techniques.

---

## Comparison table

| Game | Engine | Core look technique | Camera | Team | Dev time | Art reception |
|---|---|---|---|---|---|---|
| Tiny Glade | Custom Rust/Bevy/wgpu | Real-time GI + curated procedural detail | Free orbit + tilt-shift photo + FP walk | 2 | ~2 yrs FT (+ prototyping) | 97% positive; BAFTA tech nom |
| Snufkin | Unity | Hand-painted watercolor textures on 3D, animation-on-twos | Fixed bird's-eye + scripted vistas | 13 | ~4 yrs | Art universally praised |
| Dordogne | Unity (+Blender) | Real watercolors camera-mapped onto low-poly 3D, painted lighting | Fixed painted viewpoints | 30+ | ~4–5 yrs | 76 MC; visuals "stunning," gameplay criticized |
| Plucky Squire | Unreal | Flat bold-outline 2D pages + Pixar-ish 3D desk | Fixed page view / constrained 3rd-person | small studio + outsourcing | ~4.5 yrs | 83 MC (PC); art the star |
| Season | Unreal | "Stylized realism": painted albedo + tinted shadows + PBR light | 3rd-person + diegetic camera/journal | ~35 → 16 | ~5 yrs | 80 MC; Webby art win; 60k units |
| Eastshade | Unity | Realistic-painterly via art direction + dense foliage, heavy optimization | First-person | ~2 core | 6 yrs | Beloved; $2M gross |

---

## Implications for Brambly Hedge: The Game

### What to copy (concrete)

1. **Adopt the Snufkin surface pipeline as the baseline.** 3D environments with hand-painted (real watercolor/gouache-scanned or Procreate-painted) albedo textures; minimal PBR (roughness mostly uniform, no metallics); paint lighting cues *into* textures where the camera is predictable. Buy the Snufkin digital artbook (~$8) and the Dordogne artbook as standing art-team references.
2. **Layer Season's shading formula on top:** custom lit shader (Shader Graph) where shadow color is an art-directed tint ramp (warm shadows at golden hour, cool blue-violet in winter) rather than black multiplication, plus simple subsurface wrap on leaves/petals. This single shader carries the seasons pillar: swap palette LUT + shadow tint per season.
3. **Fake Tiny Glade's light, don't build it.** Small handcrafted world → **baked GI** (Unity GPU lightmapper or the Bakery asset, ~$60) + light probes + one real-time sun gives 90% of the soft bounce-lit pastel feel at zero runtime cost. Budget 4 time-of-day/seasonal bake sets rather than dynamic GI.
4. **Ship a photo mode with one-click tilt-shift in the first public build.** Tiny Glade's 1.37M wishlists were built on shareable images. Tilt-shift DoF also *reinforces the miniature mouse-scale fantasy* — it should arguably be subtly on by default (gentle top/bottom blur, focal plane at the player).
5. **Camera spec (informed by all six):** perspective projection, FOV ~30–35° (long-lens miniature compression, à la Tiny Glade photo mode); pitch fixed ~35–40°; yaw limited to smooth rotation between soft-snapped stops (e.g., 8 × 45° or 4 × 90°) rather than Snufkin's fixed angle or Tiny Glade's fully free orbit; zoom via dolly ~3m–14m with cursor-based pivot (Tiny Glade's cursor-pivot is notably pleasant). Use **Cinemachine** (install it now) with per-location virtual cameras for the "cinematic framing at key locations" — this is exactly the fix for Snufkin's "bird's-eye is almost a shame" critique.
6. **Journal-as-UI = our Plucky Squire moment.** Render journal pages as genuinely 2D illustrated spreads (Barklem-style borders, painted vignettes) that the 3D game literally opens into and out of. Dordogne-style hand-painted stills belong here: festival memories, recipe pages, season title cards — high art impact, fixed viewpoint, no camera conflict.
7. **Copy Tiny Glade's "it's alive" micro-reactivity, scoped tiny:** worn-path decals along frequently walked routes, birds landing when idle, doors/windows lighting at dusk. Cheap spline/decal/trigger work with outsized "living illustration" payoff, and it dovetails with community-progression (the mill visibly weathers/unweathers).
8. **Steal Eastshade's optimization playbook early:** hex-grid (or chunk) static-mesh combining for hedgerow vegetation, cluster planting with canopy-less inner trunks, mesh terrain over Unity terrain for a small sculpted world, and real version control (Git + LFS) from day one — Eastshade lost files to ransomware and "day derailers" from Unity Collaborate.

### What to avoid

- **No animated full-screen watercolor/paper shaders.** Babouche's eye-comfort warning is validated by every comp: none of them ship one. A *static* paper-grain overlay at low opacity plus watercolor-edged texture work is the safe version.
- **Do not attempt Tiny Glade-class real-time GI, custom engines, or Plucky Squire-class 2D/3D world switching.** Each is a specialist-years investment.
- **No fully painted camera-mapped world** — it forfeits the rotatable Storybook Isometric Camera that is a core differentiator.
- **Don't let one flat camera angle be the whole game** (Snufkin's main visual criticism), and don't let gorgeous art carry thin activities (Dordogne 76 MC, Season 60k units — art awards ≠ sales; the cozy loop must be deep).
- **De-risk mouse character designs immediately.** Eastshade's animal-folk backlash shows stylized animal characters can repel buyers; Brambly Hedge's mice must read as Barklem's, and key art should be A/B tested with wishlisting audiences early.

### Engine/pipeline decisions to make now (July 2026)

- **Move off built-in render pipeline to URP before any art is produced at volume.** Every technique above (Shader Graph lit-ramp shader, decals for path wear, screen-space roof-fade/cutaway for dollhouse interiors, volumetric-ish light shafts) is URP-native; built-in RP is a dead end and 2022.3 is aging — evaluate Unity 6 LTS now, before content lock, not after.
- **Dollhouse interiors:** implement Sims-4-style cutaway as a per-building roof/upper-floor fade (shader dither or renderer toggle by camera raycast), with interiors lit by their own baked lightmap volume so stepping inside reads as a warm illustrated cross-section. None of the comps solved interiors well (Tiny Glade/Snufkin mostly skip them) — this is a genuine differentiation opportunity and should be prototyped in the first 3 months.
- **Realistic scope math:** comps suggest a 1–3 person team hits "small Snufkin with deeper systems" in 3–4 years only if the world is one hedgerow (a handful of exterior zones + ~6–10 interiors), textures are reused via trim sheets/atlases, and the art style tolerates imperfection (animation-on-twos, texture boil) as charm rather than demanding polish.
