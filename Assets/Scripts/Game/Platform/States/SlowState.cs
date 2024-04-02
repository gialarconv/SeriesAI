using UnityEngine;

namespace SeriesAI.Game
{
    [StateType(PlatformType.Slow)]
    public class SlowState : IPlayerState
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
            player.Rigidbody2D.AddForce(new Vector2(forceX, 0), ForceMode2D.Force);
        }
    }
}