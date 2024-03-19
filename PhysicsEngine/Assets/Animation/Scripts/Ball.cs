using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            collisionInfo.gameObject.GetComponent<Rigidbody>().AddForce(collisionInfo.contacts[0].normal * 3000);
        }
    }
}
