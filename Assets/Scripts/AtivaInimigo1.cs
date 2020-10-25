using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaInimigo1 : MonoBehaviour
{
    public GameObject Crow;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        renderSprite = GameObject.Find ("gem1").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem2").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
            renderSprite.GetComponent<SpriteRenderer>().enabled = false;
            spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
            Crow.SetActive (true);
            botao1.Play();        
    }
}
