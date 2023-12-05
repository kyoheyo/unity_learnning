using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //虚拟轴的使用
        float horizon = Input.GetAxis("Horizontal");
        Debug.Log(horizon);

        //虚拟按键的使用
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire键按下");
        }
        if(Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Fire键松开");
        }
    }
}
