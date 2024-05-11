Shader "Custom/FixedLine/BaseForm" {
    // 定义属性块
    Properties {
        // 定义主颜色数值
        _Color ("Main Color", Color) = (1, 1, 1, 0.5)
        // 定义高光颜色数值
        _SpecularColor ("Specular Color", Color) = (1, 1, 1, 1)
        // 定义自发光颜色数值
        _EmissionColor ("Emission Color", Color) = (0, 0, 0, 0)
        // 定义高光系数数值
        _Shininess ("Shininess", Range(0.01, 1)) = 0.7
        // 定义纹理数值
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }

    SubShader {
        Pass {
            // 材质块
            Material {
                // 漫反射
                Diffuse [_Color]
                // 环境光
                Ambient [_Color]
                // 高光系数
                Shininess [_Shininess]
                // 高光
                Specular [_SpecularColor]
                // 自发光
                Emission [_EmissionColor]
            }
            // 开启关照
            Lighting On
            // 允许高光使用一个不同于主颜色的颜色
            SeparateSpecular On
            // 处理纹理块
            SetTexture [_MainTex]
            // 定义颜色值
            ConstantColor [_Color]
            // 计算最终颜色值
            Combine texture * primary double, texture + constant
        }
    }
}