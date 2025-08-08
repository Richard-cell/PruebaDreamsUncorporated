using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for storing enemy data such as score value and bullet data.
    /// </summary>
    public class EnemyData: MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private int _scoreValue = 100;
        [SerializeField] private BulletData _enemyBullet;

        public int ScoreValue => _scoreValue;
        public BulletData EnemyBullet => _enemyBullet;
        public EnemyLifeManager LifeManager => GetComponent<EnemyLifeManager>();
    }
}