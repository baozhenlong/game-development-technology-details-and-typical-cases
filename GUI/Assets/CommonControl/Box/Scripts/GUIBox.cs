using UnityEngine;

public class GUIBox : MonoBehaviour
{
    private void OnGUI()
    {
        // 绘制一个盒子，内容为 This is a title
        GUI.Box(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.5f, Screen.height * 0.5f), "This is a title");
    }
}
