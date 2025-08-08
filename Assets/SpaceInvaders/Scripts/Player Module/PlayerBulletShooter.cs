using System.Collections;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for shooting bullets from the enemy.
    /// </summary>
    public class PlayerBulletShooter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform _pointToShootBullet;

        [Header("Configuration")]
        [SerializeField] private float _shootCooldown = 0.5f;

        private bool _canShoot = true;
        private IInputStrategy _inputStrategy;
        public void Configure(IInputStrategy inputStrategy)
        {
            _inputStrategy = inputStrategy;
            _inputStrategy.OnShoot += ShootBulletCO;
        }
        private void Update()
        {
            _inputStrategy.DetectWhenIsShoot();
        }
        private void ShootBullet()
        {
            var bullet = Instantiate(_playerData.PlayerBullet, _pointToShootBullet.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(_pointToShootBullet.up * bullet.Speed, ForceMode2D.Impulse);
            bullet.GetComponent<BulletDestroyer>().Configure(TeamType.Player);
        }
        private void ShootBulletCO()
        {
            if (_canShoot)
            {
                StartCoroutine(ShootCooldownCoroutine());
            }
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

        private void OnDestroy()
        {
            _inputStrategy.OnShoot -= ShootBulletCO;
        }
    }
}

