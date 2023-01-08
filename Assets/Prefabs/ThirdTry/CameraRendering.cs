using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRendering : MonoBehaviour {
    [SerializeField] Camera portalCamera;

    void FixedUpdate() {
        // Créez une nouvelle Render Texture temporaire
        RenderTexture tempRT = RenderTexture.GetTemporary(
            portalCamera.pixelWidth,
            portalCamera.pixelHeight,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Default,
            1
        );

        // Utilisez la méthode Render() de la caméra pour rendre la vue de la caméra dans la Render Texture
        portalCamera.targetTexture = tempRT;
        portalCamera.Render();
        portalCamera.targetTexture = null;
        GetComponent<Renderer>().material.SetTexture("_MainTex", tempRT);
        RenderTexture.ReleaseTemporary(tempRT);
    }
}