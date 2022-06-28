using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundPlayer : MonoBehaviour
{
    public AudioSource output;
    public void PlayAssignedSound()
    {
        output.Play();
    }
}
