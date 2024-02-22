using UnityEngine;

public class GUIBringWindowToFront : MonoBehaviour
{
    public Rect clientRect1 = new(20f, 20f, 120f, 50f);
    public Rect clientRect2 = new(80f, 20f, 120f, 50f);

    private void OnGUI()
    {
        // 绘制窗口
        clientRect1 = GUI.Window(0, clientRect1, DoWindow, "First");
        clientRect2 = GUI.Window(1, clientRect2, DoWindow, "Second");
    }

    private void DoWindow(int windowID)
    {
        if (GUI.Button(new Rect(10f, 20f, 100f, 20f), "Bring to front " + windowID))
        {
            GUI.BringWindowToFront(windowID);
        }
    }
}
