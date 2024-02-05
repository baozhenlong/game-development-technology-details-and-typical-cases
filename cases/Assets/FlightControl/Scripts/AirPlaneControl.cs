using UnityEngine;
using UnityEngine.UIElements;

public class AirPlaneControl : MonoBehaviour
{
    [Tooltip("飞机的飞行速度")]
    public float speed = 600f;
    // 绕 z 轴旋转量，用于保存飞机的实时姿态
    private float rotationZ = .0f;
    [Tooltip("绕 z 轴的旋转速度")]
    public float rotateSpeedAxisZ = 45f;
    [Tooltip("绕 y 轴的旋转速度")]
    public float rotateSpeedAxisY = 20f;
    // 触摸点坐标
    private Vector2 touchPosition;
    // 屏幕宽度
    private float screenWidth;
    [Tooltip("螺旋桨")]
    public Transform propellerTransform;

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
        propellerTransform.Rotate(new Vector3(0, 1000f * Time.deltaTime, 0));

        // 控制飞机左右转向
        rotationZ = transform.eulerAngles.z;
        // 触摸的数量大于 0
        if(Input.touchCount > 0){
            for (var i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                    // 手指在屏幕上没有移动或发生滑动时触发的事件
                if(touch.phase == TouchPhase.Stationary|| touch.phase == TouchPhase.Moved)
                {
                    // 获取当前触摸点的坐标
                    touchPosition = touch.position;
                    if(touchPosition.x < screenWidth / 2){
                        
                    }
                }
            }
        }
    }
}
