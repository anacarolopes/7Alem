using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerController player;
      
    void Awake()
    {
        player = GameObject.Find ("Player").GetComponent<PlayerController>();
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
            player.DamagePlayerBoss(2);
            
        }
         
    }


}
