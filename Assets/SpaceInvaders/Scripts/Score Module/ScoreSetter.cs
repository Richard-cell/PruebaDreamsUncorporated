using System;
using TMPro;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for setting and displaying the score in the game.
    /// </summary>
    public class ScoreSetter : MonoBehaviour, IScoreSetter
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _currentScore = 0;
        private void Start()
        {
            _currentScore = 0;
        }
        public void SetScore(int score)
        {
            _currentScore += score;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _scoreText.text = _currentScore.ToString();
        }
    }
}

