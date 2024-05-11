using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFogCS : MonoBehaviour
{
    // 主摄像机
    private GameObject cameraGameObject;
    
    // 扰动起始角
    private float startAngle = 0;

    private Renderer render;

    private void Awake()
    {
        cameraGameObject = Camera.main.gameObject;
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        // 不断改变扰动起始角
        startAngle %= (startAngle + 0.05f);
        // 将摄像机位置传递给着色器
        render.material.SetVector("_CameraPosition", cameraGameObject.transform.position);
        // 将扰动起始角传递给着色器
        render.material.SetFloat("_StartAngle", startAngle);
    }
}
