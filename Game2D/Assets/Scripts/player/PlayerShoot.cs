using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    /* [SerializeField] private GameObject _bullet;
     // Start is called before the first frame update
     void Start()
     {

     }

     void Update()
     {
         if (!GameController.gameController.gamePauseUI.activeSelf)
         {
             float directionY = Input.GetAxisRaw("Vertical");


             if (Input.GetMouseButtonDown(0))
             {
                 shoot();
             }
         }


     }
     void shoot()
     {
         *//*    yield return new WaitForSeconds(1f);*//*
         Vector3 temp = transform.position;
         temp.x += 2f;
         Instantiate(_bullet, temp, Quaternion.identity);
         *//*   StartCoroutine(shoot());*//*
     }*/
    [SerializeField] private GameObject _bullet;

    void Update()
    {
        if (!GameController.gameController.gamePauseUI.activeSelf)
        {
            float directionY = Input.GetAxisRaw("Vertical");
            bool facingRight = directionY >= 0; // Giả sử hướng phải khi directionY không âm

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector3 temp = transform.position;
        temp.x += 2f;
        GameObject bulletObject = Instantiate(_bullet, temp, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        // Lấy thông tin hướng quay hiện tại của nhân vật
        bool facingRight = transform.localScale.x > 0;

        // Xác định hướng di chuyển của đạn dựa trên hướng quay của nhân vật
        Vector2 bulletDirection = facingRight ? Vector2.right : Vector2.left;

        // Đặt vận tốc của đạn dựa trên hướng di chuyển
        bullet.SetVelocity(bulletDirection * bullet.speed);
    }
}
