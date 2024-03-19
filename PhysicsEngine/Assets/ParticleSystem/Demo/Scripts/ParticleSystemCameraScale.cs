using UnityEngine;
public class ParticleSystemCameraScale : MonoBehaviour
{

    private void Start()
    {
        int customManualWidth = 960;
        int customManualHeight = 640;
        int manualHeight;
        if (System.Convert.ToSingle(Screen.height) / Screen.width > System.Convert.ToSingle(customManualHeight) / customManualWidth)
            manualHeight = Mathf.RoundToInt(System.Convert.ToSingle(customManualWidth) / Screen.width * Screen.height);
        else
        {
            manualHeight = customManualHeight;
        }
        Camera camera = GetComponent<Camera>();
        float scale = System.Convert.ToSingle(manualHeight / 640f);
        camera.fieldOfView *= scale;
    }
}