using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBehaviour : MonoBehaviour
{
    [SerializeField]private Toggle tog;
    void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            if (PlayerPrefs.GetFloat("Volume") == 1.0f)
            {
                tog.SetIsOnWithoutNotify(true);
            }
            else
            {
                tog.SetIsOnWithoutNotify(false);
            }
        }
    }
}
