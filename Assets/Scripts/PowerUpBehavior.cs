using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    [SerializeField] float powerUpDuration = 5f;
    [SerializeField] LeverGenerator levelGenerator;
    [SerializeField] float speedBoostMultiplier = 1.5f;
    [SerializeField] float slowMotionMultiplier = 0.5f;

    Queue<PowerUpType> powerUpQueue = new Queue<PowerUpType>();
    bool powerUpActive;
    bool shieldActive;

    void ActivatePowerUp(PowerUpType type)
    {
        
        if (type == PowerUpType.SpeedBoost)
        {
            levelGenerator.SetSpeedMultiplier(speedBoostMultiplier);
        }
        else if (type == PowerUpType.SlowMotion)
        {
            levelGenerator.SetSpeedMultiplier(slowMotionMultiplier);
        }
        else if (type == PowerUpType.Shield)
        {
            shieldActive = true;
        }
    }

    void DeactivatePowerUp(PowerUpType type)
    {
        if (type == PowerUpType.SpeedBoost || type == PowerUpType.SlowMotion)
        {
            levelGenerator.SetSpeedMultiplier(1f);
        }
        if (type == PowerUpType.Shield)
        {
            shieldActive = false;
        }
    }

    public void AddPowerUp(PowerUpType type)
    {
        powerUpQueue.Enqueue(type);

        Debug.Log("q: " + type);

        if (!powerUpActive)
        {
            powerUpActive = true;
            StartCoroutine(ProcessPowerUpQueue());
        }
    }

    IEnumerator ProcessPowerUpQueue()
    {
        while (powerUpQueue.Count > 0)
        {
            PowerUpType currentPowerUp = powerUpQueue.Dequeue();

            Debug.Log("active: " + currentPowerUp);

            ActivatePowerUp(currentPowerUp);
            yield return new WaitForSeconds(powerUpDuration);
            //deact after?
            DeactivatePowerUp(currentPowerUp);
            Debug.Log("finish: " + currentPowerUp);
        }

        powerUpActive = false;
    }

    //getter
    public bool IsShieldActive()
    {
        return shieldActive;
    }

}
