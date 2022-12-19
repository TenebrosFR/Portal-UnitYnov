using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour {
    [SerializeField] new Collider collider;
    [SerializeField] Orb bulletPrefab;
    [SerializeField] Camera cam;

    public void OnShoot(InputAction.CallbackContext context) {
        if (!context.performed) return;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        var bullet = Instantiate(bulletPrefab, ray.origin + ( ( collider.bounds.size.z/2) * cam.transform.forward), Quaternion.identity);
        bullet.direction = ray.direction;
    }
}