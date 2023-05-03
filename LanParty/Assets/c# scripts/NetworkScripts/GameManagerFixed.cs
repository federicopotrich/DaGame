using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameManagerFixed : NetworkBehaviour
{

    // Questa è un'istanza singleton del GameManager
    public static GameManagerFixed Instance { get; private set; }
    bool b = true;
    [SerializeField] private Transform playerPrefab;

    private void Awake()
    {
        Instance = this;
    }
    void Update(){
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameSchoolScene" && b == true){
            if(NetworkManager.Singleton.IsServer){
                //GameObject.Find("Camera").SetActive(true);
                NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
            }
            b = false;
        }
    }
    private void SceneManager_OnLoadEventCompleted(string sceneName, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut){
        int ctr = 0;
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if(NetworkManager.IsClient){
                Transform playerTransform = Instantiate(playerPrefab);
                Camera playerCamera = playerTransform.GetComponentInChildren<Camera>();
                playerCamera.gameObject.name = "Camera: " + NetworkManager.Singleton.LocalClientId;

                // Imposta la camera del player come camera principale della scena
                playerCamera.tag = "MainCamera";
                playerCamera.enabled = true;
                playerCamera.targetDisplay = (int)NetworkManager.Singleton.LocalClientId;
                playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
                ctr++;
            }
        }
    }
}
