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
        
        public static void ChangeToLoseScreen() {
            SceneManager.LoadScene(2);
            
        }
        public void ChangeToGame()
        {

            Debug.Log("Clicked Play");
            StartCoroutine(FadeScreen());
        }

        public void ChangeToMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }


        IEnumerator FadeScreen()
        {
            OnPlayPressed?.Invoke();
            yield return new WaitForSecondsRealtime(2);
            SceneManager.LoadScene(1);
        }
    }
}
