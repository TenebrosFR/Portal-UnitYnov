using System;
using System.Collections;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using utils;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Orb  : MonoBehaviour { 

    [SerializeField] public float Speed;
    [SerializeField] public float lifetime = 10f;
    [SerializeField] public Rigidbody rb;
    [SerializeField] LayerMask PlayerLayer;
    public void Shoot(Vector3 direction) {
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
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == Mathf.Log(PlayerLayer.value, 2)) {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

