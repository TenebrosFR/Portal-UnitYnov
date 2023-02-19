using UnityEngine;

public class Portaltemp : MonoBehaviour
{
    [SerializeField] Portaltemp other;
    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Immovable") || col.gameObject.CompareTag("PlayerCenter")) return;
        if (col.gameObject.CompareTag("Player")) {
            col.transform.position = other.transform.position + other.transform.forward;
            col.transform.GetComponent<PlayerRotation>().PortalWantRotation(other.transform,transform);
        }
        else if(col.gameObject.tag != "Immovable"){
            col.gameObject.transform.SetPositionAndRotation(other.transform.position + other.transform.forward, Quaternion.LookRotation(other.transform.forward));
            col.GetComponent<Rigidbody>().velocity = other.transform.forward;
        }
    }
}