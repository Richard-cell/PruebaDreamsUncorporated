using System.Collections;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for shooting bullets from the player.
    /// </summary>
    public class EnemyBulletShooter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private Transform _pointToShootBullet;

        [Header("Configuration")]
        [SerializeField] private float _shootCooldown = 0.5f;

        private bool _canShoot = true;
        public void ShootBulletCO()
        {
            if (_canShoot)
            {
                StartCoroutine(ShootCooldownCoroutine());
            }
        }
        private void ShootBullet()
        {
            var bullet = Instantiate(_enemyData.EnemyBullet, _pointToShootBullet.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(-_pointToShootBullet.up * bullet.Speed, ForceMode2D.Impulse);
            bullet.GetComponent<BulletDestroyer>().Configure(TeamType.Enemy);
        }
        private IEnumerator ShootCooldownCoroutine()
        {
            if (_canShoot)
            {
                _canShoot = false;
                ShootBullet();
                yield return new WaitForSeconds(_shootCooldown);
                _canShoot = true;
            }
        }
    }
}

