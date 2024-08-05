using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrb : MonoBehaviour
{
    public Transform puntoInicial;
    public GameObject orb;
    // Start is called before the first frame update
    void Start()
    {
        orb = GameObject.FindGameObjectWithTag("OrbLvl");
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicial").transform;
        MoverAPuntoInicial();
    }

    public void MoverAPuntoInicial()
    {
        orb.transform.position = puntoInicial.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
