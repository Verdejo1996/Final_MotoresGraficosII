using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCell : MonoBehaviour
{
    private Controller_Hud pickUpText;

    public Controller_Doors door;

    private void Start()
    {
        pickUpText = FindObjectOfType<Controller_Hud>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            pickUpText.ShowPickupText("Celda obtenida. Puertas abiertas.");

            Destroy(this.gameObject);

            door.MoveToA();
            door.MoveToB();
        }
    }
}
