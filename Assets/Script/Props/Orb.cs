using System;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using utils;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Orb  : MonoBehaviour { 

    [SerializeField] public float Speed;
    [SerializeField] public Rigidbody rb;
    [SerializeField] LayerMask PlayerLayer;
    public Vector3 direction = Vector3.zero;
    private void Start() {
        rb.velocity = direction * Speed;
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

