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
       slider.value = 12;
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

       float fillValue = bossHealth.currentHealth / bossHealth.maxHealth;
       
       if (fillValue <= slider.maxValue / 3)
       {
           fillImage.color = Color.yellow;
       }
       else if (fillValue > slider.maxValue / 3)
       {
           fillImage.color = Color.red;
       }

       slider.value = fillValue;
   }
}
