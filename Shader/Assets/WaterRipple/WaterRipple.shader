Shader "Custom/WaterRipple" {
    Properties {
        // 定义一个 2D 纹理属性，默认白色
        _MainTex ("Base (RGB)", 2D) = "white" {}
        // x、y、z 为波源位置，w 为正弦函数的初相位（波源产生波的角速度，可以改变波的频率）
        _Aim1 ("Aim1", Vector) = (3, 0, 3, -2.5)
        _Aim2 ("Aim2", Vector) = (5, 0, -5, 2.0)
        _Aim3 ("Aim3", Vector) = (-3, 0, -3, 1.0)
        _Aim4 ("Aim4", Vector) = (-5, 0, 5, 0.5)
        _High ("High", Float) = 1
    }

    SubShader {
        Pass {
            // 开始标记
            CGPROGRAM
            // 定义顶点着色器
            #pragma vertex verf
            // 定义片元着色器
            #pragma fragment frag
            // 引用 Unity 自带的方法库
            #include "UnityCG.cginc"
            // 2D 纹理属性
            sampler2D _MainTex;
            float4 _Aim1;
            float4 _Aim2;
            float4 _Aim3;
            float4 _Aim4;
            // 声明四维变量
            float4 _MainTex_ST;
            float _High;
            // 定义顶点数据结构体
            struct v2f {
                // 声明顶点位置
                float4 pos:SV_POSITION;
                // 声明纹理
                float2 uv:TEXCOORD0;
            };
            // 顶点着色器
            v2f verf(appdata_base v){
                // 声明一个结构体对象
                v2f o;
                // 计算当前顶点与 _Aim1、_Aim2、_Aim3、_Aim4 的距离
                float dis1 = distance(v.vertex.xyz, _Aim1.xyz);
                float dis2 = distance(v.vertex.xyz, _Aim2.xyz);
                float dis3 = distance(v.vertex.xyz, _Aim3.xyz);
                float dis4 = distance(v.vertex.xyz, _Aim4.xyz);
                // 计算当前顶点的高度
                // 计算正弦波的高度
                float h = sin(dis1 * _Aim1.w + _Time.z * _High) / 5;
                // 叠加正弦波的高度
                h += sin(dis2 * _Aim2.w + _Time.z * _High) / 10;
                h += sin(dis3 * _Aim3.w + _Time.z * _High) / 15;
                h += sin(dis4 * _Aim4.w + _Time.z * _High) / 10;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                // 将顶点转换到世界坐标的矩阵
                o.pos = mul(unity_ObjectToWorld, v.vertex);
                // 顶点的 y 值
                o.pos.y = h;
                // 将顶点转换到自身坐标的矩阵
                o.pos = mul(unity_WorldToObject, o.pos);
                // 计算顶点位置
                o.pos = UnityObjectToClipPos(o.pos);
                // 返回顶点着色器对象
                return o;
            }
            fixed4 frag(v2f i): Color{
                // 获取顶点对应 UV 的染色
                float4 texColor = tex2D(_MainTex, i.uv);
                // 返回顶点染色
                return texColor;
            }
            // 着色器结束标志
            ENDCG
        }
    }
    // 降级 着色器（备用的着色器）
    Fallback "Diffuse"
}