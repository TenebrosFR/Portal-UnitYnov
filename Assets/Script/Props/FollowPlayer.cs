using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    Vector3 objDirection;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objDirection = player.transform.forward;
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        transform.Rotate(Vector3.right * (transform.rotation.x + 90));
    }
}
