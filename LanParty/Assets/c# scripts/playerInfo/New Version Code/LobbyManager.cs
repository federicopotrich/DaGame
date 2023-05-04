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
<<<<<<< HEAD
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
    {
        UtenteReady u = new UtenteReady();
        u.ready = true;

        Debug.Log(NetworkManager.Singleton.IsHost);

        if (!NetworkManager.Singleton.IsHost)
        {
            TMP_InputField inputField = GameObject.FindObjectOfType<TMP_InputField>();
            if (inputField != null && inputField.text != "")
            {
                u._name = inputField.text;
            }
            else
            {
                u._name = "guest";
            }
        }
        else
        {
            u._name = "host";
        }
=======
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default){
        playersReadyServerRpcDic[serverRpcParams.Receive.SenderClientId] = true;
>>>>>>> eace0bea9f82c182f795795bbb5d1742d88ae479

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
