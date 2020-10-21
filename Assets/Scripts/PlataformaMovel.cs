using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    private bool moveDown = true;
    public float velocidade =2.5f;
    public Transform pontoD;
    public Transform pontoE;

    void Update()
    {
       
        if (transform.position.x < pontoD.position.x)
        moveDown = true;
        if (transform.position.x > pontoE.position.x)
        moveDown = false;
        
        if(moveDown)
        transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
        else
        transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
        
    }
}
