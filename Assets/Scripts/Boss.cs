using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public int attackDamage;
	public Transform player;
    public Vector3 attackOffset;
    public float attackRange = 5.0f;
    public LayerMask attackMask;
	public bool isFlipped = false;
	public int maxHealth = 12;
    public int currentHealth;
    public bool isAlive = true;
	protected SpriteRenderer sprite;

	 void Start()
	{
		currentHealth = maxHealth;
	}

	void Update()
	{
	
	}
	
	public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
    }

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	public void TakeDamage(int damage)
    {
		currentHealth -= damage;

        if (currentHealth < 1)
        {
            isAlive = false;
			Destroy (gameObject);
        }
    }
	IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
