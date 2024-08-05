using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform[] points;
    private int current;
    public GameObject gameObj;
    public float speed;

    void Start()
    {
        current = 0;
    }

    //En este update lo que se hace es tomar la posicion de los puntos de la escena de cada enemigo para tomar su position
    //e ir de un punto a otro tomando su velocidad.
    void Update()
    {
        if (gameObj.transform.position != points[current].position)
        {
            gameObj.transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            collision.transform.parent = null;
        }
    }
}
