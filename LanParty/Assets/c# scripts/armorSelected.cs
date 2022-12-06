using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorSelected : MonoBehaviour
{
    //creo una variabile per l'ID dell'armatura
    public ArmorsManager id;

    public void select(){
        //assegnazione al gamemanager dell'armor selected
        GameObject.Find("GameManager").GetComponent<GameManager>().armorSelected = id;

        //Tolgo tutte le armature al personaggio
        for (int i = 0; i < GameObject.Find("GameManager").GetComponent<GameManager>().nomiAnimazioniArmature.Length; i++)
        {
            GameObject.Find("Player").GetComponent<Animator>().SetBool(GameObject.Find("GameManager").GetComponent<GameManager>().nomiAnimazioniArmature[i], false);
        }
        
        //Cerco l'armatura con l'ID selezionato e la equipaggio
        /*if(id.name == "Armatura di Solair"){
            //GameObject.Find("GameManager").GetComponent<GameManager>().armature.Length
            GameObject.Find("Player").GetComponent<Animator>().SetBool("solair", true);
        }else if (){
            GameObject.Find("Player").GetComponent<Animator>().SetBool("godfrey", true);
        }*/

        //Cerco l'armatura con l'ID selezionato e la equipaggio
        switch(id.name){
            case "Armatura di Solair": 
                GameObject.Find("Player").GetComponent<Animator>().SetBool("solair", true); 
                break;
            case "Godfrey":
                GameObject.Find("Player").GetComponent<Animator>().SetBool("godfrey", true);
                break;
            case "Jotaro":
                GameObject.Find("Player").GetComponent<Animator>().SetBool("jotaro", true);
                break;
            case "Camicia":
                GameObject.Find("Player").GetComponent<Animator>().SetBool("camicia", true);
                break;
            case "Knight":
                GameObject.Find("Player").GetComponent<Animator>().SetBool("knight", true);
                break;
            default:
                GameObject.Find("Player").GetComponent<Animator>().SetBool("jotaro", true);
            break;

        }

    }
}
