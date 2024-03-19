using UnityEngine;
using System.Collections;
public class ComprehensiveCaseBallListener : MonoBehaviour
{
    // 列表中储存了能与布料发生碰撞的对象
    public static ArrayList clothColliders = new();
    // 列表中存储了将要进行销毁的对象
    public static ArrayList destroyGameObjects = new();
    [Tooltip("爆炸粒子预制件")]
    public GameObject explosionPrefab;
    // 指定的布料对象
    private Cloth cloth;
    void Start()
    {
        // 初始化布料对象
        cloth = GameObject.Find("Cloth").GetComponent<Cloth>();
    }

    // 碰撞检测
    private void OnTriggerEnter(Collider target)
    {
        // 移除碰撞列表中的对象
        RemoveCollider();
        // 声明一个四元数，并设置朝向
        Quaternion quaternion = new()
        {
            eulerAngles = new(270, 0, 0)
        };
        GameObject explosion = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 3), quaternion);
        if (!target.gameObject.name.Equals("Cloth"))
        {   // 与布料对象发生碰撞
            destroyGameObjects.Add(explosion);
        }
        // 进行自我销毁
        Destroy(gameObject);
    }
    private void RemoveCollider()
    {
        // 在碰撞列表中移除自身
        clothColliders.Remove(new ClothSphereColliderPair(GetComponent<SphereCollider>()));
        // 重新声明碰撞列表
        ClothSphereColliderPair[] clothSphereColliderPairs = new ClothSphereColliderPair[clothColliders.Count];
        // 初始化碰撞列表
        for (int i = 0; i < clothSphereColliderPairs.Length; i++)
        {
            clothSphereColliderPairs[i] = (ClothSphereColliderPair)clothColliders[i];
        }
        // 设置碰撞列表
        cloth.sphereColliders = clothSphereColliderPairs;
    }
}
