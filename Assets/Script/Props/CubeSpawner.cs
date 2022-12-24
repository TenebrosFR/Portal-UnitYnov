using System.Collections;
using UnityEngine;
using utils;

public class CubeSpawner : IsInteractable
{
    [SerializeField] Transform spawnLocation;
    [SerializeField] GameObject door;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] float doorSpeed = 0.1f;
    [SerializeField] bool continuousDo = false;
    GameObject cube;
    public override void Do(GameObject player, Vector3 lookingDirection) {
        if (door.transform.localScale == Vector3.one) NewTarget(0);
    }
    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        if (!continuousDo && door.transform.localScale == Vector3.zero) NewTarget(1);
    }
    private void NewTarget(int val) {
        CurrentRoutine.ReloadCoroutine(OpenOrCloseDoor(val));
    }
    private IEnumerator OpenOrCloseDoor(int target) {
        var direction = target == 0 ? -1 : 1;
        do {
            door.transform.localScale = door.transform.localScale + direction * (Vector3.one * doorSpeed);
            yield return new WaitForFixedUpdate();
        }
        while ( (direction == 1 && door.transform.localScale.x <= 1) || (direction == -1 && door.transform.localScale.x >= 0));
        door.transform.localScale = Vector3.one * target;
    }
    void FixedUpdate() {
        if (!cube) cube = Instantiate(cubePrefab, spawnLocation.position,Quaternion.identity);
        if (continuousDo) Do(gameObject,Vector3.zero);
    }

}
