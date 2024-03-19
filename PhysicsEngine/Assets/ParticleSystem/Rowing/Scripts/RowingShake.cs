using UnityEngine;

// 赛艇模拟在水面上随水流摆动
public class RowingShake : MonoBehaviour
{
    // x 轴旋转速度
    float rotateSpeedX = 0.04f;
    // z 轴旋转速度
    float rotateSpeedZ = 0.06f;
    float shakeFactor = 4;

    private void Update()
    {
        // x 轴旋转最大限度
        if (transform.eulerAngles.x >= shakeFactor && transform.eulerAngles.x <= 180)
        {
            rotateSpeedX = -0.04f;
        }
        // x 轴旋转最最小限度
        if (transform.eulerAngles.x <= 360 - shakeFactor && transform.eulerAngles.x > 180)
        {
            rotateSpeedX = 0.04f;
        }
        // z 轴旋转最大限度
        if (transform.eulerAngles.z >= shakeFactor && transform.eulerAngles.z <= 180)
        {
            rotateSpeedZ = -0.06f;
        }
        // z 轴旋转最最小限度
        if (transform.eulerAngles.z <= 360 - shakeFactor && transform.eulerAngles.z > 180)
        {
            rotateSpeedZ = 0.06f;
        }
        transform.Rotate(rotateSpeedX, 0, rotateSpeedZ);
    }
}
