Shader "Custom/StencilTestBall"
{
    Properties
    {
        // 颜色值
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
        // 纹理
        _MainTex ("Main Tex", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            "Queue"="Overlay"
        }
        Pass
        {
            // 定义模板测试指令
            Stencil
            {
                // 设置 referenceValue 为 2
                Ref 2
                // 相等的情况下测试通过
                Comp Equal
                // 测试通过后保留缓冲值
                Pass Keep
            }
            CGPROGRAM
            // 声明顶点着色器
            #pragma vertex vert
            // 声明片元着色器
            #pragma fragment frag
            // 导入光照工具包
            #include "Lighting.cginc"
            // 颜色值
            fixed4 _Color;
            // 纹理
            sampler2D _MainTex;
            // 坐标变化
            float4 _MainTex_ST;
            struct a2v
            {
                // 顶点坐标
                float4 pos:POSITION;
                // 法线
                float3 normal:NORMAL;
                // 纹理颜色值
                float4 texcoord:TEXCOORD0;
            };
            // 顶点着色器输入结构体
            struct v2f
            {
                // 顶点坐标
                float4 pos:SV_POSITION;
                // 顶点世界空间中的法线
                float3 worldNormal:TEXCOORD0;
                // 顶点世界空间中的位置
                float3 worldPos:TEXCOORD1;
                // 纹理 UV 坐标
                float2 uv:TEXCOORD2;
            };
            // 声明顶点着色器
            v2f vert(appdata_base v)
            {
                // 声明输出结构体
                v2f o;
                // 将顶点转换到剪裁空间
                o.pos = UnityObjectToClipPos(v.vertex);
                // 将法线转化到世界空间
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                // 将顶点转化到世界空间
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return  o;
            }
            // 声明片元着色器
            fixed4 frag(v2f i):SV_Target
            {
                // 归一化顶点法线
                fixed3 worldNormal = normalize(i.worldNormal);
                // 归一化光照方向
                fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
                // 纹理采样
                fixed3 albedo = tex2D(_MainTex, i.uv).rgb * _Color.rgb;
                // 计算环境光
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
                // 计算漫反射纸
                fixed3 diffuse = _LightColor0 * albedo * max(0, dot(worldNormal, worldLightDir));
                // 返回片元颜色值
                return  fixed4(ambient + diffuse, 1.0);
            }
            ENDCG
        }
    }
}