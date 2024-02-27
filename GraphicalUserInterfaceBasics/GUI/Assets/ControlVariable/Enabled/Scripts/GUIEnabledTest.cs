using UnityEngine;

public class GUIEnabledTest : MonoBehaviour
{
    private bool allOptions = true;
    private bool extended1 = true;
    private bool extended2 = true;

    private void OnGUI()
    {
        // 创建开关控件，并设置状态
        allOptions = GUI.Toggle(new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.1f), allOptions, "Edit All Options");
        // 创建按钮，设置监听
        if (GUI.Button(new Rect(0, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f), "OK"))
        {
            print("User clicked ok");
        }
        // 将 allOptions 的值赋值给 enabled 变量
        GUI.enabled = allOptions;
        // 创建开关控件，并设置状态
        extended1 = GUI.Toggle(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), extended1, "Extended Option1");
        extended2 = GUI.Toggle(new Rect(Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.1f), extended2, "Extended Option2");
        // 将 enabled 变量的值设置为 true
        GUI.enabled = true;
    }
}
