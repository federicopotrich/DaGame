using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Netcode;
public class LobbyManager : NetworkBehaviour
{
    public Button readyButton;
    public TMP_InputField nameInputField;
    public TMP_Dropdown teamDropdown;

    private Dictionary<string, int> playersReadyServerRpc = new Dictionary<string, int>();

    [ServerRpc]
    public void OnPlayerReadyServerRpc(string playerNameServerRpc, int team)
    {
        playersReadyServerRpc[playerNameServerRpc] = team;
        CheckAllPlayersReady();
    }

    [ClientRpc]
    public void RpcTeleportToGameSceneClientRpc()
    {
        if (NetworkManager.Singleton.IsServer && NetworkManager.Singleton.LocalClientId == NetworkManager.ServerClientId)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("PlayerInfoNet", LoadSceneMode.Single);
        }
    }

    private void CheckAllPlayersReady()
    {
        bool allPlayersReady = true;
        foreach (KeyValuePair<string, int> player in playersReadyServerRpc)
        {
            if (player.Value == 0)
            {
                allPlayersReady = false;
                break;
            }
        }

        if (allPlayersReady)
        {
            RpcTeleportToGameSceneClientRpc();
        }
    }

    public void OnReadyButtonClick()
    {
        string playerName = nameInputField.text;
        int team = teamDropdown.value;

        if (NetworkManager.Singleton.IsServer && NetworkManager.Singleton.LocalClientId == NetworkManager.ServerClientId)
        {
            OnPlayerReadyServerRpc("server", -1);
        }
        else
        {
            CmdPlayerReady(playerName, team);
        }

        readyButton.interactable = false;
    }
    
    public void CmdPlayerReady(string playerName, int team)
    {
        OnPlayerReadyServerRpc(playerName, team);
    }
}
