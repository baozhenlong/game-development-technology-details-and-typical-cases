using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public delegate void VoidDelete(MusicButton musicButton);
    public TextMeshProUGUI orderText;
    public TextMeshProUGUI infoText;
    public Button clickButton;
    public Button deleteButton;
    public void Init(RectTransform parentRectTransform, int order, string name, bool isEdit, VoidDelete playListener, VoidDelete deleteListener)
    {
        UpdateOrder(order);
        string[] infos = name.Split('-');
        infoText.text = $"{infos[0]}\n{infos[1]}";
        clickButton.onClick.AddListener(() =>
        {
            playListener(this);
        });
        deleteButton.onClick.AddListener(() =>
        {
            deleteListener(this);
        });
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.SetParent(parentRectTransform);
        rectTransform.localScale = Vector3.one;
        SetEdit(isEdit);
    }

    public string GetInfo()
    {
        return infoText.text;
    }

    public void SetEdit(bool isEdit)
    {
        deleteButton.gameObject.SetActive(isEdit);
    }

    public void UpdateOrder(int order)
    {
        orderText.text = $"{order}";
    }
}
