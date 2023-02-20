using UnityEngine;

public class Grabable : IsInteractable
{
    [SerializeField] Rigidbody rb;
    override public void Do(GameObject player, Vector3 lookingDirection) {
        player.GetComponent<PlayerData>().objectGrabbed = gameObject;
        rb.useGravity = false;
    }
    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        player.GetComponent<PlayerData>().objectGrabbed = null;
        rb.useGravity = true;
    }
}