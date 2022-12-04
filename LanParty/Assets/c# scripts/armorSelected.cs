using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorSelected : MonoBehaviour
{
    public ArmorsManager id;

    public void select(){
        GameObject.Find("GameManager").GetComponent<GameManager>().armorSelected = id;
        for (int i = 0; i < GameObject.Find("GameManager").GetComponent<GameManager>().nomiAnimazioniArmature.Length; i++)
        {
            GameObject.Find("Player").GetComponent<Animator>().SetBool(GameObject.Find("GameManager").GetComponent<GameManager>().nomiAnimazioniArmature[i], false);
        }
        
        if(id.name == "Armatura di Solair"){
            //GameObject.Find("GameManager").GetComponent<GameManager>().armature.Length
            GameObject.Find("Player").GetComponent<Animator>().SetBool("solair", true);
        }else{
            GameObject.Find("Player").GetComponent<Animator>().SetBool("godfrey", true);
        }
    }
}
