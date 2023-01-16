using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squalifica : MonoBehaviour
{
    
    void Start()
    {
        
        string foo = PlayerPrefs.GetInt("foo")==1?true:false;

        this.gameObject.SetActive(!foo);
    }
}
