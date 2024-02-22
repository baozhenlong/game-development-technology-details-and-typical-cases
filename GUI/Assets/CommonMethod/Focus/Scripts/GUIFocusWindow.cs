using UnityEngine;

public class GUIFocusWindow : MonoBehaviour
{
    public Rect clientRect1 = new(20f, 20f, 220f, 50f);
    public Rect clientRect2 = new(20f, 80f, 220f, 50f);

    private void OnGUI()
    {
        clientRect1 = GUI.Window(0, clientRect1, DoFirstWindow, "First");
        clientRect2 = GUI.Window(1, clientRect2, DoSecondWindow, "Second");
    }

    private void DoFirstWindow(int windowID)
    {
        if (GUI.Button(new Rect(10f, 20f, 200f, 20f), "Focus second window"))
        {
            GUI.FocusWindow(1);
        }
    }

    private void DoSecondWindow(int windowID)
    {
        if (GUI.Button(new Rect(10f, 20f, 200f, 20f), "Focus first window"))
        {
            GUI.FocusWindow(0);
        }
    }
}
