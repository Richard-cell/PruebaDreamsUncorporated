namespace SpaceInvaders
{
    public interface IEnemyMovementController
    {
        void Configure(float moveCooldown);
        void MoveEnemies();
        void Reset();
    }
}

