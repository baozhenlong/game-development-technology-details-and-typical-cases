using UnityEngine;

public class GUIVerticalScrollbar : MonoBehaviour
{
    private float scrollbarValue = 0.0f;
    private void OnGUI()
    {
        // 绘制一个垂直滚动条
        scrollbarValue = GUI.VerticalScrollbar(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.height * 0.33f), scrollbarValue, 1.0f, 10.0f, 0.0f);
    }
}
