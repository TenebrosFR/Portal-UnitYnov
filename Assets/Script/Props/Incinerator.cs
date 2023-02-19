using System.Collections;
using UnityEditor;
using UnityEngine;

public class Incinerator : IsInteractable {
    [SerializeField] IsInteractable Script;
    [SerializeField] GameObject thingToDestroyForDo;
    [SerializeField] LayerMask movableLayer;
    [SerializeField] Transform door;
    [SerializeField] float doorSpeed = 0.1f;
    int value = 0;
    public override void Do(GameObject player, Vector3 lookingDirection) {
        if (door.transform.localScale == Vector3.one) StartCoroutine(OpenOrCloseDoor(value));
    }
    public override void UnDo(GameObject player, Vector3 lookingDirection) {
    }
    private IEnumerator OpenOrCloseDoor(int target) {
        var direction = target == 0 ? -1 : 1;
        do {
            door.transform.localScale = door.transform.localScale + direction * (Vector3.one * doorSpeed);
            yield return new WaitForFixedUpdate();
        }
        while ((direction == 1 && door.transform.localScale.x < 1) || (direction == -1 && door.transform.localScale.x > 0));
        door.transform.localScale = Vector3.one * target;
        if (value == 0) value = 1;
        else value = 0;
        CurrentRoutine = null;

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != Mathf.Log(movableLayer, 2)) return;
        if (thingToDestroyForDo != PrefabUtility.GetCorrespondingObjectFromSource(other.gameObject) && Script) Script.Do(gameObject, Vector3.zero);
        Destroy(other.gameObject);
    }
}
