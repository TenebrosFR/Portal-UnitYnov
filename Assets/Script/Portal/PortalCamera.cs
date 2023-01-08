using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform OtherPortal;

    private void FixedUpdate() {
        if(transform.rotation.y == 180 && transform) {

        }
        //transform.rotation = PlayerCamera.transform.rotation;
    }
}
