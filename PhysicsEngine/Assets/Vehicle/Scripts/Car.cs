using UnityEngine;

public class Car : MonoBehaviour
{
    [Tooltip("车前左侧车轮碰撞体")]
    public WheelCollider frontLeftWheelCollider;
    [Tooltip("车前右侧车轮碰撞体")]
    public WheelCollider frontRightWheelCollider;
    [Tooltip("虚拟摇杆")]
    public EasyJoystick myJoystick;
    [Tooltip("最大力矩")]
    public float maxTorque = 500;
    [Tooltip("最大旋转角")]
    public float maxAngle = 20;
    private void Start()
    {
        // 调整赛车刚体重心
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -0.8f, 0);
    }
    private void FixedUpdate()
    {
        // 控制力矩
        frontLeftWheelCollider.motorTorque = maxTorque * myJoystick.JoystickTouch.y;
        // 控制旋转角
        frontLeftWheelCollider.steerAngle = maxAngle * myJoystick.JoystickTouch.x;
        frontRightWheelCollider.motorTorque = maxTorque * myJoystick.JoystickTouch.y;
        frontRightWheelCollider.steerAngle = maxAngle * myJoystick.JoystickTouch.x;
    }
}
