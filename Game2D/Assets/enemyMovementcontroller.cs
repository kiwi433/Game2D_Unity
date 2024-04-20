using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementcontroller : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D rb;
    private Animator anim;
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (collision.tag == "Player")
        {


            if (!facingRight)
            {

                rb.AddForce(new Vector2(-1, 0) * enemySpeed); anim.Play("thulinh_run");
            }

            else
            {

                rb.AddForce(new Vector2(1, 0) * enemySpeed); anim.Play("thulinh_run");
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            canFlip = true;

        rb.velocity = new Vector2(0, 0);

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
