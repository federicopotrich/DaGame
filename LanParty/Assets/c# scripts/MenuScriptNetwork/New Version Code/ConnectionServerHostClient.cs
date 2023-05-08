using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using System.Collections.Generic;
using System.Collections;

public class ConnectionServerHostClient : NetworkBehaviour
{
    [SerializeField] private Button startHostButton, startClientButton, continueButton;
    void Awake(){
        startHostButton.onClick.AddListener(()=>{
            GameManagerNet.Instance.startHost();
            continueButton.gameObject.SetActive(true);
            continueButton.onClick.AddListener(()=>{
                NetworkManager.Singleton.SceneManager.LoadScene("PlayerInfoNet", UnityEngine.SceneManagement.LoadSceneMode.Single);
            });
        });

        startClientButton.onClick.AddListener(()=>{
            startHostButton.interactable = startClientButton.interactable = false;
            GameManagerNet.Instance.startClient();
        });
    }
    
}