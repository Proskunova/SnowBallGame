using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Scoring : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Text _textScore;
        [SerializeField] LevelComplete _levelComplete;

        [Header("Data")]
        [SerializeField] private int _scoreWin;

        [Header("DEBUG")]
        [SerializeField] private int _score;

        private void Start()
        {
            _score = 0;
            UpdateText();
        }

        private void OnEnable()
        {
            Enemy.OnScore += ScoreCount;
        }

        private void OnDisable()
        {
            Enemy.OnScore -= ScoreCount;
        }

        private void ScoreCount( int points)
        {
            _score += points;
            UpdateText();

            if (_score >= _scoreWin) _levelComplete.Win();

            Debug.Log(_score);
        }

        private void UpdateText()
        {
            _textScore.text = _score.ToString();
        }
    }
}
