using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for managing the countdown UI in the game.
    /// </summary>
    public class CountdownUIController : MonoBehaviour, ICountdownUIController
    {
        [Header("UI Components references")]
        [SerializeField] private TextMeshProUGUI _countdownText;

        [Header("Countdown Settings")]
        [SerializeField] private int _countdownValue = 5;

        public event Action OnCountdownFinished;
        public event Action OnCountdownStarted;
        private int _countdownCurrentValue;

        private void Start()
        {
            _countdownText.text = _countdownValue.ToString();
            _countdownCurrentValue = _countdownValue;
        }
        private IEnumerator CountdownCO()
        {
            while (_countdownCurrentValue > 0)
            {
                _countdownText.text = _countdownCurrentValue.ToString();
                yield return new WaitForSecondsRealtime(1f);
                _countdownCurrentValue--;
                _countdownText.text = _countdownCurrentValue.ToString();
            }
            OnCountdownFinished?.Invoke();
        }
        public void StartCountdown()
        {
            OnCountdownStarted?.Invoke();
            _countdownCurrentValue = _countdownValue;
            StartCoroutine(CountdownCO());
        }
        public void ResetCountdown()
        {
            _countdownCurrentValue = _countdownValue;
            _countdownText.text = _countdownValue.ToString();
        }
    }
}
