using UnityEngine;

namespace Game.Levels
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "SeriesAI/LevelsData", order = 1)]
    public class LevelsData : ScriptableObject
    {
        public LevelData[] Levels;
    }
}