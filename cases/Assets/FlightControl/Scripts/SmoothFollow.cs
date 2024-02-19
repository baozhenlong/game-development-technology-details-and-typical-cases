using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField]
    // 要跟随的目标对象
    private Transform targetTransform = null;
    [SerializeField]
    // 与目标对象的距离
    private float distance = 10.0f;
    [SerializeField]
    // 与目标对象的高度差
    private float height = 5.0f;
    [SerializeField]
    // 高度变化中的阻尼参数
    private float heightDamping = 2.0f;
    [SerializeField]
    // 绕 y 轴的旋转中的阻尼参数
    private float rotatingDamping = 3.0f;

    private void LateUpdate()
    {
        if (!targetTransform)
        {
            Debug.Log("没找到飞机");
            return;
        }

        // 摄像机期望的旋转角度及高度
        float expectedRotatingAngleY = targetTransform.eulerAngles.y;
        float expectedHeight = targetTransform.position.y + height;

        // 摄像机当前的旋转角度及高度
        float currentRotatingAngleY = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // 计算摄像机绕 y 轴的旋转中的阻尼
        currentRotatingAngleY = Mathf.LerpAngle(currentRotatingAngleY, expectedRotatingAngleY, rotatingDamping * Time.deltaTime);

        // 计算摄像机高度变化中的阻尼
        currentHeight = Mathf.Lerp(currentHeight, expectedHeight, heightDamping * Time.deltaTime);

        // 转换成旋转角度
        Quaternion currentRotation = Quaternion.Euler(0, currentRotatingAngleY, 0);

        // 摄像机距离目标背后的距离
        transform.position = targetTransform.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // 设置摄像机的高度
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // 摄像机一直注视目标
        transform.LookAt(targetTransform);
    }
}