using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorSelected : MonoBehaviour
{
    public ArmorsManager id;

    public void select(){
        GameObject.Find("GameManager").GetComponent<GameManager>().armorSelected = id;
    }
}
