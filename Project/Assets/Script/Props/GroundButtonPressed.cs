using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class GroundButtonPressed : IsInteractable {
    [SerializeField] GameObject ButtonToMove;
    [SerializeField] float pressedAnimTime;
    [SerializeField] IsInteractable Script;
    List<Collider> objectsInside = new List<Collider>();
    Vector3 target;
    Vector3 originalPosition;
    private void Start() {
        originalPosition = ButtonToMove.transform.localPosition;
    }
    private void OnTriggerEnter(Collider other) {
        if (objectsInside.Count == 0) Do(gameObject,Vector3.zero);
        objectsInside.Add(other);
    }
    public override void Do(GameObject player, Vector3 lookingDirection) {
        target = originalPosition + (Vector3.down * 1.2f);
        CurrentRoutine = CurrentRoutine.ReloadCoroutine(HorizontalMove(true));
    }
    private void OnTriggerExit(Collider other) {
        objectsInside.Remove(other);
        if (objectsInside.Count <= 0) UnDo(gameObject, Vector3.zero);
    }

    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        target = originalPosition;
        CurrentRoutine = CurrentRoutine.ReloadCoroutine(HorizontalMove(false));
    }

    IEnumerator HorizontalMove(bool started) {
        if (Script && started) Script.Do(gameObject,Vector3.zero);
        else if (Script && !started) Script.UnDo(gameObject,Vector3.zero);
        float startTime = Time.time;
        while (Time.time < startTime + pressedAnimTime) {
            ButtonToMove.transform.localPosition = Vector3.Lerp(ButtonToMove.transform.localPosition, target, (Time.time - startTime) / pressedAnimTime);
            yield return null;
        }
        ButtonToMove.transform.localPosition = target;
        CurrentRoutine = null;
    }
}