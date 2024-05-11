Shader "Custom/TessellationFixedQuantity"
{
    // 定义属性块，用来指定这段代码将有哪些输入
    Properties
    {
        // 定义切分区间来控制模型的细分程度，值越大则细分程度越大，默认值为 4
        _Tess ("Tessellation", Range(1, 32)) = 4
        // 定义 2D 纹理属性，默认白色
        _MainTex ("Base (RGB)", 2D) = "white" {}
        // 定义 2D 纹理属性，默认灰色
        _DispTex ("Disp Texture", 2D) = "gray" {}
        // 定义法线纹理图
        _NormalMap ("Normal map", 2D) = "bump" {}
        // 定义置换区间
        _Displacement ("Displacement", Range(0,1.0)) = 0
        // 定义主颜色值
        _Color ("Color", Color) = (1,1,1,0)
        // 定义颜色值
        _SpecColor ("Spec color", Color) = (0.5,0.5,0.5,0.5)
    }
    SubShader
    {
        // 设置标签
        Tags
        {
            "RenderType"="Opaque"
        }
        // 设置 LOD 值
        LOD 300

        CGPROGRAM
        // 表面着色器编译指令
        #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessFixed nolightmap

        // 着色器编译目标
        #pragma target 5.0

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
        // 声明切分值
        float _Tess;
        // 返回切分值，曲面细分方法可以返回一个 float4 值：其中 x、y、z 是三角形的 3 个顶点的细分程度，w 是比例，在该着色器中只是一个 float 常量作为细分程度
        float4 tessFixed()
        {
            return _Tess;
        }
        // 声明 2D 纹理
        sampler2D _DispTex;
        // 声明置换值
        float _Displacement;
        void disp(inout appdata v)
        {
            // tex2Dlod 以指定的细节级别和可选位置来解析贴图
            float d = tex2Dlod(_DispTex, float4(v.texcoord.xy, 0, 0)).r * _Displacement;
            // 添加法线值
            v.texcoord.xyz += v.normal * d;
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
        void surf (Input IN, inout SurfaceOutput o)
        {
            // 根据 UV 坐标从纹理提取颜色
            half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            // 设置反射率
            o.Albedo = c.rgb;
            // 设置镜面反射率
            o.Specular = 0.2;
            o.Gloss = 1.0;
            o.Normal = UnpackNormal(tex2D(_NormalMap,IN.uv_MainTex));
        }
        ENDCG
    }
    FallBack "Diffuse"
}