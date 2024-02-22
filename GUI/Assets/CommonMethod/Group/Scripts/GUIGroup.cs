using UnityEngine;

public class GUIGroup : MonoBehaviour
{
    private void OnGUI()
    {
        // 创建一个组
        GUI.BeginGroup(new Rect(Screen.width * 0.5f - 200f, Screen.height * 0.5f - 100, 400, 200));
        // 创建一个 Box 控件
        GUI.Box(new Rect(0, 0, 400, 200), "This box is now centered! - here you would put your main menu");
        // 结束一个组
        GUI.EndGroup();
    }
}
