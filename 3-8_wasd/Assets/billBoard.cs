using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billBoard : MonoBehaviour
{

    public Transform cam;
    
    void LateUpdate()
    {
        //transform.LookAt是看向那一点；Quaternion.LookRotation()是与选定向量同向
        transform.LookAt(transform.position + cam.forward);
    }
}
