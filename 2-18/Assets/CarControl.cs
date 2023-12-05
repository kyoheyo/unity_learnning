using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    //
    public WheelCollider[] frontWheels;
    public WheelCollider[] backWheels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //
        foreach( WheelCollider wheel in frontWheels )
        {
            //设置前轮最大转弯角度
            wheel.steerAngle = horizontal * 30;
        }
        foreach( WheelCollider wheel in backWheels )
        {
            //
            wheel.motorTorque = vertical * 100;
        }
        //
        if (Input.GetKey(KeyCode.Space))
        {
            backWheels[0].brakeTorque = 4000;
            backWheels[1].brakeTorque = 4000;
            Debug.Log("刹车！");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            backWheels[0].brakeTorque = 0;
            backWheels[1].brakeTorque = 0;
            Debug.Log("刹车完！");
        }
    }
}
