using UnityEngine;


public class Portaltemp : MonoBehaviour
{
    [SerializeField] Portaltemp other;
    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Immovable") || col.gameObject.CompareTag("Player")) return;
        if (col.gameObject.CompareTag("PlayerCenter")) {
            col.transform.parent.position = other.transform.position + other.transform.forward;
            col.transform.parent.GetComponent<PlayerRotation>().PortalWantRotation(other.transform,transform);
        }
        else {
            col.gameObject.transform.SetPositionAndRotation(other.transform.position + other.transform.forward, Quaternion.LookRotation(other.transform.forward));
        }
    }
}