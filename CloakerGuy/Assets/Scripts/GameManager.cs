using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace HSS{

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    [SerializeField]private int totalEnemies = 0;
    private bool winCon = false;

    public bool WINCON { get { return winCon; }}

    private void Awake(){
            if (current != null && current != this)
                Destroy(current.gameObject);
            else
            {
                current = this;
                DontDestroyOnLoad(current);
            }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnEnable(){
        EnemyBehaviour.OnEnemyKilled += DiminishEnemyCount;
        EnemyBehaviour.OnEnemyKilled += CheckWinCondition;
        EnemyBehaviour.OnEnemyKilled += WinGame;
        EnemyBehaviour.OnEnemySpawned += AddEnemyCount;

        MovementController.OnPlayerDeath += LoseGame;
    }

    void OnDisable()
    {
        EnemyBehaviour.OnEnemyKilled -= DiminishEnemyCount;
        EnemyBehaviour.OnEnemyKilled -= CheckWinCondition;
        EnemyBehaviour.OnEnemyKilled -= WinGame;
        EnemyBehaviour.OnEnemySpawned -= AddEnemyCount;

        MovementController.OnPlayerDeath -= LoseGame;
    }

    private void AddEnemyCount(){
        totalEnemies++;
            Debug.Log("Total Enemies: " + totalEnemies);
    }

    private void DiminishEnemyCount(){
        totalEnemies--;
    }

    private void CheckWinCondition() {
            if (totalEnemies <= 0)
                winCon = true;

    }
    private void WinGame() {
        if (winCon == true)
        {
                MovementController.OnPlayerDeath -= LoseGame;
                StartCoroutine(WinWait(SceneMgmt.ChangeToWinScreen));
        }
    }

    private void LoseGame() { 
        StartCoroutine(WinWait(SceneMgmt.ChangeToLoseScreen));
    }

     IEnumerator WinWait(Action callback) {
        yield return new WaitForSeconds(2);
        callback?.Invoke();
     }

}
}
