using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerController player;

    void Awake()
    {
        player = GameObject.Find ("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag ("Enemy"))
        {
            if (!player.invunerable)
            {
                player.Damage();
            }
        }
    }

}
