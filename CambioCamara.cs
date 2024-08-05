using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CambioCamara : GameManager
{
    internal static CambioCamara _cambio;

    public Camera mainCamera; // La c�mara principal
    public Camera newCamera;  // La nueva c�mara que queremos activar
    public MonoBehaviour movimientoRobot;
    public MonoBehaviour boxMovement;

    //public float detectionRadius = 3f;
    public GameObject eMessage;
    public GameObject player;

    public float messageDuration = 3f; // Duraci�n del mensaje en segundos

    private bool isMessageVisible = false;

    private void Awake()
    {
        if (_cambio == null)
        {
            _cambio = this;
            DontDestroyOnLoad(_cambio);
            DontDestroyOnLoad(mainCamera);
            DontDestroyOnLoad(newCamera);
        }
        else
        {
            Destroy(_cambio);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        eMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (changeCamera == true)
        {
            newCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            movimientoRobot.enabled = true;
            
        }
        
    }

    private void GetInput()
    {
        // Detecta si el jugador presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            activeMove = true;
            SwitchCamera();
            DisablePlayerMovement();

            Debug.Log("E pressed");
        }
   
    }

/*    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            activeMove = true;
            SwitchCamera();
            DisablePlayerMovement();
        }
    }*/

    void SwitchCamera()
    {
        if (mainCamera != null && newCamera != null)
        {

            mainCamera.gameObject.SetActive(false);
            newCamera.gameObject.SetActive(true);
        }
        
    }

    void DisablePlayerMovement()
    {
        if (movimientoRobot != null)
        {
            movimientoRobot.enabled = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            ShowEMessage();
        }
        

    }

    public void ShowEMessage()
    {
       
        // Si el jugador est� dentro del radio de detecci�n y el mensaje no est� visible
        if (!isMessageVisible)
        {
            StartCoroutine(ShowMessageForDuration());

        }



    }
    IEnumerator ShowMessageForDuration()
    {
        // Muestra el mensaje
        eMessage.SetActive(true);
        isMessageVisible = true;

        // Espera la duraci�n del mensaje
        yield return new WaitForSeconds(messageDuration);

        // Oculta el mensaje despu�s del tiempo especificado
        eMessage.SetActive(false);
        isMessageVisible = false;
    }


}

