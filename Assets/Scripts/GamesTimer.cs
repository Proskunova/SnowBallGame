using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{
    public class GamesTimer : MonoBehaviour
    {
        [SerializeField] private Text _textTime;

        private float _gameSeconds = 0;
        private float _gameMinute = 0;
        private float _sixty = 60f;

       
        void Update()
        {
            _gameSeconds += Time.deltaTime;
            
            _textTime.text = "time "+ _gameMinute.ToString("00") + ":" + Mathf.Floor(_gameSeconds).ToString("00");

            if(_gameSeconds >= _sixty)
            {
                _gameMinute += 1.0f;
                _gameSeconds = 0;
            }
        }
    }
}
