using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PoolSnowBall : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _poolSnowBalls;
        [SerializeField] private GameObject _snowBall;
        [SerializeField] private int _poolAmound;

        private void Awake()
        {
            _poolSnowBalls = new List<GameObject>();

            for (int i = 0; i < _poolAmound; i++)
            {
                GameObject gO = Instantiate(_snowBall, transform);
                gO.SetActive(false);
                _poolSnowBalls.Add(gO);
            }
        }

        public GameObject GetSnowBall()
        {
            foreach (var item in _poolSnowBalls)
            {
                if (item.activeSelf == false) return item;

            }
            return null;
        }
    }
}

