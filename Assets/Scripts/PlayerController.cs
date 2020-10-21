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

    public GameObject gameOverPanel;

    private bool grounded;
    private bool jumping;

    private Rigidbody2D rb2d;
    private Animator anim;
    
    public SpriteRenderer sprite;
    public HudController hud;
    private AudioSource soundFx;

    public Transform groundCheck;

    public Transform myTransform;

    //variaveis do spell
    public Transform bulletSpawn;
    public GameObject bulletObject;
    public GameObject bullet2Object;
    private bool spell2;

    private GameObject activeSpell;

    public float fireRate;
    private float nextFire;
	
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        soundFx = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        activeSpell = bulletObject;
        spell2 = false;
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
        
        if (Input.GetKeyDown("0"))
        {
			activeSpell = bulletObject;
        }
        
        if (Input.GetKeyDown("1") && spell2 == true)
        {
			activeSpell = bullet2Object;

        }      

    }

    void FixedUpdate()
    {

        if (isAlive)
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
        GameObject cloneBullet = Instantiate(activeSpell, bulletSpawn.position, bulletSpawn.rotation);
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
            invunerable = true;
            health --;
            StartCoroutine (Damage());

            if (health < 1)
            {
                isAlive = false;
                gameOverPanel.SetActive (true);
                Time.timeScale = 0;
            }
        
        }

    }

    public void DamagePlayerBoss(int damage)
    {
        if (isAlive)
        {
            invunerable = true;
            health -= damage;
            StartCoroutine (Damage());

            if (health < 1)
            {
                isAlive = false;
                gameOverPanel.SetActive (true);
                Time.timeScale = 0;
            }
        
        }

    }

     public void OnTriggerEnter2D (Collider2D other)
    {
            if (other.CompareTag("Potion")) 
            {
                soundFx.Play();
                Destroy(other.gameObject);
                hud.EsconderPotion_g();
                spell2 = true;
            }

            if (other.CompareTag ("door"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
      gameOverPanel.SetActive (true);
      Time.timeScale = 0;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}




