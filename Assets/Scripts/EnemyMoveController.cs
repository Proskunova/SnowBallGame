using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyMoveController : MonoBehaviour
    {
        public event System.Action OnEndMove;

        [SerializeField] private RandomPointBox _bounds;
        [SerializeField] EnemyAttack _enemyAttack;

        [SerializeField] float _speed;

        public void Init(float speed, RandomPointBox box)
        {
            _speed = speed;
            _bounds = box;
        }

        public void EnemyMove(Vector3 positionOut)
        {
            MoveToPoint(positionOut);
        }

        public void EnemyMove()
        {
            Vector2 randomPoint = _bounds.GetRandomPoint();

            MoveToPoint(randomPoint);
        }

        private void MoveToPoint(Vector3 point)
        {
            transform.DOKill();

            float distance = Vector2.Distance(point, transform.position);
            float time = distance / _speed;
            transform.rotation = Enemy.CheckRotation(point, transform);

            transform.DOMove(point, time).SetEase(Ease.Linear).OnComplete(delegate
            {
                OnEndMove?.Invoke();
            });
        }
    }
}
