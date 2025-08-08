using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for spawning the player at a specific spawn point.
    /// </summary>
    public class PlayerSpawner : MonoBehaviour, IPlayerSpawner
    {
        [Header("Settings")]
        [SerializeField] private Transform _spawnPoint;
        private PlayerData _currentPlayerSpawned;
        public PlayerData PlayerSpawned { get => _currentPlayerSpawned; set => _currentPlayerSpawned = value; }
        public void SpawnPlayer(PlayerData playerToSpawn)
        {
            _currentPlayerSpawned = Instantiate(playerToSpawn, _spawnPoint.position, Quaternion.identity);
            _currentPlayerSpawned.transform.SetParent(_spawnPoint);
        }
        public void ResetPosition()
        {
            _currentPlayerSpawned.transform.position = _spawnPoint.position;
        }
        public void Reset()
        {
            if (_currentPlayerSpawned != null)
            {
                Destroy(_currentPlayerSpawned.gameObject);
            }
        }
    }
}

