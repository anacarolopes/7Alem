using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaInimigo4 : MonoBehaviour
{
    public GameObject shadow1;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        renderSprite = GameObject.Find ("gem5").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem6").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        shadow1.SetActive (true);
        botao1.Play();        
    }
}
