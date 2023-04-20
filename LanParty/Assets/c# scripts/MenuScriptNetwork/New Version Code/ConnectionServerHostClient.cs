using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class ConnectionServerHostClient : NetworkBehaviour
{
    //private string ipAddress = "192.168.127.137";

    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    public NetworkManager nm;

    private void Awake()
    {
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
    }
    private void StartHost()
    {
        // Configura l'host
        //NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Hello world!");

        // Avvia l'host
        var task = NetworkManager.Singleton.StartServer();

        if (!task)
        {
            Debug.LogError("Host start failed");
        }
        else
        {
            Debug.Log("Host started");
        }
    }
    private void StartClient()
    {
        if (NetworkManager.Singleton.IsClient)
        {
            return;
        }

        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("<ip_address>");

        // Connetti al server
        var task = NetworkManager.Singleton.StartClient();
        if (!task)
        {
            Debug.LogError("Connection failed");
        }
        else
        {
            Debug.Log("Connected to server");
        }
    }
}
