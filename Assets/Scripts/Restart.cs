using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

  public bool isPause;   
    // Start is called before the first frame update
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
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
            isPause = false;
        }

        if (Input.GetKeyDown (KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
            isPause = false;
        }
    }

}
