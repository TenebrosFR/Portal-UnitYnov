using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using utils;

public class GameManager : MonoBehaviour
{
    [SerializeField] MonoBehave monoBehaveScript;
    [SerializeField] GameObject player;
    public static GameManager Instance;
    void Start()
    {
        Instance = this;
        StaticMethod.MonoBehave = monoBehaveScript;
    }

    public void FixedUpdate() {
        if (player == null) SceneManager.LoadScene(0);
    }
    
    public void PlayerResetPortal() {
        var playerPortal = player.GetComponent<PlayerPortal>();
        foreach (Image image in playerPortal.images)
            image.enabled = false;
        foreach(Portaltemp portal in playerPortal.Portals)
            portal.transform.position = new Vector3(1000,1000,1000);
    }
}
