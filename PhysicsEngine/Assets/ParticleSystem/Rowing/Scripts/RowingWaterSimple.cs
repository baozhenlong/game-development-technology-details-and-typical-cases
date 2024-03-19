using UnityEngine;

[ExecuteInEditMode]
public class RowingWaterSimple : MonoBehaviour
{

    private Renderer rendererComponent;
    private Material rendererMaterial;
    void Awake()
    {
        rendererComponent = GetComponent<Renderer>();
        if (rendererComponent)
        {
            rendererMaterial = rendererComponent.sharedMaterial;
        }
    }

    private void Update()
    {
        if (!rendererComponent)
        {
            return;
        }
        if (!rendererMaterial)
        {
            return;
        }

        Vector4 waveSpeed = rendererMaterial.GetVector("WaveSpeed");
        float waveScale = rendererMaterial.GetFloat("_WaveScale");
        float t = Time.time / 20.0f;

        Vector4 offset4 = waveSpeed * (t * waveScale);
        Vector4 offsetClamped = new(Mathf.Repeat(offset4.x, 1.0f), Mathf.Repeat(offset4.y, 1.0f), Mathf.Repeat(offset4.z, 1.0f), Mathf.Repeat(offset4.w, 1.0f));
        rendererMaterial.SetVector("_WaveOffset", offsetClamped);
    }
}
