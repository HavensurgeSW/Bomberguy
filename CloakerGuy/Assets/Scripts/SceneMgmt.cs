using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSS
{
    public class SceneMgmt : MonoBehaviour
    {

        public static Action OnPlayPressed;
        public static void ChangeToWinScreen() {
            SceneManager.LoadScene(3);
        }
        public static void ChangeToLoseScreen() {
            SceneManager.LoadScene(2);
            
        }
        public void ChangeToGame()
        {
            StartCoroutine(FadeScreen());
        }

        public void ChangeToMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }


        IEnumerator FadeScreen()
        {
            OnPlayPressed?.Invoke();
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(1);
        }
    }
}
