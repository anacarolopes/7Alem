using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Image potion_y;
    public Image potion_e;
    public Image potion_r;
    public Image potion_g;
    public Image potion_g1;
    public Image potion_g2;
    public Image one;
    public Image two;
    public Image three;

    public void MostraPotion_g()
    {
        potion_g.gameObject.SetActive(true);
        potion_g1.gameObject.SetActive(true);
        potion_g2.gameObject.SetActive(true);
        potion_y.gameObject.SetActive(false);
        potion_e.gameObject.SetActive(false);
        potion_r.gameObject.SetActive(false);
        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
        three.gameObject.SetActive(false);
    }

    public void EsconderPotion_g()
    {
        potion_g.gameObject.SetActive(false);
        potion_y.gameObject.SetActive(true);
        one.gameObject.SetActive(true);
        
    }
    // Start is called before the first frame update
    void Start()
    {
       MostraPotion_g();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
