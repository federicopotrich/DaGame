using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerReadyComponent : MonoBehaviour
{
    public static PlayerReadyComponent Instance { get; private set; }
    public Dictionary<ulong, bool> playerReadyDictionary;
    void Awake()
    {
        Instance = this;
        playerReadyDictionary = new Dictionary<ulong, bool>();
    }
    public void SetPlayerReady(){
        SetPlayerReadyServer();
    }
    [ServerRpc(RequireOwnership=false)]
    private void SetPlayerReadyServer(ServerRpcParams serverRpcParams = default){
        playerReadyDictionary[serverRpcParams.Receive.SenderClientId] = true;

        bool allClientReady = true;

        foreach (ulong clientID in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if(!playerReadyDictionary.ContainsKey(clientID) || !playerReadyDictionary[clientID]){
                allClientReady = false;
                break;
            }
        }
        if (allClientReady)
        {
            Loader.LoadNetwork(Loader.Scene.GameSchoolScene);
        }
    }
}
