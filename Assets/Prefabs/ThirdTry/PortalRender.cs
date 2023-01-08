using UnityEngine;

public class PortalRender : MonoBehaviour {
    [SerializeField] Camera camera1;
    [SerializeField] Camera camera2;
    [SerializeField] RenderTexture renderTexture1;
    [SerializeField] RenderTexture renderTexture2;

    void Update() {
        // Mettre � jour la texture de rendu du portail 1 avec l'image captur�e par la cam�ra 1
        Graphics.Blit(renderTexture1, camera1.targetTexture);
        // Mettre � jour la texture de rendu du portail 2 avec l'image captur�e par la cam�ra 2
        Graphics.Blit(renderTexture2, camera2.targetTexture);
    }
}
