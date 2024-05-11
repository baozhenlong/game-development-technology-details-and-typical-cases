Shader "Custom/TessellationPhong"
{
    Properties
    {
        // 定义边线长度区间
        _EdgeLength ("Edge length", Range(2,50)) = 5
        // 定义 Phong 值区间
        _Phong ("Phong stength", Range(0,1)) = 0.5
        // 定义 2D 纹理属性，默认白色
        _MainTex ("Base (RGB)", 2D) = "white" {}
        // 定义主颜色值
        _Color ("Color", Color) = (1,1,1,0)
        // 定义颜色值
        _Tess ("Tess", Range(1,32)) = 3
    }
    SubShader
    {
        // 设置标签
        Tags
        {
            "RenderType"="Opaque"
        }
        // 设置 LOD 值
        LOD 200

        CGPROGRAM
        // 表面着色器编译指令
        #pragma surface surf Lambert vertex:dispNone tessellate:tessEdge tessphong:_Phong nolightmap

        // 引用 Tesselation.cginc
        #include "Tessellation.cginc"

        // 定义顶点属性结构体
        struct appdata
        {
            // 定义坐标值
            float4 vertex:POSITION;
            // 定义法线值
            float3 normal:NORMAL;
            // 定义坐标值
            float2 texcoord:TEXCOORD0;
        };
        void dispNone(inout appdata v)
        {
            
        }
        // 声明 Phong 值
        float _Phong;
        // 声明边线长度
        float _EdgeLength;
        // 获取新的顶点坐标
        float4 testEdge(appdata v0, appdata v1, appdata v2)
        {
            return UnityEdgeLengthBasedTess(v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
        }

        // 定义输入参数结构体
        struct Input
        {
            // 纹理 UV 坐标
            float2 uv_MainTex;
        };

        // 声明颜色值
        fixed4 _Color;
        // 声明主纹理图
        sampler2D _MainTex;
        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            // 设置反射率
            o.Albedo = c.rgb;
            // 设置透明度
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}