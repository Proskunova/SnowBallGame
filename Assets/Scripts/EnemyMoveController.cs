using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class EnemyMoveController : MonoBehaviour
    {
        [SerializeField] private RandomPointBox _bounds;
        [SerializeField] Settings _settings;

        private Vector3 lookRight = Vector3.zero;
        private Vector3 lookLeft = new Vector3(0, 180, 0);

        private void Start()
        {
            EnemyMove();
        }

        public void Init(Settings newSettings, RandomPointBox box)
        {
            _settings = newSettings;
            _bounds = box;
        }

        public void EnemyMove()
        {
            Vector2 randomPoint = _bounds.GetRandomPoint();
            float distance = Vector2.Distance(randomPoint, transform.position);
            float time = distance / _settings._speed;
            CheckRotation(randomPoint);

            transform.DOMove(randomPoint, time).SetEase(Ease.Linear);
        }

        private void CheckRotation(Vector2 randomPoint)
        {
            if(randomPoint.x < transform.position.x && transform.rotation.eulerAngles == lookRight)
            {
                transform.rotation = Quaternion.Euler(lookLeft);
            }
            else if(randomPoint.x > transform.position.x && transform.rotation.eulerAngles == lookLeft)
            {
                transform.rotation = Quaternion.Euler(lookRight);

            }
        }
    }
}
