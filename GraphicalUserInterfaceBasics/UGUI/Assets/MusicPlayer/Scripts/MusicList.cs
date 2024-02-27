using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicList : MonoBehaviour
{
    [Tooltip("音乐资源")]
    public AudioClip[] audioClips;
    [Tooltip("列表的内容的变换")]
    public RectTransform contentRectTransform;
    [Tooltip("音乐按钮预制件")]
    public GameObject musicButtonPrefab;
    [Tooltip("编辑按钮")]
    public Button editButton;
    private List<MusicButton> musicButtonList = new();
    private bool isEdit = false;

    private void Start()
    {
        for (var i = 0; i < audioClips.Length; i++)
        {
            GameObject musicButtonGameObject = Instantiate(musicButtonPrefab);
            MusicButton musicButton = musicButtonGameObject.GetComponent<MusicButton>();
            musicButton.Init(contentRectTransform, i + 1, audioClips[i].name, isEdit, OnPlayButtonClick, OnDeleteButtonClick);
            musicButtonList.Add(musicButton);
        }
        editButton.onClick.AddListener(() =>
        {
            OnEditButtonClick();
        });
    }

    private void OnEditButtonClick()
    {
        isEdit = !isEdit;
        foreach (var item in musicButtonList)
        {
            item.SetEdit(isEdit);
        }
    }

    public void OnPlayButtonClick(MusicButton musicButton)
    {
        Debug.Log(musicButton.GetInfo());
    }

    public void OnDeleteButtonClick(MusicButton musicButton)
    {
        musicButtonList.Remove(musicButton);
        Destroy(musicButton.gameObject);
        for (var i = 0; i < musicButtonList.Count; i++)
        {
            musicButtonList[i].UpdateOrder(i + 1);
        }
    }
}
