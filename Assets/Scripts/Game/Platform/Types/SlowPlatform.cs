using UnityEngine;

namespace SeriesAI.Game
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    [PlatformType(PlatformType.Slow)]
    public class SlowPlatform : Platform
    {
    }
}