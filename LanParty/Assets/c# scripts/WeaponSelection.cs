using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public WeponsManager id;

    public void select(){
        GameObject.Find("GameManager").GetComponent<GameManager>().weaponSelected = id;
    }
}
