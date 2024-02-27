using UnityEngine;

public class InputGetAxisRawTest : MonoBehaviour
{
    private void Update()
    {
        // 按左右键时触发
        float rawMoveX = Input.GetAxisRaw("Horizontal");
        Debug.Log($"GetAxisRaw moveX: {rawMoveX}");
        // 按上下键时触发
        float rawMoveY = Input.GetAxisRaw("Vertical");
        Debug.Log($"GetAxisRaw moveY: {rawMoveY}");
    }
}
