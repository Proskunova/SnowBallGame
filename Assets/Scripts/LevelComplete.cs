using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelComplete : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private GameObject _panelWin;
        [SerializeField] CheckHealth _checkHealth;

        private void Start()
        {
            //Win();
        }

        public void Win()
        {
            Time.timeScale = 0f;
            _panelWin.SetActive(true);

            //int b = _checkHealth.Heart;
            Debug.Log(" _checkHealth.Heart=" + _checkHealth.Heart);

           /* if ((_checkHealth.Heart) == 1)*/ PlayerPrefs.SetInt("stars", (_checkHealth.Heart));
            //if ((_checkHealth.Heart) == 2) PlayerPrefs.SetInt("stars", (_checkHealth.Heart));
            //if ((_checkHealth.Heart) == 3) PlayerPrefs.SetInt("stars", (_checkHealth.Heart));

            Debug.Log("stars="+PlayerPrefs.GetInt("stars"));
        }

        private void StarsWin()
        {

        }

    }
}