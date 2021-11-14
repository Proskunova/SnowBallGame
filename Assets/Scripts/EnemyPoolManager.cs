using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyPoolManager : MonoBehaviour
    {
        [SerializeField] private List<Settings> _listSettings;
        [SerializeField] private List<GameObject> _pool;
        [SerializeField] private GameObject _pooledEnemy;
        [SerializeField] private int _pooledAmount;
        [SerializeField] private RandomPointBox _bounds;
        [SerializeField] Transform _poolEnemy;

        private void Awake()
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < _pooledAmount; i++)
            {
                GameObject enemyTemp = Instantiate(_pooledEnemy, transform);
                enemyTemp.SetActive(false);
                InitEnemy(enemyTemp);

                _pool.Add(enemyTemp);
            }
        }

        private void Start()
        {
            GameObject test = GetEnemy();
            test.transform.position = _poolEnemy.position;
            test.SetActive(true);
            test.GetComponent<EnemyMoveController>().EnemyMove();
        }

        public GameObject GetEnemy()
        {
            foreach (var item in _pool)
            {
                if (item.activeSelf == false) return item;
            }
            return null;
        }

        private void InitEnemy(GameObject enemyTemp)
        {
            int randomIndex = Random.Range(0, _listSettings.Count);
            Settings random = _listSettings[randomIndex];
            enemyTemp.name = random.Skin;
            enemyTemp.GetComponent<EnemyMoveController>().Init(random, _bounds);
            enemyTemp.GetComponent<SkeletonAnimation>().initialSkinName = random.Skin;
            enemyTemp.GetComponent<SkeletonAnimation>().Initialize(true);
        }
    }
}
