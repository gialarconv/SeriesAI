using Game.Levels;
using SeriesAI.Utilities;
using UnityEngine;

namespace SeriesAI.Game
{
    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField] public int CurrentLevel { get; private set; } = 0;

        [field: SerializeField] public LevelsData LevelsData { get; private set; }

        private void OnEnable()
        {
            CurrentLevel = 0;
            GameEventManager.OnUpdateCurrenLevel += UpdateCurrentLevel;
        }

        private void OnDestroy()
        {
            GameEventManager.OnUpdateCurrenLevel -= UpdateCurrentLevel;
        }

        private void UpdateCurrentLevel()
        {
            if (CurrentLevel < LevelsData.Levels.Length - 1)
                CurrentLevel++;
            else
                CurrentLevel = 0;
        }
    }
}