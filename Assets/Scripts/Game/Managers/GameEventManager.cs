using System;
using UnityEngine;

namespace SeriesAI.Game
{
    public static class GameEventManager
    {
        public static event Action OnItemCollected;
        public static event Action<bool> OnLevelEnd;
        public static event Action OnGameOver;
        public static event Action OnUpdateCurrenLevel;
        public static event Action OnGamePause;
        public static event Action OnGameResume;
        public static event Action OnGameQuit;
        public static event Action<Collider2D> OnPlayerPlatformChange;

        public static void ItemCollected() => OnItemCollected?.Invoke();
        public static void LevelEnd(bool endState) => OnLevelEnd?.Invoke(endState);
        public static void GameOver() => OnGameOver?.Invoke();
        public static void UpdateCurrentLevel() => OnUpdateCurrenLevel?.Invoke();
        public static void GamePause() => OnGamePause?.Invoke();
        public static void GameResume() => OnGameResume?.Invoke();
        public static void GameQuit() => OnGameQuit?.Invoke();
        public static void PlayerPlatformChange(Collider2D platformCollider) => OnPlayerPlatformChange?.Invoke(platformCollider);
    }
}