using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPorta : MonoBehaviour
{
    public GameObject castledoors;
    private AudioSource porta;

    void Start()
    {
        porta = GetComponent<AudioSource>();
    }
   
    void OnTriggerEnter2D (Collider2D col)
    {
        if(PlayerController.potion == true && PlayerController.potione == true && PlayerController.potionr == true)
        {   
            castledoors.SetActive (true);
            porta.Play();  
        }
        
    }
}
