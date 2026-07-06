using UnityEngine;
using BramblyHedge.Core;
using BramblyHedge.CameraRig;
using BramblyHedge.Player;

namespace BramblyHedge.Greybox
{
    /// <summary>
    /// Builds the camera-greybox scene procedurally: a "hedgerow pocket" laid out per
    /// docs/gdd/05-world.md — hedge wall (north), cornfield beyond it, stream with a
    /// broken plank bridge (south), hero trees, a distant forest ring fading into haze,
    /// clustered grass and flowers, and a worn path leading to a gap in the hedge.
    ///
    /// Press R at play time to regenerate the scatter with a new seed.
    /// </summary>
    public class GreyboxBootstrap : MonoBehaviour
    {
        public static bool AutoStart = true;

        [Header("World")]
        public int worldSeed = 20260705;
        public KeyCode regenerateKey = KeyCode.R;

        Transform _world;
        bool _built;

        // Palette (built once per play session)
        Material mGround, mMeadowA, mMeadowB, mPath;
        Material mGrassA, mGrassB, mGrassC;
        Material mHedgeA, mHedgeB, mCanopy, mCanopyFar, mForest;
        Material mTrunk, mPlank, mCorn, mCornDark;
        Material mWater, mPebble, mReed;
        Material mBloomA, mBloomB, mBloomC, mStalk;
        Material mFur, mNose, mBerry;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void AutoBootstrap()
        {
            if (!AutoStart) return;
            if (FindObjectOfType<MouseController>() != null) return;
            if (FindObjectOfType<GreyboxBootstrap>() != null) return;
            new GameObject("GreyboxBootstrap (auto)").AddComponent<GreyboxBootstrap>();
        }

        void Awake()
        {
            if (_built) return;
            _built = true;

            MakePalette();
            SetEnvironment();
            CreateLight();
            var player = CreatePlayer();
            var rig = CreateCamera(player.transform);
            CreateHud(rig);
            RebuildWorld();
            EnsureClock();
        }

        void Update()
        {
            if (Input.GetKeyDown(regenerateKey))
            {
                worldSeed = Random.Range(0, int.MaxValue);
                RebuildWorld();
            }
        }

        // ---- palette -------------------------------------------------------------

        void MakePalette()
        {
            mGround   = Mat(new Color(0.45f, 0.56f, 0.33f));
            mMeadowA  = Mat(new Color(0.48f, 0.58f, 0.34f));
            mMeadowB  = Mat(new Color(0.42f, 0.53f, 0.31f));
            mPath     = Mat(new Color(0.72f, 0.63f, 0.46f));
            mGrassA   = Mat(new Color(0.35f, 0.50f, 0.24f));
            mGrassB   = Mat(new Color(0.44f, 0.58f, 0.28f));
            mGrassC   = Mat(new Color(0.30f, 0.46f, 0.22f));
            mHedgeA   = Mat(new Color(0.24f, 0.36f, 0.19f));
            mHedgeB   = Mat(new Color(0.29f, 0.42f, 0.22f));
            mCanopy   = Mat(new Color(0.27f, 0.40f, 0.21f));
            mCanopyFar= Mat(new Color(0.32f, 0.42f, 0.30f));
            mForest   = Mat(new Color(0.30f, 0.38f, 0.30f));
            mTrunk    = Mat(new Color(0.36f, 0.28f, 0.20f));
            mPlank    = Mat(new Color(0.52f, 0.40f, 0.26f));
            mCorn     = Mat(new Color(0.85f, 0.74f, 0.45f));
            mCornDark = Mat(new Color(0.76f, 0.65f, 0.38f));
            mWater    = Mat(new Color(0.55f, 0.72f, 0.75f));
            mPebble   = Mat(new Color(0.62f, 0.62f, 0.58f));
            mReed     = Mat(new Color(0.33f, 0.45f, 0.28f));
            mBloomA   = Mat(new Color(0.95f, 0.85f, 0.35f));  // buttercup
            mBloomB   = Mat(new Color(0.86f, 0.50f, 0.72f));  // campion
            mBloomC   = Mat(new Color(0.72f, 0.76f, 0.94f));  // bluebell
            mStalk    = Mat(new Color(0.42f, 0.52f, 0.26f));
            mFur      = Mat(new Color(0.72f, 0.58f, 0.44f));
            mNose     = Mat(new Color(0.85f, 0.60f, 0.60f));
            mBerry    = Mat(new Color(0.42f, 0.12f, 0.22f));  // ripe bramble
        }

