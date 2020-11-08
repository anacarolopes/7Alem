using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;

    public int health;
    public bool invunerable = false;
    public bool isAlive = true;

    public  GameObject gameOverPanel;

    private bool grounded;
    private bool jumping;

    private Rigidbody2D rb2d;
    private Animator anim;
    
    public SpriteRenderer sprite;
    public HudController hud;
    public HudController1 hud1;
    public HudController2 hud2;
    private AudioSource soundFx;

    public Transform groundCheck;

    public Transform myTransform;

    //variaveis do spell
    public Transform bulletSpawn;
    public GameObject bulletObject;
    public static bool potion, potione, potionr, gm1, gm2, gm3, dm1, dm2, dm3;
    public float fireRate;
    private float nextFire;
    
	
    

    private void Awake()
    {
        Time.timeScale = 1;
        isAlive = true;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        soundFx = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
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

        if (isAlive)
        {
            Time.timeScale = 1;
            
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

    public IEnumerator Damage()
    {
        for(float i = 0f; i < 1f; i += 0.1f)
        {
            sprite.color = Color.green;
            yield return new WaitForSeconds (0.1f);
            sprite.color = Color.white;
            yield return new WaitForSeconds (0.1f);
        }

        invunerable = false;

    }

    public void DamagePlayer()
    {
        if (isAlive)
        {
            Time.timeScale = 1;
            StartCoroutine (Damage());
            invunerable = true;
            health --;

            if (health < 1)
            {
                isAlive = false;
                OnBecameInvisible();
                
            }
        
        }

    }

    public void DamagePlayerBoss(int damage)
    {
        if (isAlive)
        {
            Time.timeScale = 1;
            StartCoroutine (Damage());
            invunerable = true;
            health -= damage;

            if (health < 1)
            {
                isAlive = false;
                OnBecameInvisible();
               
            }
        
        }

    }

     public void OnTriggerEnter2D (Collider2D other)
    {
            if (other.CompareTag("Potion")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud1.EsconderPotion_g();
                potion = true;
            }

            if (other.CompareTag("Potione")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud1.EsconderPotion_g1();
                potione = true;
                
            }

            if (other.CompareTag("Potionr")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud1.EsconderPotion_g2();
                potionr = true;
                
            }
            
            if (other.CompareTag("gema")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud.EsconderGem_g2();
                gm1 = true;
            }

            if (other.CompareTag("gemar")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud.EsconderGem_g3();
                gm2 = true;
                
            }

            if (other.CompareTag("gemm")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud.EsconderGem_g1();
                gm3 = true;                
            }

            if (other.CompareTag("gemy")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud2.EsconderDiamondg1();
                dm1 = true;
            }

            if (other.CompareTag("gemg")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud2.EsconderDiamondg2();
                dm2 = true;
                
            }

            if (other.CompareTag("gemr")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud2.EsconderDiamondg3();
                dm3 = true;                
            }

            if (other.CompareTag ("door"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "broom")
        {
            myTransform.parent = collision.transform;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "broom")
        {
            myTransform.parent = null;
        }
    }

    void OnBecameInvisible() 
    {
      Time.timeScale = 0;
      if (gameOverPanel != null)
      gameOverPanel.SetActive (true);
    }

}




