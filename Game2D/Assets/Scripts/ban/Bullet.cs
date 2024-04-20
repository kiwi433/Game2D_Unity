using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
        {
            rb.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);

        }
        else
        {
            rb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }
    }

    // Phương thức này được gọi mỗi khi đạn được bắn ra
    public void SetVelocity(Vector2 direction)
    {
        // Đặt vận tốc của đạn dựa trên hướng direction và tốc độ speed
        rb.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounds") || collision.CompareTag("Obstacle") || collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
