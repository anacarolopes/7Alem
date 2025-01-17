﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public float distanceAttack;
    public float speed;
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;
    protected bool isMoving = false;
    private AudioSource soundFx;
    public GameObject Tile_32;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        sprite = GetComponent<SpriteRenderer> ();
        player = GameObject.Find ("Player").GetComponent<Transform> ();
        soundFx = GetComponent<AudioSource>();
    }

    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;
    }

    protected virtual void Update()
    {
      float distance = PlayerDistance ();
      isMoving = (distance <= distanceAttack);
     
      if (isMoving)
      {
          if ((player.position.x > transform.position.x && sprite.flipX) || (player.position.x < transform.position.x && !sprite.flipX))
          {
              Flip ();
          }
      }
    }

    public void DamageEnemy(int damageBullet)
    {
        soundFx.Play();
        health -= damageBullet;
        StartCoroutine (Damage());

        if(health < 1)
        {
            Destroy (gameObject);
            Tile_32.SetActive (false);
        }
    }
    IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    
}

