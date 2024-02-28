using UnityEngine;

public enum RotationDirectionEnum
{
    None = 0,
    Positive = 1,
    Negative = -1
}

public class ArticulationJointController : MonoBehaviour
{
    // 旋转方向
    private RotationDirectionEnum rotationDirection = RotationDirectionEnum.None;
    [Tooltip("旋转速度")]
    public float speed = 100.0f;
    // 铰接体对象
    private ArticulationBody articulationBody;
    private void Start()
    {
        // 获取铰接体对象
        articulationBody = GetComponent<ArticulationBody>();
    }
    private void FixedUpdate()
    {
        // 更新旋转角度
        if (rotationDirection != RotationDirectionEnum.None)
        {
            // 计算旋转角度增量
            float rotationChange = (float)rotationDirection * speed * Time.fixedDeltaTime;
            // 计算旋转总角度
            float rotation = GetCurrentPrimaryAxisRotation() + rotationChange;
            // 旋转
            RotateTo(rotation);
        }
    }

    // 获取当前旋转角度
    private float GetCurrentPrimaryAxisRotation()
    {
        // 获取铰接体的 x 位置
        float rad = articulationBody.jointPosition[0];
        // 计算对应旋转角度
        float rotation = Mathf.Rad2Deg * rad;
        return rotation;
    }

    // 旋转
    private void RotateTo(float rotation)
    {
        // 获取 x 轴运动
        ArticulationDrive xDrive = articulationBody.xDrive;
        // 设置旋转角度
        xDrive.target = rotation;
        articulationBody.xDrive = xDrive;
    }

    public void UpdateRotationDirection(RotationDirectionEnum rotationDirection)
    {
        this.rotationDirection = rotationDirection;
    }
}
