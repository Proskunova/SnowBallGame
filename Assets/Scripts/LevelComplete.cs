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
        [SerializeField] private Image[] _arrStars;

        private void Awake()
        {
            for (int i = 0; i < _arrStars.Length; i++)
            {
                 _arrStars[i].DOFade(0.3f, 0);
            }
        }

        public void Win()
        {
            Time.timeScale = 0f;
            _panelWin.SetActive(true);
            StarsWin();
        }

        private void StarsWin()
        {
            for (int i = 0; i < _arrStars.Length; i++)
            {
                if (i < _checkHealth.Heart) _arrStars[i].DOFade(1, 3).SetUpdate(true);
            }
        }
    }
}