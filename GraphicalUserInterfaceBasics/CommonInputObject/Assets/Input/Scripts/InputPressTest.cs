using UnityEngine;

public class InputPressTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire GetButton");
        }
        if (Input.GetKey("up"))
        {
            Debug.Log("Up Arrow GetKey");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow KeyCode GetKey");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("left mouse button GetMouseButton");
        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("right mouse button GetMouseButton");
        }
        if (Input.GetMouseButton(2))
        {
            Debug.Log("middle mouse button GetMouseButton");
        }
    }
}
