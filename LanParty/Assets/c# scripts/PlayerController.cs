using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int piano = 0;
    public GameObject [] piani;
    public float speed;

    public GameObject canvasGame;

    public GameManager gm;
    public GameObject bullet;
    public Transform mouth;
    public bool isDistanceWeapon;
    public GameObject tpButton;
    public GameObject shopButton;
    public bool isSqualificato;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSqualificato){
            PlayerPrefs.SetInt("foo", 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

        float x = 0;
        float y = 0;
        if(Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) != Input.GetKey(KeyCode.RightArrow)){
            x = Input.GetAxis("Horizontal");
        }
        if(Input.GetKey(KeyCode.W) != Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) != Input.GetKey(KeyCode.DownArrow)){
            y = Input.GetAxis("Vertical");
        }
        
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

        if(isDistanceWeapon)
            if(Input.GetMouseButtonUp(0) && !gm.Shop.gameObject.activeSelf && !gm.inventory.gameObject.activeSelf){
                Transform target = mouth.transform;
                Vector3 mouse_pos;
                mouse_pos = Input.mousePosition;
                Vector3 object_pos;
                float angle;

                mouse_pos = Input.mousePosition;
                object_pos = Camera.main.WorldToScreenPoint(target.position);
                mouse_pos.x = mouse_pos.x - object_pos.x;
                mouse_pos.y = mouse_pos.y - object_pos.y;
                angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(0, 0, angle);

                GameObject bull = GameObject.Instantiate(bullet, /*Camera.main.WorldToViewportPoint*/(mouth.position), Quaternion.Euler(0, 0, angle));
                bull.transform.SetParent(mouth.transform);
            }
        
    }

    void OnTriggerEnter2D(Collider2D collisionDetected){
        //Debug.Log(collisionDetected.gameObject.name);

        //Debug.Log(tpButton);
    
        if(collisionDetected.gameObject.name == "portaEntrata" ){
            tpButton.SetActive(true);
        }else if(collisionDetected.gameObject.name == "banconeUp" ){
            shopButton.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collisionDetected){
        //Debug.Log(collisionDetected.gameObject.name);

        //Debug.Log(tpButton);
    
        if(collisionDetected.gameObject.name == "portaEntrata" ){
            tpButton.SetActive(false);
        }else if(collisionDetected.gameObject.name == "banconeUp" ){
            shopButton.SetActive(false);
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
            //Debug.Log(collisionDetected.gameObject.transform.parent);
            gm.generateQuestion(collisionDetected.gameObject.transform.parent.name);
        }
    }


    /*SICURAMENTE ZONA PER ADMIN OwO*/
    public void squalifica(){
        isSqualificato = true;
    } 
}
