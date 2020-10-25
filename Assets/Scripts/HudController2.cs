using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController2 : MonoBehaviour
{
     public Image diamondy, diamondg, diamondr, diamondg1, diamondg2, diamondg3, one, two, three;


    public void MostraDiamond_g()
    {
        diamondg1.gameObject.SetActive(true);
        diamondg2.gameObject.SetActive(true);
        diamondg3.gameObject.SetActive(true);
        diamondy.gameObject.SetActive(false);
        diamondg.gameObject.SetActive(false);
        diamondr.gameObject.SetActive(false);
        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
        three.gameObject.SetActive(false);
    }
    
    public void EsconderDiamondg1()
    {
        diamondg1.gameObject.SetActive(false);
        diamondy.gameObject.SetActive(true);
        one.gameObject.SetActive(true);
    }
    public void EsconderDiamondg2()
    {
        diamondg2.gameObject.SetActive(false);
        diamondg.gameObject.SetActive(true);
        two.gameObject.SetActive(true);
        
    }
    public void EsconderDiamondg3()
    {
        diamondg3.gameObject.SetActive(false);
        diamondr.gameObject.SetActive(true);
        three.gameObject.SetActive(true);
        
    }
       
    // Start is called before the first frame update
    void Start()
    {
       MostraDiamond_g();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