        // ---- environment -----------------------------------------------------------

        void SetEnvironment()
        {
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
            RenderSettings.ambientLight = new Color(0.58f, 0.58f, 0.55f);
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.84f, 0.86f, 0.76f);   // warm haze
            RenderSettings.fogMode = FogMode.Linear;
            RenderSettings.fogStartDistance = 35f;
            RenderSettings.fogEndDistance = 110f;

            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.localScale = Vector3.one * 24f; // 240 x 240 units
            ground.GetComponent<Renderer>().sharedMaterial = mGround;
            StripCollider(ground);
        }

        void CreateLight()
        {
            var go = new GameObject("Sun");
            var light = go.AddComponent<Light>();
            light.type = LightType.Directional;
            light.color = new Color(1f, 0.94f, 0.80f);      // warm morning
            light.intensity = 1.2f;
            light.shadows = LightShadows.Soft;
            go.transform.rotation = Quaternion.Euler(44f, 100f, 0f); // raking side light
        }

        // ---- actors ----------------------------------------------------------------

        GameObject CreatePlayer()
        {
            var root = new GameObject("PlayerMouse");
            root.transform.position = Vector3.zero;

            var body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            body.name = "Body";
            body.transform.SetParent(root.transform, false);
            body.transform.localScale = new Vector3(0.5f, 0.4f, 0.6f);
            body.transform.localPosition = new Vector3(0f, 0.4f, 0f);
            body.GetComponent<Renderer>().sharedMaterial = mFur;
            StripCollider(body);

            var nose = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            nose.name = "Nose";
            nose.transform.SetParent(root.transform, false);
            nose.transform.localScale = Vector3.one * 0.18f;
            nose.transform.localPosition = new Vector3(0f, 0.42f, 0.32f);
            nose.GetComponent<Renderer>().sharedMaterial = mNose;
            StripCollider(nose);

            // Ears — the silhouette that makes it read "mouse".
            for (int s = -1; s <= 1; s += 2)
            {
                var ear = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ear.name = "Ear";
                ear.transform.SetParent(root.transform, false);
                ear.transform.localScale = new Vector3(0.22f, 0.22f, 0.08f);
                ear.transform.localPosition = new Vector3(0.14f * s, 0.74f, 0.06f);
                ear.GetComponent<Renderer>().sharedMaterial = mFur;
                StripCollider(ear);
            }

            var tail = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tail.name = "Tail";
            tail.transform.SetParent(root.transform, false);
            tail.transform.localScale = new Vector3(0.06f, 0.35f, 0.06f);
            tail.transform.localPosition = new Vector3(0f, 0.22f, -0.42f);
            tail.transform.localRotation = Quaternion.Euler(115f, 0f, 0f);
            tail.GetComponent<Renderer>().sharedMaterial = mNose;
            StripCollider(tail);

            root.AddComponent<MouseController>();
            return root;
        }

        StorybookCameraRig CreateCamera(Transform target)
        {
            Camera cam = Camera.main;
            if (cam == null)
            {
                var go = new GameObject("Main Camera");
                go.tag = "MainCamera";
                cam = go.AddComponent<Camera>();
                go.AddComponent<AudioListener>();
            }
            cam.backgroundColor = new Color(0.84f, 0.86f, 0.76f); // matches the fog → seamless haze horizon
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.nearClipPlane = 0.05f;

            var rig = cam.GetComponent<StorybookCameraRig>();
            if (rig == null) rig = cam.gameObject.AddComponent<StorybookCameraRig>();
            rig.target = target;
            return rig;
        }

        void CreateHud(StorybookCameraRig rig)
        {
            var hud = rig.gameObject.GetComponent<GreyboxHUD>();
            if (hud == null) hud = rig.gameObject.AddComponent<GreyboxHUD>();
            hud.rig = rig;
        }

        void EnsureClock()
        {
            if (GameClock.Instance == null)
                new GameObject("GameClock").AddComponent<GameClock>();
        }

        // ---- the hedgerow pocket -----------------------------------------------------
        // Layout (per 05-world.md): cornfield far north, hedge wall north, open meadow
        // in the middle (spawn), stream with broken bridge south, forest haze all around.

