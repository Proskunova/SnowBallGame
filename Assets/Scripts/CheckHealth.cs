using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CheckHealth : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Text _textHealth;
        [SerializeField] private GameObject _obj;

        [Header("Data")]
        [SerializeField] private int _health = 3;

        [Header("DEBUG")]
        public int Heart;

        private void Start()
        {
            UpdateText();
        }

        private void OnEnable()
        {
            PlayerHit.OnHit += HealthContoller;
        }

        private void OnDisable()
        {
            PlayerHit.OnHit -= HealthContoller;

        }

        private void HealthContoller()
        {
            _health--;

            SetHealth();
            if (_health == 0)
            {
                _obj.SetActive(!_obj.activeInHierarchy);
                Time.timeScale = 0f;
            }

            UpdateText();
        }

        private void UpdateText()
        {
            _textHealth.text = _health.ToString();
        }

        private void SetHealth()
        {
            Heart = _health;
            Debug.Log(Heart);
        }
    }
}
