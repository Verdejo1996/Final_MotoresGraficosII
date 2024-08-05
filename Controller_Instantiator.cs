using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : GameManager
{
    public List<GameObject> enemies;

    public int actualEnemy = 0;

    public Controller_Doors door;
    public Controller_Doors door2;

    private void Update()
    {

    }

    //Esta clase lleva su nombre ya que al entrar al trigger que activa el nivel y las puertas, activamos tambien los enemigos en la escena.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(actualPlayer == 0)
            {
                enemies[0].SetActive(true);
                
                door.MoveToA();
                door.MoveToB();

                door2.MoveToA();
                door2.MoveToB();
            }
            else if (actualPlayer == 1)
            {
                enemies[1].SetActive(true);

                door.MoveToA();
                door.MoveToB();

                door2.MoveToA();
                door2.MoveToB();
            }
            else if(actualPlayer == 2)
            {
                enemies[2].SetActive(true);

                door.MoveToA();
                door.MoveToB();

                door2.MoveToA();
                door2.MoveToB();

            }
            else if (actualPlayer == 3)
            {
                enemies[3].SetActive(true);

                door.MoveToA();
                door.MoveToB();

                door2.MoveToA();
                door2.MoveToB();

            }
            else if (actualPlayer == 4)
            {
                enemies[4].SetActive(true);

                door.MoveToA();
                door.MoveToB();

                door2.MoveToA();
                door2.MoveToB();

            }
            else
            {
                enemies[5].SetActive(true);

                door.MoveToA();
                door.MoveToB();

                door2.MoveToA();
                door2.MoveToB();

            }
        }
    }

    

}
