using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSS{

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    [SerializeField]private int totalEnemies = 0;
    private bool winCon = false;

    private void Awake(){
        current = this;
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
            StartCoroutine(nameof(WinWait));
            SceneMgmt.ChangeToWinScreen();
        }
    }

    private void LoseGame() {

        StartCoroutine(nameof(WinWait));
        SceneMgmt.ChangeToLoseScreen();

    }

     IEnumerator WinWait() {
        yield return new WaitForSeconds(5);
     }
}
}
