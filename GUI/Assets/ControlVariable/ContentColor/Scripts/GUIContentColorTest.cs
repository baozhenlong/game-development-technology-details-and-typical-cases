using UnityEngine;

public class GUIContentColorTest : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), "A Button");
        // 将文本颜色设置为黄色
        GUI.contentColor = Color.yellow;
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f), "A Button");
    }
}
