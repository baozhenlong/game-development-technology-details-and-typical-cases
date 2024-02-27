using UnityEngine;

public class InputLiftTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Fire GetButtonUp");
        }
        if (Input.GetKeyUp("up"))
        {
            Debug.Log("Up Arrow GetKeyUp");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow KeyCode GetKeyUp");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("left mouse button GetMouseButtonUp");
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("right mouse button GetMouseButtonUp");
        }
        if (Input.GetMouseButtonUp(2))
        {
            Debug.Log("middle mouse button GetMouseButtonUp");
        }
    }
}