        void RebuildWorld()
        {
            if (_world != null) Destroy(_world.gameObject);
            _world = new GameObject("Hedgerow").transform;
            Random.InitState(worldSeed);

            BuildMeadowPatches();
            BuildPath();
            BuildHedgeWall();
            BuildCornfield();
            BuildStream();
            BuildHeroTrees();
            BuildOldOakLandmark();
            BuildDistantForest();
            BuildBrambleBushes();
            ScatterGrass();
            ScatterFlowers();
        }

        void BuildMeadowPatches()
        {
            for (int i = 0; i < 8; i++)
            {
                float r = Random.Range(10f, 26f);
                Vector3 pos = new Vector3(Random.Range(-60f, 60f), 0.012f, Random.Range(-30f, 25f));
                Prim(PrimitiveType.Cylinder, "MeadowPatch", pos,
                     new Vector3(r, 0.01f, r), i % 2 == 0 ? mMeadowA : mMeadowB);
            }
        }

        void BuildPath()
        {
            // A worn path from the spawn, curving to a gap in the hedge — leads the eye.
            for (int i = 0; i < 10; i++)
            {
                float t = i / 9f;
                float x = Mathf.Lerp(0f, 7.2f, t) + Mathf.Sin(t * 3.1f) * 1.6f;
                float z = Mathf.Lerp(0.8f, 12.5f, t);
                Prim(PrimitiveType.Cylinder, "PathStone",
                     new Vector3(x + Random.Range(-0.3f, 0.3f), 0.025f, z),
                     new Vector3(Random.Range(1.9f, 2.5f), 0.015f, Random.Range(1.9f, 2.5f)), mPath);
            }
            // ...and two patches beyond the gap, so the world implies continuation.
            Prim(PrimitiveType.Cylinder, "PathStone", new Vector3(7.4f, 0.025f, 15f), new Vector3(2.2f, 0.015f, 2.2f), mPath);
            Prim(PrimitiveType.Cylinder, "PathStone", new Vector3(7.8f, 0.025f, 17.4f), new Vector3(2f, 0.015f, 2f), mPath);
        }

        void BuildHedgeWall()
        {
            // The hedge: a wall of stacked leafy blobs along the north, with a gap at the path.
            for (float x = -70f; x <= 70f; x += Random.Range(3.2f, 4.6f))
            {
                if (x > 5f && x < 10f) continue; // the gap the path leads to

                float depth = Random.Range(13.5f, 19f);
                float colHeight = Random.Range(7f, 12f);
                int blobs = Random.Range(2, 5);

                for (int i = 0; i < blobs; i++)
                {
                    float s = Random.Range(6f, 11f);
                    float y = Mathf.Lerp(s * 0.28f, colHeight, blobs <= 1 ? 0.5f : i / (float)(blobs - 1));
                    Prim(PrimitiveType.Sphere, "HedgeBlob",
                         new Vector3(x + Random.Range(-1.5f, 1.5f), y, depth + Random.Range(-1.8f, 1.8f)),
                         Vector3.one * s, Random.value > 0.5f ? mHedgeA : mHedgeB);
                }

                if (Random.value > 0.75f) // occasional visible trunk at the base
                    Prim(PrimitiveType.Cylinder, "HedgeTrunk",
                         new Vector3(x, 1.6f, depth),
                         new Vector3(0.9f, 1.8f, 0.9f), mTrunk);
            }
        }

