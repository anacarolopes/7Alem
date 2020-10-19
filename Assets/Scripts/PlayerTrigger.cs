using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerController player;
    private DamageBoss playerB;
      
    void Awake()
    {
        player = GameObject.Find ("Player").GetComponent<PlayerController>();
        playerB = GameObject.Find ("Player").GetComponent<DamageBoss>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag ("Enemy") || other.CompareTag ("deathPit"))
        {
            if (!player.invunerable)
            {
                player.DamagePlayer();
            }
        }

        if (other.CompareTag ("Boss"))
        {
            playerB.TakeDamage();
            
        }
         
    }


}
