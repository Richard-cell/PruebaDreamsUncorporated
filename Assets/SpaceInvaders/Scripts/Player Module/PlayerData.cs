using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for storing player data such as initial lives, movement speed, and bullet data.
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField][Range(0,5)] private int _initialLives = 3;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private BulletData _playerBullet;

        public int InitialLives => _initialLives;
        public float MoveSpeed => _moveSpeed;
        public BulletData PlayerBullet => _playerBullet;
        public PlayerMovementController PlayerMovementController => GetComponent<PlayerMovementController>();
        public PlayerBulletShooter PlayerBulletShooter => GetComponent<PlayerBulletShooter>();
        public PlayerLifeManager LifeManager => GetComponent<PlayerLifeManager>();
        public DamageController DamageController => GetComponent<DamageController>();
    }
}
