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
            pauseToggle();
            pauseTime();
        }

    }

    public void pauseTime() {
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

    public void pauseToggle()
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


}
