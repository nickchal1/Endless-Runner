using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 3f;

    Vector2 movement;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        //Debug.Log(movement);
    }

    private void HandleMovement()
    {
        Vector3 currPos = rb.position;
        Vector3 moveDir = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPos = currPos + moveSpeed * Time.fixedDeltaTime * moveDir;

        newPos.x = Mathf.Clamp(newPos.x, -xClamp, xClamp);
        newPos.z = Mathf.Clamp(newPos.z, -zClamp, zClamp);

        rb.MovePosition(newPos);
    }

}
