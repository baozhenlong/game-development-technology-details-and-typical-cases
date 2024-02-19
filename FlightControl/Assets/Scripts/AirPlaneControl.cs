using UnityEngine;

public class AirPlaneControl : MonoBehaviour
{
    [Tooltip("飞机的飞行速度")]
    public float speed = 6f;
    // 绕 z 轴旋转量，用于保存飞机的实时姿态
    private float rotationZ = .0f;
    [Tooltip("绕 z 轴的旋转速度")]
    public float rotateSpeedAxisZ = 45f;
    [Tooltip("绕 y 轴的旋转速度")]
    public float rotateSpeedAxisY = 30;
    // 触摸点坐标
    private Vector2 touchPosition;
    // 屏幕宽度
    private float screenWidth;
    [Tooltip("螺旋桨")]
    public Transform propellerTransform;

    private float inclinedAngleZ = 45f;

    private void Start()
    {
        // 关闭重力影响
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        // 获取屏幕宽度
        screenWidth = Screen.width;
    }

    private void Update()
    {
        // 向前移动
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        // 螺旋桨绕 y 轴旋转
        propellerTransform.Rotate(new Vector3(0, 100f, 0));
        // 获取飞机绕 x 轴的旋转量
        rotationZ = transform.eulerAngles.z;

        if (Application.isPlaying)
        {
            if (Input.GetMouseButton(0))
            {
                TurnLeft();
            }
            if (Input.GetMouseButton(1))
            {
                TurnRight();
            }
            if (Input.GetMouseButton(2))
            {
                BackToBalance();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        else
        {
            // 触摸的数量大于 0
            if (Input.touchCount > 0)
            {
                for (var i = 0; i < Input.touchCount; i++)
                {
                    // 获取当前触摸点
                    Touch touch = Input.touches[i];
                    // 手指在屏幕上没有移动或发生滑动时触发的事件
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // 获取当前触摸点的坐标
                        touchPosition = touch.position;
                        float halfWidth = screenWidth / 2;
                        // 触摸点在屏幕左半部分
                        if (touchPosition.x < halfWidth)
                        {
                            TurnLeft();
                        }
                        // 触摸点在屏幕右半部分
                        else if (touchPosition.x >= halfWidth)
                        {
                            TurnRight();
                        }
                    }
                    // 手指离开屏幕时触发的事件
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        // 恢复平衡状态
                        BackToBalance();
                    }
                }
            }
            // 没有手指触摸屏幕时
            else if (Input.touchCount == 0)
            {
                BackToBalance();
            }

            // 退出游戏
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    private void TurnLeft()
    {
        // 飞机机身向左倾斜
        if (rotationZ <= inclinedAngleZ || rotationZ >= 360 - inclinedAngleZ)
        {
            float rotatingAngleZ = Time.deltaTime * rotateSpeedAxisZ;
            float targetRotationZ = rotationZ + rotatingAngleZ;
            if (!(targetRotationZ > inclinedAngleZ && targetRotationZ < 360 - inclinedAngleZ))
            {
                transform.Rotate(new Vector3(0, 0, rotatingAngleZ), Space.Self);
            }
        }
        // 飞机左转
        transform.Rotate(new Vector3(0, -Time.deltaTime * rotateSpeedAxisY, 0), Space.World);
    }

    private void TurnRight()
    {
        // 飞机机身向右倾斜
        if (rotationZ <= inclinedAngleZ || rotationZ >= 360 - inclinedAngleZ)
        {
            float rotatingAngleZ = Time.deltaTime * rotateSpeedAxisZ;
            float targetRotationZ = rotationZ - rotatingAngleZ;
            if (!(targetRotationZ > inclinedAngleZ && targetRotationZ < 360 - inclinedAngleZ))
            {
                transform.Rotate(new Vector3(0, 0, -rotatingAngleZ), Space.Self);
            }
        }
        // 飞机右转
        transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeedAxisY, 0), Space.World);
    }


    // 恢复平衡
    private void BackToBalance()
    {
        // 如果飞机为右倾状态
        if (rotationZ <= 180)
        {
            // 在阈值内轻微晃动
            if (rotationZ <= 2)
            {
                transform.Rotate(0, 0, Time.deltaTime * -1);
            }
            // 快速恢复到平衡状态
            else
            {
                transform.Rotate(0, 0, Time.deltaTime * -40);
            }
        }
        // 如果飞机为左倾状态
        else if (rotationZ > 180)
        {
            // 在阈值内轻微晃动
            if (360 - rotationZ <= 2)
            {
                transform.Rotate(0, 0, Time.deltaTime * 1);
            }
            // 快速恢复到平衡状态
            else
            {
                transform.Rotate(0, 0, Time.deltaTime * 40);
            }
        }
    }
}
