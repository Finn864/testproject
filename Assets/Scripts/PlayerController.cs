using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;
    private float _speedLimit = 80f;


    private float turningSpeed = 120;
    private float horizontalInput;
    private float verticalInput;
    private bool accelerate;
    private bool decelerate;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float SpeedLimit
    {
        get => _speedLimit;
        set => _speedLimit = value;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        DriveCar();
    }

    void DriveCar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            accelerate = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            accelerate = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            decelerate = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            decelerate = false;
        }

        if (accelerate)
        {
            int variable = 2;
            if (Speed <= SpeedLimit) Speed += variable;
        }
        else if (!accelerate && Speed != 0)
        {
            if (Speed > 0) Speed -= 1.0f;
        }

        if (decelerate)
        {
            int variable = 1;
            if (Speed >= -20) Speed -= variable;
        }
        else if (!decelerate && Speed != 0)
        {
            if (Speed < 0) Speed += 1;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        float invertedHorizontalInput = horizontalInput * Mathf.Sign(verticalInput);

        if (Speed > 0) transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turningSpeed);
        if (Speed < 0) transform.Rotate(Vector3.up, invertedHorizontalInput * Time.deltaTime * turningSpeed);
    }

    public void ChangeSpeed()
    {

    }
}
