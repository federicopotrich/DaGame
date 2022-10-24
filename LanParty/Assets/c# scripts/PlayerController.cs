using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int piano = 0;
    public GameObject [] piani;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, y, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collisionDetected){
        //Debug.Log();
        if(collisionDetected.gameObject.tag == "scale"){
            piani[piano].SetActive(false);
            if(collisionDetected.gameObject.name=="up"){
                piano++;
                piani[piano+1].SetActive(true);
            }else if(collisionDetected.gameObject.name=="up"){
                piano--;
                piani[piano-1].SetActive(true);
            }
            //pianoTerra.SetActive(false);
            //piano1.SetActive(true);


            if(collisionDetected.gameObject.transform.parent.gameObject.tag == "sinistra")
                this.transform.position = new Vector3(this.transform.position.x+5, this.transform.position.y, 0);
            else
                this.transform.position = new Vector3(this.transform.position.x-5, this.transform.position.y, 0);

        }
    }
}
