Shader "Custom/Queue100"
{
    Properties
    {
        // 主颜色值
        _Color ("Main Color", Color) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags
        {
            // 设置渲染队列
            "Queue"="Geometry+200"
        }
        // 关闭深度检测
        ZTest Off
        
        // 表面着色器编译指令
        CGPROGRAM
        #pragma surface surf Lambert

        // 主颜色属性
        fixed4 _Color;
        
        // Input 结构体
        struct Input
        {
            float2 uv_MainTex;
        };

        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            // 设置对象表面颜色
            o.Albedo = _Color;
        }
        ENDCG
    }
}