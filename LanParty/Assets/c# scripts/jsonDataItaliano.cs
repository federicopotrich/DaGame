using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class jsonDataItaliano : MonoBehaviour
{
    private string jsonDataString;
    public quest [] arrayData;

    [System.Serializable]
    public class dataClass{
        public quest[] data;
    }
    public class quest{
        public string poeta;
        public string emoji;
        public string [] opzioni;
    }
    void Start()
    {

        jsonDataString = File.ReadAllText(Application.dataPath + "/json/italiano.json");
        dataClass d = JsonConvert.DeserializeObject<dataClass>(jsonDataString);
        arrayData = d.data;

        // foreach (var item in arrayData)
        // {
        //     for (int i = 0; i < item.opzioni.Length; i++)
        //     {
        //         Debug.Log(item.opzioni[i]);
        //     }
        // }
        
        
    }
    void Update(){
        
    }

}
