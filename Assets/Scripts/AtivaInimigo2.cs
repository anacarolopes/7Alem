using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaInimigo2 : MonoBehaviour
{
    public GameObject shadow;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        renderSprite = GameObject.Find ("gem11").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem12").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        shadow.SetActive (true);
        botao1.Play();        
    }
}
