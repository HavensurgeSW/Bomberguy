using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HSS
{
    public class EndScreenBehaviour : MonoBehaviour
    {
        [SerializeField] GameObject winScreen;
        [SerializeField] GameObject loseScreen;

        void Awake()
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(false);

            if (GameManager.current.WINCON)
            {
                winScreen.SetActive(true);
            }
            else {
                loseScreen.SetActive(true);
            }

            
        }

    }

}
