using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] float _power;
        [SerializeField] Transform _spawnPointF;
        [SerializeField] Pool _poolFareBall;


        public void Init(float newPower, Pool pool)
        {
            _poolFareBall = pool;
            _power = newPower;
        }

        public void AttackEnemy()
        {
            GameObject fareBall = _poolFareBall.GetSnowBall();
            if (fareBall == null) return;
            fareBall.transform.position = _spawnPointF.position;
            fareBall.SetActive(true);
        }
    }
}