using UnityEngine;

namespace BramblyHedge.Player
{
    /// <summary>
    /// Camera-relative movement for the player mouse (docs/gdd/10-core-systems.md).
    /// Verbs at greybox scope: walk / scamper (run). No jump — jumping is de-emphasised (D14).
    /// Movement is relative to the Storybook Camera's facing, so "up" is always
    /// "away from the camera" even as the camera snaps between its 8 yaws.
    /// </summary>
    public class MouseController : MonoBehaviour
    {
        [Header("Speed (build units / second)")]
        public float walkSpeed = 3.5f;
        public float scamperSpeed = 6f;

        [Tooltip("How quickly the mouse turns to face travel direction.")]
        public float turnLerp = 12f;

        [Tooltip("Ground height the mouse is clamped to.")]
        public float groundY = 0f;

        Transform _cam;

        void Start()
        {
            if (Camera.main != null) _cam = Camera.main.transform;
        }

        void Update()
        {
            if (_cam == null && Camera.main != null) _cam = Camera.main.transform;

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 input = new Vector3(h, 0f, v);
            if (input.sqrMagnitude > 1f) input.Normalize();

            // Project the camera's basis onto the ground plane.
            Vector3 fwd = _cam != null ? Vector3.ProjectOnPlane(_cam.forward, Vector3.up).normalized : Vector3.forward;
            Vector3 right = _cam != null ? Vector3.ProjectOnPlane(_cam.right, Vector3.up).normalized : Vector3.right;
            Vector3 move = fwd * input.z + right * input.x;

            bool running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton0);
            float speed = running ? scamperSpeed : walkSpeed;

            if (move.sqrMagnitude > 0.0001f)
            {
                transform.position += move.normalized * speed * Time.deltaTime * Mathf.Min(1f, input.magnitude);
                Quaternion look = Quaternion.LookRotation(move.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, look, turnLerp * Time.deltaTime);
            }

            // Keep the mouse on the ground (greybox has no terrain height yet).
            Vector3 p = transform.position;
            p.y = groundY;
            transform.position = p;
        }
    }
}
