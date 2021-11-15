using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CheckHealth : MonoBehaviour
    {
        [SerializeField] private Text _textHealth;
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
            if(_health == 0)
            {

            }

            UpdateText();
        }

        private void UpdateText()
        {
            _textHealth.text = _health.ToString();
        }
    }
}
