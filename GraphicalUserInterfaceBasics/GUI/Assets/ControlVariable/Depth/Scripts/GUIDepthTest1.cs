using UnityEngine;

public class GUIDepthTest1 : MonoBehaviour
{
    public static int gUIDepth = 0;
    private void OnGUI()
    {
        GUI.depth = gUIDepth;
        GUI.contentColor = Color.yellow;
        if (GUI.RepeatButton(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.2f), "Go Back"))
        {
            gUIDepth = 1;
            GUIDepthTest2.gUIDepth = 0;
        }
    }
}
