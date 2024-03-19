using UnityEngine;

// 赛艇尾部螺旋桨加速转动、减速转动、匀速转动
public class RowingPropeller : MonoBehaviour
{
    // 旋转速度
    float speed;
    // 最小速度
    float minSpeed = -1;
    // 最大速度
    float maxSpeed = -10;
    // 加速标志位
    public static bool addSpeed;
    // 减速标志位
    public static bool minusSpeed;
    // 加速计时标志位
    bool add = true;
    // 减速计时标志位
    bool minus = true;
    // 加速时间
    float addTime;
    // 减速时间
    float minusTime;

    private void Update()
    {
        // 旋转螺旋桨
        transform.Rotate(speed, 0, 0);

        // 加速
        if (addSpeed)
        {
            // 加速计时
            if (add)
            {
                // 计时
                addTime = Time.time;
                // 停止计时
                add = false;
            }
            // 计算速度
            speed = Mathf.Lerp(minSpeed, maxSpeed, Time.time - addTime);
            if (speed == maxSpeed)
            {
                // 到最大速度，停止加速
                addSpeed = false;
            }
        }
        else
        {
            // 开始计时
            add = true;
        }

        // 减速
        if (minusSpeed)
        {
            // 减速计时
            if (minus)
            {
                // 计时
                minusTime = Time.time;
                // 停止计时
                minus = false;
            }
            // 计算速度
            speed = Mathf.Lerp(maxSpeed, minSpeed, Time.time - minusTime);
            if (speed == minSpeed)
            {
                // 到最小速度，停止减速
                minusSpeed = false;
            }
        }
        else
        {
            // 开始计时
            minus = true;
        }
    }
}
