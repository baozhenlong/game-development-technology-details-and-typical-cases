Shader "Custom/Surface/SurfaceFinalColor"
{
    Properties
    {
        // 2D 纹理值
        _MainTex ("Texture", 2D) = "white" {}
        // 调色数值
        _ColorTint ("Tint", Color) = (1.0, 0.6, 0.6, 1.0)
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        CGPROGRAM
        // 表面着色器编译指令（finalColor:myColor 告诉编译器表面着色器名称为 myColor 的为最终颜色修改方法）
        #pragma surface surf Lambert finalColor:myColor
        // Input 结构体
        struct Input
        {
            // UV 纹理坐标
            float2 uv_MainTex;
        };
        // 调色数值属性
        fixed4 _ColorTint;
        // 2D 纹理属性
        sampler2D _MainTex;

        // 最终颜色修改方法
        void myColor(Input IN, SurfaceOutput o, inout fixed4 color)
        {
            // 通过调色数值修改最终颜色
            color *= _ColorTint;
        }

        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // 从纹理提取颜色为漫反射颜色赋值
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    // 降级着色器
    FallBack "Diffuse"
}