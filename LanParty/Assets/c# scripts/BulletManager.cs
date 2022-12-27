using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(transform.up*0.2f);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
