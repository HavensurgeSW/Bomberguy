using UnityEngine;

namespace HSS{
public class Destructible : MonoBehaviour
{
    public float destructionTime = 1f;
    public GameObject[] spawnableItems;
    private AudioSource sfxOutput;

        private void Awake()
        {
            sfxOutput = GetComponent<AudioSource>();
        }
        private void Start(){
            sfxOutput.Play();
            Destroy(gameObject, destructionTime);
        }

}
}
