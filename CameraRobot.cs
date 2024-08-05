using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRobot : MonoBehaviour
{
    public GameObject robot;
    public Camera _camera;
    public float dampTime = 0.15f;
    public float smoothTime = 2f;
    public float zoomvalue;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (robot != null)
        {
            Vector3 point = _camera.WorldToViewportPoint(robot.transform.position);
            Vector3 delta = robot.transform.position - _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.4f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
