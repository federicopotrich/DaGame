using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WeponsManager [] armi;
    public ArmorsManager [] armature;

    public GameObject container;
    public GameObject slotShop;

    public GameObject inventory;

    void Start()
    {
        for (int i = 0; i < armi.Length; i++)
        {
            GameObject gInstantiated = GameObject.Instantiate(slotShop, new Vector3(), Quaternion.identity);
            gInstantiated.transform.Find("");
            gInstantiated.transform.SetParent(container.transform);
            gInstantiated.transform.localScale = new Vector3(1, 1, 1);

            gInstantiated.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = armi[i].imageWeapon;
            gInstantiated.transform.Find("TextNome").GetComponent<TMPro.TextMeshProUGUI>().text = armi[i].nome;
            gInstantiated.transform.Find("TextDmg").GetComponent<TMPro.TextMeshProUGUI>().text = ""+armi[i].dmg;
            gInstantiated.transform.Find("TextCost").GetComponent<TMPro.TextMeshProUGUI>().text = ""+armi[i].cost;
            gInstantiated.transform.Find("TextRarita").GetComponent<TMPro.TextMeshProUGUI>().text = armi[i].rarita;
        }

        for (int i = 0; i < armature.Length; i++)
        {
            GameObject gInstantiated = GameObject.Instantiate(slotShop, new Vector3(), Quaternion.identity);
            gInstantiated.transform.SetParent(container.transform);
            gInstantiated.transform.localScale = new Vector3(1, 1, 1);

            gInstantiated.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = armature[i].imageArmor;
            gInstantiated.transform.Find("TextNome").GetComponent<TMPro.TextMeshProUGUI>().text = armature[i].nome;
            gInstantiated.transform.Find("TextDmg").GetComponent<TMPro.TextMeshProUGUI>().text = ""+armature[i].defence;
            gInstantiated.transform.Find("TextCost").GetComponent<TMPro.TextMeshProUGUI>().text = ""+armature[i].cost;
            gInstantiated.transform.Find("TextRarita").GetComponent<TMPro.TextMeshProUGUI>().text = armature[i].rarita;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I)){
            inventory.SetActive(!inventory.activeSelf);
        }
        if(inventory.activeSelf){
            Time.timeScale=0;
        }else{
            Time.timeScale=1;
        }
    }
}
