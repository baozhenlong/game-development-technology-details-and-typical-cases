Shader "Custom/Surface/BaseForm"
{
    Properties
    {
        // 定义主颜色值
        _Color ("Color", Color) = (1,1,1,1)
        // 定义纹理值
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        // 定义高光系数值
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        // 定义金属材质系数值
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        // 标签
        Tags
        {
            "RenderType"="Opaque"
        }
        // LOG 数值
        LOD 200

        CGPROGRAM
        // 表面着色器编译指令
        #pragma surface surf Standard fullforwardshadows

        // 着色器编译目标
        #pragma target 3.0

        // 2D 纹理属性
        sampler2D _MainTex;

        // 定义输入参数结构体
        struct Input
        {
            // 纹理 UV 坐标
            float2 uv_MainTex;
        };

        // 生命高光系数
        half _Glossiness;
        // 声明金属材质系数
        half _Metallic;
        // 声明主颜色
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            //根据 UV 坐标从纹理提取颜色
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            // 设置颜色
            o.Albedo = c.rgb;
            // 设置金属材质系数
            o.Metallic = _Metallic;
            // 设置高光系数
            o.Smoothness = _Glossiness;
            // 设置透明度
            o.Alpha = c.a;
        }
        ENDCG
    }
    // 降级着色器
    FallBack "Diffuse"
}