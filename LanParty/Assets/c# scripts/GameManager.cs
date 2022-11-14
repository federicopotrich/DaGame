using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WeponsManager arco;
    void Start()
    {
        Debug.Log(arco.dmg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
