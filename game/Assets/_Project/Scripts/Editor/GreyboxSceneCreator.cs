#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using BramblyHedge.Greybox;

namespace BramblyHedge.EditorTools
{
    /// <summary>
    /// Convenience menu items for the camera greybox. Nothing here ships in a build.
    /// </summary>
    public static class GreyboxSceneCreator
    {
        const string ScenesDir = "Assets/_Project/Scenes";
        const string MainScenePath = ScenesDir + "/Main.unity";

        [MenuItem("Brambly/Create Greybox Scene (Main)")]
        public static void CreateMainScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var go = new GameObject("GreyboxBootstrap");
            go.AddComponent<GreyboxBootstrap>();

            if (!Directory.Exists(ScenesDir)) Directory.CreateDirectory(ScenesDir);
            EditorSceneManager.SaveScene(scene, MainScenePath);

            AssetDatabase.Refresh();
            Debug.Log($"[Brambly] Created {MainScenePath}. Press Play to walk the mouse around the Storybook Camera.");
            EditorUtility.DisplayDialog(
                "Brambly Hedge",
                "Created Assets/_Project/Scenes/Main.unity.\n\nPress Play to run the camera greybox.\n\nControls:\n  WASD / arrows — move\n  Shift — scamper\n  Q / E — rotate camera 45°\n  Mouse wheel / [ ] — zoom band",
                "Got it");
        }

        [MenuItem("Brambly/Setup Greybox In Current Scene")]
        public static void SetupInCurrentScene()
        {
            if (Object.FindObjectOfType<GreyboxBootstrap>() != null)
            {
                Debug.Log("[Brambly] A GreyboxBootstrap already exists in this scene.");
                return;
            }
            var go = new GameObject("GreyboxBootstrap");
            go.AddComponent<GreyboxBootstrap>();
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            Debug.Log("[Brambly] Added GreyboxBootstrap. Press Play.");
        }
    }
}
#endif
