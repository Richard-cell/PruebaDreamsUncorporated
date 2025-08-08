using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// Class responsible for injecting the necessary dependencies into the gameplayFlowController.
    /// </summary>
    public class GameplayInstaller : MonoBehaviour
    {
        [Header("Services")]
        [SerializeField] private InputFactory _inputFactory;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private CountdownUIController _countdownUIController;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyMovementController _enemyMovementController;
        [SerializeField] private EnemyMovementWithLimitsController _enemyMovementWithLimitsController;
        [SerializeField] private PlayerLifeUIDrawer _playerLifeUIDrawer;
        [SerializeField] private GameOverPanelEnabler _gameOverPanelEnabler;
        [SerializeField] private VictoryPanelEnabler _victoryPanelEnabler;
        [SerializeField] private ScoreSetter _scoreSetter;

        [Header("References")]
        [SerializeField] private GameplayFlowController _gameplayFlowController;
        private void Awake()
        {
            _gameplayFlowController.Configure(
                _playerSpawner,
                _inputFactory, 
                _countdownUIController,
                _enemySpawner,
                _enemyMovementWithLimitsController,
                _playerLifeUIDrawer,
                _gameOverPanelEnabler,
                _victoryPanelEnabler,
                _scoreSetter
                );
        }
    }
}
