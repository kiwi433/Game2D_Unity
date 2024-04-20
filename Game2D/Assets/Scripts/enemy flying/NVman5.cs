using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NVman5 : MonoBehaviour
{
    public Text thulinhText;
    public static int sothulinh;
    public static Hienthiquai instance;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScore();
    }

    void UpdateScore()
    {
        sothulinh = 1;
        thulinhText.text = "X" + sothulinh;
    }

    void Update()
    {
        thulinhText.text = "X" + sothulinh;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thulinh"))
        {
            sothulinh = 0;
            // Khóa trục X của Rigidbody
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
