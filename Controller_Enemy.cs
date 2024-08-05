using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyProjectile;

    private float shootingCooldown;


    internal static Vector3 startPosition;

    public float xLimit;

    public int playerNumber;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //rb = GetComponent<Rigidbody>();
        shootingCooldown = Random.Range(1, 7);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        shootingCooldown -= Time.deltaTime;
        ShootPlayer();
        //CheckLimits();
    }

    void ShootPlayer()
    {
        if (Controller_Player.player != null || MovimientoRobot._robot != null)
        {
            if (shootingCooldown <= 0)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
                shootingCooldown = Random.Range(1, 3);
            }
        }
    }

/*    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }*/
}
