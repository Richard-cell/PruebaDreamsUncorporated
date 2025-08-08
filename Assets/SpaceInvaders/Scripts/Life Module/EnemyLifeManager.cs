namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for managing the lives of enemies.
    /// </summary>
    public class EnemyLifeManager : LifeManager
    {
        private EnemySpawner _enemySpawner;
        private IScoreSetter _scoreSetter;

        public void Init(EnemySpawner enemySpawner, IScoreSetter scoreSetter)
        {
            _enemySpawner = enemySpawner;
            _scoreSetter = scoreSetter;
        }
        protected override void DestroyObject()
        {
            _scoreSetter.SetScore(GetComponent<EnemyData>().ScoreValue);
            _enemySpawner.RemoveEnemieFromList(GetComponent<EnemyData>());
            Destroy(gameObject);
        }
    }
}

