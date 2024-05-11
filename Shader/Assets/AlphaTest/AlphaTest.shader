Shader "Custom/AlphaTest"
{
    Properties
    {
        // 主颜色值
        _Color ("Color", Color) = (1,1,1,1)
        // 2D 纹理
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        // Alpha 范围
        _CutOff ("Alpha cutoff", Range(0, 9)) = 0.0
    }
    SubShader
    {
        Tags
        {
            // 设置渲染队列为 AlphaTest
            "RenderType"="AlphaTest"
        }
        Pass
        {
            Material
            {
                // 设置漫反射颜色
                Diffuse [_Color]
                // 设置环境光颜色
                Ambient [_Color]
            }
            // 进行 Alpha 测试
            AlphaTest GEqual [_CutOff]
            // 打开光照
            Lighting On
            // 设置纹理
            SetTexture[_MainTex]
            {
                // 颜色常量
                ConstantColor [_Color]
                // 计算最终颜色
                Combine texture * primary Double, texture * constant
            }
        }
    }
}