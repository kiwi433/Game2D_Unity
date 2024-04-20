using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    /*private bool isOpen = false;

    public void Start()
    {
        ResetDoor();
    }
    public void OpenDoor()
    {
        // Kiểm tra xem cửa đã mở chưa
        if (!isOpen)
        {
            // Mở cửa

            isOpen = true;

            Debug.Log("Door opened!");
        }
    }  // Đóng cửa
    public void CloseDoor()
    {
        // Code để đóng cửa
        Debug.Log("Door dong!");
        // Đặt trạng thái của cửa thành đã đóng
        isOpen = false;

    }
    public void ResetDoor()
    {
        // Đảm bảo cửa đang được đóng
        if (isOpen)
        {
            CloseDoor();
        }

        // Các bước khác để đặt lại trạng thái của cửa nếu cần
    }
    // Kiểm tra xem cửa có mở không
    public bool IsOpen()
    {
        return isOpen;
    }*/
    private bool isOpen = false;
    private void Start()
    {
        isOpen = false;
        gameObject.SetActive(true);
    }
    // Hàm mở cửa
    public void OpenDoor()
    {
        // Kiểm tra xem cửa đã mở chưa
        if (!isOpen)
        {
            // Mở cửa
            isOpen = true;
            gameObject.SetActive(false);
            Debug.Log("Door opened!");
        }
    }
    }
