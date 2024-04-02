namespace SeriesAI.Enemy
{
    public interface IEnemyState
    {
        void Enter(EnemyAI enemy);
        void Exit(EnemyAI enemy);
        void Update(EnemyAI enemy);
    }
}