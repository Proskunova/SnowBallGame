using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyManager : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] EnemyPoolManager enemyPoolManager;
        [SerializeField] Transform _spawnPoint;
        [SerializeField] private RandomPointBox _bounds;
        [SerializeField] Pool _poolFireBalls;

        [Header("Data")]
        [SerializeField] int countEnemiesOnField = 3;
        [SerializeField] float _timeSpawnCheck = 1f;

        [Header("DEBUG")]
        [SerializeField] int currentActiveEnemies = 0;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());        
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                CheckCount();

                yield return new WaitForSeconds(_timeSpawnCheck);
            }
        }

        private void CheckCount()
        {
            if(currentActiveEnemies < countEnemiesOnField)
            {
                if (TrySpawnEnemy())
                {
                    currentActiveEnemies++;
                }
            }
        }

        private bool TrySpawnEnemy()
        {
            Enemy enemy = enemyPoolManager.GetEnemy();
            if (enemy == null) return false;
            enemy.Init(_bounds, _poolFireBalls, _spawnPoint);
            enemy.transform.position = _spawnPoint.position;
            enemy.OnDead -= Enemy_OnDead;
            enemy.OnDead += Enemy_OnDead;

            enemy.Activate();

            return true;
        }

        private void Enemy_OnDead()
        {
            currentActiveEnemies--;
        }
    }
}