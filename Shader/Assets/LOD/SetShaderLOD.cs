using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderLOD : MonoBehaviour
{
    // 着色器
    public Shader myShader;
    // LOD 数值
    private float lodValue = 6f;

    private void Update()
    {
        // 设置最大 LOD 数值
        myShader.maximumLOD = (int)lodValue * 100;
    }

    private void OnGUI()
    {
        // 显示控制 LOD 数值的滑动条控件
        lodValue = (int)GUI.HorizontalSlider(new Rect(250, 125, 300, 30), lodValue, 3, 6);
        GUI.Label(new Rect(333, 100, 170, 30), "Current LOD is: "+ lodValue * 100);
    }
}
