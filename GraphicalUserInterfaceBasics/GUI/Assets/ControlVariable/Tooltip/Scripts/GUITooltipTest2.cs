using UnityEngine;

public class GUITooltipTest2 : MonoBehaviour
{
    private void OnGUI()
    {
        // 绘制一个盒子，且提示信息为 This box has a tooltip
        GUI.Box(new Rect(Screen.width * 0.05f, Screen.height * 0.1f, Screen.width * 0.6f, Screen.height * 0.6f), new GUIContent("Box", "This box has a tooltip"));
        // 绘制一个按钮，名为 No tooltip here
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.33f, Screen.width * 0.5f, Screen.height * 0.1f), "No tooltip here");
        // 绘制一个按钮，名为 I have a tooltip，且提示信息为 The button overrides the box
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), new GUIContent("I have a tooltip", "The button overrides the box"));
        // 绘制一个标签，标签显示的内容为 GUI.tooltip 提供的信息
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.4f, Screen.height * 0.1f), GUI.tooltip);
    }
}
