# 1. Working Title

[← Back to Index](./INDEX.md) | [Previous: Decisions Brief](./00-decisions.md) | [Next: Vision →](./02-vision.md)

---

## 1.1 The Three Names

This project operates under three names at once, by design. The strategy is **IP Option C** — build quietly, pitch the rights holder, stay rename-ready — as locked in [D1 of the decisions brief](./00-decisions.md) and detailed in the [IP & licensing research](../research/02-ip-licensing.md).

| Name | What it is | Where it lives |
|---|---|---|
| **Brambly Hedge: The Game** | The aspirational title. What the game is called if the licence pitch succeeds. | Internal only: this GDD, the private repo, the pitch deck. |
| **Project Hedgerow** | The public/external codename until the licence is resolved. | Everything with an external surface: Steam page, devlogs, trailers, playtest builds, contractor briefs, press contact. |
| **Plan B title** (direction defined below, name not yet chosen) | The legally distinct original-IP title, held in reserve. | Adopted irrevocably if the pitch fails or stalls past the 3-month decision window. |

Brambly Hedge is owned by **Four Seasons Licensing and Merchandising Ltd** (Jill Barklem's children), agented by **Rockpool Licensing**; copyright runs to the end of 2087 and trademark rights are asserted. Shipping under the name unlicensed is straightforward infringement, not a grey area ([IP research §5](../research/02-ip-licensing.md)). The estate is small, online, agency-managed, and mid-relaunch: detection probability of any public use is **high**.

## 1.2 Naming Rules — who may say "Brambly Hedge", and where

These rules are binding on every team member, contractor, and document from today.

| Context | Permitted name | Notes |
|---|---|---|
| This GDD, research docs, private repo, internal task tracker | Canon names freely | The repo and docs are private (D1). Canon character/location names may be used without restriction *inside* them. |
| Builds that leave the core team (playtesters, contractors, porting quotes) | **Project Hedgerow** only | Ship the rename-safe string layer (see §1.3) in any external build; zero canon strings on screen, in logs, or in file metadata. |
| Steam page (M4–5 per [D16](./00-decisions.md)) | **Project Hedgerow** or the licensed name — nothing else | A Steam page named "Brambly Hedge" would reach Rockpool within days ([IP research §5](../research/02-ip-licensing.md)). |
| Devlogs, social posts, trailers, festival submissions | **Project Hedgerow** only | Marketing copy may say "inspired by classic British picture books"; it may never name Brambly Hedge pre-licence ([IP research §6, Option B](../research/02-ip-licensing.md)). |
| The licence pitch deck for Rockpool | Brambly Hedge, with book imagery | Book imagery must be clearly marked as rights-holder property used for pitch purposes only ([IP research §6, Option C](../research/02-ip-licensing.md)). |
| Publisher / investor conversations and decks | **Project Hedgerow** for all materials and builds (rename-safe layer) | The licence strategy and rights-holder identity may be disclosed verbally or under NDA only — never in written materials the counterparty retains without an NDA. Governs the publisher pitching scheduled alongside the vertical slice ([funding §6](../production/funding.md)). |
| Store metadata, achievements, save files, telemetry keys | Rename-safe identifiers only | These surfaces leak; treat them as public. |

**One test covers all of it:** if a stranger could ever see it, it says *Project Hedgerow*.

## 1.3 The Rename-Ready Data Layer (engineering requirement)

Plan B must be a **~one-week content swap that loses only the name, not one design pillar** (D1). That is an architecture requirement, not a hope:

1. **Every character name, location name, and story string lives in localization/data assets** — Unity Localization string tables and ScriptableObject definitions — never hardcoded in scripts, prefabs, or scene text (D2, D15).
2. **String IDs describe role, never canon name.** `npc.dairy_keeper`, `loc.palace_tree`, `item.autumn_berry_jam` — so the ID layer survives the rename untouched. An ID containing a canon name (`npc.poppy`) fails code review.
3. **Two content tiers exist from month one** (D1, D17): the **canon layer** (Barklem names, book-derived story beats — quarantined to private string tables) and the **rename-safe layer** (roles, systems, our own parallel name set). The game must boot and read correctly with the rename-safe table active.
4. **Art pipeline rule:** zero Barklem-derived textures, zero traced silhouettes or compositions. Style and genre are free; specific artwork is not ([IP research §5](../research/02-ip-licensing.md) — Winter Burrow is the live proof of where the line sits).
5. **Audio rule:** no canon names baked into recorded audio. The zero-VO baseline (D12) makes this nearly free; keep it true for any stretch-goal VO by recording name-bearing lines last.

**Acceptance test (run quarterly, and before any external build):** activate the placeholder name table, play 30 minutes, grep the build — zero canon strings anywhere: screen, logs, filenames, achievements, save JSON. This is the same muscle as the pseudo-localization stress test (D15); schedule them together.

## 1.4 Licence Timeline and the Decision Window

- Build the vertical slice under the codename; **pitch Rockpool Licensing ~Q2 2027** with the slice and a 10-page brand-fit deck, Snufkin/Hyper-Games-style brand-guardianship framing: no combat, no monetization gimmicks, seasonal faithfulness, "distil the essence" rather than trace the plates ([IP research §3](../research/02-ip-licensing.md)).
- Ask small: PC/console only, worldwide, ~5-year term, first option on mobile/sequels — platform carve-outs are normal (the Rovio/Moomin mobile split).
- **Hard 3-month decision window** after first substantive contact (at most two follow-ups). Yes → option or licence; no or silence → **commit irrevocably to Plan B** with zero wasted work (D1).
- Budget expectations if yes: option fee, ~10–15% royalty on net, low-five-figure minimum guarantee, £5–15k legal. **⚠ DEFAULT — owner to confirm** the budget appetite for this pitch (D1).
- Before the pitch: the £170 UK IPO trademark search (especially classes 9 and 41) plus a one-hour IP-solicitor consult ([IP research, implication 8](../research/02-ip-licensing.md)).

## 1.5 Plan B Naming Direction (held in reserve, not chosen now)

If the licence fails, the game becomes an **original hedgerow-mice IP**. The design loses nothing — "the pitch document loses only the name" ([IP research §6, Option B](../research/02-ip-licensing.md)) — and Winter Burrow (91% positive, ~1,400 reviews, mainstream coverage, zero legal trouble) proves the audience finds Brambly-Hedge-*like* games on aesthetics alone.

**Legal boundaries for the Plan B title and content:**

- No "Brambly"; no word pairing that echoes the "Brambly Hedge" mark or trade dress. A single common word like *hedgerow* or *bramble* is fine in isolation (*Bramble: The Mountain King* shipped without issue); the two-word echo is not.
- New character names and visual designs — no Barklem lookalikes; no recreation of the canonical map *ensemble* (palace tree + store stump + dairy + mill as-is); individual generic elements (an oak, a mill, a stump larder) are fine.
- No text, recipes, or compositions lifted from the books; marketing never names Brambly Hedge, even as a comparison.

**Naming direction:** a warm, concrete, English-pastoral two-or-three-word title that names a *place* or a *season of a place*, the way the books do — working shapes to explore later: *The Hedgerow Year*, *Under the Hawthorn*, *Dewberry Bank*, *The Long Hedge*. Every candidate gets a trademark screen before adoption. The rename-safe layer's parallel character/location name set (see §1.3) is drafted alongside the Plan B title so the one-week swap has content ready to swap *in*.

## 1.6 Terminology

Use the project vocabulary from [D17](./00-decisions.md) in all documents and code comments — *Project Hedgerow*, *Storybook Isometric Camera*, *community project*, *Store Stump economy*, *the Journal*, *heart-scene*, *season valve*, *canon layer / rename-safe layer*. Consistent terms keep the GDD greppable and the rename mechanical.

---

[← Back to Index](./INDEX.md) | [Previous: Decisions Brief](./00-decisions.md) | [Next: Vision →](./02-vision.md)
