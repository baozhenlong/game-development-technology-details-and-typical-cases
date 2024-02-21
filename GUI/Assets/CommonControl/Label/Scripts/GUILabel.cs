using UnityEngine;

public class GUILabel : MonoBehaviour
{
    public Texture texture;
    private void OnGUI()
    {
        // 绘制一个文本标签
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), "Hello World!");
        // 绘制一个纹理标签
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.33f, Screen.width * texture.width, texture.height), texture);
    }
}
