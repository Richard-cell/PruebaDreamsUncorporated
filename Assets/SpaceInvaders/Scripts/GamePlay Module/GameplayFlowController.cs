using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for managing the gameplay flow, including level transitions, player and enemy spawning, and UI updates.
    /// </summary>
    public class GameplayFlowController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]private int _levelsToWin;

        [Header("Level references")]
        [SerializeField] private LevelConfigurationSO _levelConfigurationSO;
        private int _currentLevelIndex = 0;

        private IPlayerSpawner _playerSpawner;
        private IInputFactory _inputFactory;
        private ICountdownUIController _countdownUIController;
        private IGameOverPanelEnabler _gameOverPanelEnabler;
        private IEnemySpawner _enemySpawner;
        private IEnemyMovementController _enemyMovementController;
        private IPlayerLifeUIDrawer _playerLifeUIDrawer;
        private IVictoryPanelEnabler _victoryPanelEnabler;
        private IScoreSetter _scoreSetter;

        private LevelConfiguration _currentLevelSettings;
        private bool _isRestartLevel = false;
        

        public void Configure(IPlayerSpawner playerSpawner, IInputFactory inputFactory, ICountdownUIController countdownUIController, IEnemySpawner enemySpawner, IEnemyMovementController enemyMovementController, IPlayerLifeUIDrawer playerLifeUIDrawer, IGameOverPanelEnabler gameOverPanelEnabler, IVictoryPanelEnabler victoryPanelEnabler, IScoreSetter scoreSetter)
        {
            _playerSpawner = playerSpawner;
            _inputFactory = inputFactory;
            _countdownUIController = countdownUIController;
            _enemySpawner = enemySpawner;
            _enemyMovementController = enemyMovementController;
            _playerLifeUIDrawer = playerLifeUIDrawer;
            _gameOverPanelEnabler = gameOverPanelEnabler;
            _victoryPanelEnabler = victoryPanelEnabler;
            _scoreSetter = scoreSetter;

            _levelConfigurationSO = ScriptableObject.Instantiate(_levelConfigurationSO);
            _enemySpawner.OnDefeatedAllEnemies += PassToNextLevel;

            _countdownUIController.OnCountdownFinished += LoadCurrentLevel;
            _countdownUIController.StartCountdown();
        }
        private void LoadCurrentLevel()
        {
            _currentLevelSettings = _levelConfigurationSO.levelSettings[_currentLevelIndex];

            if (_currentLevelIndex == 0 && !_isRestartLevel)
            {
                SpawnPlayerInLevel();
                _playerLifeUIDrawer.Configure(_currentLevelSettings.playerLives);
            }
            SpawnEnemiesInLevel();
        }
        private void Restartevel(int value)
        {
            _isRestartLevel = true;
            ResetAllSystems();
            _countdownUIController.StartCountdown();
        }
        private void PassToNextLevel()
        {
            if (_currentLevelIndex + 1 == _levelsToWin)
            {
                _victoryPanelEnabler.EnablePanel();
                return;
            }
            if (_currentLevelIndex > _levelConfigurationSO.levelSettings.Count)
            {
                Debug.Log("All levels completed!");
            }
            else
            {
                _isRestartLevel = false;
                ResetAllSystems();
                _currentLevelIndex++;
                _playerSpawner.PlayerSpawned.LifeManager.IncreaseLife();
                LoadCurrentLevel();
            }
        }
        private void SpawnPlayerInLevel()
        {
            if (_playerSpawner is null)
            {
                Debug.LogError("Player Spawner is not assigned in GameplayFlowController");
                return;
            }
            var currentInputType = _currentLevelSettings.inputType;
            var input = _inputFactory.GetInputStrategyByType(currentInputType);
            
            _playerSpawner.SpawnPlayer(_levelConfigurationSO.levelSettings[_currentLevelIndex].defaultPlayerInLevel);
            _playerSpawner.PlayerSpawned.PlayerMovementController.Configure(input);
            _playerSpawner.PlayerSpawned.PlayerBulletShooter.Configure(input);
            _playerSpawner.PlayerSpawned.LifeManager.Configure(_currentLevelSettings.playerLives);
            _playerSpawner.PlayerSpawned.LifeManager.OnLivesChanged += _playerLifeUIDrawer.DrawLives;
            _playerSpawner.PlayerSpawned.LifeManager.OnLivesChanged += Restartevel;
            _playerSpawner.PlayerSpawned.LifeManager.OnObjectDestroyed += _gameOverPanelEnabler.EnablePanel;
            _playerSpawner.PlayerSpawned.DamageController.OnPlayerCollidedWithEnemy += _gameOverPanelEnabler.EnablePanel;

        }
        private void SpawnEnemiesInLevel()
        {
            if(_playerSpawner is null)
            {
                Debug.LogError("Enemy Spawner is not assigned in GameplayFlowController");
                return;
            }
            _enemySpawner.Configure(_currentLevelSettings.enemyColumns, _currentLevelSettings.enemyRowsData, _currentLevelSettings.enemiesLives, _currentLevelSettings.enemyFireRateCooldown, _scoreSetter);
            _enemySpawner.SpawnEnemies();
            _enemyMovementController.Configure(_currentLevelSettings.enemyMoveSpeedCooldown);
            _enemyMovementController.MoveEnemies();
        }
        private void ResetAllSystems()
        {
            _playerSpawner.ResetPosition();
            _enemySpawner.Reset();
            _countdownUIController.ResetCountdown();
            _enemyMovementController.Reset();
        }
        private void OnDestroy()
        {
            if (_playerSpawner.PlayerSpawned != null)
            {
                _playerSpawner.PlayerSpawned.LifeManager.OnLivesChanged -= _playerLifeUIDrawer.DrawLives;
                _playerSpawner.PlayerSpawned.LifeManager.OnLivesChanged -= Restartevel;
                _playerSpawner.PlayerSpawned.LifeManager.OnObjectDestroyed -= _gameOverPanelEnabler.EnablePanel;
                _playerSpawner.PlayerSpawned.DamageController.OnPlayerCollidedWithEnemy -= _gameOverPanelEnabler.EnablePanel;
            }
            _enemySpawner.OnDefeatedAllEnemies -= PassToNextLevel;
            _countdownUIController.OnCountdownFinished -= LoadCurrentLevel;
        }
    }
}
