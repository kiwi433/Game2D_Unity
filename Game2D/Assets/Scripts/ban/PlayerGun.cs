using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform guntip;
    public GameObject bullet;
    float firerate = 0.5f;
    float nextFire = 0;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    } 
    private void FixedUpdate()
    {// chuc nang tu ban phim
        if (Input.GetAxisRaw("Fire1") > 0)
            fireBullet();
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            if(facingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            }else if(!facingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
