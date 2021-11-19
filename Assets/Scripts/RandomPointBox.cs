using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RandomPointBox : MonoBehaviour
    {
        public Vector2 GetBoundMax => boundMax;
        public Vector2 GetBoundMin => boundMin;

        [Header("Data")]
        [SerializeField] private Vector2 boundMin;
        [SerializeField] private Vector2 boundMax;
        [SerializeField] private Color _color;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;

            var point1 = new Vector3(boundMin.x, boundMax.y);
            var point2 = new Vector3(boundMax.x, boundMin.y);

            Gizmos.DrawLine(boundMin, point1);
            Gizmos.DrawLine(point1, boundMax);
            Gizmos.DrawLine(boundMax, point2);
            Gizmos.DrawLine(point2, boundMin);
        }

        public Vector2 GetRandomPoint()
        {
            float randomX = Random.Range(boundMin.x, boundMax.x);
            float randomY = Random.Range(boundMin.y, boundMax.y);

            return new Vector2(randomX, randomY);
        }
    }
}
