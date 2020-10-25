using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPotion : MonoBehaviour
{
   public GameObject gem_3;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;
    void Start ()
    {
        renderSprite = GameObject.Find ("gem_S2").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gemS").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        gem_3.SetActive (true);
        botao1.Play();        
    }
}