        void BuildCornfield()
        {
            // The field margin beyond the hedge — pale gold stalks peeking over the top.
            for (float x = -70f; x <= 70f; x += Random.Range(1.8f, 2.8f))
            {
                for (float z = 24f; z <= 40f; z += Random.Range(2.4f, 3.6f))
                {
                    float h = Random.Range(12f, 17f);
                    Prim(PrimitiveType.Cylinder, "CornStalk",
                         new Vector3(x + Random.Range(-0.8f, 0.8f), h * 0.5f, z + Random.Range(-0.8f, 0.8f)),
                         new Vector3(Random.Range(0.35f, 0.55f), h * 0.5f, Random.Range(0.35f, 0.55f)),
                         Random.value > 0.4f ? mCorn : mCornDark,
                         new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f)));
                }
            }
        }

        void BuildStream()
        {
            // The stream along the south edge, with a half-broken plank crossing —
            // greybox foreshadowing of the vertical slice's bridge project.
            Prim(PrimitiveType.Cube, "Stream", new Vector3(0f, 0.02f, -16f), new Vector3(160f, 0.08f, 5.5f), mWater);

            for (int i = 0; i < 16; i++)
            {
                float x = Random.Range(-55f, 55f);
                float z = -16f + (Random.value > 0.5f ? 1f : -1f) * Random.Range(3f, 4.2f);
                Prim(PrimitiveType.Sphere, "Pebble", new Vector3(x, 0.15f, z),
                     new Vector3(Random.Range(0.8f, 1.8f), 0.4f, Random.Range(0.8f, 1.8f)), mPebble);
            }

            for (int i = 0; i < 10; i++)
            {
                float x = Random.Range(-50f, 50f);
                float z = -16f + (Random.value > 0.5f ? 1f : -1f) * Random.Range(2.8f, 3.6f);
                float h = Random.Range(3.5f, 6f);
                Prim(PrimitiveType.Cylinder, "Reed", new Vector3(x, h * 0.5f, z),
                     new Vector3(0.14f, h * 0.5f, 0.14f), mReed,
                     new Vector3(Random.Range(-6f, 6f), 0f, Random.Range(-6f, 6f)));
            }

            // The sound plank, and the broken one tipped into the water.
            Prim(PrimitiveType.Cube, "FootPlank", new Vector3(-4f, 0.22f, -16f), new Vector3(1.6f, 0.12f, 6.6f), mPlank);
            Prim(PrimitiveType.Cube, "BrokenPlank", new Vector3(-2f, 0.12f, -14.8f), new Vector3(1.5f, 0.12f, 3.6f), mPlank,
                 new Vector3(14f, 8f, 4f));
        }

        void BuildHeroTrees()
        {
            Tree(new Vector3(-13f, 0f, 11f), 7f, 2.2f, 5, 10f, 14f, mCanopy);   // near-left, frames the shot
            Tree(new Vector3(26f, 0f, 16f), 6f, 1.8f, 4, 9f, 12f, mCanopyFar);  // mid-right
        }

        void BuildOldOakLandmark()
        {
            // The mega-landmark, visible from everywhere over the hedge line (D14).
            var basePos = new Vector3(8f, 0f, 70f);
            Prim(PrimitiveType.Cylinder, "OldOakTrunk", basePos + Vector3.up * 14f, new Vector3(6f, 14f, 6f), mTrunk);
            for (int i = 0; i < 5; i++)
            {
                float s = Random.Range(26f, 36f);
                Prim(PrimitiveType.Sphere, "OldOakCanopy",
                     basePos + new Vector3(Random.Range(-9f, 9f), Random.Range(30f, 38f), Random.Range(-7f, 7f)),
                     Vector3.one * s, mCanopyFar);
            }
        }

        void Tree(Vector3 basePos, float trunkH, float trunkR, int canopyBlobs, float canopyMin, float canopyMax, Material leafMat)
        {
            Prim(PrimitiveType.Cylinder, "Trunk", basePos + Vector3.up * trunkH * 0.5f,
                 new Vector3(trunkR, trunkH * 0.5f, trunkR), mTrunk);
            for (int i = 0; i < canopyBlobs; i++)
            {
                float s = Random.Range(canopyMin, canopyMax);
                Prim(PrimitiveType.Sphere, "Canopy",
                     basePos + new Vector3(Random.Range(-3.5f, 3.5f), trunkH + Random.Range(2f, 6f), Random.Range(-3f, 3f)),
                     Vector3.one * s, leafMat);
            }
        }

        void BuildDistantForest()
        {
            // A ring of soft silhouettes on the horizon; the fog turns them into layered haze.
            for (int i = 0; i < 26; i++)
            {
                float ang = (i / 26f) * Mathf.PI * 2f + Random.Range(-0.08f, 0.08f);
                float rad = Random.Range(72f, 98f);
                float sy = Random.Range(14f, 24f);
                Prim(PrimitiveType.Sphere, "ForestHaze",
                     new Vector3(Mathf.Cos(ang) * rad, sy * 0.32f, Mathf.Sin(ang) * rad),
                     new Vector3(Random.Range(26f, 44f), sy, Random.Range(26f, 44f)), mForest);
            }
        }

        void BuildBrambleBushes()
        {
            for (int c = 0; c < 9; c++)
            {
                Vector2 d = Random.insideUnitCircle * 34f;
                if (d.magnitude < 4.5f) d = d.normalized * 4.5f;
                float z = Mathf.Clamp(d.y, -11f, 9f); // keep out of stream and hedge bands
                Vector3 center = new Vector3(d.x, 0f, z);

                int blobs = Random.Range(3, 6);
                for (int i = 0; i < blobs; i++)
                {
                    float s = Random.Range(2.4f, 4.8f);
                    Vector3 pos = center + new Vector3(Random.Range(-1.6f, 1.6f), s * 0.32f, Random.Range(-1.6f, 1.6f));
                    Prim(PrimitiveType.Sphere, "Bramble", pos, Vector3.one * s, Random.value > 0.5f ? mHedgeB : mGrassC);

                    int berries = Random.Range(2, 5);
                    for (int b = 0; b < berries; b++)
                    {
                        Vector3 dir = Random.onUnitSphere; dir.y = Mathf.Abs(dir.y) * 0.7f + 0.2f;
                        Prim(PrimitiveType.Sphere, "Berry", pos + dir.normalized * (s * 0.5f),
                             Vector3.one * 0.28f, mBerry);
                    }
                }
            }
        }

        void ScatterGrass()
        {
            Material[] greens = { mGrassA, mGrassB, mGrassC };
            for (int c = 0; c < 42; c++)
            {
                Vector3 center = new Vector3(Random.Range(-48f, 48f), 0f, Random.Range(-12f, 11f));
                if (center.magnitude < 2.5f) center = center.normalized * 2.5f;

                int blades = Random.Range(5, 11);
                for (int i = 0; i < blades; i++)
                {
                    Vector2 off = Random.insideUnitCircle * 1.5f;
                    float h = Random.Range(1.4f, 4.6f);
                    Prim(PrimitiveType.Cube, "Grass",
                         new Vector3(center.x + off.x, h * 0.5f, center.z + off.y),
                         new Vector3(0.12f, h, 0.12f), greens[Random.Range(0, greens.Length)],
                         new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 360f), Random.Range(-8f, 8f)));
                }
            }
        }

        void ScatterFlowers()
        {
            Material[] petals = { mBloomA, mBloomB, mBloomC };
            for (int c = 0; c < 14; c++)
            {
                Vector3 center = new Vector3(Random.Range(-42f, 42f), 0f, Random.Range(-11f, 10f));
                if (center.magnitude < 3f) center = center.normalized * 3f;
                Material bloom = petals[Random.Range(0, petals.Length)];

                int count = Random.Range(2, 5);
                for (int i = 0; i < count; i++)
                {
                    Vector2 off = Random.insideUnitCircle * 1.8f;
                    float h = Random.Range(2.2f, 4.2f);
                    Vector3 basePos = new Vector3(center.x + off.x, 0f, center.z + off.y);
                    Prim(PrimitiveType.Cylinder, "Stalk", basePos + Vector3.up * h * 0.5f,
                         new Vector3(0.12f, h * 0.5f, 0.12f), mStalk);
                    Prim(PrimitiveType.Sphere, "Bloom", basePos + Vector3.up * (h + 0.25f),
                         Vector3.one * Random.Range(0.55f, 0.95f), bloom);
                }
            }
        }

        // ---- helpers -------------------------------------------------------------

        GameObject Prim(PrimitiveType type, string name, Vector3 pos, Vector3 scale, Material m, Vector3? euler = null)
        {
            var go = GameObject.CreatePrimitive(type);
            go.name = name;
            go.transform.SetParent(_world, false);
            go.transform.position = pos;
            go.transform.localScale = scale;
            if (euler.HasValue) go.transform.rotation = Quaternion.Euler(euler.Value);
            go.GetComponent<Renderer>().sharedMaterial = m;
            StripCollider(go);
            return go;
        }

        static Shader _lit;
        static Shader Lit()
        {
            if (_lit == null)
            {
                _lit = Shader.Find("Universal Render Pipeline/Lit")
                       ?? Shader.Find("Standard")
                       ?? Shader.Find("Legacy Shaders/Diffuse")
                       ?? Shader.Find("Sprites/Default");
            }
            return _lit;
        }

        static Material Mat(Color c)
        {
            var m = new Material(Lit());
            if (m.HasProperty("_BaseColor")) m.SetColor("_BaseColor", c);
            if (m.HasProperty("_Color")) m.SetColor("_Color", c);
            return m;
        }

        static void StripCollider(GameObject go)
        {
            var col = go.GetComponent<Collider>();
            if (col != null) Destroy(col);
        }
    }
}
