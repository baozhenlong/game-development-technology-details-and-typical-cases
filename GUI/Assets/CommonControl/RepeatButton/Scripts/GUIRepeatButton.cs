using UnityEngine;

public class GUIRepeatButton : MonoBehaviour
{
    public Texture texture;
    private void OnGUI()
    {
        // 绘制一个纹理图片长按按钮
        if (GUI.RepeatButton(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.width * 0.1f), texture))
        {
            // 若长按按钮，则打印提示信息
            Debug.Log("Clicked the repeatButton with an image");
        }
        // 绘制一个文本长按按钮
        if (GUI.RepeatButton(new Rect(Screen.width * 0.1f, Screen.height * 0.33f, Screen.width * 0.2f, Screen.width * 0.1f), "Click"))
        {
            // 若长按按钮，则打印提示信息
            Debug.Log("Clicked the repeatButton with text");
        }
    }
}
