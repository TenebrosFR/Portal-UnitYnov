using UnityEngine;

public class Reinitialisator : MonoBehaviour
{
    [SerializeField] LayerMask PlayerLayer;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == Mathf.Log(PlayerLayer, 2)) GameManager.Instance.PlayerResetPortal();
    }
}
