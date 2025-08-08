using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for moving the player based on input strategy.
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerData _playerData;

        private IInputStrategy _inputStrategy;
        public void Configure(IInputStrategy inputStrategy)
        {
            _inputStrategy = inputStrategy;
        }
        private void Update()
        {
            MovePlayer();
        }
        private void MovePlayer()
        {
            Vector3 movement = _inputStrategy.GetPositionVector();
            transform.Translate(movement * _playerData.MoveSpeed * Time.deltaTime);
        }
    }
}
