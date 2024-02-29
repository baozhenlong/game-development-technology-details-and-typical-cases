using UnityEngine;

public class CollisionFilterOnGameObject : MonoBehaviour
{
    public Collider ballACollider;
    public Collider ballBCollider;
    public Collider ballCCollider;

    private void Start()
    {
        // 控制 ballCCollider 不和 ballACollider、ballBCollider 发生碰撞
        Physics.IgnoreCollision(ballACollider, ballCCollider);
        Physics.IgnoreCollision(ballBCollider, ballCCollider);
    }
}
