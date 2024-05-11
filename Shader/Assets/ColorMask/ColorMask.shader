Shader "Custom/ColorMask"
{
    SubShader
    {
        Tags
        {
            // 设置渲染队列
            "Queue"="Geometry+2"
        }
        Pass
        {
            // 设置通道遮罩模式为 0
            ColorMask 0
            // 设置对象表面颜色
            Color(1, 1, 1,1)
        }
    }
}