using SeriesAI.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SeriesAI.Game
{
    public class GameOverManager : MonoBehaviour
    {
        [Header("Game over panel")]
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _playRestartText;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            GameEventManager.OnLevelEnd += HandleLevelEnd;
            GameEventManager.OnGameQuit += HandleQuitGame;
        }

        private void OnDisable()
        {
            GameEventManager.OnLevelEnd -= HandleLevelEnd;
            GameEventManager.OnGameQuit -= HandleQuitGame;
        }

        private void Start()
        {
            Application.runInBackground = true;
            _gameOverPanel.SetActive(false);
            DelegateButtonsCallbacks();
        }

        private void DelegateButtonsCallbacks()
        {
            _restartButton.onClick.AddListener(() =>
            {
                GameEventManager.GameOver();
                _gameOverPanel.SetActive(false);
            });
            _quitButton.onClick.AddListener(GameEventManager.GameQuit);
        }

        private void HandleLevelEnd(bool endState)
        {
            _gameOverPanel.SetActive(true);

            if (endState)
            {
                GameEventManager.UpdateCurrentLevel();

                _playRestartText.text = "Next level";
                _titleText.text = "Level complete!";
                CustomDebug.LogEditor(nameof(GameOverManager), "Game Complete!", Color.green);
            }
            else
            {
                _playRestartText.text = "Restart level";
                _titleText.text = "Game Over!";
                CustomDebug.LogEditor(nameof(GameOverManager), "Game Over!", Color.red);
            }
        }

        private void HandleQuitGame()
        {
            if (Application.isEditor)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
                Application.Quit();
        }

        private void GameOver()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}