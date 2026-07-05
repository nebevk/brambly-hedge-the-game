using UnityEngine;
using BramblyHedge.Core;
using BramblyHedge.CameraRig;
using BramblyHedge.Player;

namespace BramblyHedge.Greybox
{
    /// <summary>
    /// Builds the camera-greybox scene procedurally so there is nothing to hand-author:
    /// ground, warm lighting, a player mouse, the Storybook Camera, a HUD, and a
    /// scattered hedgerow of greybox grass/flowers/landmarks to test scale and framing.
    ///
    /// Two ways to run it:
    ///   1. Menu "Brambly ▸ Create Greybox Scene (Main)" makes a scene containing this
    ///      component; open it and press Play.
    ///   2. AutoStart (below) spawns it in any scene with no player, so pressing Play
    ///      on the default sample scene also works.
    /// </summary>
    public class GreyboxBootstrap : MonoBehaviour
    {
        public static bool AutoStart = true;

        [Header("Hedgerow density")]
        public int grassBlades = 140;
        public int flowers = 26;
        public float scatterRadius = 34f;
        public int worldSeed = 20260705;

        bool _built;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void AutoBootstrap()
        {
            if (!AutoStart) return;
            if (FindObjectOfType<MouseController>() != null) return; // a real scene is set up already
            if (FindObjectOfType<GreyboxBootstrap>() != null) return;
            var go = new GameObject("GreyboxBootstrap (auto)");
            go.AddComponent<GreyboxBootstrap>();
        }

        void Awake()
        {
            if (_built) return;
            _built = true;
            Build();
        }

        void Build()
        {
            SetEnvironment();
            CreateLight();
            var player = CreatePlayer();
            var rig = CreateCamera(player.transform);
            CreateHud(rig);
            ScatterHedgerow(player.transform.position);
            EnsureClock();
        }

        // ---- environment -------------------------------------------------------

        void SetEnvironment()
        {
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
            RenderSettings.ambientLight = new Color(0.55f, 0.55f, 0.6f);
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.86f, 0.85f, 0.78f);
            RenderSettings.fogMode = FogMode.Linear;
            RenderSettings.fogStartDistance = 22f;
            RenderSettings.fogEndDistance = 70f;

            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.localScale = Vector3.one * 12f; // 120 x 120 units
            ground.GetComponent<Renderer>().sharedMaterial = Mat(new Color(0.42f, 0.55f, 0.32f));
        }

        void CreateLight()
        {
            var go = new GameObject("Sun");
            var light = go.AddComponent<Light>();
            light.type = LightType.Directional;
            light.color = new Color(1f, 0.95f, 0.82f);   // warm morning
            light.intensity = 1.15f;
            light.shadows = LightShadows.Soft;
            go.transform.rotation = Quaternion.Euler(48f, 40f, 0f);
        }

        // ---- actors ------------------------------------------------------------

        GameObject CreatePlayer()
        {
            var root = new GameObject("PlayerMouse");
            root.transform.position = Vector3.zero;

            var body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            body.name = "Body";
            body.transform.SetParent(root.transform, false);
            body.transform.localScale = new Vector3(0.5f, 0.4f, 0.6f); // ~0.8u tall, slightly long
            body.transform.localPosition = new Vector3(0f, 0.4f, 0f);
            body.GetComponent<Renderer>().sharedMaterial = Mat(new Color(0.72f, 0.58f, 0.44f));
            StripCollider(body);

            // A nose so the facing direction is obvious.
            var nose = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            nose.name = "Nose";
            nose.transform.SetParent(root.transform, false);
            nose.transform.localScale = Vector3.one * 0.18f;
            nose.transform.localPosition = new Vector3(0f, 0.42f, 0.32f);
            nose.GetComponent<Renderer>().sharedMaterial = Mat(new Color(0.85f, 0.6f, 0.6f));
            StripCollider(nose);

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
            cam.backgroundColor = new Color(0.82f, 0.86f, 0.86f);
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

        // ---- hedgerow scatter --------------------------------------------------

        void ScatterHedgerow(Vector3 around)
        {
            var parent = new GameObject("Hedgerow").transform;
            Random.InitState(worldSeed);

            Material[] greens =
            {
                Mat(new Color(0.35f, 0.5f, 0.24f)),
                Mat(new Color(0.44f, 0.58f, 0.28f)),
                Mat(new Color(0.3f, 0.46f, 0.22f)),
            };
            Material[] petals =
            {
                Mat(new Color(0.95f, 0.85f, 0.35f)), // buttercup
                Mat(new Color(0.86f, 0.5f, 0.72f)),  // campion
                Mat(new Color(0.75f, 0.8f, 0.95f)),  // bluebell
            };
            Material stalkMat = Mat(new Color(0.42f, 0.52f, 0.26f));

            for (int i = 0; i < grassBlades; i++)
            {
                Vector2 d = Random.insideUnitCircle * scatterRadius;
                if (d.magnitude < 2.5f) d = d.normalized * 2.5f; // keep the spawn point clear
                float height = Random.Range(2f, 5.5f);

                var blade = GameObject.CreatePrimitive(PrimitiveType.Cube);
                blade.name = "Grass";
                blade.transform.SetParent(parent, false);
                blade.transform.localScale = new Vector3(0.14f, height, 0.14f);
                blade.transform.position = new Vector3(around.x + d.x, height * 0.5f, around.z + d.y);
                blade.transform.rotation = Quaternion.Euler(Random.Range(-6f, 6f), Random.Range(0f, 360f), Random.Range(-6f, 6f));
                blade.GetComponent<Renderer>().sharedMaterial = greens[Random.Range(0, greens.Length)];
                StripCollider(blade);
            }

            for (int i = 0; i < flowers; i++)
            {
                Vector2 d = Random.insideUnitCircle * scatterRadius;
                if (d.magnitude < 3f) d = d.normalized * 3f;
                float stalkH = Random.Range(2.5f, 4.5f);
                Vector3 basePos = new Vector3(around.x + d.x, 0f, around.z + d.y);

                var stalk = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                stalk.name = "Stalk";
                stalk.transform.SetParent(parent, false);
                stalk.transform.localScale = new Vector3(0.08f, stalkH * 0.5f, 0.08f);
                stalk.transform.position = basePos + Vector3.up * stalkH * 0.5f;
                stalk.GetComponent<Renderer>().sharedMaterial = stalkMat;
                StripCollider(stalk);

                var head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                head.name = "Bloom";
                head.transform.SetParent(parent, false);
                head.transform.localScale = Vector3.one * Random.Range(0.6f, 1.0f);
                head.transform.position = basePos + Vector3.up * (stalkH + 0.2f);
                head.GetComponent<Renderer>().sharedMaterial = petals[Random.Range(0, petals.Length)];
                StripCollider(head);
            }

            // A few far landmarks that break the horizon — the "always visible" rule (D14).
            Material barkMat = Mat(new Color(0.36f, 0.28f, 0.2f));
            for (int i = 0; i < 3; i++)
            {
                float ang = (i / 3f) * Mathf.PI * 2f + 0.6f;
                var oak = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                oak.name = "Landmark";
                oak.transform.SetParent(parent, false);
                float th = Random.Range(26f, 40f);
                oak.transform.localScale = new Vector3(3.5f, th * 0.5f, 3.5f);
                oak.transform.position = new Vector3(around.x + Mathf.Cos(ang) * 52f, th * 0.5f, around.z + Mathf.Sin(ang) * 52f);
                oak.GetComponent<Renderer>().sharedMaterial = barkMat;
                StripCollider(oak);
            }
        }

        // ---- helpers -----------------------------------------------------------

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
