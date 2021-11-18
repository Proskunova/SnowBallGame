using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Game
{
    public class PauseGame : MonoBehaviour, IPointerClickHandler
    {
        [Header("Links")]
        [SerializeField] private RectTransform _rect;

        [Header("Data")]
        [SerializeField] private Vector2 _showPosition;
        [SerializeField] private Vector2 _hidePosition;
        [SerializeField] private float _showTime;
        [SerializeField] private float _hideTime;
        [SerializeField] private Ease _show;

        public static bool IsPaused = false;

        private void Awake()
        {
            MoveRect(_hidePosition, 0);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsPaused)
            {
                Back();
            }
            else
            {
                Pause();
            }
        }

        public void MoveRect(Vector2 endPos, float time, Ease ease = Ease.Linear)
        {
            _rect.DOAnchorPos(endPos, time).SetEase(ease).SetUpdate(true);
        }

        public void Pause()
        {
            MoveRect(_showPosition, _showTime, _show);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        private void Back()
        {
            MoveRect(_hidePosition, _hideTime);
            Time.timeScale = 1f;
            IsPaused = false;
        }

        private void OnDestroy()
        {
            _rect.DOKill();
        }
    }
}
