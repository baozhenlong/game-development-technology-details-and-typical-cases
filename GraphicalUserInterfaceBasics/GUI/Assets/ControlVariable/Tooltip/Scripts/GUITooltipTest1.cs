using UnityEngine;

public class GUITooltipTest1 : MonoBehaviour
{
    private void OnGUI()
    {
        // 创建按钮控件，并设置提示信息
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), new GUIContent("Click me", "This is the tooltip"));
        // 创建标签控件，并将提示信息传递给标签控件
        GUI.Label(new Rect(Screen.width * 0.08f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f), GUI.tooltip);
        // 创建盒子控件，并将提示信息传递给盒子控件
        GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f), GUI.tooltip);
    }
}
