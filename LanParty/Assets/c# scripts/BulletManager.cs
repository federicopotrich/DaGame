using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(transform.up*Time.deltaTime);
    }
    void OnColliderEnter2D(Collision2D coll){
        Destroy(this);
    }
}
