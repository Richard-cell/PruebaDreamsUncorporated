using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for drawing the player's lives in the UI.
    /// </summary>
    public class PlayerLifeUIDrawer : MonoBehaviour, IPlayerLifeUIDrawer
    {
        [Header("UI References")]
        [SerializeField] private GameObject _lifePanel;

        [Header("Settings")]
        [SerializeField] private GameObject _lifePrefab;

        private int _currentLives;
        private int _maxLives;
        public void Configure(int lives)
        {
            _maxLives = lives;
            _currentLives = _maxLives;
            for (int i = 0; i < _currentLives; i++)
            {
                var life = Instantiate(_lifePrefab);
                life.transform.SetParent(_lifePanel.transform, false);
            }
        }
        public void DrawLives(int livesValue)
        {
            _currentLives += livesValue;
            if (_currentLives > _maxLives)
            {
                _currentLives = _maxLives;
            }

            if (livesValue < 0)
            {
                if (_lifePanel.transform.childCount > 0)
                {
                    _lifePanel.transform.GetChild(_currentLives).gameObject.SetActive(false);
                }
            }
            else
            {
                _lifePanel.transform.GetChild(_currentLives - 1).gameObject.SetActive(true);
            }

        }
    }
}

