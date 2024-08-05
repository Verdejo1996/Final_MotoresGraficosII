using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireRate = 1f;
    //private float nextFireTime = 0f;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Robot"))
        {
            player = other.transform;
            InvokeRepeating("Shoot", 0f, 1f / fireRate);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Robot"))
        {
            CancelInvoke("Shoot");
            player = null;
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            GameObject firedProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody rb = firedProjectile.GetComponent<Rigidbody>();
            Vector3 direction = (player.position - firePoint.position).normalized;
            rb.velocity = direction * 10f; // Ajusta la velocidad del proyectil según tus necesidades
        }
    }

    void OnDrawGizmosSelected()
    {
        SphereCollider sc = GetComponent<SphereCollider>();
        if (sc != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sc.radius);
        }
    }
}
