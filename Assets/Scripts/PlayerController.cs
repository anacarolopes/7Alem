using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;

    public int health;
    public bool invunerable = false;

    private bool grounded;
    private bool jumping;

    private Rigidbody2D rb2d;
    private Animator anim;
    
    public SpriteRenderer sprite;

    public Transform groundCheck;

    //variaveis do spell
    public Transform bulletSpawn;
    public GameObject bulletObject;
    public float fireRate;
    private float nextFire;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
        sprite.enable = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Fire();
        }
    }

    void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if ((move > 0f && !sprite.flipX) || (move < 0f && sprite.flipX))
        {
            Flip();
        }


        if (jumping)
        {
            rb2d.AddForce (new Vector2(0f, jumpForce));
            jumping = false;
        }
    }

   
    void Flip()
    {
        sprite.flipX = !sprite.flipX;

        if (!sprite.flipX)
        {
            bulletSpawn.position = new Vector3(this.transform.position.x - 0.400f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
        else
        {
            bulletSpawn.position = new Vector3(this.transform.position.x + 0.400f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
        
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;
        GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
        if (!sprite.flipX)
        {
            cloneBullet.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    IEnumerator Damage()
    {
        for(float i = 0f; i < 1f; i += 0.1f)
        {
            sprite.enable = false;
            yield return new WaitForSeconds (0.1f);
            sprite.enable = true;
            yield return new WaitForSeconds (0.1f);
        }

        invunerable = false;

    }

    public void DamagePlayer()
    {
        invunerable = true;
        health --;
        StartCoroutine (Damage());

        if (health < 1)
        {
            Debug.Log("Morreu");
        }
    }

}




