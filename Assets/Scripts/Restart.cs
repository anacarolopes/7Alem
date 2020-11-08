using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
   public bool isPause;   
    void Awake()
    {
        Time.timeScale = 1;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;

            if (isPause == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                isPause = false;
            }
        }
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 1;
            isPause = false;
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown (KeyCode.R))
        {
            Time.timeScale = 1;
            isPause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
