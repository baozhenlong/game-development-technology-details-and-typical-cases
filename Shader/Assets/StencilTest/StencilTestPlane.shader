Shader "Custom/StencilTestPlane"
{
    Properties
    {
        // 纹理
        _MainTex ("MainTex", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Tranparent"
            "IgnoreProjector"="True"
        }
        
        Pass
        {
            // 定义模板测试指令
            Stencil
            {
                // 设置 referenceValue 为 2
                Ref 2
                // 总是通过模板测试
                Comp Always
                // 测试通过后将缓冲值替换
                Pass Replace
            }
            // 关闭深度检测
            ZWrite Off
            // 开启混合
            Blend SrcAlpha OneMinusSrcAlpha
        }

        CGPROGRAM
        // 声明顶点着色器
        #pragma vertex vert
        // 声明片元着色器
        #pragma fragment fragment
        // 导入光照计算包
        #include "Lighting.cginc"
        // 纹理
        sampler2D _MainTex;
        // 坐标变化值
        float4 _MainTex_ST;
        struct v2f
        {
            // 顶点位置
            float4 pos:SV_POSITION;
            // 法线
            float3 normal:TEXCOORD0;
            // 纹理 UV 坐标
            float2 uv:TEXCOORD1;
        };
        // 顶点着色器
        v2f vert(appdata_base v)
        {
            // 输出结构体
            v2f o;
            // 将顶点位置变换到剪裁空间
            o.pos = UnityObjectToClipPos(v.vertex);
            // 纹理坐标变换
            o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
            return o;
        }
        // 片元着色器
        half4 fragment(v2f i):SV_Target
        {
            // 对纹理进行采样
            fixed3 albedo = tex2D(_MainTex, i.uv).rgb;
            // 将采样的纹理值赋给对应片元
            return fixed4(albedo, 0.5);
        }
        ENDCG
    }
}