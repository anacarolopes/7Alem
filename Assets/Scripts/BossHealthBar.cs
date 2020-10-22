using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Boss bossHealth;
    public Image fillImage;
    private Slider slider;

   void Awake()
   {
       slider = GetComponent<Slider>();
   }

   void Update()
   {
       if (slider.value <= slider.minValue)
       {
           fillImage.enabled = false;
       }

       if (slider.value > slider.minValue && !fillImage.enabled)
       {
           fillImage.enabled = true;
       }

       slider.value = (float) bossHealth.currentHealth / bossHealth.maxHealth;
       
       if (slider.value <= slider.maxValue / 3)
       {
           fillImage.color = Color.yellow;
       }
       else if (slider.value > slider.maxValue / 3)
       {
           fillImage.color = Color.red;
       }

   }
}
