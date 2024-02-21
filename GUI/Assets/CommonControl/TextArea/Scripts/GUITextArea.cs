using UnityEngine;

public class GUITextArea : MonoBehaviour
{
    private string text = "Hello World\nI've got 2 lines...";
    private void OnGUI()
    {
        // 绘制一个多行文本编辑框
        text = GUI.TextArea(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.5f), text, 200);
    }
}
