using UnityEngine;
using BramblyHedge.Core;
using BramblyHedge.CameraRig;

namespace BramblyHedge.Greybox
{
    /// <summary>
    /// Minimal on-screen readout so the greybox is visibly "alive": the game clock,
    /// the camera's snapped yaw and zoom band, and the controls. This is a debug
    /// overlay, not the shipping UI (the real UI is the Journal — see 17-ui-philosophy.md).
    /// </summary>
    public class GreyboxHUD : MonoBehaviour
    {
        public StorybookCameraRig rig;

        GUIStyle _panel, _title, _line;
        Texture2D _bg;

        void EnsureStyles()
        {
            if (_title != null) return;

            _bg = new Texture2D(1, 1);
            _bg.SetPixel(0, 0, new Color(0.15f, 0.12f, 0.10f, 0.72f));
            _bg.Apply();

            _panel = new GUIStyle { normal = { background = _bg } };
            _title = new GUIStyle
            {
                fontSize = 18, fontStyle = FontStyle.Bold, richText = true,
                normal = { textColor = new Color(1f, 0.95f, 0.85f) }
            };
            _line = new GUIStyle
            {
                fontSize = 14, richText = true,
                normal = { textColor = new Color(0.93f, 0.9f, 0.85f) }
            };
        }

        void OnGUI()
        {
            EnsureStyles();

            const float w = 320f;
            float h = 168f;
            GUI.Box(new Rect(12, 12, w, h), GUIContent.none, _panel);
            GUILayout.BeginArea(new Rect(24, 22, w - 24, h - 12));

            GUILayout.Label("Brambly Hedge — Camera Greybox", _title);
            GUILayout.Space(6);

            string clock = GameClock.Instance != null ? GameClock.Instance.TimeString : "--:--";
            GUILayout.Label($"Time of day:  <b>{clock}</b>", _line);

            if (rig != null)
                GUILayout.Label($"Camera:  yaw <b>{rig.YawDegrees}°</b>   zoom <b>{rig.ZoomBandName}</b>", _line);

            GUILayout.Space(8);
            GUILayout.Label("<b>Controls</b>", _line);
            GUILayout.Label("WASD / arrows / left stick — move", _line);
            GUILayout.Label("Shift — scamper (run)", _line);
            GUILayout.Label("Q / E — rotate camera 45°", _line);
            GUILayout.Label("Mouse wheel or [ ] — zoom band", _line);

            GUILayout.EndArea();
        }
    }
}
