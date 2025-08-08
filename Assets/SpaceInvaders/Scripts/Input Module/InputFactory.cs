using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for creating and managing input strategies.
    /// </summary>
    public class InputFactory : MonoBehaviour, IInputFactory
    {
        private KeyboardInputStrategy _keyboardInputStrategy;
        private JoystickInputStrategy _joystickInputStrategy;
        private Dictionary<InputType, IInputStrategy> _inputStrategies;
        private void Awake()
        {
            _keyboardInputStrategy = new KeyboardInputStrategy();
            _joystickInputStrategy = new JoystickInputStrategy();
            _inputStrategies = new Dictionary<InputType, IInputStrategy>();
            _inputStrategies.Add(InputType.Keyboard, _keyboardInputStrategy);
            _inputStrategies.Add(InputType.Joystick, _joystickInputStrategy);
        }
        public IInputStrategy GetInputStrategyByType(InputType inputType)
        {
            if (_inputStrategies.TryGetValue(inputType, out IInputStrategy inputStrategy))
            {
                return inputStrategy;
            }
            Debug.LogError($"Input strategy for {inputType} not found.");
            return null;
        }
    }
}
