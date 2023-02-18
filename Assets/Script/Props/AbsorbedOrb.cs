using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbedOrb : MonoBehaviour
{
    [SerializeField] new Light light;
    [SerializeField] LayerMask orbLayer;
    [SerializeField] IsInteractable Script;
    [SerializeField] bool autoDesactivate;
    [SerializeField] float DesactivateTime;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != Mathf.Log(orbLayer, 2)) return;

        light.color = Color.blue;
        if(Script && Script.CurrentRoutine == null) Script.Do(other.gameObject,Vector3.zero);
        Destroy(other.gameObject);
    }

    public void FixedUpdate() {
        if (autoDesactivate && light.color == Color.blue && Script.CurrentRoutine == null) StartCoroutine(Desactivate());
    }

    private IEnumerator Desactivate() {
        yield return new WaitForSeconds(DesactivateTime);
        light.color = Color.yellow + Color.red;
        Script.UnDo(this.gameObject, Vector3.zero);
    }
}
