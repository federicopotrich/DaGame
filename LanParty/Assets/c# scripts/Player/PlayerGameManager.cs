using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    public GameObject [] arrPiani;
    public Stats myStats;
    // Start is called before the first frame update
    void Start()
    {
        myStats = this.gameObject.AddComponent<Stats>();
        myStats.MaxHP = myStats.CurrentHP = 150;
        myStats.coins = 0;
        myStats.floor = 0;
        this.gameObject.AddComponent<PlayerControllerNet>();

        Interactions interactionPlayer = this.gameObject.AddComponent<Interactions>();

        interactionPlayer.s = myStats;
        
        this.gameObject.GetComponent<PlayerControllerNet>().speed = 10;
    }
    void Update()
    {
        
    }
    
    public class Stats : MonoBehaviour
    {
        public int MaxHP, CurrentHP, coins, floor;
    }
    public class Interactions : MonoBehaviour
    {
        public Stats s;
        void OnCollisionEnter2D(Collision2D coll){
            switch (coll.gameObject.name)
            {
                case "up":
                    if (s.floor >= 0 && s.floor <= 2)
                    {
                        s.floor++;
                    }
                    break;
                case "down":
                    if (s.floor >= 1 && s.floor <= 3)
                    {
                        s.floor--;
                        
                    }
                    break;
            }
        }
    }
}
