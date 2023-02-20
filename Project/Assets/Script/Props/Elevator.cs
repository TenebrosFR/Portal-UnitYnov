using System.Collections;
using UnityEngine;
using utils;

public class Elevator : IsInteractable
{
    [SerializeField] Transform Piston;
    [SerializeField] float Height = 5.1f;
    [SerializeField] float Speed = 0.1f;
    float targetHeight = 1;
    public override void Do(GameObject player, Vector3 lookingDirection) {
        if (Piston.localScale.y != targetHeight ) return;
        targetHeight = Height;

        CurrentRoutine = CurrentRoutine.ReloadCoroutine(Move(1));
    }

    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        if (Piston.localScale.y != targetHeight ) return;
        targetHeight = 1;

        CurrentRoutine = CurrentRoutine.ReloadCoroutine(Move(-1));

    }
    IEnumerator Move(int orientation) {
        while(Piston.localScale.y != targetHeight) {
            if (orientation == 1 && Piston.localScale.y > targetHeight) Piston.localScale = Piston.localScale.UpdateAxis(Height, VectorAxis.Y);
            else if (orientation == -1 && Piston.localScale.y < targetHeight) Piston.localScale = Piston.localScale.UpdateAxis(1, VectorAxis.Y);
            else Piston.localScale = Piston.localScale.UpdateAxis(Piston.localScale.y + ( Speed * orientation), VectorAxis.Y);

            transform.localPosition = transform.localPosition.UpdateAxis((Piston.localScale.y-1) + 0.05f, VectorAxis.Y);

            yield return new WaitForFixedUpdate();
        }
        CurrentRoutine = null;

    }
}
