using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class Shoot : MonoBehaviour
{
    [SerializeField] Orb orbPrefab;
    [SerializeField] new Light light;
    [SerializeField] float delayBeforeShooting = 3f;
    Orb currentOrb;
    bool preparingToShoot = false;

    private void FixedUpdate() {
        if (currentOrb || preparingToShoot) return;
        light.color = Color.red;
        preparingToShoot = true;
        StartCoroutine(PrepareToShoot());
    }

    private IEnumerator PrepareToShoot() {
        yield return new WaitForSeconds(delayBeforeShooting);
        light.color = Color.yellow;
        preparingToShoot = false;
        currentOrb = Instantiate(orbPrefab, light.transform.position, Quaternion.identity);
        currentOrb.Shoot(Vector3.forward);
    }
}
