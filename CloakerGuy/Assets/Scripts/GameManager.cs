using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSS{

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    [SerializeField]private int totalEnemies = 0;

    private void Awake(){
        current = this;
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnEnable(){
        EnemyBehaviour.OnEnemyKilled+=AddEnemyCount;
    }

    void OnDisable()
    {
        EnemyBehaviour.OnEnemyKilled-=DiminishEnemyCount;
    }

    private void AddEnemyCount(){
        totalEnemies++;
    }

    private void DiminishEnemyCount(){
        totalEnemies--;
    }
}
}
