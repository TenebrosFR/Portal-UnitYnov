using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using utils;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    [SerializeField] float movementForce = 1;
    [SerializeField] float JumpSpeed = 1;
    [SerializeField] float JumpDuration = 1;
    [SerializeField] LayerMask PlayerLayer;
    bool isJumping;
    Vector3 currentDirection;
    public void OnMovement(InputAction.CallbackContext context) {
        if(!context.performed && !context.canceled) return;
        currentDirection = context.ReadValue<Vector3>();
    }
    public void OnJump(InputAction.CallbackContext context) {
        if (!context.performed || !isGrounded() || isJumping ) return;
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
        //Conserve la velocity dans l'axe vertical + calcul de la nouvelle vitesse en horizontal
        rb.velocity = rb.velocity.Restricted(true,false,true) + (movementForce * Time.fixedDeltaTime * (forwardMovement + sideMovement).Restricted(false,true).normalized);
        //Force de saut
        if (isJumping) rb.AddForce(Vector3.up * JumpSpeed * Time.fixedDeltaTime, ForceMode.Force);
    }
    bool isGrounded() {
        Vector3 bottomCenter = col.bounds.min + col.bounds.extents.Restricted(false, true);
        return Physics.OverlapCapsule(bottomCenter, 
            //Bottom Center - largeur du collider /2 en dessous pour check un peu plus bas que le joueur
            bottomCenter.UpdateAxis(bottomCenter.y - col.bounds.extents.x/2,VectorAxis.Y),
            col.bounds.extents.x / 2).Where(hit => hit.gameObject.layer != Mathf.Log(PlayerLayer,2)).Count() > 0;
    }
    void OnDrawGizmos() {   
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(col.bounds.min+col.bounds.extents.Restricted(false,true), col.bounds.extents.x);
    }
}