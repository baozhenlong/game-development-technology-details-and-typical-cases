using UnityEngine;

public class GUIPasswordField : MonoBehaviour
{
    private string password = "My Password";
    private void OnGUI()
    {
        password = GUI.PasswordField(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), password, '*', 25);
    }
}
