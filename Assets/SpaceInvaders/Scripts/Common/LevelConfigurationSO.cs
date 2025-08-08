using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// ScriptableObject that holds the configuration for different levels in the game.
    /// </summary>
    [CreateAssetMenu(fileName = "LevelConfigurationSO", menuName = "Scriptable Objects/LevelConfigurationSO")]
    public class LevelConfigurationSO : ScriptableObject
    {
        public List<LevelConfiguration> levelSettings;
        private void Awake()
        {
            for (int i = 0; i < levelSettings.Count; i++)
            {
                levelSettings[i].LevelNumber = i;
            }
        }
    }
}
