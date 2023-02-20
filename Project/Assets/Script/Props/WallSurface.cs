using UnityEngine;

public class WallSurface : MonoBehaviour
{
    [SerializeField] WallSurface[] surfaces;
    [SerializeField] WallSurface bot;
    [SerializeField] WallSurface top;
    [SerializeField] public Collider me;

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Portal") SwitchEnabled(false, col);
    }
    private void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Portal") SwitchEnabled(true, col);
    }

    private void SwitchEnabled(bool state, Collider col) {
        bool isTop = col.bounds.center.y < me.bounds.center.y;
        if(bot)bot.me.enabled = isTop ? state : !state;
        if(top)top.me.enabled = isTop ? !state : state;
        me.enabled = state;
    }
}