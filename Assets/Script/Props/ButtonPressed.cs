using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {

    [SerializeField] float pressedAnimTime;
    [SerializeField] DoSomething Script;
    List<Collider> objectsInside = new List<Collider>();
    Vector3 target;
    Vector3 originalPosition;
    private void Start() {
        originalPosition = transform.localPosition;
    }
    private void OnTriggerEnter(Collider other) {
        objectsInside.Add(other);
        if(objectsInside.Count == 1)Pressed();
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
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, (Time.time - startTime) / pressedAnimTime);
            yield return null;
        }
        transform.localPosition = target;
        if (Script && started) Script.Do(gameObject);
        else if (Script && !started) Script.UnDo(gameObject);
    }
}
