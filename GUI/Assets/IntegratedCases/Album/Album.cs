using UnityEngine;

public class Album : MonoBehaviour
{
    public Texture backgroundTexture;
    public Texture albumTexture;
    public Texture leftArrowTexture;
    public Texture rightArrowTexture;
    public Texture[] textures;
    private int textureIndex = 0;

    private Vector2 designedSize = new(540f, 960f);

    private void OnGUI()
    {
        if (textures.Length == 0)
        {
            return;
        }
        // 计算缩放比
        float ratioScaleWidth = Screen.width / designedSize.x;
        float ratioScaleHeight = Screen.height / designedSize.y;
        // 绘制背景纹理图片
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), backgroundTexture, ScaleMode.StretchToFill);
        // 绘制相册标题纹理图片
        GUI.DrawTexture(new Rect(170f * ratioScaleWidth, 20f * ratioScaleHeight, 200f * ratioScaleWidth, 100f * ratioScaleHeight), albumTexture, ScaleMode.ScaleToFit, true, 200f / 100f);
        // 绘制左箭头按钮
        if (GUI.Button(new Rect(20f * ratioScaleWidth, 145 * ratioScaleHeight, 50 * ratioScaleWidth, 50 * ratioScaleHeight), leftArrowTexture))
        {
            textureIndex -= 1;
            if (textureIndex < 0)
            {
                textureIndex = textures.Length - 1;
            }
        }
        // 绘制右箭头按钮
        if (GUI.Button(new Rect(470f * ratioScaleWidth, 145 * ratioScaleHeight, 50 * ratioScaleWidth, 50 * ratioScaleHeight), rightArrowTexture))
        {
            textureIndex += 1;
            if (textureIndex >= textures.Length)
            {
                textureIndex = 0;
            }
        }
        // 绘制示例图片
        for (var i = 0; i < textures.Length; i++)
        {
            Rect buttonRect = new((designedSize.x / 2f - 80f * textures.Length / 2 + 80f * i) * ratioScaleWidth, 130f * ratioScaleHeight, 80f * ratioScaleWidth, 80f * ratioScaleHeight);
            if (GUI.Button(buttonRect, textures[i]))
            {
                textureIndex = i;
            }
        }
        // 绘制窗口
        Rect clientRect = GUI.Window(
            0,
            new Rect(20f * ratioScaleWidth, 250f * ratioScaleHeight, 500f * ratioScaleWidth, 550f * ratioScaleHeight),
            DoWindow,
            ""
        );
    }


    private void DoWindow(int windowID)
    {
        // 计算缩放比
        float ratioScaleWidth = Screen.width / designedSize.x;
        float ratioScaleHeight = Screen.height / designedSize.y;
        // 绘制纹理
        GUI.DrawTexture(new Rect(10f * ratioScaleWidth, 30f * ratioScaleHeight, 480f * ratioScaleWidth, 480f * ratioScaleHeight), textures[textureIndex], ScaleMode.ScaleToFit, true, 500f / 500f);
    }

}
