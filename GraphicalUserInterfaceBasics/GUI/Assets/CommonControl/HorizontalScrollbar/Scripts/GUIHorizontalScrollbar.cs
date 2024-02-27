using UnityEngine;

public class GUIHorizontalScrollbar : MonoBehaviour
{
    private float scrollbarValue = 0.0f;
    private void OnGUI()
    {
        // 绘制一个水平滚动条
        scrollbarValue = GUI.HorizontalScrollbar(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.33f, Screen.height * 0.1f), scrollbarValue, 1.0f, 0.0f, 10.0f);
    }
}
