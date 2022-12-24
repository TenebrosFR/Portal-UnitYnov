using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IsInteractable : MonoBehaviour
{
    protected Coroutine CurrentRoutine;
    public abstract void Do(GameObject player ,Vector3 lookingDirection);
    public abstract void UnDo(GameObject player, Vector3 lookingDirection);
}
