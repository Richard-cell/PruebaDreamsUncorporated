using SpaceInvaders;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for enabling and disabling the game over panel in the game.
    /// </summary>
    public class GameOverPanelEnabler : MonoBehaviour, IGameOverPanelEnabler
    {
        [Header("UI References")]
        [SerializeField] private GameObject _gameOverPanel;

        private void Start()
        {
            DisablePanel();
        }
        public void DisablePanel()
        {
            Time.timeScale = 1f;
            _gameOverPanel.SetActive(false);
        }
        public void EnablePanel()
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

