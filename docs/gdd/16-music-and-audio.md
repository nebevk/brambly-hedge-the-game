# 16. Music & Audio

[← Back to Index](./INDEX.md) | [Previous](./15-progression.md) | [Next: UI Philosophy →](./17-ui-philosophy.md)

**Direction in one sentence:** the hedge sounds like a small, busy, safe place tucked inside a vast, slow England — tiny sounds close and lovingly detailed, big sounds distant, soft and unhurried.

Audio carries half of the "you are a mouse" illusion (the camera carries the other half — see [07 Camera Direction](./07-camera-direction.md)). It is also our substitute for voice acting: per [D12](./00-decisions.md), the game ships with **zero VO at baseline**, so foley, vocalisation and score must do the emotional work that other games buy with actors. The reference stack, in order of authority: **Ernie Wood's scoring for the 1996–2000 TV series** (tone), **Moss** (instrumentation for a small hero), **Pikmin 4** (zoom-linked mixing and footsteps), **Unpacking** (SFX-as-charm). See the [canon bible §7](../research/01-brambly-hedge-canon.md), [small-scale-worlds research](../research/07-comps-small-scale-worlds.md), and the [synthesis](../research/00-synthesis.md).

---

## 16.1 Mouse-Scale Sound Principles (govern everything below)

