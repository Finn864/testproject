using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour
{
    private float rotationSpeed = 20f;

    private float moveSpeed = 5f;
    private float moveHeight = 0.1f;
    private float positionHeight = 2.5f;

    private List<string> powerUps = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        AddPowerUps();
    }

    // Update is called once per frame
    void Update()
    {
        RotateBlock();
    }

    private void RotateBlock()
    {
        transform.Rotate(0, 0, (Time.deltaTime * rotationSpeed));

        // Move the block up and down using a sine wave
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveHeight;
        transform.position = new Vector3(transform.position.x, newY + positionHeight, transform.position.z);
    }

    private void AddPowerUps()
    {
        powerUps.Add("Speed");
        powerUps.Add("Slow");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PowerUpsController>())
        {
            int randomIndex = Random.Range(0, powerUps.Count);

            PowerUpsController powerUpsController = other.gameObject.GetComponent<PowerUpsController>();

            powerUpsController.RandomPowerUp(powerUps[randomIndex]);
        }

        Destroy(gameObject);
    }
}
