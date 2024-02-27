using System;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    [Tooltip("球体游戏对象的引用")]
    public GameObject ballGameObject;
    // 上一次两根手指的距离
    private float lastDistance = .0f;
    // 主摄像机距离球体的距离
    private float cameraDistance = -20f;
    [Tooltip("缩放阻尼")]
    public float scaleDump = 0.1f;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            // 获取单指触控点
            Touch touch = Input.GetTouch(0);
            // 手指移动终端
            if (touch.phase == TouchPhase.Moved)
            {
                // 垂直旋转
                ballGameObject.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y"), Space.World);
                // 水平旋转
                ballGameObject.transform.Rotate(Vector3.up, -1f * Input.GetAxis("Mouse X"), Space.World);
            }
        }
        else if (Input.touchCount > 1)
        {
            // 获取第一个触控点
            Touch touch1 = Input.GetTouch(0);
            // 获取第二个触控点
            Touch touch2 = Input.GetTouch(1);
            if (touch2.phase == TouchPhase.Began)
            {
                // 初始化 lastDistance
                lastDistance = Vector2.Distance(touch1.position, touch2.position);
            }
            // 两根手指都在移动，推进或拉远主摄像机
            else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                // 计算手指位置
                float distance = Vector2.Distance(touch1.position, touch2.position);
                // 若是手指距离 > 1
                float deltaDistance = distance - lastDistance;
                if (Mathf.Abs(deltaDistance) > 1)
                {
                    // 设置主摄像机到物体的距离
                    cameraDistance += deltaDistance * scaleDump;
                    // 限制主摄像机到物体的距离
                    cameraDistance = Math.Clamp(cameraDistance, -40, -5);
                    // 备份本次触摸结果
                    lastDistance = distance;
                }
            }
        }
    }

    private void LateUpdate()
    {
        // 调整主摄像机的位置
        transform.position = new Vector3(0, 0, cameraDistance);
    }

    private void OnGUI()
    {
        string message = string.Format("Input.touchCount = {0}\ncameraDistance = {1}", Input.touchCount, cameraDistance);
        GUI.TextArea(new Rect(0, 0, Screen.width * .1f, Screen.height), message);
    }
}
