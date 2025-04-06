using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, 0, v) * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1 pressed");
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody projRb = proj.GetComponent<Rigidbody>();
        projRb.linearVelocity = firePoint.forward * projectileSpeed;
    }
}
