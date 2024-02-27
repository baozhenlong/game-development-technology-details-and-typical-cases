using UnityEngine;

public class GUIControlName : MonoBehaviour
{
    private string focusedControlName = "";
    private void OnGUI()
    {
        // 设置接下来创建的控件的名称为 Amy
        GUI.SetNextControlName("Amy");
        GUI.TextArea(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.33f, Screen.height * 0.1f), "Amy");

        // 设置接下来创建的控件的名称为 Bob
        GUI.SetNextControlName("Bob");
        GUI.TextArea(new Rect(Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.33f, Screen.height * 0.1f), "Bob");

        focusedControlName = GUI.GetNameOfFocusedControl();
        if (focusedControlName == "Amy")
        {
            Debug.Log("Current focused control name is Amy!");
        }
        else if (focusedControlName == "Bob")
        {
            Debug.Log("Current focused control name is Bob!");
        }
    }
}
