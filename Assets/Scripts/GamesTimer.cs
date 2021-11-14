using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{
    public class GamesTimer : MonoBehaviour
    {
        [SerializeField] private Text _textTime;

        private string _stringSeconds;
        private string _stringMinute;
        private float _gameSeconds;
        private float _gameMinute;
        private float _secondsAmount = 60f;
        private float _minuteAmount = 60f;

        void Update()
        {
            _gameSeconds = _gameSeconds + Time.deltaTime;
            _stringSeconds = _gameSeconds.ToString();
            //_stringMinute = _stringMinute.ToString();

            _textTime.text = "time -"+ _stringMinute + ":" + _stringSeconds;

            if(_gameSeconds >= _secondsAmount)
            {
                _stringMinute = _stringMinute + 1.0f;
                _gameSeconds = 0;
            }

            if(_gameMinute >= _minuteAmount) _gameMinute = 0;
        }
    }
}
