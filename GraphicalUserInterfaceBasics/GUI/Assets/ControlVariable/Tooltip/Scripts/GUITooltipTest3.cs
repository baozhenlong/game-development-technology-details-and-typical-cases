using UnityEngine;

public class GUITooltipTest3 : MonoBehaviour
{
    private string lastTooltip = "";
    private void OnGUI()
    {
        GUILayout.Button(new GUIContent("Play Game", "Button1"));
        GUILayout.Button(new GUIContent("Quit", "Button2"));
        if (Event.current.type == EventType.Repaint && GUI.tooltip != lastTooltip)
        {
            if (lastTooltip != "")
            {
                SendMessage(lastTooltip + "OnMouseOut", SendMessageOptions.DontRequireReceiver);
            }
            if (GUI.tooltip != "")
            {
                SendMessage(GUI.tooltip + "OnMouseOver", SendMessageOptions.DontRequireReceiver);
            }
            lastTooltip = GUI.tooltip;
        }
    }

    private void Button1OnMouseOver()
    {
        Debug.Log("Play game got focus");
    }
    private void Button1OnMouseOut()
    {
        Debug.Log("Play game lost focus");
    }

    private void Button2OnMouseOver()
    {
        Debug.Log("Quit got focus");
    }

    private void Button2OnMouseOut()
    {
        Debug.Log("Quit lost focus");
    }
}
