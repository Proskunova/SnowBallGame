using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyPoolManager : MonoBehaviour
    {
        [SerializeField] private List<Settings> _listSettings;
        [SerializeField] private List<Enemy> _pool;
        [SerializeField] private Enemy _pooledEnemy;
        [SerializeField] private int _pooledAmount;
        [SerializeField] Pool _poolFireBalls;

        private void Awake()
        {
            _pool = new List<Enemy>();

            for (int i = 0; i < _pooledAmount; i++)
            {
                Enemy enemyTemp = Instantiate(_pooledEnemy, transform);
                enemyTemp.gameObject.SetActive(false);
                InitEnemy(enemyTemp);

                _pool.Add(enemyTemp);
            }
        }

        public Enemy GetEnemy()
        {
            foreach (var item in _pool)
            {
                if (item.gameObject.activeSelf == false) return item;
            }
            return null;
        }

        private void InitEnemy(Enemy enemyTemp)
        {
            int randomIndex = Random.Range(0, _listSettings.Count);
            Settings random = _listSettings[randomIndex];
            enemyTemp.name = random.Skin;

            enemyTemp.SetSettings(random);
        }
    }
}
