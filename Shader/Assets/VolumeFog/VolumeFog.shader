Shader "Custom/VolumeFog"
{
    Properties
    {
        // 岩石纹理
        _RockTex ("Rock", 2D) = "white" {}
        // 草皮纹理
        _SodTex ("Sod", 2D) = "white" {}
        // 摄像机位置
        _CameraPosition ("CameraPosition", Vector) = (0, 0, 0, 1)
        // 扰动起始角
        _StartAngle ("StartAngle", float) = 0
        // 雾颜色
        _FogColor ("FogColor", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags
        {
            // 要确保渲染顺序在透明之前
            "RenderType"="Geometry"
        }

        CGPROGRAM
        #pragma surface surf Lambert vertex:myVertex
        // 岩石纹理
        sampler2D _RockTex;
        // 草皮纹理
        sampler2D _SodTex;
        // 摄像机位置
        float4 _CameraPosition;
        // 扰动起始角
        float _StartAngle;
        // 雾颜色
        float4 _FogColor;

        struct Input
        {
            // 纹理坐标
            float2 uv_MainTex;
            // 片元位置
            float3 originPosition;
        };

        void myVertex(inout appdata_full v, out Input o)
        {
            // 初始化结构体 o
            UNITY_INITIALIZE_OUTPUT(Input, o);
            // 设置 originPosition 参数为该顶点位置
            o.originPosition = v.vertex.xyz;
        }

        // 计算体积雾浓度因子的方法
        float fogCal(float3 location)
        {
            // 获取扰动起始角
            float startAngle = _StartAngle;
            // 设置雾平面高度
            float slabY = 24.0f;
            // 获取摄像机位置
            float cameraLocation = _CameraPosition.xyz;
            float fogFactor;
            // 计算出顶点 x 坐标折算出的角度
            float xAngle = location.x / 30.0 * 3.1415926;
            // 计算出顶点 z 坐标折算出的角度
            float zAngle = location.z / 30.0 * 3.1415925;
            // 计算出角度和的正弦值
            float slabYFactor = sin(xAngle + zAngle + startAngle) * 1.5f;
            // 求从摄像机到顶点射线参数方程 Pc + (Pp - Pc)t t 中的 t 值
            float t = (slabY + slabYFactor - cameraLocation.y) / (location.y - cameraLocation.y);
            // 有效的 t 范围应该是 0~1
            if(t > 0.0 && t < 1.0)
            {
                // 求射线与雾平面交点的 x 坐标
                float x = cameraLocation.x + (location.x - cameraLocation.x) * t;
                // 求射线与雾平面交点的 z 坐标
                float z = cameraLocation.z + (location.z - cameraLocation.z) * t;
                // 射线与雾平面的交点坐标
                float intersection = float3(x, slabY, z);
                // 求出交点到顶点的距离
                float l = distance(intersection, location.xyz);
                float l0 = 20.0;
                // 计算雾浓度因子
                fogFactor = l0 / (l0 + l);
            }else
            {
                // 待处理片元不在雾平面以下，则此片元不受雾影响
                fogFactor = 1.0;
            }
            return  fogFactor;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            // 获取片元位置
            float3 location = IN.originPosition;
            // 从纹理图片中获取片元颜色
            half4 c;
            // 如果片元的 y 坐标值小于 20，从草皮纹理中获取片元颜色
            if(location.y < 20)
            {
                c = tex2D(_SodTex, IN.uv_MainTex);
            }
            // 如果片元 y 的坐标值大于 36，从岩石纹理中获取片元颜色
            else if(location.y >= 36)
            {
                c= tex2D(_RockTex, IN.uv_MainTex);
            }
            // 如果片元的 y 坐标在草皮和岩石的混合处
            else
            {
                // 计算岩石纹理所占的百分比
                float te = (location.y - 20) / 16;
                // 将岩石、草皮纹理颜色按比例混合
                c = tex2D(_RockTex, IN.uv_MainTex) * te + tex2D(_SodTex, IN.uv_MainTex) * (1-te);
            }
            // 设置 Alpha 值
            o.Alpha = 1;
            // 计算雾浓度因子
            float fogFactor = fogCal(location);
            // 根据雾浓度因子、雾的颜色及片元的本身采集的纹理颜色计算出片元的最终颜色
            o.Albedo = c.rgb * fogFactor + (1 - fogFactor) * half3(_FogColor.rgb);
        }
        ENDCG
    }
    FallBack "Diffuse"
}