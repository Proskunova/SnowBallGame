using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CheckHealth : MonoBehaviour
    {
        public int Heart => _health;

        [Header("Links")]
        [SerializeField] private Text _textHealth;
        [SerializeField] private GameObject _obj;

        [Header("Data")]
        [SerializeField] private int _health = 3;


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
    }
}
