using UnityEngine;

public class PanWithMouse : MonoBehaviour
{
    public Vector2 degree = new(5f, 3f);
    public float range = 1f;
    private Quaternion originalRotation;

    private Vector2 euler = Vector2.zero;

    private void Start()
    {
        originalRotation = transform.localRotation;
    }

    private void Update()
    {
        float halfWidth = Screen.width * .5f;
        float halfHeight = Screen.height * .5f;
        Vector3 position = Input.mousePosition;
        if (range < .1f)
        {
            range = .1f;
        }
        float x = Mathf.Clamp((position.x - halfWidth) / halfWidth / range, -1f, 1f);
        float y = Mathf.Clamp((position.y - halfHeight) / halfHeight / range, -1f, 1f);
        euler = Vector2.Lerp(euler, new Vector2(x, y), Time.deltaTime * 5f);
        // transform.localRotation = originalRotation * Quaternion.Euler(euler.x * degree.x, -euler.y * degree.y, 0f);

    }
}
