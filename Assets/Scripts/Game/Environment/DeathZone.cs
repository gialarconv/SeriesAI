using UnityEngine;

namespace SeriesAI.Game
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameEventManager.LevelEnd(false);
            }
        }
    }
}