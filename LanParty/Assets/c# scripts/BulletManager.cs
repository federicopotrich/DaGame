using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.Transform.Translate(Transform.Up);
    }
}
