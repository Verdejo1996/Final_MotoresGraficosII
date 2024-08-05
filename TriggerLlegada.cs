using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLlegada : GameManager
{
    public List<GameObject> enemies;

    public Controller_Doors door;
    public Controller_Doors door2;

    public int actualEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Metodo en el cual cuando el jugador activa el trigger ademas activa el comportamiento de ambas puertas, cerrando y abriendo respectivamente
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(actualPlayer == 0)
            {
                enemies[0].SetActive(false);
                
                door.MoveToA();

                door2.MoveToA();

            }
            else if (actualPlayer == 1)
            {
                enemies[1].SetActive(false);

                door.MoveToA();

                door2.MoveToA();

            }
            else if (actualPlayer == 2)
            {
                enemies[2].SetActive(false);

                door.MoveToA();

                door2.MoveToA();

            }
            else if (actualPlayer == 3)
            {
                enemies[3].SetActive(false);

                door.MoveToA();

                door2.MoveToA();

            }
            else if (actualPlayer == 4)
            {
                enemies[4].SetActive(false);

                door.MoveToA();

                door2.MoveToA();

            }
            else
            {
                enemies[5].SetActive(false);

                door.MoveToA();

                door2.MoveToA();

            }
        }
    }
}
