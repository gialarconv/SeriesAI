using System;
using System.Collections.Generic;
using System.Reflection;
using SeriesAI.Utilities;
using UnityEngine;

namespace SeriesAI.Game
{
    public class PlatformStateManager : Singleton<PlatformStateManager>
    {
        public Dictionary<PlatformType, IPlayerState> StateMap { get; private set; } = new();
        public Dictionary<PlatformType, Action<PlayerMovement, Collider2D>> PlatformHandlers { get; private set; }
        
        public Collider2D CurrentPlatform { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();

            InitializeStateTypes();
            InitializePlatformHandlers();
            
            GameEventManager.OnPlayerPlatformChange += OnPlayerPlatformChange;
        }

        private void OnDestroy()
        {
            GameEventManager.OnPlayerPlatformChange -= OnPlayerPlatformChange;
        }

        private void InitializeStateTypes()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttribute<StateTypeAttribute>();
                    if (attribute != null && typeof(IPlayerState).IsAssignableFrom(type))
                    {
                        var instance = (IPlayerState)Activator.CreateInstance(type);
                        StateMap[attribute.Type] = instance;
                    }
                }
            }
        }

        private void InitializePlatformHandlers()
        {
            PlatformHandlers = new Dictionary<PlatformType, Action<PlayerMovement, Collider2D>>
            {
                { PlatformType.Wind, HandleWindPlatform }
            };
        }

        private void HandleWindPlatform(PlayerMovement playerMovement, Collider2D collider)
        {
            var windArea = collider.gameObject.GetComponent<WindPlatform>();
            if (windArea != null)
            {
                playerMovement.ChangeState(new WindAreaState(windArea.WindForce));
                CustomDebug.LogEditor(nameof(PlatformStateManager), $"WindAreaState {windArea.WindForce}", Color.green);
            }
        }
        
        private void OnPlayerPlatformChange(Collider2D platformCollider)
        {
            if (platformCollider == null)
                return;
            
            CurrentPlatform = platformCollider;
        }
    }
}