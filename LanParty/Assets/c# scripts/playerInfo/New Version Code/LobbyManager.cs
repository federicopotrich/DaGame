using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LobbyManager : NetworkBehaviour
{
    public static LobbyManager instance {get; private set;}
    private Dictionary<ulong, UtenteReady> playersReadyServerRpcDic;
    private void Awake(){
        instance = this;
        playersReadyServerRpcDic = new Dictionary<ulong, UtenteReady>();
    }

    public void SetPlayerReady(){
        Debug.Log(NetworkManager.Singleton.IsClient);
        SetPlayerReadyServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default){
        UtenteReady u = new UtenteReady();
        u.ready = true;
        if(NetworkManager.Singleton.IsHost){
            if (GameObject.Find("UserName").GetComponent<TMP_InputField>().text != "")
            {
                u._name = GameObject.Find("UserName").GetComponent<TMP_InputField>().text;
            }else{
                u._name = "host";
            }
        }

        Debug.Log(u._name);

        playersReadyServerRpcDic[serverRpcParams.Receive.SenderClientId] = u;
        bool allClientReady = true;

        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if(!playersReadyServerRpcDic.ContainsKey(clientId) || !playersReadyServerRpcDic[clientId].ready){
                allClientReady = false;
                break;
            }
        }

        if(allClientReady){
            GameObject g = Instantiate(new GameObject());

            g.AddComponent<c>();
            g.GetComponent<c>().players = playersReadyServerRpcDic;
            g.name = "dataConnectedPlayers";
            DontDestroyOnLoad(g);
            NetworkManager.Singleton.SceneManager.LoadScene("GameSchoolScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

    }
}
public class UtenteReady{
    public bool ready;
    public string _name;
}

public class c : MonoBehaviour{
    public  Dictionary<ulong, UtenteReady> players;
}