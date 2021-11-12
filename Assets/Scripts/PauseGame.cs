using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PauseGame : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject _pausePanel;

        public static bool IsPaused = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            //_obj.SetActive(!_obj.activeInHierarchy);
            //Pause();
            if (IsPaused)
            {
                Back();
            }
            else
            {
                Pause();
            }
        }
         
        private void Pause()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        private void Back()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
    }
}
