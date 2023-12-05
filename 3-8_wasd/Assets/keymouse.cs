using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keymouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("按下了A键");
        }
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("持续按下A键");
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("松开了A键");
        }

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("按下了鼠标左键");
        }
        if(Input.GetMouseButton(0))
        {
            Debug.Log("持续按下鼠标左键");
        }
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("松开了鼠标左键");
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("按下了鼠标右键");
        }
        if(Input.GetMouseButton(1))
        {
            Debug.Log("持续按下鼠标右键");
        }
        if(Input.GetMouseButtonUp(1))
        {
            Debug.Log("松开了鼠标右键");
        }
    }
}
