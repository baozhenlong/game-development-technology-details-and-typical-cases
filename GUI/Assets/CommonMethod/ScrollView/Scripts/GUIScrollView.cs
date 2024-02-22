using UnityEngine;

public class GUIScrollView : MonoBehaviour
{
    private Vector2 scrollbarPosition = Vector2.zero;
    private void OnGUI()
    {
        // 创建一个滚动视图
        scrollbarPosition = GUI.BeginScrollView(
            new Rect(Screen.width * .1f, Screen.height * .1f, Screen.width * .2f, Screen.height * .25f),
            scrollbarPosition,
            new Rect(0f, 0f, Screen.width * .5f, Screen.height * .55f)
        );

        if (GUI.Button(new Rect(0f, 0f, Screen.width * .2f, Screen.height * .1f), "Go Right"))
        {
            GUI.ScrollTo(new Rect(Screen.width * .25f, 0f, Screen.width * .2f, Screen.height * .1f));
        }

        if (GUI.Button(new Rect(Screen.width * .25f, 0f, Screen.width * .2f, Screen.height * .1f), "Go Left"))
        {
            GUI.ScrollTo(new Rect(0f, 0f, Screen.width * .2f, Screen.height * .1f));
        }

        // 结束滚动视图
        GUI.EndScrollView();
    }
}
