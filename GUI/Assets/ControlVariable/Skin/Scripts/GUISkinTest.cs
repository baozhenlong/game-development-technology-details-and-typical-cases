using UnityEngine;

public class GUISkinTest : MonoBehaviour
{
    [Tooltip("GUISkin 资源引用数组")]
    public GUISkin[] gUISkins;
    // 当前使用皮肤的索引
    private int skinIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 切换皮肤索引
            skinIndex += 1;
            if (skinIndex >= gUISkins.Length)
            {
                skinIndex = 0;
            }
        }
    }

    private void OnGUI()
    {
        if (gUISkins.Length == 0)
        {
            return;
        }
        // 设置皮肤风格
        GUI.skin = gUISkins[skinIndex];
        // 创建按钮控件
        if (GUI.Button(new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f), "A Button"))
        {
            Debug.Log("Button has been pressed");
        }
        // 创建标签控件
        GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f), $"Skin-{skinIndex + 1}");
    }
}
