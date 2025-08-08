using System;

namespace SpaceInvaders
{
    public interface IEnemySpawner
    {
        event Action OnDefeatedAllEnemies;
        void Configure(int columnsCount, RowEnemyData[] rowEnemyDatas, int enemiesLives, float fireRateCooldown, IScoreSetter scoreSetter);
        void SpawnEnemies();
        void Reset();
    }
}

