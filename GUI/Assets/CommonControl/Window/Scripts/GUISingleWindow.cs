using UnityEngine;

public class GUISingleWindow : MonoBehaviour
{
    [Tooltip("窗口的矩形区域")]
    public Rect clientRect = new(20f, 20f, 120f, 50f);

    private void OnGUI()
    {
        // 绘制一个窗口
        clientRect = GUI.Window(0, clientRect, DoWindow, "My Window");
    }

    private void DoWindow(int windowID)
    {
        // 创建一个按钮
        if (GUI.Button(new Rect(10f, 25f, 100f, 20f), "Hello World"))
        {
            print("Got a click");
        }
    }
}
