using UnityEngine;
using utils;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform OtherPortal;

    private void OnTriggerEnter(Collider other) {
        other.gameObject.transform.position = OtherPortal.transform.position;
        other.gameObject.transform.rotation = Quaternion.LookRotation(transform.forward);
    }
}
