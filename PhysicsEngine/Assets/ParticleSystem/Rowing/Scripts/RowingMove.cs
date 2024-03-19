using UnityEngine;

public class RowingMove : MonoBehaviour
{
    [Tooltip("摇杆")]
    public EasyJoystick myJoystick;
    // 移动速度
    float moveSpeed = 0.05f;
    // 旋转速度
    float rotateSpeed = 0.5f;
    // 尾部水花
    public GameObject tailSplashGameObject;
    private void Start()
    {
        tailSplashGameObject.SetActive(false);
    }

    private void Update()
    {
        // 摇杆到右半部分
        if (myJoystick.JoystickTouch.x > 0.5f)
        {
            // 赛艇向右旋转
            transform.Rotate(0, rotateSpeed, 0);
            // 螺旋桨加速
            RowingPropeller.addSpeed = true;
        }
        // 摇杆到左半部分
        if (myJoystick.JoystickTouch.x < -0.5f)
        {
            // 赛艇向左旋转
            transform.Rotate(0, -rotateSpeed, 0);
            // 螺旋桨加速
            RowingPropeller.addSpeed = true;
        }
        // 摇杆到上半部分
        if (myJoystick.JoystickTouch.y > 0.5f)
        {
            // 尾部水花可见
            tailSplashGameObject.SetActive(true);
            // 赛艇向前移动
            transform.Translate(0, 0, moveSpeed);
            // 螺旋桨加速
            RowingPropeller.addSpeed = true;
        }
        // 摇杆到下半部分
        if (myJoystick.JoystickTouch.y < -0.5f)
        {
            // 赛艇向后移动
            transform.Translate(0, 0, -moveSpeed);
            // 螺旋桨加速
            RowingPropeller.addSpeed = true;
        }
        // 摇杆未移动
        if (myJoystick.JoystickTouch.x == 0 && myJoystick.JoystickTouch.y == 0)
        {
            // 尾部水不可见
            tailSplashGameObject.SetActive(false);
            // 螺旋桨减速
            RowingPropeller.minusSpeed = true;
        }
    }
}
