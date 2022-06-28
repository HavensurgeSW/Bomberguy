using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HSS{

public class EnemyBehaviour : MonoBehaviour
{

    public static Action OnEnemyKilled;
    public static Action OnEnemySpawned;

    private void Start()
    {
        OnEnemySpawned?.Invoke();
        
    }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
            {
                Debug.Log("Wachoin");
                OnEnemyKilled?.Invoke();
            }
        }

}
}
