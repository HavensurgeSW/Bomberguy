using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSS
{
    public class SceneMgmt : MonoBehaviour
    {
        public void ChangeToGame()
        {
            SceneManager.LoadScene(1);
        }
        public void ChangeToTutorial()
        {
            SceneManager.LoadScene(3);
        }
        public void ChangeToCredits()
        {
            SceneManager.LoadScene(2);
        }

        public void ChangeToMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();

#if UNITY_EDITOR

#endif
        }
    }
}
