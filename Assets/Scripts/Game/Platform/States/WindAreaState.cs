using UnityEngine;

namespace SeriesAI.Game
{
    [StateType(PlatformType.Wind)]
    public class WindAreaState : IPlayerState
    {
        private float _windForce;

        public WindAreaState() { }

        public WindAreaState(float windForce)
        {
            _windForce = windForce;
        }

        public void Enter(PlayerMovement player)
        {
            player.Rigidbody2D.gravityScale = 0;
            player.Rigidbody2D.velocity = new Vector2(player.Rigidbody2D.velocity.x, _windForce);
        }

        public void Exit(PlayerMovement player)
        {
            player.Rigidbody2D.gravityScale = 1f;
        }
        
        public void FixedUpdate(PlayerMovement player, float forceX)
        {
        }
    }
}