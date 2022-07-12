using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HSS
{
    public class EndScreenBehaviour : MonoBehaviour
    {
        [SerializeField] Texture2D winScreen;
        [SerializeField] Texture2D loseScreen;

        private Texture2D shownImage;
        public GameObject imageDisplay;
        void Awake()
        {
            if (GameManager.current.WINCON)
            {
                shownImage = winScreen;
            }
            else {
                shownImage = loseScreen;
            }
        }

    }

}
