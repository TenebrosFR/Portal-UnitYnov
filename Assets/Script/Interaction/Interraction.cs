using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interraction : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] new Collider collider;
    [SerializeField] float interactDistance;
    Interactable interaction;
    public void OnInterraction(InputAction.CallbackContext context) {
        if (context.performed) {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            Physics.Raycast(ray.origin,ray.direction,out RaycastHit firstHit, interactDistance);
            if (firstHit.transform) {
                if(interaction = firstHit.transform.GetComponent<Interactable>()) {
                    interaction.Script.Do(gameObject,cam.transform.forward);
                }
            }
        }else if (context.canceled) {
            if (interaction) interaction.Script.UnDo(gameObject, cam.transform.forward);
            interaction = null;
         }
    }
    void FixedUpdate() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));  
        Debug.DrawLine(ray.origin, ray.direction * 10000, Color.red);
    }
}