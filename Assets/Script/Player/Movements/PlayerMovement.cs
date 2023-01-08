using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using utils;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    [SerializeField] float movementForce = 1;
    [SerializeField] float JumpSpeed = 1;
    [SerializeField] float JumpDuration = 1;
    bool isJumping;
    Vector3 currentDirection;
    bool isGrounded;
    public void OnMovement(InputAction.CallbackContext context) {
        if(!context.performed) return;
        currentDirection = context.ReadValue<Vector3>();
    }
    public void OnJump(InputAction.CallbackContext context) {
        if (!context.performed ||!isGrounded) return;
        isJumping = true;
        StartCoroutine(stopJumping());
    }

    private IEnumerator stopJumping() {
        yield return new WaitForSeconds(JumpDuration);
        isJumping = false;
    }

    void FixedUpdate() {
        var forwardMovement = (transform.forward * currentDirection.z).normalized;
        var sideMovement = (transform.right * currentDirection.x).normalized;
        rb.AddForce((forwardMovement + sideMovement).Restricted(false,true).normalized * Time.fixedDeltaTime * movementForce, ForceMode.VelocityChange);
        if(isJumping)   rb.AddForce(Vector3.up * JumpSpeed * Time.fixedDeltaTime, ForceMode.Acceleration);
        isGrounded = false;
    }
    void OnCollisionStay(Collision collision) {
        isGrounded = collision.contacts.Where(contact => contact.point.y < transform.position.y).ToList().Count > 0;
    }
}