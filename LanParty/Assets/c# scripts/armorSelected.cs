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
        
        //attivo l'animazione
        GameObject.Find("Player").GetComponent<Animator>().SetBool(id.nomeAnimazione, true);

    }
}