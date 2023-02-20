using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerPortal : MonoBehaviour
{
    [SerializeField] public Portaltemp[] Portals;
    [SerializeField] LayerMask TargetPortal;
    [SerializeField] Camera aim;
    [SerializeField] public Image[] images;
    public void OnShootPortal(InputAction.CallbackContext context) {
        if (!context.performed) return;
        if (Physics.Raycast(aim.transform.position, aim.transform.forward, out var objectHit)) {
            if (objectHit.transform.gameObject.layer == Mathf.Log(TargetPortal.value, 2)) SpawnPortal((int)context.ReadValue<float>(), objectHit);
        }
    }

    private void SpawnPortal(int index, RaycastHit hit) {
        var center = hit.collider.bounds.center;
        Portals[index].transform.SetPositionAndRotation( new Vector3(center.x,Mathf.Round(hit.point.y)+0.1f ,hit.point.z), Quaternion.LookRotation(hit.normal));
        if (!images[index].enabled) images[index].enabled = true;
    }
}
