using UnityEngine;

namespace SeriesAI.Game
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    [PlatformType(PlatformType.Ice)]
    public class IcePlatform : Platform
    {
    }
}