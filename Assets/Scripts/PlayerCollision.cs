using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
        }
        
        if (other.gameObject.tag == "PowerUp")
        {
            PowerUpPickup pickup = other.GetComponent<PowerUpPickup>();

            if (pickup != null)
            {
                Debug.Log("collected " + pickup.Type);
                Destroy(other.gameObject);
            }
        }
    }
}
