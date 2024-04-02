using UnityEngine;

namespace SeriesAI.Game
{
    [StateType(PlatformType.Normal)]
    public class NormalState : IPlayerState
    {
        public void Enter(PlayerMovement player)
        {
            player.Rigidbody2D.gravityScale = 1f;
            player.SetSpeedMultiplier(1f);
        }

        public void Exit(PlayerMovement player)
        {
            player.SetSpeedMultiplier(1f);
        }

        public void FixedUpdate(PlayerMovement player, float forceX)
        {
            player.Rigidbody2D.velocity = new Vector2(forceX, player.Rigidbody2D.velocity.y);
        }
    }
}