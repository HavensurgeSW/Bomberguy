using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour
{
    public void ChangeToGame() {
        SceneManager.LoadScene(1);
    }
    public void ChangeToSettings() {
    }
    public void ChangeToCredits() {

    }

    public void ChangeToMenu() {
        SceneManager.LoadScene(0);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
