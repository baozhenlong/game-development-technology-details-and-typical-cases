Shader "Custom/GrabPassShader"
{
    SubShader
    {
        Tags
        {
            // 设置渲染队列
            "Queue"="Overlay"
        }
        // 捕获屏幕的内容并写入 _MyGrab 纹理中
        GrabPass {"_MyGrab"}
        Pass
        {
            CGPROGRAM
            // 指定 vert 方法为顶点着色器方法
            #pragma vertex vert
            // 指定 frag 方法为片元着色器方法
            #pragma fragment frag
            // 引入 UnityCG.cginc 文件
            #include "UnityCG.cginc"
            // 声明 _MYGrab 纹理变量
            sampler2D _MyGrab;
            // 片元着色器方法输入结构体
            struct  v2f
            {
                // 顶点位置
                float4 pos:SV_POSITION;
                // UV 纹理坐标
                float2 uv:TEXCOORD0;
            };
            // 顶点着色器啊方法
            v2f vert(appdata_full v)
            {
                v2f o;
                // 计算变换后最终顶点位置
                o.pos = mul(unity_MatrixVP, v.vertex);
                // 设置 uv 坐标
                o.uv = v.texcoord.xy;
                // 返回顶点数据
                return  o;
            }
            // 片元着色器方法
            float4 frag(v2f i):COLOR{
                // 从捕获屏幕的内容的纹理中提取颜色
                float4 c = tex2D(_MyGrab, i.uv);
                // 返回片元颜色
                return  c;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}