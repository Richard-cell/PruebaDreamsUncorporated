using System.Collections;
using UnityEngine;

namespace SpaceInvaders
{
    /// <summary>
    /// This class is resposnible for moving enemies in a grid-like pattern.
    /// Version creada por mi, pero no funciona correctamente ya que independientemente de la cantidad de enemigos, se mueve siempre el mismo número de pasos.
    /// </summary>
    public class EnemyMovementController : MonoBehaviour, IEnemyMovementController
    {
        [Header("Enemy Movement Settings")]
        [SerializeField] private Transform _initPosition;
        [SerializeField] private int _stepCount = 6;

        [Header("References")]
        [SerializeField] private Transform _enemiesParent;

        private bool _isMoveDown = false;
        private bool _isMoveLeft = false;
        private Vector3 _moveDirection = Vector2.right;
        private int _movementCounter = 0;
        private float _moveCooldown = 0.5f;
        public void Configure(float moveCooldown)
        {
            _moveCooldown = moveCooldown;
        }
        public void MoveEnemies()
        {
            StartCoroutine(MoveEnemiesCO());
        }
        private IEnumerator MoveEnemiesCO()
        {
            _enemiesParent.position = _initPosition.position;
            yield return new WaitForSeconds(1f);
            while (true)
            {
                if (_movementCounter == _stepCount)
                {
                    _isMoveDown = true;
                    SetNewPosition();
                    _enemiesParent.position += _moveDirection;
                    _isMoveDown = false;
                    _movementCounter = 0;
                    _isMoveLeft = !_isMoveLeft;
                    SetNewPosition();
                }
                else
                {
                    _enemiesParent.position += _moveDirection;
                    _movementCounter++;
                }

                yield return new WaitForSeconds(_moveCooldown);
            }
        }
        private void SetNewPosition()
        {
            if (_isMoveDown)
            {
                _moveDirection = Vector2.down;
            }
            else
            {
                if (_isMoveLeft)
                {
                    _moveDirection = Vector2.left;
                }
                else
                {
                    _moveDirection = Vector2.right;
                }
            }
        }
        public void Reset()
        {
            StopAllCoroutines();
            _enemiesParent.position = _initPosition.position;
            _isMoveDown = false;
            _isMoveLeft = false;
            _moveDirection = Vector2.right;
            _movementCounter = 0;
        }
    }
}

