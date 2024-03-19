using UnityEngine;
public class ComprehensiveCaseListener : MonoBehaviour
{
    [Tooltip("炮弹预制件")]
    public GameObject ballPrefab;
    [Tooltip("炮弹生成点")]
    public Transform targetTransform;
    [Tooltip("布料")]
    public Cloth cloth;
    // 计数器
    private int count;
    [Tooltip("发射烟雾")]
    public GameObject FireFlare;
    private void Start()
    {
        InitUI();
    }
    public void Fire()
    {
        // 实例化炮弹
        Rigidbody ballRigidbody = Instantiate(ballPrefab, targetTransform.position, targetTransform.rotation).GetComponent<Rigidbody>();
        // 向炮弹施加一个力
        ballRigidbody.AddForce((targetTransform.position - transform.position) * 500);
        // 将自身添加到布料碰撞列表
        AddCollider(ref cloth, ballRigidbody.gameObject.GetComponent<SphereCollider>());
        // 将烟雾添加到待销毁列表
        ComprehensiveCaseBallListener.destroyGameObjects.Add(Instantiate(FireFlare, targetTransform.position, targetTransform.rotation));
    }
    private void Update()
    {
        // 检测待销毁对象列表是否为空
        if (ComprehensiveCaseBallListener.destroyGameObjects.Count != 0)
        {
            // 计数器自增
            count++;
            if (count > 60)
            {
                // 销毁列表头对象
                Destroy((GameObject)ComprehensiveCaseBallListener.destroyGameObjects[0]);
                // 移除列表中的对象
                ComprehensiveCaseBallListener.destroyGameObjects.RemoveAt(0);
                // 重置计数器
                count = 0;
            }
        }
    }

    // 炮管旋转回调方法

    public void Rotate(int i)
    {
        // 炮管围绕自身坐标轴进行旋转
        transform.Rotate(Vector3.forward, i * 5);
    }
    private void AddCollider(ref Cloth cloth, SphereCollider sphereCollider)
    {
        // 重新声明碰撞器数组
        ClothSphereColliderPair[] clothSphereColliderPairs = new ClothSphereColliderPair[cloth.sphereColliders.Length + 1];
        // 初始化碰撞器数组
        for (int i = 0; i < cloth.sphereColliders.Length; i++)
        {
            clothSphereColliderPairs[i] = cloth.sphereColliders[i];
        }
        // 添加碰撞器
        clothSphereColliderPairs[^1] = new ClothSphereColliderPair(sphereCollider);
        // 储存碰撞器至列表
        ComprehensiveCaseBallListener.clothColliders.Add(clothSphereColliderPairs[^1]);
        // 设置碰撞列表
        cloth.sphereColliders = clothSphereColliderPairs;
    }
    private void InitUI()
    {
        // UI按钮屏幕自适应方法
        Vector2 editScreen = new(1381, 638);
        Transform canvas = GameObject.Find("Canvas").transform;
        // 在 Canvas 下的对象将进行位置和大小的调整
        Vector2 scaleExchange = new(Screen.width / editScreen.x, Screen.height / editScreen.y);
        for (int i = 0; i < canvas.childCount; i++)
        {
            RectTransform childRectTransform = canvas.GetChild(i).GetComponent<RectTransform>();
            // 调整其位置
            childRectTransform.position = new Vector3(
                scaleExchange.x * childRectTransform.position.x,
                scaleExchange.y * childRectTransform.position.y,
                0
            );
            // 调整其大小
            childRectTransform.sizeDelta = new Vector3(
                scaleExchange.x * childRectTransform.sizeDelta.x,
                scaleExchange.y * childRectTransform.sizeDelta.y,
                0
            );
        }
    }
}
