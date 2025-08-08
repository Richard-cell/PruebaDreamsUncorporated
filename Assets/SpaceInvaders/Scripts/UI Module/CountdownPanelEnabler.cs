using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for enabling and disabling the countdown panel in the game.
    /// </summary>
    public class CountdownPanelEnabler : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private GameObject _countdownPanel;

        [Header("References")]
        [SerializeField] private CountdownUIController _countdownUIController;
        private void Start()
        {
            EnablePanel();
            _countdownUIController.OnCountdownFinished += DisablePanel;
            _countdownUIController.OnCountdownStarted += EnablePanel;
        }
        public void DisablePanel()
        {
            Time.timeScale = 1f;
            _countdownPanel.SetActive(false);
        }
        public void EnablePanel()
        {
            _countdownPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        private void OnDestroy()
        {
            _countdownUIController.OnCountdownFinished -= DisablePanel;
            _countdownUIController.OnCountdownStarted -= EnablePanel;
        }
    }
}
