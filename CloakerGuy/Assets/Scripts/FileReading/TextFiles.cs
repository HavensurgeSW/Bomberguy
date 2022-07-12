using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

namespace HSS
{
    public class TextFiles : MonoBehaviour
    {
        private string filepath;


        // Start is called before the first frame update
        void Start()
        {
            filepath = Application.dataPath + "/StreamingAssets";

            FileStream fs = File.OpenWrite(filepath + "/EnemyAmount.txt");
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(6);
            sw.Close();
            fs.Close();
        }
    }
}
