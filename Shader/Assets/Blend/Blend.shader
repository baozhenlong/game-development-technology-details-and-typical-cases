Shader "Custom/Blend"
{
    Properties
    {
        // 主颜色值
        _Color ("Color", Color) = (1,1,1,1)
        // 2D 纹理
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            // 设置渲染队列为 Transparent
            "RenderType"="Transparent"
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
            // 开启混合
            Blend SrcAlpha OneMinusSrcAlpha
            // 开灯
            Lighting On
            // 设置纹理
            SetTexture[_MainTex]
            {
                // 颜色常量
                ConstantColor [_Color]
                // 计算最终颜色
                Combine texture * Primary Double, texture * Constant
            }
        }
    }
}