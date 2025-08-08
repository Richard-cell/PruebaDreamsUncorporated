using System;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class that implements keyboard input strategy for the game.
    /// </summary>
    public class KeyboardInputStrategy : IInputStrategy
    {
        private Vector2 _positionVector;

        public event Action OnShoot;

        public InputType Type { get; set; }
        public KeyboardInputStrategy()
        {
            Type = InputType.Keyboard;
        }
        public Vector2 GetPositionVector()
        {
            _positionVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            return _positionVector;
        }

        public void DetectWhenIsShoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnShoot?.Invoke();
            }
        }
    }
}
