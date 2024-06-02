using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float turningSpeed = 120;
    private float horizontalInput;
    private float verticalInput;
    private bool accelerate;
    private bool decelerate;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        if (Input.GetKeyDown(KeyCode.W))
        {
            accelerate = true;
        } else if (Input.GetKeyUp(KeyCode.W))
        {
            accelerate = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            decelerate = true;
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            decelerate = false;
        }

        if (accelerate)
        {
            int variable = 2;
            if (speed <= 80) speed += variable;
        }
        else if (!accelerate && speed != 0)
        {
            if (speed > 0) speed -= 1.0f;
        }

        if (decelerate)
        {
            int variable = 1;
            if (speed >= -20) speed -= variable;
        }
        else if (!decelerate && speed != 0)
        {
            if (speed < 0) speed += 1;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        float invertedHorizontalInput = horizontalInput * Mathf.Sign(verticalInput);

        if (speed > 0) transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turningSpeed);
        if (speed < 0) transform.Rotate(Vector3.up, invertedHorizontalInput * Time.deltaTime * turningSpeed);
    }
}
