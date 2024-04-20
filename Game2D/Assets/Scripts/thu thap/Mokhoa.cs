using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mokhoa : MonoBehaviour
{/*
    public doorController[] doorsToOpen; // Mảng các DoorController cần mở khi sử dụng chìa
    private bool used = false; // Biến kiểm tra xem chìa đã được sử dụng chưa
    public GameObject[] doors;
    private void OnTriggerEnter2D(Collider2D other)
    {
          if (!used && other.gameObject.CompareTag("Key"))
        {
            // Nếu chìa chưa được sử dụng và va chạm với người chơi
            foreach (doorController door in doorsToOpen)
            {
                
                // Mở từng cửa trong mảng
                door.OpenDoor();
            }
            used = true; // Đánh dấu chìa đã được sử dụng
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
          
            // Sau đó hủy chìa khóa
          
        }
    }*/
    public doorController doorToOpen; // Cửa mà chìa này mở
    private Animator anim;
    private bool used = false; // Biến kiểm tra xem chìa đã được sử dụng chưa
    private void Awake()
    {
         ResetKey();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (!used && collision.gameObject.CompareTag("Player"))
        {
            
            // Mở cửa
            doorToOpen.OpenDoor();

            // Đánh dấu chìa đã được sử dụng
            used = true;
anim.Play("congtacbat");
           /* // Sau đó hủy chìa khóa
            Destroy(gameObject);*/
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    
    public void ResetKey()
    {
        used = false;
    }
}
