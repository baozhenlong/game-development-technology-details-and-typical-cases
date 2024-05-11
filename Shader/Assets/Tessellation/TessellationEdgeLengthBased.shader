Shader "Custom/TessellationEdgeLengthBased"
{
    Properties
    {
        // 定义边线长度区间
        _EdgeLength ("Edge length", Range(2, 50)) = 15
        // 定义 2D 纹理属性，默认白色
        _MainTex ("Base (RBG)", 2D) = "white" {}
        // 定义 2D 纹理属性，默认灰色
        _DispTex ("Disp Texture", 2D) = "gray" {}
        // 定义法线纹理图
        _NormalMap ("NormalMap", 2D) = "bump" {}
        // 定义置换区间
        _Displacement ("Displacement", Range(0,1.0)) = 0.3
        // 定义主颜色值
        _Color ("Color", Color) = (1,1,1,1)
        // 定义颜色值
        _SpecColor ("Spec Color", Color) = (0.5,0.5,0.5,0.5)
        _Tess ("Tess", Range(1,32)) = 3
    }
    SubShader
    {
        // 设置标签
        Tags
        {
            "RenderType"="Opaque"
        }
        // 设置 LOD
        LOD 300

        CGPROGRAM
        // 表面着色器编译指令
        #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessEdge nolightmap

        // 着色器编译目标
        #pragma target 5.0

        // 引用 Tessellation.cginc
        #include  "Tessellation.cginc"

        // 定义顶点属性结构体
        struct appdata
        {
            // 定义坐标值
            float4 vertex:POSITION;
            // 定义切线值
            float4 tangent:TANGENT;
            // 定义法线值
            float3 normal:NORMAL;
            // 定义坐标值
            float2 texcoord:TEXCOORD0;
        };
        // 声明边线长度
        float _EdgeLength;
        // 返回新的顶点坐标
        float4 tessEdge(appdata v0, appdata v1, appdata v2)
        {
            return UnityEdgeLengthBasedTess(v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
        }
        // 声明 2D 纹理
        sampler2D _DispTex;
        // 声明置换值
        float _Displacement;
        void disp(inout appdata v)
        {
            // 按照纹理图进行采样
            float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0).r * _Displacement);
            // 添加法线值
            v.vertex.xyz += v.normal * d;
        }
        // 定义输入参数结构体
        struct Input
        {
            // 纹理 UV 坐标
            float2 uv_MainTex;
        };
        // 声明主纹理图
        sampler2D _MainTex;
        // 声明法线纹理图
        sampler2D _NormalMap;
        // 声明颜色值
        fixed4 _Color;
        // 表面着色器方法
        void surf(Input IN, inout SurfaceOutput o)
        {
            // 根据 UV 坐标从纹理图进行采样
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            // 设置反射率
            o.Albedo = c.rgb;
            // 设置镜面反射
            o.Specular = 0.2;
            o.Gloss = 1.0;
            o.Normal = UnpackNormal((tex2D(_NormalMap, IN.uv_MainTex)));
        }
        ENDCG
    }
    FallBack "Diffuse"
}