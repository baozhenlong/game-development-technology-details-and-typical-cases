using UnityEngine;

public class InputGetAxisTest : MonoBehaviour
{
    private void Update()
    {
        // 按左右键时触发
        float moveX = Input.GetAxis("Horizontal");
        Debug.Log($"GetAxis moveX: {moveX}");
        // 按上下键时触发
        float moveY = Input.GetAxis("Vertical");
        Debug.Log($"GetAxis moveY: {moveY}");
    }
}
