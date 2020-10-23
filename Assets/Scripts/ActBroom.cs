using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActBroom : MonoBehaviour
{
    public static bool acionouBroom;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        acionouBroom = false;
        renderSprite = GameObject.Find ("gem_5").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem_4").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {
        if(PlayerController.potion == true)
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        acionouBroom = true;
        botao1.Play();
    }
}
