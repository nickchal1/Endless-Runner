using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] PowerUpBehavior powerUpBehavior;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (powerUpBehavior.IsShieldActive())
            {
                Destroy(other.gameObject);
                return;
            }
            //no shield
            gameManager.GameOver();
            Debug.Log("Hit");
            return;
        }
        
        if (other.gameObject.tag == "PowerUp")
        {
            PowerUpPickup pickup = other.GetComponent<PowerUpPickup>();

            if (pickup != null)
            {
                //Debug.Log("collected: " + pickup.Type);
                powerUpBehavior.AddPowerUp(pickup.Type);
                Destroy(other.gameObject);

            }
        }
    }
}
