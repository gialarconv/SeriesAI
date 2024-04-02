using System;
using JetBrains.Annotations;
using SeriesAI.Game;
using TMPro;
using UnityEngine;

namespace Game.Levels
{
    [Serializable]
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private GameObject LevelPrefab;
        [SerializeField] private GameItemsCounter _gameItemsCounter;
        [SerializeField] private SignInteraction SignInteraction;

        public void Initialize(TextMeshProUGUI gemCountText, SignElements signElements)
        {
            _gameItemsCounter.Initialize(gemCountText);
            if (SignInteraction != null)
                SignInteraction.InitializeSign(signElements);
        }
    }
}