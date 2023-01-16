using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class jsonData : MonoBehaviour
{
    public string jsonDataString;

    [System.Serializable]
    public class dataClass{
        public quest[] data;
    }
    public class quest{
        public int id;
        public string immagine;
        public string nome;
        public int anno;
    }
    void Start()
    {

        jsonDataString = File.ReadAllText(Application.dataPath + "/json/storia.json");
       
        dataClass d = JsonConvert.DeserializeObject<dataClass>(jsonDataString);
        
    
        foreach (var item in d.data)
        {
            Debug.Log(((quest)item).anno);
        }
        
    }
    void Update(){
        
    }

}
