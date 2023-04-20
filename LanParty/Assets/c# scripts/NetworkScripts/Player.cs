using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    // Questo codice deve essere inserito nella classe del tuo giocatore

    public override void OnNetworkSpawn()
    {
        // Se questo è il giocatore locale, non è necessario fare nulla
        if (!IsLocalPlayer)
        {
            // Aggiungi il giocatore alla lista di tutti i giocatori nella scena
            GameManagerNetwork.Instance.AddPlayer(this);
        }
    }
}
