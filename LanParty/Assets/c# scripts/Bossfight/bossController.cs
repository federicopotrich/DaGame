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
    public Attacks att;


    void Start()
    {
        speed = 10f;
        spotIndex = (int) Random.Range(0,3);
        b = false;
        StartCoroutine(ChangeBehaviour());
    }

    void Update()
    {

    }

    IEnumerator Move(){
        Debug.Log("Moving");
        while(b==false){
            yield return new WaitForFixedUpdate();
            this.transform.position = Vector2.MoveTowards(this.transform.position, BossSpots[spotIndex].transform.position, speed*Time.deltaTime);
            if(this.transform.position==BossSpots[spotIndex].transform.position)
                b=true;
        }
        StartCoroutine(ChangeBehaviour());
    }

    IEnumerator ChangeDirection(){
        Debug.Log("Direction change");
        spotIndex = (int) Random.Range(0,3);
        b = false;
        yield return new WaitForSeconds(0);
        StartCoroutine(ChangeBehaviour());
    }

    IEnumerator ChangeBehaviour(){
        Debug.Log("Behaviour change");
        if(!b)
            yield return StartCoroutine(Move());   
        else{
            Debug.Log("attack or move");
            int index = (int) Random.Range(1,20);
            if(index%2==0){
                index = (int) Random.Range(0,5);
                yield return StartCoroutine(att.call(5));
                StartCoroutine(ChangeBehaviour());
            }
            else
                yield return ChangeDirection();
        }
    }
}
