Shader "Custom/ZTestLEqual"
{
    SubShader
    {
        // 深度测试
        ZTest LEqual
        
        CGPROGRAM
        // 表面着色器编译指令
        #pragma surface surf Standard fullforwardshadows

        // Input 结构体
        struct Input
        {
            // uv 纹理坐标
            float2 uv_MainTex;
        };

        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // 设置漫反射颜色为白色
            o.Albedo = float3(1, 1, 1);
        }
        ENDCG
    }
}