using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraFollowPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera camera;
    

    // Update is called once per frame
    void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }
    public void FollowPlayer(Transform tr){
        camera.Follow = tr;
    }
}
