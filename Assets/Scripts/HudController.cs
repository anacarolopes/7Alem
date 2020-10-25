using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Image one, two, three, gem_y, gem_b, gem_r, gem_g1, gem_g2, gem_g3;

    public void MostraGem_g()
    {
        gem_y.gameObject.SetActive(false);
        gem_b.gameObject.SetActive(false);
        gem_r.gameObject.SetActive(false);
        gem_g1.gameObject.SetActive(true);
        gem_g2.gameObject.SetActive(true);
        gem_g3.gameObject.SetActive(true);
        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
        three.gameObject.SetActive(false);
    }
     public void EsconderGem_g1()
    {
        gem_g1.gameObject.SetActive(false);
        gem_y.gameObject.SetActive(true);
        one.gameObject.SetActive(true);
    }
     public void EsconderGem_g2()
    {
        gem_g2.gameObject.SetActive(false);
        gem_b.gameObject.SetActive(true);
        two.gameObject.SetActive(true);
    }
     public void EsconderGem_g3()
    {
        gem_g3.gameObject.SetActive(false);
        gem_r.gameObject.SetActive(true);
        three.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
       MostraGem_g();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
