using UnityEngine;

public class GUITextField : MonoBehaviour
{
    private string text = "Hello World";
    private void OnGUI()
    {
        // 绘制一个单行文本编辑框
        text = GUI.TextField(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.33f, Screen.height * 0.1f), text, 25);
    }
}
