using System.Text;
using TMPro;
using UnityEngine;

namespace SeriesAI.Game
{
    public class GameItemsCounter : MonoBehaviour
    {
        [SerializeField] private CollectibleItem[] collectibleItems;

        private int _gemsCollected = 0;
        private StringBuilder _stringBuilder;
        private TextMeshProUGUI _gemCountText;

        private void OnEnable()
        {
            GameEventManager.OnItemCollected += HandleItemCollected;
        }

        private void OnDisable()
        {
            GameEventManager.OnItemCollected -= HandleItemCollected;
        }

        public void Initialize(TextMeshProUGUI gemCountText)
        {
            _stringBuilder = new StringBuilder();
            _gemCountText = gemCountText;
            UpdateUI();
        }

        private void HandleItemCollected()
        {
            _gemsCollected++;
            UpdateUI();

            if (_gemsCollected >= collectibleItems.Length)
            {
                GameEventManager.LevelEnd(true);
            }
        }

        private void UpdateUI()
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(_gemsCollected);
            _stringBuilder.Append("/");
            _stringBuilder.Append(collectibleItems.Length);
            _gemCountText.text = _stringBuilder.ToString();
        }
    }
}