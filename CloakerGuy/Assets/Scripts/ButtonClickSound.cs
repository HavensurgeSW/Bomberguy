using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource output;
    public void PlayButtonClick()
    {
        output.Play();
    }
}
