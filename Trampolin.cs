using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float trampolineForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(new Vector3(0, trampolineForce, 0), ForceMode.Impulse);
        }
    }
}
