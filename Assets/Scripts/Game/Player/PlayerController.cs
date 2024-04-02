using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace SeriesAI.Game
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private CharacterFlipper _characterFlipper;
        [SerializeField] private Transform _characterTransform;
        
        private InputAction _moveAction;
        private InputAction _jumpAction;

        public static Transform PlayerTransform { get; private set; }

        private void Awake()
        {
            if (!_playerMovement)
                _playerMovement = GetComponent<PlayerMovement>();

            if (!_playerInput)
                _playerInput = GetComponent<PlayerInput>();

            _moveAction = _playerInput.actions["Move"];
            _jumpAction = _playerInput.actions["Jump"];

            PlayerTransform = transform;

            DelegateInputActions();
        }

        private void OnDisable()
        {
            UndelegateInputActions();
        }

        private void DelegateInputActions()
        {
            if (_moveAction != null)
            {
                _moveAction.performed += OnMove;
                _moveAction.canceled += OnMove;
            }

            if (_jumpAction != null)
            {
                _jumpAction.started += OnJump;
            }
        }

        private void UndelegateInputActions()
        {
            if (_moveAction != null)
            {
                _moveAction.performed -= OnMove;
                _moveAction.canceled -= OnMove;
            }

            if (_jumpAction != null)
            {
                _jumpAction.started -= OnJump;
            }
        }

        private void HandleMoveInputChanged(Vector2 moveInput)
        {
            float moveX = moveInput.x;
            
            _characterFlipper.FlipCharacter(moveX);

            if (moveX > 0)
                transform.DORotate(new Vector3(0, 0, -10), 0.2f);
            else if (moveX < 0)
                transform.DORotate(new Vector3(0, 0, 10), 0.2f);
            else
                transform.DORotate(Vector3.zero, 0.2f);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _playerMovement.SetMoveInput(context.ReadValue<Vector2>());

            HandleMoveInputChanged(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started && _playerMovement.IsGrounded())
            {
                _playerMovement.Jump();
                _characterTransform.DOPunchScale(new Vector3(0.2f, -0.2f, 0), 0.5f).OnComplete(() =>
                {
                    _characterTransform.localScale = Vector3.one;
                });
            }
        }

        public void ResetPlayer()
        {
            transform.SetParent(null);
            transform.position = Vector3.zero;
        }
    }
}