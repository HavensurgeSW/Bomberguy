using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSS{

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    public static GameManager current;
    public static Action<EnemyBehaviour> OnEnemyKilled;

    private void Awake(){
        current = this;
    }

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf) {
                aliveCount++;
            }
        }
 
        if (aliveCount <= 1) {
            Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnEnable(){
        OnEnemyKilled+=DiminishEnemyCount;

    }

    void OnDisable()
    {
        OnEnemyKilled-=DiminishEnemyCount;
    }

    private void AddEnemyCount(){


    }

    private void DiminishEnemyCount(){


    }


}
}
