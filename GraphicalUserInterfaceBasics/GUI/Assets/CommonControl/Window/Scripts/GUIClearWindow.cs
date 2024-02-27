using UnityEngine;

public class GUIClearWindow : MonoBehaviour
{
    [Tooltip("窗口的矩形区域")]
    public Rect clientRect = new(110f, 10f, 200f, 60f);

    private bool doWindow = true;

    private void OnGUI()
    {
        // 绘制一个开关
        doWindow = GUI.Toggle(new Rect(10f, 10f, 100f, 20f), doWindow, "Do Window");
        if (doWindow)
        {
            // 绘制一个窗口
            clientRect = GUI.Window(0, clientRect, DoWindow, "Basic Window");
        }
    }

    private void DoWindow(int windowID)
    {
        // 创建一个按钮
        GUI.Button(new Rect(10f, 30f, 80f, 20f), "Click Me!");
    }
}
