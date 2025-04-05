using UnityEngine;
public class Projectile : MonoBehaviour
{
    public float lifeTime = 2f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}