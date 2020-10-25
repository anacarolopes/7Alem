using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomAwake : MonoBehaviour
{
   private bool moveDown = true;
    public float velocidade =3f;
    public Transform pontoA;
    public Transform pontoB;

    void Update()
    {
        if (ActBroom.acionouBroom == true)
        {
            if (transform.position.x < pontoA.position.x)
            moveDown = true;
            if (transform.position.x > pontoB.position.x)
            moveDown = false;
        
            if(moveDown)
            transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
            else
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
        }
    }
}
