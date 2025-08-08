using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for destroying bullets and handling their interactions with other objects.
    /// </summary>
    public class BulletDestroyer : MonoBehaviour
    {
        private TeamType _team;
        public TeamType Team => _team;
        public void Configure(TeamType team)
        {
            _team = team;
            DestroyBullet(6f);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                if (collision.GetComponent<BulletDestroyer>().Team != _team)
                {
                    DestroyBullet(0f);
                }
            }
            else if (collision.GetComponent<DamageController>() != null)
            {
                if (collision.GetComponent<DamageController>().Team != _team)
                {
                    DestroyBullet(0f);
                }
            }
        }
        private void DestroyBullet(float timeToDestroy)
        {
            Destroy(gameObject, timeToDestroy);
        }
    }
}

