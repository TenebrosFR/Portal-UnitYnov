using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRendering : MonoBehaviour {
    [SerializeField] Camera portalCamera;

    void FixedUpdate() {
        // Cr�ez une nouvelle Render Texture temporaire
        RenderTexture tempRT = RenderTexture.GetTemporary(
            portalCamera.pixelWidth,
            portalCamera.pixelHeight,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Default,
            1
        );

        // Utilisez la m�thode Render() de la cam�ra pour rendre la vue de la cam�ra dans la Render Texture
        portalCamera.targetTexture = tempRT;
        portalCamera.Render();
        portalCamera.targetTexture = null;
        GetComponent<Renderer>().material.SetTexture("_MainTex", tempRT);
        RenderTexture.ReleaseTemporary(tempRT);
    }
}