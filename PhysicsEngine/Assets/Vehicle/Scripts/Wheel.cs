using UnityEngine;

public class Wheel : MonoBehaviour
{
    [Tooltip("车轮碰撞体")]
    public WheelCollider wheelCollider;
    [Tooltip("车轮滚动角")]
    public float cirValue = 0;

    void Update()
    {
        transform.rotation = wheelCollider.transform.rotation * Quaternion.Euler(cirValue, wheelCollider.steerAngle, 0);
        cirValue += wheelCollider.rpm * 360 / 60 * Time.deltaTime;
    }
}
