using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    public Transform puntoInicial;
    public MovimientoRobot robot;
    // Start is called before the first frame update
    void Start()
    {
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicialRobot").transform;
        robot.rb.position = puntoInicial.position;
        
    }

}
