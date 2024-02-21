using UnityEngine;

public class GUIHorizontalSlider : MonoBehaviour
{
    private float sliderValue = .0f;
    private void OnGUI()
    {
        // 绘制一个水平滑动条
        sliderValue = GUI.HorizontalSlider(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.33f, Screen.height * 0.1f), sliderValue, .0f, 10.0f);
    }
}
