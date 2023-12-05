using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        //
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        float horizontal = Input.GetAxis("Horizontal");
        //
        float vertical = Input.GetAxis("Vertical");

        //
        Vector3 dir = new Vector3(horizontal,0,vertical);
        //
        characterController.Move(dir * 4 * Time.deltaTime);
        //characterController.SimpleMove(dir * 2);
    }
}
