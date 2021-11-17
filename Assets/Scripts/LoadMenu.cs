using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class LoadMenu : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] Button _tryAgain;

        public void TryAgain()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}