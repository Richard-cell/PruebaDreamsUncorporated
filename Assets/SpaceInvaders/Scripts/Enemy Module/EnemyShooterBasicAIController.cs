using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for controlling the enemy shooter AI, allowing enemies to shoot bullets at a specified rate.
    /// </summary>
    public class EnemyShooterBasicAIController : MonoBehaviour
    {
        private float _fireRateCooldown = 5f;
        private List<EnemyData> _currentsEnemiesInGame;
        public void Configure(List<EnemyData> enemies, float fireRateCooldown)
        {
            _fireRateCooldown = fireRateCooldown;
            _currentsEnemiesInGame = enemies;
            CancelInvoke(nameof(ShootWithAI));
            InvokeRepeating(nameof(ShootWithAI), _fireRateCooldown, _fireRateCooldown);
        }
        private int GetRandomEnemyIndex()
        {
            return Random.Range(0, _currentsEnemiesInGame.Count);
        }
        private void ShootWithAI()
        {
            if (_currentsEnemiesInGame.Count > 0)
            {
                var enemyIndex = GetRandomEnemyIndex();
                var enemy = _currentsEnemiesInGame[enemyIndex];
                enemy.GetComponent<EnemyBulletShooter>().ShootBulletCO();
            }

        }
        public void Reset()
        {
            _currentsEnemiesInGame.Clear();
        }
    }
}

