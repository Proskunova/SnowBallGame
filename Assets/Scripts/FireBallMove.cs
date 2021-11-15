using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FireBallMove : MonoBehaviour
    {
        [SerializeField] private float _speedFB = 10f;

        private void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speedFB);
        }

    }
}
