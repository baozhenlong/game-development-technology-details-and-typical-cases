using UnityEngine;

public class InputHoldTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire GetButtonDown");
        }
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Up Arrow GetKeyDown");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow KeyCode GetKeyDown");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left mouse button GetMouseButtonDown");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right mouse button GetMouseButtonDown");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("middle mouse button GetMouseButtonDown");
        }
    }

}
