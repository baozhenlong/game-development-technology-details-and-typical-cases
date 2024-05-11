Shader "Custom/Cull"
{
    SubShader
    {
        Pass
        {
            // 不绘制面向摄像机的面
            Cull Front
            CGPROGRAM
            // 指定 vert 方法为顶点着色器方法
            #pragma vertex vert
            // 指定 frag 方法为 片元着色器方法
            #pragma fragment frag
            // 引入 UnityCG.cginc 文件
            #include "UnityCG.cginc"
            // 片元着色器方法输入结构体
            struct v2f
            {
                float4 pos:SV_POSITION;
            };
            // 顶点着色器方法
            v2f vert(appdata_base v)
            {
                v2f o;
                // 获取定点位置
                o.pos = v.vertex;
                // 是顶点位置沿法线挤出一点点
                o.pos.xyz += v.normal * 0.03;
                // 计算变换后最终顶点位置
                o.pos = mul(unity_MatrixMVP, o.pos);
                // 返回顶点数据
                return  o;
            }
            // 片元着色器方法
            float4 frag(v2f i): COLOR
            {
                // 返回片元颜色为白色
                return  float4(1, 1, 1, 1);
            }
            ENDCG
        }
        Pass
        {
            // 不绘制背向摄像机的面
            Cull Back
            // 打开光照
            Lighting On
            // 设置漫反射颜色
            Material
            {
                Diffuse (1,1,1,1)
            }
        }
    }
}