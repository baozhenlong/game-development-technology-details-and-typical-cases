using UnityEngine;

public class GUIDepthTest2 : MonoBehaviour
{
    public static int gUIDepth = 0;
    private void OnGUI()
    {
        GUI.depth = gUIDepth;
        GUI.contentColor = Color.red;
        if (GUI.RepeatButton(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.2f, Screen.height * 0.2f), "Go Back"))
        {
            gUIDepth = 1;
            GUIDepthTest1.gUIDepth = 0;
        }
    }
}
