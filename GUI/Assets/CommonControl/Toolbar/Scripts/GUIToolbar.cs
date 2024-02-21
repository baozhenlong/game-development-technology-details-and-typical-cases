using UnityEngine;

public class GUIToolbar : MonoBehaviour
{
    public string[] toolbarStrings = new string[] {
        "Toolbar1",
        "Toolbar2",
        "Toolbar3",
    };

    private int toolbarIndex = 0;

    private void OnGUI()
    {
        // 绘制一个工具栏
        toolbarIndex = GUI.Toolbar(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.1f), toolbarIndex, toolbarStrings);
    }
}
