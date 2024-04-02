using SeriesAI.Game;
using UnityEngine;

namespace SeriesAI.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [field: SerializeField] public float PatrolSpeed { get; private set; } = 2.0f;
        [field: SerializeField] public float AttackingSpeed { get; private set; } = 4.0f;
        [field: SerializeField] public Collider2D PlatformCollider { get; private set; }
        [SerializeField] private CharacterFlipper _characterFlipper;
        
        
        private IEnemyState _currentState;
        private Transform _playerTransform;

        private void Start()
        {
            ChangeState(new PatrollingState());
        }

        private void Update()
        {
            if (_currentState.GetType() != typeof(AttackingState) && IsPlayerOnSamePlatform())
            {
                ChangeState(new AttackingState());
            }
            else if (_currentState.GetType() == typeof(AttackingState) && !IsPlayerOnSamePlatform())
            {
                ChangeState(new PatrollingState());
            }

            _currentState.Update(this);
        }

        private void ChangeState(IEnemyState newState)
        {
            _currentState?.Exit(this);
            _currentState = newState;
            newState.Enter(this);
        }

        private bool IsPlayerOnSamePlatform()
        {
            var playerPlatform = PlatformStateManager.Instance.CurrentPlatform;
            return PlatformCollider != null && playerPlatform == PlatformCollider;
        }

        public void Move(float speed)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            
            _characterFlipper.FlipCharacter(speed);
        }
    }
}