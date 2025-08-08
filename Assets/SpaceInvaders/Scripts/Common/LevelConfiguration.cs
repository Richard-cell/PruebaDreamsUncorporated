using System;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for storing the configuration of a level in the game.
    /// </summary>
    [Serializable]
    public class LevelConfiguration
    {
        [HideInInspector]public int LevelNumber;
        [Header("Input configuration")]
        public InputType inputType;

        [Header("Player configuration")]
        public PlayerData defaultPlayerInLevel;
        [HideInInspector]public int playerLives = 3;

        [Header("Enemies configuration")]
        public int enemyColumns;
        public RowEnemyData[] enemyRowsData;
        [HideInInspector]public int enemiesLives = 1;
        public float enemyMoveSpeedCooldown;
        public float enemyFireRateCooldown;
    }
}
