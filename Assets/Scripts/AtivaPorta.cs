﻿using System.Collections;
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
        if(PlayerController.gm1 == true && PlayerController.gm2 == true && PlayerController.gm3 == true)
        {   
            castledoors.SetActive (true);
            porta.Play();  
        }
        
    }
}
