using System;
using SeriesAI.Utilities;
using UnityEngine;

namespace SeriesAI.Game
{
    public class PlayerTriggerDetector : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            if (_playerMovement == null)
            {
                CustomDebug.LogErrorEditor(nameof(PlayerPlatformCollisionDetector), "Player Movement not found on the game object!");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var platform = other.gameObject.GetComponent<MonoBehaviour>();

            if (platform != null)
            {
                var attribute = (PlatformTypeAttribute)Attribute.GetCustomAttribute(platform.GetType(), typeof(PlatformTypeAttribute));
                if (attribute != null && PlatformStateManager.Instance.PlatformHandlers.TryGetValue(attribute.Type, out var handler))
                {
                    handler.Invoke(_playerMovement, other);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_playerMovement != null)
            {
                _playerMovement.ChangeState(new NormalState());
            }
        }
    }
}