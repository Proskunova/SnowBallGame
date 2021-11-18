using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    public class LevelComplete : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private GameObject _panelWin;
        [SerializeField] CheckHealth _checkHealth;
        [SerializeField] private Image _stars1;
        [SerializeField] private Image _stars2;
        [SerializeField] private Image _stars3;

        public void Win()
        {
            StarsWin();
            _panelWin.SetActive(true);
            Time.timeScale = 0f;
        }

        private void StarsWin()
        {
            if(_checkHealth.Heart== 2)
            {
                _stars1.DOFade(255, 1);
                _stars2.DOFade(255, 1);
            }
            else if(_checkHealth.Heart == 3)
            {
                _stars1.DOFade(255, 1);
                _stars2.DOFade(255, 1);
                _stars3.DOFade(255, 1);
            }
            _stars1.DOFade(255, 1);
        }
    }
}