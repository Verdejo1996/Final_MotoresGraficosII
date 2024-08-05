using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;

    public static bool winCondition = false;

    public static bool changeCamera = false;
    public static bool activeMove = false;

    public static int actualPlayer = 0;

    public List<Controller_Target> targets;

    public List<Controller_Player> players;

    public GameObject Trampolin;


    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        activeMove = false;
        SetConstraits();
    }

    void Update()
    {
        GetInput();
        ActiveTramploin();

    }

    //Metodo en el cual sustitui la variable que daba como ganador al jugador al completar todos los lugares por
    //activar el trampolin que nos va a ayudar a agarrar los orbes.
    private void ActiveTramploin()
    {
        int i = 0;

        foreach(Controller_Target t in targets)
        {
            if (t.playerOnTarget)
            {
                i++;
                
                Debug.Log(i.ToString());

            }
        }
        if (i >= 6)
        {
            Trampolin.SetActive(true);
            changeCamera = true;

        }
    }

    private void GetInput()
    {
        if(activeMove == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (actualPlayer <= 0)
                {
                    actualPlayer = 5;
                    SetConstraits();
                }
                else
                {
                    actualPlayer--;
                    SetConstraits();
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (actualPlayer >= 5)
                {
                    actualPlayer = 0;
                    SetConstraits();
                }
                else
                {
                    actualPlayer++;
                    SetConstraits();
                }
            }
        }
    }

    private void SetConstraits()
    {
        foreach(Controller_Player p in players)
        {
            if (p == players[actualPlayer])
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
