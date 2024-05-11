Shader "Custom/Surface/SurfaceBlowingExpansion"
{
    Properties
    {
        // 2D 纹理值
       _MainTex ("Texture", 2D) = "white" {}
        // 膨胀系数值
        _Amount ("Extrusion", Range(0, 0.1)) = 0.05
    }
    SubShader
    {
        CGPROGRAM
        // 表面着色器编译指令；vertex:vert 告诉编译器表面着色器名称为 vert 的方法为顶点变换方法
        #pragma surface surf Lambert vertex:vert
        // Input 结构体
        struct Input
        {
            // UV 纹理坐标
            float2 uv_MainTex;
        };
        // 声明膨胀系数属性
        float _Amount;
        // 声明 2D 纹理
        sampler2D _MainTex;

        // 顶点变换方法
        void vert (inout appdata_base v)
        {
            // 通过法线挤压实现充气的效果（将顶点向法线方向移动来实现充气的效果）
            v.vertex.xyz += v.normal * _Amount;
        }
        // 表面着色器方法
        void surf (Input IN, inout SurfaceOutput o)
        {
            // 从纹理提取颜色为漫反射颜色赋值
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    // 降级着色器
    FallBack "Diffuse"
}