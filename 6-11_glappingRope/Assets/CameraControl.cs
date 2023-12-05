using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float angleSpeed = 0.005f;
    //public bool isRotate = true;

    // Start is called before the first frame update
    //void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizon,vertical,0);
        if(dir.magnitude != 0)
        {
            Quaternion rotate = Quaternion.LookRotation(dir);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotate, angleSpeed);
        }

        /*
        if(Vector3.Angle(dir, transform.forward) < 0.1f)
        {
            isRotate = false;
        }

        if(isRotate)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotate, angleSpeed);
        }
        */
    }
}
