using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
//
//
    public GameObject Effectpre;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //
        Invoke("Boom",2f);
        player = GameObject.FindWithTag("Player");
    }
    //
    public void Boom()
    {
        //
        GameObject effect = Instantiate(Effectpre,transform.position,transform.rotation);
        //
        Destroy(effect,2f);
        //
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //
        //
        foreach( GameObject enemy in enemys )
        {
            //
            if( Vector3.Distance(transform.position,enemy.transform.position) < 3f )
            {
                enemyHealth_control enemy11 = enemy.GetComponent<enemyHealth_control>();
                enemy11.currentHealth_enemy -= 5;
                enemy11.healthBar.SetHealth(enemy11.currentHealth_enemy);
                Debug.Log("have attacked the enemy [enemy: HP-5]");

                if(enemy11.currentHealth_enemy <= 0)
                {
                    Debug.Log("damage one enemy successfully");
                    Destroy(enemy);
                    //Time.timeScale = 0;
                }
                //Destroy(enemy);
            }
        }

        playerHealth_control player11 = player.GetComponent<playerHealth_control>();
        if( Vector3.Distance(transform.position,player.transform.position) < 3f )
        {
            player11.currentHealth_player -= 2;
            player11.healthBar.SetHealth(player11.currentHealth_player);
            Debug.Log("injured in the explosion [HP-2]");
            //Invoke("DelayFunc",0.1f);
        }

        //
        Destroy(gameObject,0.11f);
    }

    //private void DelayFunc()
    //{
    //    Debug.Log("玩家死亡，游戏结束!");
    //    Time.timeScale = 0;
    //}

}
