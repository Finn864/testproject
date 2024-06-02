using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    private float speedPower = 50f;
    private float timer = 10f;
    private bool activePowerUp;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateCheck();
    }

    public void RandomPowerUp(string powerUp)
    {
        if (powerUp == "Speed")
        {
            activePowerUp = true;
            IncreaseSpeed();
        }
        else if (powerUp == "Slow")
        {
            DecreaseSpeed();
        }
    }

    void IncreaseSpeed()
    {
        if (!activePowerUp)
        {
            playerController.Speed -= speedPower;
            playerController.SpeedLimit -= speedPower;
            return;
        }

        playerController.SpeedLimit += speedPower;
        playerController.Speed += speedPower;

    }

    void DecreaseSpeed()
    {
        if (!activePowerUp)
        {
            playerController.Speed += speedPower;
            playerController.SpeedLimit += speedPower;
            return;
        }

        playerController.SpeedLimit -= speedPower;
        playerController.Speed -= speedPower;

    }

    void ActivateCheck()
    {
        if (activePowerUp)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                activePowerUp = false;
                IncreaseSpeed();
            }
        }
    }

}

