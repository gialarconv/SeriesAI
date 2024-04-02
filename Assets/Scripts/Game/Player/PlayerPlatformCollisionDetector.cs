using System;
using SeriesAI.Utilities;
using UnityEngine;

namespace SeriesAI.Game
{
    public class PlayerPlatformCollisionDetector : MonoBehaviour
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            var platform = other.gameObject.GetComponent<MonoBehaviour>();

            if (platform != null)
            {
                var attribute = (PlatformTypeAttribute)Attribute.GetCustomAttribute(platform.GetType(), typeof(PlatformTypeAttribute));
                if (attribute != null)
                {
                    var newState = GetStateFromType(attribute.Type);
                    _playerMovement.ChangeState(newState);
                }

                GameEventManager.PlayerPlatformChange(other.collider);

                transform.SetParent(other.transform.parent);
                transform.localScale = Vector3.one;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            var platform = other.gameObject.GetComponent<MonoBehaviour>();

            if (platform == null)
                return;
            var attribute = (PlatformTypeAttribute)Attribute.GetCustomAttribute(platform.GetType(), typeof(PlatformTypeAttribute));
            if (attribute == null)
                return;
            
            GameEventManager.PlayerPlatformChange(null);
            transform.SetParent(null);
            transform.localScale = Vector3.one;
        }

        private IPlayerState GetStateFromType(PlatformType type)
        {
            if (PlatformStateManager.Instance.StateMap.TryGetValue(type, out var behavior))
            {
                return behavior;
            }

            throw new ArgumentException($"No behavior implemented for type: {type}");
        }
    }
}