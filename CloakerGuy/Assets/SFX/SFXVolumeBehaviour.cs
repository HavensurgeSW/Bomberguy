using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("Enabling Audio volume: " + PlayerPrefs.GetFloat("Volume"));
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void ToggleAudio() {
        Debug.Log("Audio has toggled");
        if (AudioListener.volume == 1.0f)
        {
            AudioListener.volume = 0f;
            Debug.Log("TogOFF Audio volume: " + AudioListener.volume);
        }
        else {
            AudioListener.volume = 1.0f;
            Debug.Log("TogON Audio volume: " + AudioListener.volume);
        }
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        Debug.Log("Setting Audio volume: " + PlayerPrefs.GetFloat("Volume"));
    }
}
