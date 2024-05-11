Shader "Custom/LODShader"
{
    // 使对象渲染为红色的 SubShader
    SubShader
    {
        // 设置 LOD 的数值为 600
        LOD 600

        // 表面着色器编译指令
        CGPROGRAM
        #pragma surface surf Lambert

        // Input 结构体
        struct Input
        {
            float2 uv_MainTex;
        };

        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            // 设置颜色为红色
            o.Albedo = float3(1, 0, 0);
        }
        ENDCG
    }

    // 使对象渲染为绿色的 SubShader
    SubShader
    {
        // 设置 LOD 数值为 400
        LOD 500
        
        // 表面着色器编译指令
        CGPROGRAM
        #pragma surface surf Lambert
        // Input 结构体
        struct  Input
        {
            float2 uv_MainTex;
        };
        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = float3(0, 1, 0);
        }
        ENDCG
    }

    // 使对象渲染为蓝色的 SubShader
    SubShader
    {
        // 设置 LOD 数值为 400
        LOD 400
        
        // 表面着色器编译指令
        CGPROGRAM
        #pragma surface surf Lambert
        // Input 结构体
        struct  Input
        {
            float2 uv_MainTex;
        };
        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = float3(0, 0, 1);
        }
        ENDCG
    }
}