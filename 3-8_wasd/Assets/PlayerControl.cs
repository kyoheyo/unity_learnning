using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject BombPre;
    public static Vector3 dir;
    //
    private GameObject position_Bomb;
    private float CD = 2;

    void Start()
    {
        position_Bomb = GameObject.Find("position_Bomb");
    }

    void Update()
    {
        //
        float horizon = Input.GetAxis("Horizontal");
        //
        float vertical = Input.GetAxis("Vertical");

        //
        //dir = new Vector3(horizon,0,vertical);
        Vector3 dir = new Vector3(horizon,0,vertical);
        if( dir != Vector3.zero)
        {
            //
            transform.rotation = Quaternion.LookRotation(dir);

            //
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
        //
        CD += Time.deltaTime;
        if( (Input.GetKeyDown(KeyCode.U)) )
        {
            //
            if( CD > 2 )
            {
                //
                CD = 0;
                //
                Instantiate(BombPre,position_Bomb.transform.position,transform.rotation);
            }
        } 
    }
}
