using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using utils;

public class CubeSpawner : IsInteractable
{
    [SerializeField] Transform spawnLocation;
    [SerializeField] GameObject door;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] float openDelay;
    [SerializeField] float doorSpeed = 0.1f;
    [SerializeField] bool continuousDo = false;
    GameObject cube;

    public override void Do(GameObject player, Vector3 lookingDirection) {
        if (door.transform.localScale == Vector3.one) StartCoroutine(OpenOrCloseDoor(0));
    }


    public override void UnDo(GameObject player, Vector3 lookingDirection) {
        if (!continuousDo && door.transform.localScale == Vector3.zero) StartCoroutine(OpenOrCloseDoor(1));
    }
    private IEnumerator OpenOrCloseDoor(int target) {
        var direction = target == 0 ? -1 : 1;
        do {
            door.transform.localScale = door.transform.localScale + direction * (Vector3.one * doorSpeed);
            yield return new WaitForFixedUpdate();
        }
        while ( (direction == 1 && door.transform.localScale.x < 1) || (direction == -1 && door.transform.localScale.x > 0));
        door.transform.localScale = Vector3.one * target;
    }
    void FixedUpdate() {
        if (!cube) cube = Instantiate(cubePrefab, spawnLocation.position,Quaternion.identity);
        if (continuousDo) Do(gameObject,Vector3.zero);
    }

}
