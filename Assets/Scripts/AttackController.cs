using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class AttackController : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] Settings _settings;
        [SerializeField] Button _buttonAttack;
        [SerializeField] Pool _poolSnowBall;
        [SerializeField] Transform _spawnPoint;
        [SerializeField] Slider _slider;

        private void Awake()
        {
            _buttonAttack.onClick.AddListener(Attack);
        }

        private void Attack()
        {
            float powerY = _slider.value * _settings.Power;
            GameObject snowB = _poolSnowBall.GetSnowBall();
            if (snowB == null) return;
            snowB.transform.position = _spawnPoint.position;
            snowB.SetActive(true);
            snowB.GetComponent<Rigidbody2D>().AddForce(new Vector2(powerY*2, powerY));
            
            Debug.Log("attack");
        }
    }
}