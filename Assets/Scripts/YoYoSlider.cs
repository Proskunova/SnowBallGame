using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    public class YoYoSlider : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Slider _slider;

        [Header("Data")]
        [SerializeField] private float _timeMove;

        private void Start()
        {
            _slider.value = _slider.minValue;
            DOTween.To(() => _slider.value, x => _slider.value = x, 1, _timeMove).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
