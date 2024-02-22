using UnityEngine;

public class GUIDragWindow : MonoBehaviour
{
    public Rect clientRect = new(20f, 20f, 120f, 50f);

    private void OnGUI()
    {
        clientRect = GUI.Window(0, clientRect, DoWindow, "My Window");
    }

    private void DoWindow(int windowID)
    {
        GUI.Button(new Rect(10f, 20f, 100f, 25f), "A Button");
        // 绘制一个可拖动窗口
        GUI.DragWindow(new Rect(0f, 0f, 60f, 50f));
    }
}
