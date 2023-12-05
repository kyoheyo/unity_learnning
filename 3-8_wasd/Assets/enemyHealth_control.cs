using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth_control : MonoBehaviour
{

    public int maxHealth_enemy = 20;
    public int currentHealth_enemy;

    public health_bar_control_enemy healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth_enemy = maxHealth_enemy;
        healthBar.SetMaxHealth(maxHealth_enemy);
    }

    // Update is called once per frame
    //void Update()
    //{
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(5);
        //}

        //if(currentHealth_enemy == 0)
        //{
        //    Debug.Log("damage one enemy successfully");
            //Time.timeScale = 0;
        //}
    //}

    //void TakeDamage(int damage)
    //{
    //    currentHealth_enemy -= damage;
    //    healthBar.SetHealth(currentHealth_enemy);
    //}
}
