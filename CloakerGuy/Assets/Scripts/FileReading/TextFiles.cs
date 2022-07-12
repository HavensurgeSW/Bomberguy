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
            filepath = Application.dataPath + "/StreamingAssets/EnemyAmount.txt";
            if (!System.IO.File.Exists(filepath))
            {
                FileStream fs = File.OpenWrite(filepath);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(6);
                sw.Close();
                fs.Close();  
            }
        }
    }
}
