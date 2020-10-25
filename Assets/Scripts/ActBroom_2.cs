﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBroom_2 : MonoBehaviour
{
    public static bool acionouBroom2;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        acionouBroom2 = false;
        renderSprite = GameObject.Find ("gem_5").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem_4").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        acionouBroom2 = true;
        botao1.Play();
    }
}