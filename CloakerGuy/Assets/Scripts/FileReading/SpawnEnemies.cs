using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

namespace HSS
{
    public class SpawnEnemies : MonoBehaviour
    {
        int numOfEnemiesToSpawn;
        public EnemySpawnPoints SP;
        public GameObject prefab;
        public GameObject[] enemyList;
        public Transform parent;
        private void Start()
        {
           numOfEnemiesToSpawn =  ReadFile();

            for (int i = 0; i < numOfEnemiesToSpawn; i++)
            {
                enemyList[i] = Instantiate(prefab, parent);
                enemyList[i].gameObject.transform.position = SP.spawnPoints[i];
            }
        }

        int ReadFile()
        {
            string filepath = Application.dataPath + "/StreamingAssets";

            FileStream fs = File.OpenRead(filepath + "/EnemyAmount.txt");
            StreamReader sr = new StreamReader(fs);
            string texto = sr.ReadLine();
            sr.Close();
            fs.Close();

            int num = Int32.Parse(texto);
   
            return num;
        }
    }
}
