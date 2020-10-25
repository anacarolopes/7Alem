using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
      base.Update();
      anim.SetBool ("walking", isMoving);

    if (isMoving)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    
    else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

}
