using System;
using UnityEngine;

public class FanController : MonoBehaviour
{
    [Serializable, Tooltip("铰接体")]
    public struct Joint
    {
        // 铰接体对象控制脚本
        public ArticulationJointController controller;
    }

    // 铰接体对象集合
    public Joint[] joints;

    // 停止所有铰接体对向的旋转
    public void StopAllJointsRotation()
    {
        for (var i = 0; i < joints.Length; i++)
        {
            UpdateRotationState(RotationDirectionEnum.None, joints[i].controller);
        }
    }

    // 更新指定铰接体的旋转方向
    public void RotateJoint(int jointIndex, RotationDirectionEnum rotationDirection)
    {
        StopAllJointsRotation();
        UpdateRotationState(rotationDirection, joints[jointIndex].controller);
    }

    // 更新旋转方向
    public void UpdateRotationState(RotationDirectionEnum rotationDirection, ArticulationJointController controller)
    {
        // 改变旋转方向
        controller.UpdateRotationDirection(rotationDirection);
    }
}
