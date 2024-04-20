using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
        {
        rb.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);

        }else rb.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);

    }
    // Update is called once per frame
    void Update()
    {

    }
    //chuc nang vien dan dung lai

    public void removeForce()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
