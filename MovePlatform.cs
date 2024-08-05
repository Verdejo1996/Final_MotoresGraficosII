using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;
    public float waitTime = 1f;

    private Vector3 nextPosition;

    void Start()
    {
        // Inicializa la posición siguiente como el punto de inicio
        nextPosition = endPoint.position;
    }

    void Update()
    {
        MovePl();
    }

    void MovePl()
    {
        // Mueve la plataforma hacia la posición siguiente
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // Si la plataforma alcanza la posición siguiente
        if (Vector3.Distance(transform.position, nextPosition) < 0.1f)
        {
            // Cambia la posición siguiente
            if (nextPosition == endPoint.position)
            {
                nextPosition = startPoint.position;
            }
            else
            {
                nextPosition = endPoint.position;
            }

            // Inicia la Coroutine para esperar antes de moverse nuevamente
            StartCoroutine(WaitBeforeMove());
        }
    }

    IEnumerator WaitBeforeMove()
    {
        // Desactiva el movimiento durante el tiempo de espera
        enabled = false;
        yield return new WaitForSeconds(waitTime);
        // Reactiva el movimiento después del tiempo de espera
        enabled = true;
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
