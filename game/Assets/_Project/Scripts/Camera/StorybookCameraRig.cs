using UnityEngine;

namespace BramblyHedge.CameraRig
{
    /// <summary>
    /// The Storybook Isometric Camera (docs/gdd/07-camera-direction.md, decision D3).
    /// Perspective, ~38° pitch, ~28° FOV, 8 × 45° snapped yaw with a smooth tween,
    /// 3 discrete zoom bands, pivot on the player. No free orbit at MVP.
    ///
    /// Attach to the Camera GameObject and assign <see cref="target"/> (the player).
    /// Controls: Q / E rotate 45°; mouse wheel or [ ] change zoom band.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class StorybookCameraRig : MonoBehaviour
    {
        [Header("Follow")]
        public Transform target;
        [Tooltip("How high above the target's pivot the camera looks (build units).")]
        public float focusHeight = 0.6f;
        [Tooltip("Position smoothing time (seconds). Gentle, never abrupt.")]
        public float followSmooth = 0.18f;

        [Header("Framing (D3 spec)")]
        [Range(22f, 45f)] public float pitch = 38f;
        [Range(22f, 35f)] public float fieldOfView = 28f;

        [Header("Yaw — 8 × 45° snaps")]
        [Tooltip("Approx. seconds for a 45° turn to settle (D3: ~0.35s smoothstep).")]
        public float yawTween = 0.35f;
        [Range(0, 7)] public int startYawIndex = 1; // 45° = a three-quarter view

        [Header("Zoom bands — Near / Default / Vista (build units)")]
        public float[] zoomDistances = { 6f, 10f, 16f };
        [Range(0, 2)] public int startZoomIndex = 1;

        Camera _cam;
        Vector3 _focus, _focusVel;
        float _yaw, _yawVel;         // current smoothed yaw
        int _yawIndex;
        float _distance, _distanceVel;
        int _zoomIndex;

        public int YawDegrees => Mathf.RoundToInt(Mathf.Repeat(_yawIndex * 45f, 360f));
        public string ZoomBandName => _zoomIndex == 0 ? "Near" : _zoomIndex == 1 ? "Default" : "Vista";

        void Awake()
        {
            _cam = GetComponent<Camera>();
            _cam.orthographic = false;         // perspective, always (D3)
            _cam.fieldOfView = fieldOfView;

            _yawIndex = Mathf.Clamp(startYawIndex, 0, 7);
            _zoomIndex = Mathf.Clamp(startZoomIndex, 0, zoomDistances.Length - 1);
            _yaw = _yawIndex * 45f;
            _distance = zoomDistances[_zoomIndex];
            if (target != null) _focus = target.position + Vector3.up * focusHeight;
        }

        void ReadInput()
        {
            // Yaw: snap by 45°. Input latches even mid-tween (D3).
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton4))
                _yawIndex = (_yawIndex + 7) % 8;
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton5))
                _yawIndex = (_yawIndex + 1) % 8;

            // Zoom: 3 discrete bands.
            float scroll = Input.mouseScrollDelta.y;
            if (scroll > 0.01f || Input.GetKeyDown(KeyCode.RightBracket))
                _zoomIndex = Mathf.Max(0, _zoomIndex - 1);
            if (scroll < -0.01f || Input.GetKeyDown(KeyCode.LeftBracket))
                _zoomIndex = Mathf.Min(zoomDistances.Length - 1, _zoomIndex + 1);
        }

        void LateUpdate()
        {
            if (target == null) return;
            ReadInput();

            // Smooth the pieces independently so movement always feels gentle.
            _focus = Vector3.SmoothDamp(_focus, target.position + Vector3.up * focusHeight,
                                        ref _focusVel, followSmooth);

            float targetYaw = _yawIndex * 45f;
            // Shortest-path smoothing around the 360° wrap.
            _yaw = Mathf.SmoothDampAngle(_yaw, NearestEquivalentAngle(_yaw, targetYaw),
                                         ref _yawVel, yawTween);

            _distance = Mathf.SmoothDamp(_distance, zoomDistances[_zoomIndex],
                                         ref _distanceVel, 0.2f);

            Quaternion rot = Quaternion.Euler(pitch, _yaw, 0f);
            Vector3 pos = _focus - (rot * Vector3.forward) * _distance;
            transform.SetPositionAndRotation(pos, rot);
            _cam.fieldOfView = fieldOfView;
        }

        // Return an angle equivalent to 'to' that is within ±180° of 'from',
        // so SmoothDampAngle always takes the short way round.
        static float NearestEquivalentAngle(float from, float to)
        {
            return from + Mathf.DeltaAngle(from, to);
        }
    }
}
