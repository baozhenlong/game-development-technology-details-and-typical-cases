using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFogController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 获取摄像机位置
            Vector3 position = transform.position;
            // 如果摄像机的 z 坐标值大于 -224
            if (position.z > -224f)
            {
                // 摄像机向前移动
                position.z -= 1;
                transform.position = position;
            }
        }
        
        if(Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = transform.position;
            if (position.z < 518f)
            {
                position.z += 1;
                transform.position = position;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = transform.position;
            if (position.x < 300f)
            {
                position.x += 1;
                transform.position = position;
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = transform.position;
            if (position.x > -300f)
            {
                position.x -= 1;
                transform.position = position;
            }
        }
    }
}
