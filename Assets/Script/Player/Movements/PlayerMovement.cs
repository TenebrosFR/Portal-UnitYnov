using UnityEngine;
using UnityEngine.InputSystem;
using utils;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    [SerializeField] float Speed = 1;
    Vector3 currentDirection;
    bool isGrounded;
    public void OnMovement(InputAction.CallbackContext context) {
        if(!context.performed) return;
        currentDirection = context.ReadValue<Vector3>();
    }

    void FixedUpdate() {
        var forwardMovement = (transform.forward * currentDirection.z).normalized * Time.fixedDeltaTime * Speed;
        var sideMovement = (transform.right * currentDirection.x).normalized * Time.fixedDeltaTime * Speed;
        var currentGravity = isGrounded ? Vector3.zero : Physics.gravity;
        rb.velocity = (forwardMovement + sideMovement).Restricted(false,true) + currentGravity;
        isGrounded = false;
    }
    void OnCollisionStay(Collision collision) {
        isGrounded = ((collision.contacts[0].point - transform.position).y < 0 && collision.gameObject.layer == LayerMask.NameToLayer("Ground"));
    }
}