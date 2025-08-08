using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is responsible for spawning enemies in a grid-like pattern.
    /// </summary>
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        [Header("Settings")]
        [SerializeField] private float _columnsSpaceBetweenEnemies = 2;
        [SerializeField] private float _rowsSpaceBetweenEnemies = 2;

        [Header("References")]
        [SerializeField] private Transform _enemiesSpawnerPoint;
        [SerializeField] private EnemyShooterBasicAIController _enemyShooterBasicAIController;

        private int _columnsCount;
        private int _rowsCount;
        private RowEnemyData[] _currentRowsEnemyData;
        private int _currentEnemiesLives;
        private List<EnemyData> _currentEnemiesInGame;
        private float _fireRateCooldown;
        private IScoreSetter _scoreSetter;

        public event Action OnDefeatedAllEnemies;

        public void Configure(int columnsCount, RowEnemyData[] rowEnemyDatas, int enemiesLives, float fireRateCooldown, IScoreSetter scoreSetter)
        {
            _columnsCount = columnsCount;
            _rowsCount = rowEnemyDatas.Length;
            _currentRowsEnemyData = rowEnemyDatas;
            _currentEnemiesLives = enemiesLives;
            _currentEnemiesInGame = new List<EnemyData>(_columnsCount * _rowsCount);
            _fireRateCooldown = fireRateCooldown;
            _scoreSetter = scoreSetter;
        }
        public void SpawnEnemies()
        {
            ClearEnemies();
            for (int rowIndex = 0; rowIndex < _rowsCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _columnsCount; columnIndex++)
                {
                    var enemyData = _currentRowsEnemyData[rowIndex].EnemyInRow;
                    if (enemyData == null) continue;
                    Vector3 spawnPosition = new Vector3(
                        _enemiesSpawnerPoint.position.x + columnIndex * _columnsSpaceBetweenEnemies,
                        _enemiesSpawnerPoint.position.y - rowIndex * _rowsSpaceBetweenEnemies,
                        0f
                    );
                    var enemyClone = Instantiate(enemyData, spawnPosition, Quaternion.identity);
                    enemyClone.transform.SetParent(_enemiesSpawnerPoint);
                    enemyClone.LifeManager.Configure(_currentEnemiesLives);
                    enemyClone.GetComponent<EnemyLifeManager>().Init(this,_scoreSetter);

                    _currentEnemiesInGame.Add(enemyClone);


                    if (rowIndex == 0)
                    {
                        enemyClone.tag = "EnemyTopRow";
                    }
                }
            }

            _enemyShooterBasicAIController.Configure(_currentEnemiesInGame, _fireRateCooldown);
        }
        public void RemoveEnemieFromList(EnemyData enemyToRemove)
        {
            _currentEnemiesInGame.Remove(enemyToRemove);
            if (_currentEnemiesInGame.Count == 0)
            {
                OnDefeatedAllEnemies?.Invoke();
                Debug.Log("All enemies defeated!");
            }
        }
        public void ClearEnemies()
        {
            _currentEnemiesInGame.Clear();
            foreach (Transform child in _enemiesSpawnerPoint)
            {
                Destroy(child.gameObject);
            }
        }
        public void Reset()
        {
            _enemyShooterBasicAIController.Reset();
            _columnsCount = 0;
            _rowsCount = 0;
            _currentRowsEnemyData = null;
            _currentEnemiesLives = 0;
            ClearEnemies();

        }
    }
}

