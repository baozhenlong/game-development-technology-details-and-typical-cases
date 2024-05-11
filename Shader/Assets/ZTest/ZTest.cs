using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTest : MonoBehaviour
{
    // 渲染器组件
    public Renderer renderer;
    // 材质数组
    public Material[] materials;
    // 用于显示当前深度测试模式
    public string[] labels;
    // 滑动条控件和显示控件的位置和大小
    public Rect sliderPosition, tipPosition;
    // 渲染器当前使用材质的序列号
    public int n;

    private void Start()
    {
        // 获取渲染器组件
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        renderer.material = materials[n];
    }

    private void OnGUI()
    {
        // 显示滑动条控件并获取滑动条控件的值
        n = (int)GUI.HorizontalSlider(sliderPosition, n, 0, 6);
        // 显示当前深度测试模式
        GUI.Label(tipPosition, "Current ZTest " + labels[n]);
    }
}