1. **Tiny is close and detailed; big is distant and soft.** Everything mouse-made or mouse-touched (crockery, wicker, cloth, tools, doors) is recorded rich and intimate, mixed forward. Everything human-world-scale (wind in the canopy, rooks across the field, distant thunder, a far-off farm) is low-frequency, reverberant, slow, and never loud. The speed differential is itself a scale cue: small things sound quick and busy; big things sound slow ([research 07, implication 11](../research/07-comps-small-scale-worlds.md)).
2. **Sounds are larger than their geometric size** (Moss's rule — [research 07 §2](../research/07-comps-small-scale-worlds.md)). A mouse teacup clinks like a real teacup, gently brightened (+2 to +4 semitones at most). **Never pitch props into comedy-chipmunk register** — the world is miniature, not silly.
3. **Weather is an event at mouse scale.** Over the rain bed, individual fat drops strike leaves near the player as discrete one-shots (a soft "thock" with a leaf-flex tail). Snow is rendered mostly as *silence*: exterior beds duck and low-pass, footsteps go soft, the robin sounds very alone.
4. **Never state size in audio either** (Miyamoto's ambiguity rule): no human voices, no traffic, no aircraft, no machinery except the mice's own mill. The human world exists only as weather, birds and distance.
5. **Audio is never the sole channel** for gameplay-critical information (accessibility, [D15](./00-decisions.md)) — every cue that matters has a visual counterpart.

**Operational test (every milestone build):** the *eyes-closed test* — 30 seconds of audio alone, team must correctly name season, zone, and indoors/outdoors. Logged build-over-build like the camera's 10-screenshot test.

---

## 16.2 Score

### Instrument palette

Physically small instruments, per [D12](./00-decisions.md) and the Moss playbook (Jason Graves chose instruments "small in size and sound" — ukulele, hammered dulcimer, Celtic harp; [research 07 §2](../research/07-comps-small-scale-worlds.md)):

| Tier | Instruments | Role |
|---|---|---|
| **Core quartet** | Celtic harp, hammered dulcimer, recorder (descant + treble), celeste | Carry every theme; ≥1 core instrument in every cue |
| **Support colours** | Clarinet, solo violin/viola (never a section), pizzicato cello, glockenspiel, music box, soft frame drum | Seasonal colouration, ceremony weight |
| **Forbidden** | Brass, string-section tuttis, epic/trailer percussion, synth pads, drum kit, choir | Instantly breaks the miniature register |

Tonal reference is Ernie Wood's TV scoring — "gentle orchestral/folk… used simply but elegantly" ([canon §7](../research/01-brambly-hedge-canon.md)): melody-forward, diatonic, English folk-inflected, comfortable with silence. Record the core quartet with live players (breath and finger noise are the point); sampled support is acceptable.

### Leitmotif policy — restraint as a rule

- **One main hedge theme**, hummable, ≤8 bars — this is also the licence-pitch asset and must survive being whistled ([canon implication 10](../research/01-brambly-hedge-canon.md)).
- In ordinary play the theme appears only as **2–4 bar fragments** inside exploration cues.
- The **full statement swells only at ceremonies**: festival Celebration phases, community-project completion reveals, season title cards, and the year-one cottage-reveal climax ([D7](./00-decisions.md)). Budget: a player should hear the full theme **at most once per session**. If the theme plays over routine foraging, the mix is wrong.
- Character leitmotifs are a **Could** (1.0 ships without them). If added, motif IDs are role-based and rename-safe (`theme_miller`, not a character name) per [D1](./00-decisions.md).

### Seasonal variants — "same hedge, four books," applied to music

The main theme and exploration material are re-orchestrated per season, mirroring the art doctrine ([D4](./00-decisions.md)):

| Season | Lead voices | Character |
|---|---|---|
| Spring | Recorder + harp | Bright, quick ornaments, major |
| Summer | Hammered dulcimer + lazy violin | Warm, slower tempo, drowsy afternoons |
| Autumn | Clarinet + low harp | Modal/minor inflection, wind in it |
| Winter | Celeste + music box + soft strings | Sparse, crystalline, firelit at cadences |

### Cue list at 1.0 (32 cues incl. 6 stings, ~48 min composed)

| Slot | Cues | Minutes | Notes |
|---|---|---|---|
| Main theme (title) + music-box journal variant | 2 | 4.0 | Journal variant plays softly under long journal reading |
| Seasonal daytime exploration | 4 × 2 | 16.0 | Theme-derived fragments, generous rests |
| Seasonal evening | 4 × 1 | 6.0 | Golden-hour register |
| Night | 0 | — | Ambience only; rare 20 s music-box fragments |
| Interior domestic beds | 2 | 4.0 | Season-agnostic, hearth-warm |
| Community meeting cue | 1 | 1.5 | Under Proposal-phase gatherings |
| Work-in-progress cue | 1 | 2.0 | Industrious, light; Contribution/Construction phases |
| Heart-scene underscore beds | 3 | 4.5 | Shared across NPCs (tender / merry / wistful) |
| Spring picnic festival suite | 2 | 3.5 | Preparations + celebration ([D10](./00-decisions.md)) |
| Midwinter's Eve suite | 3 | 5.5 | Log procession, grand entertainment, quiet embers |
| Stings: wake, sleep/save, season title card, project complete, discovery, heart-up | 6 | 1.5 | ≤10 s each |

Post-launch (free updates, [D10](./00-decisions.md)): Midsummer wedding suite and Snow Ball suite, ~7 min additional.

### Scheduling inside the 20-minute day

Wall-to-wall music would exhaust a ~20-minute day loop ([D6](./00-decisions.md)). Music plays in **bouts**: wake cue at 06:00, one optional midday bout, evening cue at ~18:00, ambience-only night — roughly **35–45% music coverage** of an ordinary day. Rules:

- A playing cue always finishes; phase changes swap the *pool*, never interrupt (exception: festival start and cutscenes).
- Never the same cue twice consecutively.
- Festivals override with continuous music for the whole Celebration phase.
- Time pauses in the journal ([D6](./00-decisions.md)); world audio ducks −9 dB with a gentle low-pass and the music-box variant may enter after ~10 s of reading.

### Diegetic music

Canon gives us musicians: Wilfred plays whistle and drums ([canon §3](../research/01-brambly-hedge-canon.md)), and Midwinter's Eve features a "grand entertainment" of recitals. Festival music is staged **diegetically**: at Near zoom it emits as 3D audio from the band's actual position; at Vista the mix hands over to the non-diegetic mastered version of the same cue. This zoom-linked handover is a signature moment — cheap, and nobody else does it.

---

## 16.3 Music Interactivity Scope (deliberately small)

Music state = **day-phase (morning / midday / evening / night) × season (4) + festival override + interior flag**. That is the entire interactive-music design. No vertical layering, no stingers-on-actions, no beat-synced transitions, no middleware. Transitions are 2–4 s equal-power crossfades at cue boundaries. A `MusicCue` table (ScriptableObjects) maps states to cue pools; the AudioDirector picks with a no-repeat shuffle. Anything cleverer is scope creep — cut per [D5](./00-decisions.md)'s quarterly review rule.

---

## 16.4 The Zoom-Linked Mix (copy Pikmin 4 wholesale)

Pikmin 4 changes its mix with camera height: low camera = footsteps and voices "as if listening with your face close to the ground"; zoomed out = "faint noises from the world of tiny creatures spreading out below" under broad ambience ([research 07 §6](../research/07-comps-small-scale-worlds.md)). Our camera has exactly three zoom bands ([D3](./00-decisions.md)), so this is a **mixer-snapshot problem, not a systems problem**.

### Snapshot table (starting values, tune in the greybox)

| Mixer group | **Near** | **Default** | **Vista** |
|---|---|---|---|
| Footsteps + player foley | +2 dB | 0 dB | −8 dB |
| Interaction SFX | +1 dB | 0 dB | −6 dB |
| Ambience bed | −4 dB, stereo width ~60% | 0 dB, width 85% | +2 dB, width 100% |
| Birds / canopy layer | −5 dB | 0 dB | +2 dB |
| Tiny-world detail | via 3D sources (naturally close) | 0 dB | −12 dB dedicated *Vista detail bed* |
| Music | 0 dB | 0 dB | +1 dB |
| Reverb send | intimate, short | medium | long, airy |

- **Near** = face close to the ground: intimate foley, narrowed ambience, close leaf rustle and insect detail; pairs with the camera's low "pallet moments."
- **Vista** = the diorama register: wide ambience on top, and underneath it the **Vista detail bed** — a purpose-mixed faint loop of tiny-world life (distant mill clatter, faint hammering, thin voices, a door closing somewhere). This bed exists *only* at Vista and is the audio equivalent of tilt-shift: the hedge as a living miniature.
- **Snapshot transitions:** `TransitionTo(0.4 s)` on zoom-band change (matches the camera's ~0.35 s tweens); 0.6 s for interior/exterior; 0.25 s for journal open/close.
- Snapshot set at 1.0: `Ext_Near`, `Ext_Default`, `Ext_Vista`, `Int_Near`, `Int_Default`, `Journal`, `Cutscene`. Seven snapshots, no more.

**Operational test:** with eyes closed, a zoom change must be identifiable within 0.5 s. Prototype this mix with library placeholder sounds **during the 2-week camera greybox** ([D3](./00-decisions.md)) — it is half the flagship feature's feel and costs days, not weeks.

---

## 16.5 Ambience

### Layer stack (exterior)

| # | Layer | Content | Driven by |
|---|---|---|---|
| 1 | Base bed | Season × zone stereo loop, 60–90 s, seamless | Zone volume + season |
| 2 | Birdsong | Dawn chorus 06:00–08:00 (dense), sparse day, dusk song, silent night | Time of day + season |
| 3 | Wind | Canopy wash + foliage rustle; gust one-shots | Weather intensity |
| 4 | Water | Stream loops along a spline (distance-attenuated); mill wheel; drips | Proximity |
| 5 | Weather | Rain-on-leaves bed + close drop one-shots; snow hush (duck + LPF layer 1–4) | Weather state |
| 6 | Insects | Bees (summer day), crickets (summer/autumn dusk) | Season + time |
| 7 | Spot emitters | 15–25 per zone: a creaking branch, seed heads, a woodpecker far off, NPC work sounds | Hand-placed |

### Seasonal character matrix (botanically honest, per [D4](./00-decisions.md))

| Season | Birds | Signature | Weather bias |
|---|---|---|---|
| Spring | Full dawn chorus — blackbird, wren, robin, wood pigeon | Showers on new leaves, bees arriving | Light rain |
| Summer | Sparser midday song, swifts high and faint | Crickets, mill wheel, drowsy warm wind | Rare heavy shower |
| Autumn | Rooks across the field, robin re-singing | Dry leaf rustle, wind gusts, heavy rain | Rain + wind |
| Winter | Robin only; rooks distant | Snow silence, ice creak on the stream margin | Snow hush |

### Interior room tones (one per interior; heroes first, [D14](./00-decisions.md))

| Interior | Room tone |
|---|---|
| Store Stump | Cellar hush, jar-lid ticks, distant footsteps on wood stairs |
| Old Oak Palace | Airy hall reverb, fire crackle, a big clock somewhere above |
| The Mill | The star: rhythmic wheel-and-gears clatter loop, flour-sack thumps — canon calls it cramped and clattering ([canon §2](../research/01-brambly-hedge-canon.md)) |
| Dairy | Drips on stone, pan resonance, churn rhythm when Poppy works |
| Family burrows (kit) | Fire crackle, kettle, floorboard settle — shared kit, per-home dressing |

Every interior also gets an **exterior bleed layer** (the outside bed, low-passed and −12 dB, weather-reactive) so rain on the window reads from inside.

### Community projects are audible ([D7](./00-decisions.md))

- **Contribution/Construction phases:** NPC work shifts have spot-emitter foley — sawing, thatching, hammering, rope creak — audible before visible. Witnessed construction is partly *heard* construction.
- **Function phase:** the binding "≥1 ambient change" is an ambience-layer edit that persists forever. Examples: repaired mill → mill-wheel loop joins the water layer; repaired bridge → footsteps and NPC greetings across the stream; Ice Hall → muffled dance music leaking through snow blocks; new cottage → a new hearth crackle and kettle on that doorstep. The ambience data model must support **save-flagged layer additions** from day one.

---

## 16.6 Footsteps & Player Foley

The Pikmin 4 recipe, adopted verbatim: each step = **crisp responsive transient + micro-texture tail** (their "first half human footsteps, second half fingers crushing gravel" — [research 07 §6](../research/07-comps-small-scale-worlds.md)).

### Spec

- **Two layers per step:** transient (50–80 ms, shared per material) + texture tail (material-specific granular detail).
- **Materials at 1.0 (8):** leaf litter, moss, bark/branch, flagstone, packed soil, grass thatch, interior floorboard, snow. **Vertical slice (6):** leaf litter, moss, bark/branch, flagstone, packed soil, interior floorboard — the summer set plus interiors; grass thatch and snow wait for 1.0.
- **Round-robin:** ≥6 transients + ≥6 tails per material, shuffle-bag (no immediate repeats), pitch jitter ±40 cents, gain jitter ±1.5 dB.
- **Gaits:** walk and scamper share samples with velocity-scaled gain/low-frequency content; scamper adds cadence (small = fast). Climb uses a separate grip/scrabble set; squeeze plays cloth-rustle foley; balance-run adds a wood-flex creak layer on branches ([D14](./00-decisions.md) verbs).
- **Detection:** downward raycast → `SurfaceType` from physics material or terrain layer; interiors tag floors per room.
- **NPC footsteps** use the same sets at −6 dB with half the round-robin depth.

Asset count: 8 materials × (6+6) × ~2 variants ≈ **200 files**, a weekend of focused foley recording with dried leaves, bark slabs, stone and moss trays.

---

## 16.7 Interaction SFX — Charm Is the Reward Channel

Unpacking proved foley can be the personality of an unvoiced game ([synthesis §3.16](../research/00-synthesis.md)); with no money and no XP, **sound is our reward juice**. Rules:

- **Every player verb has a bespoke sound** — no generic "pickup.wav." Foraging a blackberry ≠ pulling a chestnut ≠ snipping meadowsweet.
- **The Store Stump deposit is the game's "coin sound":** a warm wicker-and-jar *thunk-rustle-settle*, three-layer, slightly randomised. It must be satisfying enough that playtesters deposit things just to hear it. This single sound gets a dedicated foley session.
- **Cooking chain:** chop, stir, pour, sizzle, oven door, the finished-dish chime (a soft celeste arpeggio — the score leaking into SFX).
- **Journal:** paper-heavy — page turns, quill scratch, the clasp. The journal must *sound* like the physical books feel ([canon §1](../research/01-brambly-hedge-canon.md): the miniature format is part of the brand).
- **Gift-giving:** paper unwrap + recipient vocalisation, warmth scaled by gift preference tier ([D9](./00-decisions.md)).
- **UI is diegetic-adjacent:** paper, pencil, cloth — never digital bleeps.

**Charm test (per milestone):** 10 random interactions; each sound must pass a team vote of "replay-worthy." Any failure goes on the re-record list.

---

## 16.8 Voices — the D12 Stance

### Baseline at 1.0: zero VO (⚠ DEFAULT — owner to confirm)

Per [D12](./00-decisions.md). Writing must work unvoiced — a binding rule for [12 NPCs](./12-npcs.md) and [14 Quests](./14-quests.md): no line may depend on spoken delivery; emotion is carried by word choice, portrait/animation, and vocalisation. Zero VO is also **rename insurance**: no recorded audio contains canon names, so a Plan B rename ([D1](./00-decisions.md)) never touches the audio pipeline.

### Expressive vocalisations

- **6 archetype voice kits** (elder m/f, adult m/f, child m/f), each ~12 short non-verbal expressions: greeting, agreement, surprise, chuckle, thoughtful hum, effort, farewell, brr-cold, appreciative "mmm," worry, delight, and a sung/hummed fragment. 12 scheduled NPCs draw from the 6 kits with a fixed per-NPC EQ/pitch signature (±2 semitones max — see §16.1 rule 2).
- **Trigger policy:** one vocalisation at dialogue open, selected by Yarn line metadata (`#mood:cheerful` → kit lookup); occasional emotes in ambient life (humming while working, a chuckle at the supper). Text advances **silently** after the opening sound.
- **Explicitly rejected:** per-syllable babble (Animalese-style). It implies voice, fights the storybook hush, and grates over 25–35 hours. One warm sound, then quiet.
- Asset count: 6 kits × 12 expressions × 2–3 takes ≈ **170 files**, one or two recording days with 2–3 versatile performers.

### Partial-VO stretch (funded stretch goal only, ~$10–15k, Eastshade model)

If funded ([D12](./00-decisions.md)): key scenes only — heart-scene openings, festival ceremony lines (Old Vole's blessing, the Midwinter recital), and optionally a storybook narrator for season title cards in the register of the John Moffatt audiobooks / Robert Lindsay TV narration ([canon §7](../research/01-brambly-hedge-canon.md)). **Canon-layer warning ([D1](./00-decisions.md)):** any recorded line containing a character or place name is licence-locked and cannot be renamed by a string swap. Record VO only after licence resolution, or record from rename-safe scripts. This is the one place in the audio plan where the canon-layer/rename-safe distinction has teeth.

---

## 16.9 Implementation (Unity-native, deliberately boring)

**Unity's built-in audio engine + AudioMixer snapshots is sufficient. No FMOD, no Wwise** ([D2](./00-decisions.md) stack discipline). Our needs — 7 snapshots, crossfaded music pools, layered loops, round-robin one-shots — are all first-class Unity features. Reconsider middleware only if a concrete need emerges (beat-synced music transitions, routine >40-voice scenes, a dedicated audio designer who cannot work in-Editor, or console-port platform audio); until one of those is true, adopting middleware is scope creep.

### Mixer hierarchy

```
Master
├── Music
├── Ambience
│   ├── Bed  ├── Birds  ├── Wind  ├── Water  ├── Weather  └── RoomTone (+ VistaDetail)
├── SFX
│   ├── Footsteps  ├── Foley  ├── Interaction  ├── Vocalisations  └── UI
└── (Reverb return)
```

Options screen exposes Master / Music / Ambience / SFX / UI sliders (SFX slider governs vocalisations too).

### Data model sketch

```
SurfaceType        (SO): id, footstepSet
FootstepSet        (SO): transients[], tails[], pitchJitter, gainJitter
AmbienceBed        (SO): zoneId, season, clip, dayPhaseGainCurve
AmbienceLayerFlag  (save data): persistent layer additions from project Function phases
MusicCue           (SO): id, clip, minutes, statePool {season, dayPhase, interior, festival}
VoiceKit           (SO): archetype, expression→clips[] map
AudioDirector      (1 MonoBehaviour at composition root): subscribes to SO event
                   channels — TimeService.PhaseChanged, EC_SeasonChanged,
                   CameraRig.ZoomBandChanged, InteriorVolume.Enter/Exit,
                   FestivalService.StateChanged — selects snapshot + music pool.
```

Event wiring uses the same SO-event-channel seams as the rest of the architecture ([19 Technical Direction](./19-technical-direction.md)).

### Performance & mastering

- Voice budget: **32 real voices**, virtualise beyond; pooled AudioSources, no `PlayClipAtPoint` allocations in loops. Must hold 60 fps on Steam Deck ([D2](./00-decisions.md)).
- Formats: music + beds = Vorbis streaming (~q0.5); short SFX = PCM/ADPCM decompress-on-load. Runtime audio memory target ≤ 60 MB.
- Occlusion: **none at 1.0.** Interior/exterior bleed is trigger-volume LPF only. Raycast occlusion is on the "specific need" list, not the plan.
- Reverb: per-snapshot send levels + per-interior reverb settings (small wooden rooms for burrows; longer, warmer for the Palace hall).
- Loudness: full mix ≈ **−23 LUFS integrated** in ordinary play, festival peaks ≈ −18, true peak ≤ −1 dBTP.

---

## 16.10 Asset Budget & Build Order

| Category | 1.0 count (approx.) |
|---|---|
| Music cues | 32 cues (incl. 6 stings) / ~48 min |
| Ambience beds + weather + room tones | ~40 loops |
| Footsteps | ~200 files |
| Interaction/foley one-shots | ~250 files |
| Vocalisations | ~170 files |
| UI/journal | ~25 files |
| **Total** | **~700 files + score** |

Bespoke foley for hero interactions (Store Stump deposit, cooking, journal); reputable library sources acceptable for beds, weather and birds — provided species and season are correct (the botanical-accuracy bar extends to birdsong).

**Build order:** (1) *Camera greybox weeks 1–2:* zoom snapshots live with placeholder library audio — the mix is half the flagship's feel. (2) *Vertical slice (M3–6):* complete **summer** vertical — summer beds, 6 footstep materials, 2 voice kits, meeting/work/summer-exploration cues, main theme first draft, Store Stump deposit sound at final quality (it's in every GIF with sound on). (3) *1.0:* remaining seasons, festivals, full kit. Composer and foley are contractor line items inside the [D16](./00-decisions.md) budget frame (~€140–220k total) — plan roughly a low-five-figure euro allocation across score, foley sessions and vocalisation recording, firmed up when the vertical slice measures real per-asset costs.

---

## 16.11 Testable Bars (summary)

| # | Test | Pass condition | Cadence |
|---|---|---|---|
| 1 | Eyes-closed test | 30 s of audio identifies season, zone, in/out | Every milestone |
| 2 | Zoom audibility | Zoom band change audible ≤0.5 s, eyes closed | Every milestone |
| 3 | Charm test | 10 random interaction sounds, team-voted replay-worthy | Every milestone |
| 4 | Theme restraint | Full main-theme statement ≤1× per ordinary session | Design review |
| 5 | Fatigue test | 2 h playtest: no cue repeats back-to-back; no tester mutes music (survey) | Each external playtest |
| 6 | Function-phase audio | Every completed project adds ≥1 persistent ambience change | Per project ship |

---

[← Back to Index](./INDEX.md) | [Previous](./15-progression.md) | [Next: UI Philosophy →](./17-ui-philosophy.md)
