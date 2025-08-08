using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for storing bullet data such as speed.
    /// </summary>
    public class BulletData : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private float _speed = 10f;

        public float Speed => _speed;
    }
}
