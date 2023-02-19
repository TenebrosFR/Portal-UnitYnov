using System.Collections;
using UnityEngine;

public class Orb  : MonoBehaviour { 

    [SerializeField] public float Speed;
    [SerializeField] public float lifetime = 10f;
    [SerializeField] public Rigidbody rb;
    [SerializeField] LayerMask PlayerLayer;
    public Shoot parent;
    public void Shoot(Vector3 direction, Shoot creator) {
        parent = creator;
        rb.velocity = direction * Speed;
        StartCoroutine(DieInSeconds());
    }

    private IEnumerator DieInSeconds() {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
    void FixedUpdate() {
        if(rb.velocity.magnitude != Speed) rb.velocity = rb.velocity.normalized * Speed;
    }
}

