using UnityEngine;

public class RowingShowFPS : MonoBehaviour
{

    public float updateInterval = 0.5f;

    private float lastInterval;

    private int frames = 0;

    private float fps;

    private void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 100, 200, 200), "FPS:" + fps.ToString("f2"));
    }

    private void Update()
    {
        frames += 1;

        if (Time.realtimeSinceStartup > lastInterval + updateInterval)
        {
            fps = frames / (Time.realtimeSinceStartup - lastInterval);

            frames = 0;

            lastInterval = Time.realtimeSinceStartup;
        }
    }
}
