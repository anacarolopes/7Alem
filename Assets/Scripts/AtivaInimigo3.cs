using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaInimigo3 : MonoBehaviour
{
   public GameObject Crow1;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        renderSprite = GameObject.Find ("gem15").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem16").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        Crow1.SetActive (true);
        botao1.Play();        
    }
}
