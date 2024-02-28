using UnityEngine;

public class FanManualInput : MonoBehaviour
{
    public FanController fanController;

    private void Update()
    {
        for (var i = 0; i < fanController.joints.Length; i++)
        {
            // 获取键盘输入
            float inputAxisValue = Input.GetAxis("Horizontal");
            // 获取旋转方向
            RotationDirectionEnum rotationDirection = GetRotationDirection(inputAxisValue);
            if (rotationDirection != RotationDirectionEnum.None)
            {
                // 更新旋转方向
                fanController.RotateJoint(i, rotationDirection);
                return;
            }
        }
        // 停止所有子对象旋转
        fanController.StopAllJointsRotation();
    }

    private RotationDirectionEnum GetRotationDirection(float value)
    {
        if (value > 0)
        {
            return RotationDirectionEnum.Positive;
        }
        if (value < 0)
        {
            return RotationDirectionEnum.Negative;
        }
        return RotationDirectionEnum.None;
    }
}
