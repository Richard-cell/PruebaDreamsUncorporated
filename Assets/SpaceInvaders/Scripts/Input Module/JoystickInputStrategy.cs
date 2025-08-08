using System;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class that implements joystick input strategy for the game.
    /// </summary>
    public class JoystickInputStrategy : IInputStrategy
    {
        public InputType Type { get; set; }
        public event Action OnShoot;
        public JoystickInputStrategy()
        {
            Type = InputType.Joystick;
        }

        public Vector2 GetPositionVector()
        {
            return new Vector2(0, 0);
        }

        public void DetectWhenIsShoot()
        {
            
        }
    }
}
