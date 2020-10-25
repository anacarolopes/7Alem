using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}
