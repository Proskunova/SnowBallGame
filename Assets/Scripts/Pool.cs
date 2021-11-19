using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _poolBalls;

        [Header("Links")]
        [SerializeField] private GameObject _ball;

        [Header("Data")]
        [SerializeField] private int _poolAmound;

        private void Awake()
        {
            _poolBalls = new List<GameObject>();

            for (int i = 0; i < _poolAmound; i++)
            {
                GameObject gO = Instantiate(_ball, transform);
                gO.SetActive(false);
                _poolBalls.Add(gO);
            }
        }

        public GameObject GetSnowBall()
        {
            foreach (var item in _poolBalls)
            {
                if (item.activeSelf == false) return item;

            }
            return null;
        }
    }
}

