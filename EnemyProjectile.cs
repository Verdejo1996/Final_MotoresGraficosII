using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private Transform player;
    private Transform robot;

    private Vector3 direction;

    private Rigidbody rb;

    public float enemyProjectileSpeed;

    void Start()
    {
        player = FindObjectOfType<Controller_Player>().transform;
        robot = FindAnyObjectByType<MovimientoRobot>().transform;
        rb = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        if(robot != null)
        {
            direction = robot.position - transform.position;

        }
        else if(player != null)
        {
            direction = player.position - transform.position;
        }
        rb.AddForce(direction * enemyProjectileSpeed);
        base.Update();
    }
}
