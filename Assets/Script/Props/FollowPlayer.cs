using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        transform.Rotate(Vector3.right * (transform.rotation.x + 90));
    }
}