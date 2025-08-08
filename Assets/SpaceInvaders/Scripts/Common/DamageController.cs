using System;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for managing damage interactions between game objects. 
    /// </summary>
    public class DamageController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private TeamType _team;

        [Header("References")]
        [SerializeField] private LifeManager _lifeManager;
        public TeamType Team => _team;
        public event Action OnPlayerCollidedWithEnemy;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                if (_team == collision.GetComponent<BulletDestroyer>().Team)
                {
                    return;
                }
                _lifeManager?.DecreaseLife();
            }
            else
            {
                if (_team == TeamType.Player && collision.GetComponent<DamageController>().Team != _team)
                {
                    OnPlayerCollidedWithEnemy?.Invoke();
                }
            }
        }
    }
}

