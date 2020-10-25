using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPotion3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject potion_r;
    private SpriteRenderer renderSprite, spriteRenderer;
    private AudioSource botao1;
    void Start ()
    {
        renderSprite = GameObject.Find ("gem9").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("gem10").GetComponent<SpriteRenderer>();
        botao1 = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {  
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
        potion_r.SetActive (true);
        botao1.Play();        
    }
}
