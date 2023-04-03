using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class bossController : MonoBehaviour
{
    
    public int hp;
    public Transform[] BossSpots;
    float speed;
    int spotIndex;
    bool b;

    void Start()
    {
        speed = 10f;
        spotIndex = (int) Random.Range(0,3);
        b = false;
    }

    void Update()
    {
        if(!b)
            Move();   
        else
            ChangeDirection();
    }

    void Move(){

        this.transform.position = Vector2.MoveTowards(this.transform.position, BossSpots[spotIndex].transform.position, speed*Time.deltaTime);
        if(this.transform.position==BossSpots[spotIndex].transform.position)
            b=true;
    }

    void ChangeDirection(){
        spotIndex = (int) Random.Range(0,3);
        b = false;
    }
}
