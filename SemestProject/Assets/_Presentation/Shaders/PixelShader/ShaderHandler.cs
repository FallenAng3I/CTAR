using UnityEngine;

namespace Shaders
{
    [ExecuteInEditMode]
    public class ShaderHandler : MonoBehaviour
    {
        public Material effectMaterial;

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(source, destination, effectMaterial);
        }
    }
}
