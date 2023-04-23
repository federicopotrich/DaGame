using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LobbyManager : NetworkBehaviour
{
    public static LobbyManager instance {get; private set;}
    private Dictionary<ulong, bool> playersReadyServerRpcDic;
    private void Awake(){
        instance = this;
        playersReadyServerRpcDic = new Dictionary<ulong, bool>();
    }

    public void SetPlayerReady(){
        SetPlayerReadyServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default){
        playersReadyServerRpcDic[serverRpcParams.Receive.SenderClientId] = true;

        bool allClientReady = true;

        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if(!playersReadyServerRpcDic.ContainsKey(clientId) || !playersReadyServerRpcDic[clientId]){
                allClientReady = false;
                break;
            }
        }

        if(allClientReady){
            NetworkManager.Singleton.SceneManager.LoadScene("GameSchoolScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

    }
}
