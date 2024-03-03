using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : Selectable, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    //在属性面板中显示方法
    [SerializeField]
    UnityEvent onClick = new();
    [SerializeField]
    UnityEvent onDown = new();
    [SerializeField]
    UnityEvent onEnter = new();
    [SerializeField]
    UnityEvent onExit = new();
    [SerializeField]
    UnityEvent onUp = new();
    [SerializeField]
    UnityEvent onPress = new();
    //声明方法名
    public UnityEvent OnClick
    {
        get
        {
            return onClick;
        }
        set
        {
            onClick = value;
        }
    }
    public UnityEvent OnDown
    {
        get
        {
            return onDown;
        }
        set
        {
            onDown = value;
        }
    }
    public UnityEvent OnEnter
    {
        get
        {
            return onEnter;
        }
        set
        {
            onEnter = value;
        }
    }
    public UnityEvent OnExit
    {
        get
        {
            return onExit;
        }
        set
        {
            onExit = value;
        }
    }
    public UnityEvent OnUp
    {
        get
        {
            return onUp;
        }
        set
        {
            onUp = value;
        }
    }
    public UnityEvent OnPress
    {
        get
        {
            return onPress;
        }
        set
        {
            onPress = value;
        }
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        // 点击监听
        IgnoreError();
        onClick.Invoke();
    }
    new public virtual void OnPointerDown(PointerEventData eventData)
    {
        // 按下监听
        IgnoreError();
        //isPress = true;
        onDown.Invoke();
    }
    new public virtual void OnPointerEnter(PointerEventData eventData)
    {    // 鼠标进入监听
        IgnoreError();
        onEnter.Invoke();
    }
    new public virtual void OnPointerExit(PointerEventData eventData)
    {     // 鼠标离开监听
        IgnoreError();
        onExit.Invoke();
    }
    new public virtual void OnPointerUp(PointerEventData eventData)
    {   // 抬起监听
        IgnoreError();
        //isPress = false;
        onUp.Invoke();
    }
    private void IgnoreError()
    {
        // 判断按钮是否可用
        if (!IsActive() || !IsInteractable())
        {
            return;
        }
    }
    /*  //按钮长按功能
    private bool isPress;
    private Selectable buttonSelectable;
    void Start() {
        buttonSelectable = GetComponent<Selectable>();
        if (!buttonSelectable) {
            buttonSelectable = gameObject.AddComponent<Selectable>();
        }
    }
    void Update() {
        if (isPress) {
            if (buttonSelectable.IsActive() && buttonSelectable.IsInteractable()) {
                m_OnPress.Invoke();
            }
        }
    }
     */
}