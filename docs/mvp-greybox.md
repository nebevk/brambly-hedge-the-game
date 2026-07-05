# MVP Step 1 — The Storybook Camera Greybox

This is the first playable thing in the project. Per the GDD ([20-mvp.md](./gdd/20-mvp.md)), the very first build validates the **flagship feature** — the Storybook Isometric Camera ([07-camera-direction.md](./gdd/07-camera-direction.md), decision [D3](./gdd/00-decisions.md)) — before any art is made. It's greybox (primitive shapes) on purpose: the point is to feel the camera, movement, and mouse-scale, not to look pretty yet.

It uses **no extra packages** (no Cinemachine) and builds its own scene at runtime, so there's nothing to wire up by hand.

## How to run it

1. Open **Unity Hub → Add → select the `game/` folder**, then open the project. (Editor version is pinned in `game/ProjectSettings/ProjectVersion.txt` — 2022.3 LTS; it also opens cleanly in newer LTS.)
2. Let Unity import. Then in the top menu bar: **Brambly → Create Greybox Scene (Main)**. This creates and opens `Assets/_Project/Scenes/Main.unity`.
3. Press **Play**.

> Shortcut: you can also just press **Play** on any open scene — an auto-bootstrap spawns the greybox if the scene has no player. The menu item is the tidy way that gives you a saved `Main.unity`.

## Controls

| Input | Action |
|---|---|
| **WASD / arrows / left stick** | Move the mouse (camera-relative) |
| **Shift** | Scamper (run) |
| **Q / E** | Rotate the camera by 45° (8 snapped angles) |
| **Mouse wheel** or **[** / **]** | Change zoom band (Near / Default / Vista) |

The on-screen panel shows the game clock, the camera's snapped yaw, and the current zoom band, so you can see the systems are live.

## What it demonstrates (the Step-1 checklist)

- **Perspective camera** at ~38° pitch, ~28° FOV — the composed "book plate" framing, not a flat top-down.
- **8 × 45° snapped yaw** with a gentle 0.35 s settle, and **3 discrete zoom bands** — exactly the D3 spec, minus the later polish (arrival shots, roof-fade interiors).
- **Camera-relative movement** that stays intuitive as the camera snaps around.
- **Mouse scale**: oversized grass, flowers, and far "Old Oak" landmarks that break the horizon (the no-minimap wayfinding rule, D14).
- **The game clock** running at 1 game-minute per real-second (D6).

## What's deliberately NOT here yet

Roof-fade dollhouse interiors, Cinemachine arrival shots, real art/shaders, NPCs, gathering/cooking, the Journal. Those come after the camera feel is confirmed. If the camera feels right here, the flagship risk is retired and the vertical slice is worth building.

## If input doesn't respond

The scripts use Unity's classic Input Manager. If nothing moves, set **Edit → Project Settings → Player → Active Input Handling → "Both"** (the Input System package is installed in the scaffold and may default to new-only), then reopen the scene. Everything else is package-free.

## The code

All under `game/Assets/_Project/Scripts/`:

| File | Role |
|---|---|
| `Camera/StorybookCameraRig.cs` | The flagship camera (pitch/FOV/yaw-snap/zoom/follow) |
| `Player/MouseController.cs` | Camera-relative mouse movement, no jump |
| `Core/GameClock.cs` | The in-game clock (D6 spec) |
| `Greybox/GreyboxBootstrap.cs` | Builds the test scene procedurally |
| `Greybox/GreyboxHUD.cs` | Debug on-screen readout |
| `Editor/GreyboxSceneCreator.cs` | The `Brambly ▸ …` menu items |

Tuning values (pitch, FOV, zoom distances, speeds) are exposed in the Inspector on each component — select the **Main Camera** or **PlayerMouse** at Play time and adjust to taste.
