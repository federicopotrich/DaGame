using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public int dmg;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active=false;
        StartCoroutine(activate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator activate(){
        yield return new WaitForSeconds(1f);
        active = true;
    }

}
