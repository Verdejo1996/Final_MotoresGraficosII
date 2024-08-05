using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MovimientoRobot : MonoBehaviour
{
    internal static MovimientoRobot _robot;

    public Animator animator;

    private float x, y;

    public Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private Vector3 v3;

    public float jumpForce;
    public float moveSpeed = 5f;
    private bool isGrounded;

    public Transform puntoInicial;
    public GameObject robot;

    private float rotationSpeed = 100f;
    private bool facingRight = true;

    private int itemCount = 0;
    private Controller_Hud pickUpText;

    public void MoverAPuntoInicial()
    {
        robot.transform.position = puntoInicial.transform.position;

        Debug.Log(robot.transform.position);
    }

/*    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (_robot == null)
            {
                _robot = this;
                DontDestroyOnLoad(gameObject);
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    /*    public override bool IsOnSomething()
        {
            return Physics.Raycast(transform.position, Vector3.down, out downHit, 1.1f);
        }*/

    public void MovimientoPersonaje()
    {
        x = Input.GetAxis("Horizontal");

        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight)
            {
                Flip();
            }
        }

        //transform.Translate(x * Time.deltaTime * moveSpeed, y * Time.deltaTime * moveSpeed, 0);

        Vector3 movement = new Vector3 (x, y, 0f) * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position +  movement);

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        animator.SetFloat("Velx", x);
        animator.SetFloat("VelY", y);

    }


    void Start()
    {
        pickUpText = FindObjectOfType<Controller_Hud>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicialRobot").transform;
        rb.position = puntoInicial.position;
        /*        Debug.Log(robot.transform.position);
                MoverAPuntoInicial();*/

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        MovimientoPersonaje();
/*        if (Input.GetKeyDown(KeyCode.S))
        {
            capsuleCollider.center.Set(0, 1.39f, 0);
            capsuleCollider.height = 0.51f;
        }*/
        v3 = rb.position;
        v3.z = 0f;
        rb.position = v3;
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(this.gameObject);
            GameManager.gameOver = true;
        }
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cell"))
        {
            itemCount++;
            if (itemCount < 4)
            {
                pickUpText.ShowPickupText("Celda obtenida. Tienes: " + itemCount);
            }
            else
            {
                pickUpText.ShowPickupText("Celda obtenida. Ya puede recoger el orbe.");
            }

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Water"))
        {
            Destroy(this.gameObject);
            GameManager.gameOver = true;
        }
    }

    void Flip()
    {
        // Cambia la dirección a la que está mirando el personaje
        facingRight = !facingRight;

        // Multiplica la escala x del personaje por -1 para invertir la dirección
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        //MovimientoPersonaje();

    }

    /*    void MoveCharacter()
        {
            // Movimiento en el eje X
            float moveX = Input.GetAxis("Horizontal") * moveSpeed;

            // Configurar el vector de movimiento
            Vector3 move = new Vector3(moveX, rb.velocity.y, 0);

            // Aplicar el movimiento al Rigidbody
            rb.velocity = move;

            // Salto con la tecla W
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }*/

    // Verificar si el personaje está en el suelo
    /*    private bool IsGrounded()
        {
            // Asumiendo que el personaje tiene un Collider
            return Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }*/
}
