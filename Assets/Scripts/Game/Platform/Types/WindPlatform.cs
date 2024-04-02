using UnityEngine;

namespace SeriesAI.Game
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    [PlatformType(PlatformType.Wind)]
    public class WindPlatform : MonoBehaviour
    {
        [field: SerializeField] public float WindForce { get; private set; } = 1f;
    }
}