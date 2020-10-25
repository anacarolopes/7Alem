using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPotion1 : MonoBehaviour
{
    public GameObject potion1;
    void Start ()
    {
        
    }
 
    void Update()        
    {  
        if (Boss.isAlive == false)
        {
            potion1.SetActive (true);
        }        
    }
}
