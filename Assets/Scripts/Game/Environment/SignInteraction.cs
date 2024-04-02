using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SeriesAI.Game
{
    public class SignInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionIcon;
        [SerializeField] private float _animationDuration = 0.3f;

        [Space] [TextArea(10, 10)]
        [SerializeField] private string _signTextString;

        private SignElements _signElements;
        private InputAction _interactAction;

        private void OnDestroy()
        {
            _interactAction.Disable();
        }

        public void InitializeSign(SignElements signElements)
        {
            _signElements = signElements;

            _interactAction = _signElements.playerInput.actions["Interaction"];
            _interactAction.performed += _ => ShowSign();
            _interactAction.Enable();

            _signElements.signPanel.SetActive(false);
            _interactionIcon.SetActive(false);

            _signElements.closeButton.onClick.AddListener(CloseSign);
            _signElements.signText.text = _signTextString;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _interactionIcon.transform.localScale = Vector3.zero;
                _interactionIcon.SetActive(true);
                _interactionIcon.transform.DOScale(Vector3.one, _animationDuration);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _interactionIcon.transform.DOScale(Vector3.zero, _animationDuration)
                    .OnComplete(() => _interactionIcon.SetActive(false));
            }
        }

        private void ShowSign()
        {
            if (_interactionIcon != null && _interactionIcon.activeSelf && _signElements != null && !_signElements.signPanel.activeSelf)
            {
                _signElements.signPanel.transform.localScale = Vector3.zero;
                _signElements.signPanel.SetActive(true);
                _signElements.signPanel.transform.DOScale(Vector3.one, _animationDuration);

                _interactionIcon.transform.DOScale(Vector3.zero, _animationDuration)
                    .OnComplete(() => _interactionIcon.SetActive(false));
            }
        }

        public void CloseSign()
        {
            _signElements.signPanel.transform.DOScale(Vector3.zero, _animationDuration)
                .OnComplete(() => _signElements.signPanel.SetActive(false));
        }
    }
}