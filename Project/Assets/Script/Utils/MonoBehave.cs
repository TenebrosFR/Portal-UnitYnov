using System;
using System.Collections;
using UnityEngine;

public class MonoBehave : MonoBehaviour {
    public Coroutine ReloadCoroutine(Coroutine current, IEnumerator ToLoad) {
        if(current != null)StopCoroutine(current);
        return StartCoroutine(ToLoad);
    }
}