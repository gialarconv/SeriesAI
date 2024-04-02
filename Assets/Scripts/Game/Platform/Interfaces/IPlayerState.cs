namespace SeriesAI.Game
{
    public interface IPlayerState
    {
        void Enter(PlayerMovement player);
        void Exit(PlayerMovement player);
        void FixedUpdate(PlayerMovement player, float forceX);
    }
}