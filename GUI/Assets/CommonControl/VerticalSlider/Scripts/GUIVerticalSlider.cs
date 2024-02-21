using UnityEngine;

public class GUIVerticalSlider : MonoBehaviour
{
    private float sliderValue = .0f;
    private void OnGUI()
    {
        // 绘制一个垂直滑动条
        sliderValue = GUI.VerticalSlider(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.height * 0.33f), sliderValue, 10.0f, .0f);
    }
}
