using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerSetting : NetworkBehaviour
{
    public Button btnReady;
    void Awake()
    {
        btnReady.onClick.AddListener(()=>{
            if(GameObject.Find("Text_name").GetComponent<TMPro.TextMeshProUGUI>().text != ""){
                PlayerReadyComponent.Instance.SetPlayerReady();
            }
        });
    }
}
