Shader "Custom/Surface/SurfaceCustomIlluminationModel"
{
    Properties
    {
        // 主颜色值
        _Color ("Color", Color) = (1,1,1,1)
        // 2D 纹理值
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        // 镜面反射系数
        _Shininess ("Shininess", Range(0, 10)) = 10
    }
    SubShader
    {
        CGPROGRAM
        // 表面着色器编译指令
        #pragma surface surf Phong
        // 2D 纹理属性
        sampler2D _MainTex;
        // 主颜色属性
        fixed4 _Color;
        // 镜面反射系数属性
        float _Shininess;

        struct Input
        {
            // uv 纹理坐标
            float2 uv_MainTex;
        };

        // 光照模型方法
        float4 LightingPhong(SurfaceOutput s, float3 lightDir, half3 viewDir, half atten)
        {
            float4 c;
            // 计算漫反射强度（计算法线和光线的点积）
            float diffuseF = max(0, dot(s.Normal, lightDir));
            // 计算视线与光线的半向量
            float3 H = normalize((viewDir + lightDir));
            // 计算镜面反射强度（计算法线与半向量的点积）
            float specBase = max(0, dot(s.Normal, H));
            float specF = pow(specBase, _Shininess);
            // 结合漫反射光与镜面反射光计算最终光照颜色
            c.rgb = s.Albedo * _LightColor0 * diffuseF * atten + _LightColor0 * specF;
            c.a = s.Alpha;
            return c;
        }

        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            // 根据 UV 坐标从纹理提取颜色
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            // 设置颜色
            o.Albedo = c.rgb;
            // 设置透明度
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}