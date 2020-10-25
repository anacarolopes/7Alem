using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPotion1 : MonoBehaviour
{
    public GameObject gemy;
    void Start ()
    {
        
    }
 
    void Update()        
    {  
        if (Boss.isAlive == false)
        {
            gemy.SetActive (true);
        }        
    }
}
