using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    bool pauseState = false;
    public GameObject canvasObj;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GeneralPauseCall();
        }

    }

    public void GeneralPauseCall() {
        PauseToggle();
        PauseTime();
    }
     void PauseTime() {
        if (!pauseState)
        {
            Time.timeScale = 0f;
            pauseState = true;
        }
        else {
            Time.timeScale = 1f;
            pauseState = false;
        }
    }

     void PauseToggle()
    {
        if (!pauseState)
        {
            canvasObj.SetActive(true);
        }
        else
        {
            canvasObj.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Debug.Log("Resetting timecale");
        Time.timeScale = 1f;
    }


}
