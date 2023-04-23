using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameManagerNetwork : NetworkBehaviour
{

    // Questa è un'istanza singleton del GameManager
    public static GameManagerNetwork Instance { get; private set; }
    bool b = true;
    [SerializeField] private Transform playerPrefab;

    private void Awake()
    {
        Instance = this;
    }
    void Update(){
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameSchoolScene" && b == true){
            if(NetworkManager.Singleton.IsServer){
                GameObject.Find("Camera").SetActive(true);
                NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
            }else{
                NetworkManager.Singleton.LocalClient.PlayerObject.Spawn();
            }
            b = false;
        }
    }
    private void SceneManager_OnLoadEventCompleted(string sceneName, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut){
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            Transform playerTransform = Instantiate(playerPrefab);
            playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
        }
    }
}
