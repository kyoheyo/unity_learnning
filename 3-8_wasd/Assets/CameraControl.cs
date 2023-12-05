using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //
    private Transform player;
    private Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        vector = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dirCam = PlayerControl.dir.normalized;
        //float length = vector.magnitude;
        //transform.position = player.transform.position - dirCam * length;
        //Vector3 pos = transform.position;
        //pos.y = 3;
        //transform.position = pos;
        //transform.rotation = Quaternion.LookRotation(PlayerControl.dir);
        //transform.Rotate(new Vector3(18,0,0));
        transform.position = player.transform.position - vector;
    }
}
