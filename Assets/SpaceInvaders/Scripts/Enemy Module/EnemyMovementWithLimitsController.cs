using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceInvaders
{
    /// <summary>
    /// Esta clase si es creada con la ayuda de la AI, y es la versión que funciona correctamente.
    /// </summary>
    public class EnemyMovementWithLimitsController : MonoBehaviour, IEnemyMovementController
    {
        [Header("Enemy Movement Settings")]
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _moveCooldown = 0.5f;
        [SerializeField] private float _dropDistance = 0.5f;
        [SerializeField] private float _leftBound = -8f;
        [SerializeField] private float _rightBound = 8f;

        [Header("References")]
        [SerializeField] private Transform _enemiesParent;
        [SerializeField] private Transform _initPosition;

        private bool _isMovingRight = true;

        public void Configure(float moveCooldown)
        {
            _moveCooldown = moveCooldown;
        }

        public void MoveEnemies()
        {
            StopAllCoroutines(); // Detener cualquier corrutina anterior
            StartCoroutine(MoveEnemiesCO());
        }

        private IEnumerator MoveEnemiesCO()
        {
            while (true)
            {
                yield return new WaitForSeconds(_moveCooldown);

                // 1. Obtener todos los enemigos (excluyendo el padre)
                var enemies = _enemiesParent.GetComponentsInChildren<Transform>()
                    .Where(t => t != _enemiesParent && t.gameObject.activeInHierarchy)
                    .ToList();

                // Si no quedan enemigos, salimos del bucle
                if (enemies.Count == 0) yield break;

                // 2. Encontrar los enemigos en los extremos
                float minX = enemies.Min(t => t.position.x);
                float maxX = enemies.Max(t => t.position.x);

                // 3. Comprobar los límites y cambiar de dirección si es necesario
                bool shouldMoveDown = false;
                if (_isMovingRight && maxX >= _rightBound)
                {
                    _isMovingRight = false;
                    shouldMoveDown = true;
                }
                else if (!_isMovingRight && minX <= _leftBound)
                {
                    _isMovingRight = true;
                    shouldMoveDown = true;
                }

                // 4. Mover el grupo de enemigos
                if (shouldMoveDown)
                {
                    _enemiesParent.position += Vector3.down * _dropDistance;
                }
                else
                {
                    Vector3 moveDirection = _isMovingRight ? Vector3.right : Vector3.left;
                    _enemiesParent.position += moveDirection * _moveSpeed;
                }
            }
        }

        public void Reset()
        {
            StopAllCoroutines();
            _enemiesParent.position = _initPosition.position;
        }
    }
}

