using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    public class YoYoSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _slider.value = _slider.minValue;
            DOTween.To(() => _slider.value, x => _slider.value = x, 1, 3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
