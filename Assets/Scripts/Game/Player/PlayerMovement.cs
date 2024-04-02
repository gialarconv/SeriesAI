using UnityEngine;
using UnityEngine.InputSystem;

namespace SeriesAI.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] private float _walkSpeed = 2f;
        [SerializeField] private float _jumpPower = 5f;
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; set; }
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;

        private Vector2 _moveInput;
        private float _speedMultiplier = 1f;
        private IPlayerState _currentState;
        
        private void Awake()
        {
            if (!Rigidbody2D)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            ChangeState(new NormalState());
        }
        public void ChangeState(IPlayerState newState)
        {
            _currentState?.Exit(this);
            _currentState = newState;
            newState.Enter(this);
        }
        
        private void FixedUpdate()
        {
            var forceX = _moveInput.x * _walkSpeed * _speedMultiplier;

            _currentState.FixedUpdate(this, forceX);
        }
        
        public void SetSpeedMultiplier(float multiplier)
        {
            _speedMultiplier = multiplier;
        }

        internal void SetMoveInput(Vector2 input)
        {
            _moveInput = input;
        }

        internal void Jump()
        {
            if (!IsGrounded())
                return;
            
            _currentState.Exit(this);
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, _jumpPower);
        }

        internal bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        }
    }
}