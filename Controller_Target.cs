using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Target : MonoBehaviour
{
    public int targetNumber;

    public bool playerOnTarget;
    

    private void Start()
    {
        playerOnTarget = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
/*            if (Controller_Player.renderer != null && Controller_Player.renderer.material != null)
            {
                Controller_Player.renderer.material.EnableKeyword("_EmissionColor");
                //Controller_Player.renderer.material.SetTexture("Emission Map", Controller_Player.player.targetTexture);
                Controller_Player.renderer.material.SetColor("_EmissionColor", Color.red);
            }*/

            if (other.GetComponent<Controller_Player>().playerNumber == targetNumber)
            {
                playerOnTarget = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<Controller_Player>().playerNumber == targetNumber)
            {
                playerOnTarget = false;
                //Debug.Log("P off T");
            }
        }
    }
}
