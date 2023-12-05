using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject player;

    private float Cd = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position);
        //
        if( distance < 4 )
        {
            //
            transform.LookAt(player.transform);
            //
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
        }
        //
        if( distance < 2 )
        {
            Cd += Time.deltaTime;
            if(Cd > 1.5)
            {
                Cd = 0;
                playerHealth_control player11 = player.GetComponent<playerHealth_control>();
                player11.currentHealth_player -= 2;
                player11.healthBar.SetHealth(player11.currentHealth_player);
                Debug.Log("injured by the enemy [HP-2]");
            }
            //Debug.Log("玩家死亡，游戏结束!");
            //Time.timeScale = 0;
        }
    }
}
