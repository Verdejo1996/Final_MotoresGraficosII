using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy_Projectile : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Robot") || collision.gameObject.CompareTag("Player"))
        {
            GameManager.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
