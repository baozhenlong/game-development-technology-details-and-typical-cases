using UnityEngine;

public class GUISelectionGrid : MonoBehaviour
{
    private int selectionGridIndex = 0;
    public string[] selectionStrings = new string[] {
        "SelectionGrid1",
        "SelectionGrid2",
        "SelectionGrid3",
        "SelectionGrid4",
    };

    private void OnGUI()
    {
        // 绘制一个按钮网格
        selectionGridIndex = GUI.SelectionGrid(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.33f), selectionGridIndex, selectionStrings, 2);
    }
}
