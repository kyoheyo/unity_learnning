using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth_control : MonoBehaviour
{

    public int maxHealth_player = 10;
    public int currentHealth_player;

    public health_bar_control_player healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth_player = maxHealth_player;
        healthBar.SetMaxHealth(maxHealth_player);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(2);
        //}

        if(currentHealth_player <= 0)
        {
            Debug.Log("you die, game over");
            Time.timeScale = 0;
        }
    
    }

    //void TakeDamage(int damage)
    //{
    //    currentHealth_player -= damage;
    //    healthBar.SetHealth(currentHealth_player);
    //}
}
