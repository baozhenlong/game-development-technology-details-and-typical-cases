using UnityEngine;

public class GUIFocusControl : MonoBehaviour
{
    private string username = "username";
    private string password = "a password";
    private void OnGUI()
    {
        GUI.SetNextControlName("MyTextField");
        username = GUI.TextField(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.33f, Screen.height * 0.1f), username);
        password = GUI.TextField(new Rect(Screen.width * 0.1f, Screen.height * 0.25f, Screen.width * 0.33f, Screen.height * 0.1f), password);
        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.4f, Screen.width * 0.17f, Screen.height * 0.1f), "Move Focus"))
        {
            GUI.FocusControl("MyTextField");
        }
    }
}
