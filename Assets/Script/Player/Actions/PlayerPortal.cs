using UnityEngine;
using UnityEngine.InputSystem;
using utils;

public class PlayerPortal : MonoBehaviour
{
    [SerializeField] Portaltemp[] Portals;
    [SerializeField] LayerMask TargetPortal;
    [SerializeField] Camera aim;
    public void OnShootPortal(InputAction.CallbackContext context) {
        if (!context.performed) return;
        if (Physics.Raycast(aim.transform.position, aim.transform.forward, out var objectHit)) {
            if (objectHit.transform.gameObject.layer == Mathf.Log(TargetPortal.value, 2)) SpawnPortal((int)context.ReadValue<float>(), objectHit);
        }
    }

    private void SpawnPortal(int index, RaycastHit hit) {
        var center = hit.collider.bounds.center;
        Portals[index].transform.SetPositionAndRotation( new Vector3(center.x,center.y - 0.5f,hit.point.z), Quaternion.LookRotation(hit.normal));
    }
}
