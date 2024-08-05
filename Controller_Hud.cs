using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public Text gameOverText;
    public Text doorText;
    
    private float displayDuration = 3f;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        doorText.gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (GameManager.gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over" ;
            gameOverText.gameObject.SetActive(true);
        }
        if (GameManager.winCondition)
        {
            Time.timeScale = 0;
            gameOverText.text = "You Win";
            gameOverText.gameObject.SetActive(true);
        }
    }


    public void ShowPickupText(string message)
    {
        StartCoroutine(DisplayTextCoroutine(message));
    }

    private IEnumerator DisplayTextCoroutine(string message)
    {
        // Establece el mensaje y activa el texto
        doorText.text = message;
        doorText.gameObject.SetActive(true);

        // Espera el tiempo especificado
        yield return new WaitForSeconds(displayDuration);

        // Desactiva el texto después del tiempo especificado
        doorText.gameObject.SetActive(false);
    }
}
