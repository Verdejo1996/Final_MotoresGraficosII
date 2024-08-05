using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Doors : MonoBehaviour
{
    public Transform pointA;  // Punto de origen
    public Transform pointB;  // Punto de destino
    public float speed = 5f;  // Velocidad inicial

    private bool movingToB = false;
    private bool movingToA = false;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        if (movingToB)
        {
            MoveTowards(pointB.position);

        }
        else if (movingToA)
        {
            MoveTowards(pointA.position);
        }
        if (GameManager.changeCamera == true)
        {
            MoveToA();
        }
    }

    //Metodo en el cual las puertas se mueven de un punto a otro dependiendo el punto de origen
    private void MoveTowards(Vector3 target)
    {
        float step = currentSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            currentSpeed = 0f;  // Detenerse cuando llegue al destino
            movingToB = false;
            movingToA = false;
        }
    }

    internal void MoveToB()
    {
        currentSpeed = speed;
        movingToB = true;
    }

    internal void MoveToA()
    {
        currentSpeed = speed;
        movingToA = true;
    }

}
