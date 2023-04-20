using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameManagerNetwork : NetworkBehaviour
{
    // Questa è la lista di tutti i giocatori nella scena
    private readonly List<Player> players = new List<Player>();

    // Questa è un'istanza singleton del GameManager
    public static GameManagerNetwork Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    // Questo metodo può essere utilizzato per ottenere la lista di tutti i giocatori nella scena
    public List<Player> GetPlayers()
    {
        return players;
    }
}
