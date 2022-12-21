using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbedOrb : MonoBehaviour
{
    [SerializeField] new Light light;
    [SerializeField] LayerMask orbLayer;
    [SerializeField] IsInteractable Script;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != Mathf.Log(orbLayer, 2)) return;
        light.color = Color.blue;
        if(Script)Script.Do(other.gameObject,Vector3.zero);
        Destroy(other.gameObject);
    }
}
