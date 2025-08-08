using System;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for managing the lives of game objects.
    /// </summary>
    public abstract class LifeManager : MonoBehaviour
    {
        private int _lives = 3;
        private int _currentLives;
        public event Action<int> OnLivesChanged;
        public event Action OnObjectDestroyed;
        public void Configure(int lives)
        {
            _lives = lives;
            _currentLives = _lives;
        }
        public void DecreaseLife()
        {
            _currentLives--;
            if (_currentLives <= 0)
            {
                OnObjectDestroyed?.Invoke();
                DestroyObject();
            }
            else
            {
                OnLivesChanged?.Invoke(-1);
            }
        }
        public void IncreaseLife()
        {
            _currentLives++;
            if (_currentLives > _lives)
            {
                _currentLives = _lives;
            }
            OnLivesChanged?.Invoke(1);
        }

        protected abstract void DestroyObject();


    }
}

