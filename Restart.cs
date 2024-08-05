using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(SceneManager.GetActiveScene().name == "SegundoNivel")
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 1;
                GameManager.actualPlayer = 0;
                SceneManager.LoadScene(0);

            }
        }
    }
}
