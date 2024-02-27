using UnityEngine;

public class GUIColorTest : MonoBehaviour
{
    private void OnGUI()
    {
        // 将控件颜色设置为黄色
        GUI.color = Color.yellow;
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.2f), "Hello World");
        GUI.Box(new Rect(Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.2f), "A Box");
        // 将控件颜色设置为红色
        GUI.color = Color.red;
        GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.2f), "A Button");
    }
}
