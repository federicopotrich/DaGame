using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int piano = 0;
    public GameObject [] piani;
    public float speed;

    public GameObject canvasGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        this.GetComponent<Animator>().SetFloat("speed", Mathf.Abs(x));

        if(x < 0){
            this.GetComponent<SpriteRenderer>().flipX = true;
        }else if(x > 0){
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        
        
        if(x == 0 && y != 0){
            this.GetComponent<Animator>().SetFloat("speed", 1);
        }

        Vector3 movement = new Vector3(x, y, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        if(Input.GetKeyUp(KeyCode.P)){
            canvasGame.SetActive(!canvasGame.activeSelf);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionDetected){
        if(collisionDetected.gameObject.tag == "scale"){
            piani[piano].SetActive(false);

            if(collisionDetected.gameObject.name=="up"){
                piani[piano+1].SetActive(true);
                piano++;
            }else if(collisionDetected.gameObject.name=="down"){
                piani[piano-1].SetActive(true);
                piano--;
            }

            if(collisionDetected.gameObject.transform.parent.gameObject.tag == "sinistra")
                this.transform.position = new Vector3(collisionDetected.gameObject.transform.position.x+10, collisionDetected.gameObject.transform.position.y, 0);
            else
                this.transform.position = new Vector3(collisionDetected.gameObject.transform.position.x-10, collisionDetected.gameObject.transform.position.y, 0);

        }
        if(collisionDetected.gameObject.tag == "Porta"){
            Debug.Log(collisionDetected.gameObject.transform.parent);
        }
    }
}
