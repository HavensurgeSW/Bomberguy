using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSS
{
    public class SceneMgmt : MonoBehaviour
    {
        public static void ChangeToWinScreen() {
            SceneManager.LoadScene(3);
        }
        public static void ChangeToLoseScreen() {
            SceneManager.LoadScene(2);
            
        }
        public void ChangeToGame()
        {
            FadeScreen();
            SceneManager.LoadScene(1);

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
            yield return new WaitForSeconds(2);
        }
    }
}
