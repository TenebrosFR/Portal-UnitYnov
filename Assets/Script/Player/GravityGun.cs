using UnityEngine;
using utils;

public class GravityGun : MonoBehaviour {
    [SerializeField] PlayerData Data;
    [SerializeField] Camera cam;
    [SerializeField] float moveSpeed = 1f;
    Rigidbody objectRigidbody;
    public float offset = 2;

    void FixedUpdate() {
        if(!Data.objectGrabbed) return;
        if (!objectRigidbody || objectRigidbody.transform != Data.objectGrabbed.transform) objectRigidbody = Data.objectGrabbed.GetComponent<Rigidbody>();
        objectRigidbody.MovePosition(Vector3.Lerp(Data.objectGrabbed.transform.position, (cam.transform.position + (cam.transform.forward) * offset), Time.fixedDeltaTime * moveSpeed));
        objectRigidbody.transform.LookAt(transform);
    }
}
