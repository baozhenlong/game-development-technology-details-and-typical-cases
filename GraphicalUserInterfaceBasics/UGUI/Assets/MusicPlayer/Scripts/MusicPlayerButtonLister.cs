using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerButtonLister : MonoBehaviour
{
    [Tooltip("播放按钮")]
    public Button playButton;
    [Tooltip("播放上一首按钮")]
    public Button previousButton;
    [Tooltip("播放下一首按钮")]
    public Button nextButton;
    [Tooltip("随机播放按钮")]
    public Button shuffleButton;
    [Tooltip("单曲循环播放按钮")]
    public Button repeatButton;
    [Tooltip("音乐列表按钮")]
    public Button listButton;
    [Tooltip("音量设置按钮")]
    public Button soundButton;
    [Tooltip("音乐列表")]
    public GameObject musicListGameObject;
    [Tooltip("音量设置")]
    public GameObject soundGameObject;
    // 是否正在设置音量
    private bool isSetSound = false;
    // 是否显示音乐列表
    private bool isShowMusicList = false;

    private void Start()
    {
        isShowMusicList = false;
        musicListGameObject.SetActive(false);
        listButton.onClick.AddListener(OnListButtonClick);

        playButton.onClick.AddListener(OnPlayButtonClick);

        isSetSound = false;
        soundGameObject.SetActive(false);
        soundButton.onClick.AddListener(OnSoundButtonClick);
    }

    private void OnListButtonClick()
    {
        isShowMusicList = !isShowMusicList;
        musicListGameObject.SetActive(isShowMusicList);
    }

    private void OnPlayButtonClick()
    {
        Debug.Log("play");
    }

    private void OnSoundButtonClick()
    {
        isSetSound = !isSetSound;
        soundButton.gameObject.SetActive(isSetSound);
    }
}
