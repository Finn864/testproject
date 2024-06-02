using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWheels : MonoBehaviour
{
    public GameObject wheel;
    private float rotationSpeed = 100f;
    private float maxSteerAngle = 30f;
    private float currentSteerAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        currentSteerAngle = steerInput * maxSteerAngle;

        if (wheel.name == "Voorwiel Links")
        {
            transform.localRotation = Quaternion.Euler(0, currentSteerAngle, 0);
        }
        else if (wheel.name == "Voorwiel Rechts")
        {
            transform.localRotation = Quaternion.Euler(0, currentSteerAngle, 180);
        }

        transform.Rotate(Vector3.right, forwardInput * rotationSpeed);
    }
}