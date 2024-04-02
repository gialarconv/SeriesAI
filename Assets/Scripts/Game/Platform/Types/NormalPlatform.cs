using UnityEngine;

namespace SeriesAI.Game
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    [PlatformType(PlatformType.Normal)]
    public class NormalPlatform : Platform
    {
    }
}