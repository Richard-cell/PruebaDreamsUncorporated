using System;
using UnityEngine;

namespace SpaceInvaders
{
	public interface IInputStrategy
	{
		InputType Type { get; set; }
		event Action OnShoot;
		void DetectWhenIsShoot();
        Vector2 GetPositionVector();
	}
	public enum InputType
	{
		Keyboard,
		Joystick
    }
}
