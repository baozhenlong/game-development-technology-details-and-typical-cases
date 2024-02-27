using UnityEngine;

public class GUIChangedTest : MonoBehaviour
{
    private string text = "Modify me.";
    private void OnGUI()
    {
        // 创建一个单行文本编辑框控件，并将输入的数据赋给变量 text
        text = GUI.TextField(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.25f, Screen.height * 0.2f), text, 25);
        // 调用 changed 变量，检测输入数据是否发生改变
        if (GUI.changed)
        {
            Debug.Log("Text filed has changed.");
        }
    }
}
