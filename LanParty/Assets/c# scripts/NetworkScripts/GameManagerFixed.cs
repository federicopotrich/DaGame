using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Linq;

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
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameSchoolScene" && b == true)
        {
            if (NetworkManager.Singleton.IsServer)
            {
                //GameObject.Find("Camera").SetActive(true);
                NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
            }
            b = false;
        }
    }
    private void SceneManager_OnLoadEventCompleted(string sceneName, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            List<ulong> clientsList = new List<ulong>(clientsCompleted);
            int clientIndex = clientsList.IndexOf(clientId);
            GameObject cameraObj = GameObject.Find("Camera: " + clientIndex);
            // cameraObj.tag = "MainCamera";
            // cameraObj.GetComponent<Camera>().enabled = true;
            // cameraObj.GetComponent<AudioListener>().enabled = true; // se vuoi abilitare anche l'AudioListener della telecamera
        }

    }
}