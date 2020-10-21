using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActStairs : MonoBehaviour
{
    public GameObject stairs;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;

    void Start ()
    {
        renderSprite = GameObject.Find ("gem_6").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem_7").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        stairs.SetActive (true);
        botao1.Play();
    }
}
