using UnityEngine;

public class GUIButton : MonoBehaviour
{
    public Texture texture;
    private void OnGUI()
    {
        // 创建一个纹理图片按钮，并进行是否执行按钮操作的判断
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.width * 0.1f), texture))
        {
            // 若单击按钮，则打印提示信息
            Debug.Log("Clicked the button with an image");
        }
        // 创建一个文本按钮，并进行是否执行按钮操作的判断
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.33f, Screen.width * 0.2f, Screen.width * 0.1f), "Click"))
        {
            // 若单击按钮，则打印提示信息
            Debug.Log("Clicked the button with an text");
        }
    }
}
