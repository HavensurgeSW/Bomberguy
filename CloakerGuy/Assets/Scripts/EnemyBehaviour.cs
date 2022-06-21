using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HSS{

public class EnemyBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            GameManager.OnEnemyKilled?.Invoke(this);      
        }
    }
}
}
