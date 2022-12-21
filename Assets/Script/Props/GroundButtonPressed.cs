using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButtonPressed : MonoBehaviour {
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
        if (objectsInside.Count == 0) Pressed();
        objectsInside.Add(other);
    }
    private void OnTriggerExit(Collider other) {
        objectsInside.Remove(other);
        if (objectsInside.Count <= 0) UnPressed();
    }
    void Pressed() {
        target = originalPosition + (Vector3.down * 1.2f);
        StartCoroutine(HorizontalMove(true));
    }

    void UnPressed() {
        target = originalPosition;
        StartCoroutine(HorizontalMove(false));
    }

    IEnumerator HorizontalMove(bool started) {
        float startTime = Time.time;
        while (Time.time < startTime + pressedAnimTime) {
            ButtonToMove.transform.localPosition = Vector3.Lerp(ButtonToMove.transform.localPosition, target, (Time.time - startTime) / pressedAnimTime);
            yield return null;
        }
        ButtonToMove.transform.localPosition = target;
        if (Script && started) Script.Do(gameObject,Vector3.zero);
        else if (Script && !started) Script.UnDo(gameObject,Vector3.zero);
    }
}
