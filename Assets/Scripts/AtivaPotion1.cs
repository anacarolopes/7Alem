using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPotion1 : MonoBehaviour
{
    public GameObject gemy;
    
    public void OnTriggerEnter2D (Collider2D other)
    {
            if (other.CompareTag("Boss"))
            {
                gemy.SetActive (true);
            }
    }
}
