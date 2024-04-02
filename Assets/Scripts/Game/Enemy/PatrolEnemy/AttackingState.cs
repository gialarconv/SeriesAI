using SeriesAI.Game;
using UnityEngine;

namespace SeriesAI.Enemy
{
    public class AttackingState : IEnemyState
    {
        private const float AttackRange = 1.0f;
        private const float VerticalAttackThreshold = 0.1f;

        public void Enter(EnemyAI enemy)
        {
        }

        public void Exit(EnemyAI enemy)
        {
        }

        public void Update(EnemyAI enemy)
        {
            var playerPosition = PlayerController.PlayerTransform.position;
            var distanceX = Mathf.Abs(playerPosition.x - enemy.transform.position.x);
            var distanceY = playerPosition.y - enemy.transform.position.y;

            switch (distanceX)
            {
                case <= AttackRange when (distanceY < VerticalAttackThreshold):
                    GameEventManager.LevelEnd(false);
                    break;
                case > AttackRange:
                {
                    var direction = Mathf.Sign(playerPosition.x - enemy.transform.position.x);
                    if ((direction < 0 && enemy.transform.position.x > enemy.PlatformCollider.bounds.min.x) ||
                        (direction > 0 && enemy.transform.position.x < enemy.PlatformCollider.bounds.max.x))
                    {
                        enemy.Move(direction * enemy.AttackingSpeed);
                    }

                    break;
                }
            }
        }
    }
}