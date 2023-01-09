using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonData : MonoBehaviour
{
    public TextAsset textJson;

    [System.Serializable]
    public class data{
        public int id;
        public string immagine;
        public string anno;
        public string nome;
    }

    [System.Serializable]
    public class storiaDataArray{
        public data [] dataArr;
    }
    public storiaDataArray myList =  new storiaDataArray();
    void Start()
    {
        myList = JsonUtility.FromJson<storiaDataArray>(textJson.text);
    }
    void Update(){
        
    }

}
