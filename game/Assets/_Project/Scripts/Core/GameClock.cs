using UnityEngine;

namespace BramblyHedge.Core
{
    /// <summary>
    /// The single owner of in-game time (see docs/gdd/13-time-and-seasons.md).
    /// Greybox scope: runs the daylight clock 06:00–24:00 at 1 game-minute per real-second.
    /// The real game sleeps to advance the day; here we simply loop the day so the
    /// lighting/HUD have something live to read.
    /// </summary>
    public class GameClock : MonoBehaviour
    {
        public static GameClock Instance { get; private set; }

        [Tooltip("Real seconds per game minute. 1.0 = normal (D6). ~1.43 = 'unhurried mode'.")]
        public float realSecondsPerGameMinute = 1.0f;

        public const int DayStartMinute = 6 * 60;   // 06:00
        public const int DayEndMinute = 24 * 60;     // 24:00

        /// <summary>Minutes since midnight, fractional. Starts at 06:00.</summary>
        public float MinuteOfDay { get; private set; } = DayStartMinute;

        public int Hour => Mathf.FloorToInt(MinuteOfDay / 60f) % 24;
        public int Minute => Mathf.FloorToInt(MinuteOfDay % 60f);
        public string TimeString => $"{Hour:00}:{Minute:00}";

        /// <summary>0 = dawn start, 1 = end of night. Handy for lighting blends.</summary>
        public float DayProgress =>
            Mathf.InverseLerp(DayStartMinute, DayEndMinute, MinuteOfDay);

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(this); return; }
            Instance = this;
        }

        void Update()
        {
            if (realSecondsPerGameMinute <= 0f) return;
            MinuteOfDay += Time.deltaTime / realSecondsPerGameMinute;

            if (MinuteOfDay >= DayEndMinute)
            {
                // Greybox: loop the day. The shipping game runs an overnight pass on sleep.
                MinuteOfDay = DayStartMinute + (MinuteOfDay - DayEndMinute);
            }
        }
    }
}
