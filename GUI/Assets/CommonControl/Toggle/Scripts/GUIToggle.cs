using UnityEngine;

public class GUIToggle : MonoBehaviour
{
    public Texture texture;
    private bool toggleText = false;
    private bool toggleImage = false;

    private void OnGUI()
    {
        // 绘制一个文本开关
        toggleText = GUI.Toggle(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.33f, Screen.height * 0.1f), toggleText, "A Toggle text");
        // 绘制一个纹理图片开关
        toggleImage = GUI.Toggle(new Rect(Screen.width * 0.1f, Screen.height * 0.25f, Screen.width * 0.1f, Screen.height * 0.1f), toggleImage, texture);
    }
}
