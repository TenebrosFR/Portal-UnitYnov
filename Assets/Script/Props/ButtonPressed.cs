using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : IsInteractable
{
    [SerializeField] public IsInteractable Script;
    [SerializeField] float pressedAnimTime;
    [SerializeField] float pressedDuration;
    [SerializeField] float distance;
    Vector3 target;
    Vector3 originalPosition;
    private void Start() {
        originalPosition = transform.localPosition;
    }
    public override void Do(GameObject player, Vector3 lookingDirection) {
        if (transform.localPosition != originalPosition) return; 
        target = originalPosition + (-transform.up * distance);
        StartCoroutine(Move());
    }

    public override void UnDo(GameObject player, Vector3 lookingDirection) {
    }
    IEnumerator Move() {
        float startTime = Time.time;
        while (Time.time < startTime + pressedAnimTime) {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, (Time.time - startTime) / pressedAnimTime);
            yield return null;
        }
        transform.localPosition = target;
        if(Script)Script.Do(gameObject,Vector3.zero);
        yield return new WaitForSeconds(pressedDuration);
        target = originalPosition;
        startTime = Time.time;
        while (Time.time < startTime + pressedAnimTime) {
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, (Time.time - startTime) / pressedAnimTime);
            yield return null;
        }
        if(Script)Script.UnDo(gameObject, Vector3.zero);
    }
}

