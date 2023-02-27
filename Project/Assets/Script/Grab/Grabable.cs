using UnityEngine;

public class Grabable : IsInteractable
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    override public void Do(GameObject player, Vector3 lookingDirection) {
        player.GetComponent<PlayerData>().objectGrabbed = gameObject;
        rb.useGravity = false;
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), col, true);
    }
    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        player.GetComponent<PlayerData>().objectGrabbed = null;
        rb.useGravity = true;
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), col, false);
    }
}