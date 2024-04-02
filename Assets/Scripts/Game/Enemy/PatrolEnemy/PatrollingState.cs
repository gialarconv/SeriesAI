using UnityEngine;

namespace SeriesAI.Enemy
{
    public class PatrollingState : IEnemyState
    {
        private const float Offset = 0.5f;

        private Vector2 _leftBoundary;
        private Vector2 _rightBoundary;
        private bool _movingLeft = true;

        public void Enter(EnemyAI enemy)
        {
            var platformCollider = enemy.PlatformCollider;
            if (platformCollider != null)
            {
                var bounds = platformCollider.bounds;
                var position = enemy.transform.position;
                _leftBoundary = new Vector2(bounds.min.x + Offset, position.y);
                _rightBoundary = new Vector2(bounds.max.x - Offset, position.y);
            }
        }

        public void Exit(EnemyAI enemy)
        {
        }

        public void Update(EnemyAI enemy)
        {
            
            if (_movingLeft)
            {
                if (enemy.transform.position.x > _leftBoundary.x)
                    enemy.Move(-enemy.PatrolSpeed);
                else
                    _movingLeft = false;
            }
            else
            {
                if (enemy.transform.position.x < _rightBoundary.x)
                    enemy.Move(enemy.PatrolSpeed);
                else
                    _movingLeft = true;
            }
        }
    }
}