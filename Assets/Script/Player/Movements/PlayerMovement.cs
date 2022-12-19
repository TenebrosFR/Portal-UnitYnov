using UnityEngine;
using UnityEngine.InputSystem;
using utils;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed = 1;
    Vector3 currentDirection;
    public void OnMovement(InputAction.CallbackContext context) {
        if(!context.performed) return;
        currentDirection = context.ReadValue<Vector3>();
    }

    void FixedUpdate() {
        var forwardMovement = (transform.forward * currentDirection.z).normalized * Time.fixedDeltaTime * Speed;
        var sideMovement = (transform.right * currentDirection.x).normalized * Time.fixedDeltaTime * Speed;
        rb.velocity = (forwardMovement + sideMovement).Restricted(false,true);
    }
}