using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Orb : MonoBehaviour
{

    public static Controller_Orb instance;


    public int contadorOrbes = 0;

    private void Start()
    {
/*        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }*/
    }

    //En este metodo utilizo un patron Singleton para que al cambiar de escena se mantenga la instancia del objeto y no pierda el valor contador.
    private void Awake()
    {
        if (Controller_Orb.instance == null)
        {
            Controller_Orb.instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Metodo en el cual al activar el trigger, si estamos en el primer nivel avanzamos al segundo y si lo agarramos en el segundo ganamos la partida.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            contadorOrbes++;
            if(contadorOrbes == 1)
            {
/*                GameManager.actualPlayer = 0;
                GameManager.changeCamera = true;
                GameManager.activeMove = false;*/
                SceneManager.LoadScene("SegundoNivel");
            }
            else if(contadorOrbes == 2)
            {
                GameManager.winCondition = true;
            }
        }
    }
}
