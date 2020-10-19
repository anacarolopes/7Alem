using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    public int health;
    public bool invunerable = false;
    public bool isAlive = true;

   public void TakeDamage()
    {
        if (isAlive)
        {
            invunerable = true;
            health -= 2;
            GetComponent<PlayerController>().Damage();

            if (health < 1)
            {
                isAlive = false;
                Invoke ("ReloadLevel", 2f);
            }
        }
    }
}
