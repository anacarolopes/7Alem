using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPorta2 : MonoBehaviour
{
    public GameObject castledoors;
    private AudioSource porta;

    void Start()
    {
        porta = GetComponent<AudioSource>();
    }
   
    void OnTriggerEnter2D (Collider2D col)
    {
        if(PlayerController.dm1 == true && PlayerController.dm2 == true && PlayerController.dm3 == true)
        {   
            castledoors.SetActive (true);
            porta.Play();  
        }
        
    }
}
