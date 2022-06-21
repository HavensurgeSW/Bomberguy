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

    //void OnCollisionEnter(Collision other){
    //    if (other.gameObject.CompareTag("Explosion"))
    //    {
    //       OnEnemyKilled?.Invoke();      
    //    }
    //}

    private void OnDisable()
    {
        OnEnemyKilled?.Invoke();
    }
}
}
