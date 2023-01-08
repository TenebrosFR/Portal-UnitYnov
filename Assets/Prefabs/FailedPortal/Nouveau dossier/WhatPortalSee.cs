using UnityEngine;
using utils;
public class WhatPortalSee : MonoBehaviour {

	[SerializeField] Transform player;
	[SerializeField] Transform me;
	[SerializeField] Transform other;
	[SerializeField] float angularDiff;
    [SerializeField] Quaternion rotationDiff;
	private Camera cam;

	void Start() {
		cam = gameObject.GetComponent<Camera>();
	}
	void FixedUpdate () {
        Vector3 playerDistanceFromOther = player.position.Sub(other.position).Abs();
        transform.position = me.position + playerDistanceFromOther;
        angularDiff = Quaternion.Angle(me.rotation, other.rotation);
		rotationDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
		Vector3 newCameraDirection = rotationDiff * player.forward;
		transform.rotation = Quaternion.LookRotation(-newCameraDirection, Vector3.up);
	}
}
