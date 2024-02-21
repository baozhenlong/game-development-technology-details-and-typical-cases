using UnityEngine;

public class GUIDrawTexture : MonoBehaviour
{
    public Texture texture;
    private void OnGUI()
    {
        // 创建一个纹理图片
        GUI.DrawTexture(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.height * 0.1f), texture, ScaleMode.ScaleToFit, true, 0.0f);
    }
}
