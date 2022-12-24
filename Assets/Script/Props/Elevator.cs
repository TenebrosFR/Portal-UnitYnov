using System.Collections;
using UnityEngine;
using utils;

public class Elevator : IsInteractable
{
    [SerializeField] Collider Piston;
    [SerializeField] Rigidbody rb;
    [SerializeField] float Height = 5.1f;
    [SerializeField] float Speed = 0.1f;
    [SerializeField] Vector3 originalPosition;
    [SerializeField] Vector3 target;
    private void Start() {
        originalPosition = transform.position;
        target = transform.position + (Vector3.up * Height);
    }
    public override void Do(GameObject player, Vector3 lookingDirection) {
        if (transform.position != originalPosition) return;
        target = transform.position + (Vector3.up * Height);
        CurrentRoutine.ReloadCoroutine(Move(1));
    }

    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        if (transform.position != target) return;
        target = originalPosition;
        CurrentRoutine.ReloadCoroutine(Move(-1));
    }
    IEnumerator Move(int orientation) {
        while(transform.position != target) {
            Piston.transform.localScale = Piston.transform.localScale.UpdateAxis(Piston.transform.localScale.y + ( Speed * orientation), VectorAxis.Y);
            rb.MovePosition(transform.position.UpdateAxis((Piston.bounds.size.y/2)-1.35f, VectorAxis.Y));
            if (orientation == 1 && transform.position.y > target.y) transform.position = target;
            if (orientation == -1 && transform.position.y < target.y) transform.position = target;
            yield return new WaitForFixedUpdate();
        }
    }
}
