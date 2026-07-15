using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] PowerUpType type;

    public PowerUpType Type
    {
        get 
        {
            return type;
        }
    }
}
