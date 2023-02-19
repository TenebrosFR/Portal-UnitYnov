using System.Collections;
using UnityEngine;
using utils;

public class Door : IsInteractable {
    [SerializeField] Transform Left;
    [SerializeField] Transform Right;
    [SerializeField] Transform LeftClose;
    [SerializeField] Transform RightClose;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform LeftDoor;
    [SerializeField] Transform RightDoor;

    public override void Do(GameObject player, Vector3 lookingDirection) {
        CurrentRoutine = CurrentRoutine.ReloadCoroutine(Move(false));
    }


    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        CurrentRoutine = CurrentRoutine.ReloadCoroutine(Move(true));
    }
    private IEnumerator Move(bool hasToBeClosed) {
        if (hasToBeClosed) {
            do {
                LeftDoor.localPosition = Vector3.MoveTowards(LeftDoor.localPosition,LeftClose.localPosition,moveSpeed);
                RightDoor.localPosition = Vector3.MoveTowards(RightDoor.localPosition,RightClose.localPosition,moveSpeed);
                yield return new WaitForFixedUpdate();
            } while (LeftDoor.localPosition != LeftClose.localPosition || RightDoor.localPosition != RightClose.localPosition);
        }else {
            do {
                Debug.Log("here");
                LeftDoor.localPosition = Vector3.MoveTowards(LeftDoor.localPosition, LeftDoor.localPosition.UpdateAxis(Left.localPosition.x, VectorAxis.X), moveSpeed);
                RightDoor.localPosition = Vector3.MoveTowards(RightDoor.localPosition, RightDoor.localPosition.UpdateAxis(Right.localPosition.x,VectorAxis.X), moveSpeed);
                yield return new WaitForFixedUpdate();
            } while (LeftDoor.localPosition != LeftDoor.localPosition.UpdateAxis(Left.localPosition.x, VectorAxis.X) || RightDoor.localPosition.UpdateAxis(Right.localPosition.x, VectorAxis.X) != Right.localPosition);
        }
    }

}
