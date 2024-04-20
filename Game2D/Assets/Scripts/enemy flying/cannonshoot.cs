using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonshoot : MonoBehaviour
{
    public GameObject theBoom;
    public Transform shootForm;
    public float shootTime;
    float nextShoot = 0f; public float enemySpeed;
    Rigidbody2D rb;
    public GameObject enemyGraphic; bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!facingRight && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player" && Time.time >nextShoot)
        {
            nextShoot = Time.time + shootTime;
            Instantiate(theBoom, shootForm.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }
    void flip()
    {
        if (!canFlip)//=> canflip = false
            return;
        facingRight = !facingRight;

        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;

    }
}
