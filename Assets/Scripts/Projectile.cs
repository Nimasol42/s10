using UnityEngine;
public class Projectile : MonoBehaviour
{
    public float lifeTime = 2f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}

