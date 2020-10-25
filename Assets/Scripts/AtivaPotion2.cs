using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPotion2 : MonoBehaviour
{
    public GameObject gemg;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;
    void Start ()
    {
        renderSprite = GameObject.Find ("gem17").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem18").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        gemg.SetActive (true);
        botao1.Play();        
    }
}
