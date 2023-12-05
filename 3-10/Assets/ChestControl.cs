using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    public GameObject CoinPre;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //
        float dis = Vector3.Distance(transform.position,player.position);
        //
        if( dis < 2 && Input.GetMouseButtonDown(0) )
        {
            if( Random.Range(0,10) > 5 )
            {
                Instantiate(CoinPre,transform.position,transform.rotation);
            }
            //
            Destroy(gameObject);
        }
    }
}
