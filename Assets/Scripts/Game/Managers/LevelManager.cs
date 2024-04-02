using Game.Levels;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace SeriesAI.Game
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private LevelCanvasElements _levelCanvasElements;

        [Header("Pause panel")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private InputAction _interactAction;
        private LevelData _currentLevel;

        private void OnEnable()
        {
            GameEventManager.OnGameOver += HandleGameOver;
            GameEventManager.OnGamePause += PauseGame;
            GameEventManager.OnGameResume += ResumeGame;
            _interactAction.Enable();
        }

        private void OnDisable()
        {
            GameEventManager.OnGameOver -= HandleGameOver;
            GameEventManager.OnGamePause -= PauseGame;
            GameEventManager.OnGameResume -= ResumeGame;
            _interactAction.Disable();
        }

        private void Awake()
        {
            if (_playerInput)
            {
                _interactAction = _playerInput.actions["Exit"];

                _interactAction.performed += _ => ShowPausePanel();
            }
        }


        void Start()
        {
            if (_playerController == null)
            {
                _playerController = FindObjectOfType<PlayerController>();
            }

            _pausePanel.SetActive(false);
            DelegateButtonsCallbacks();
            CreateLevel();
        }

        private void CreateLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }

            _currentLevel = Instantiate(GameManager.Instance.LevelsData.Levels[GameManager.Instance.CurrentLevel]);
            _currentLevel.Initialize(_levelCanvasElements.gemCountText, _levelCanvasElements.signElements);
        }

        private void DelegateButtonsCallbacks()
        {
            _resumeButton.onClick.AddListener(GameEventManager.GameResume);
            _restartButton.onClick.AddListener(GameEventManager.GameOver);
            _quitButton.onClick.AddListener(GameEventManager.GameQuit);
        }

        private void HandleGameOver()
        {
            _playerController.ResetPlayer();
            CreateLevel();
        }

        private void ShowPausePanel()
        {
            if (_pausePanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void ResumeGame()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}