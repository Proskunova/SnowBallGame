using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private Text _textScore;
        [SerializeField] Settings _settings;

        private int _score;

        private void Start()
        {
            _score = 0;
            UpdateText();
        }


        private void OnEnable()
        {
            HitCheck.OnHit += ScoreCount;
        }

        private void OnDisable()
        {
            HitCheck.OnHit -= ScoreCount;

        }
        private void ScoreCount( int points)
        {
            points = _settings.Score;
            _score += points;// подписаться на лист врагов и получить от туда Скор.
            UpdateText();

            Debug.Log(_score);
        }

        private void UpdateText()
        {
            _textScore.text = _score.ToString();
        }
    }
}
