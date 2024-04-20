using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

 
    public CinemachineVirtualCamera virtualCamera;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); // Tìm đối tượng PlayerMovement trong scene
        if (playerMovement == null)
        {
            Debug.LogError("Không tìm thấy đối tượng PlayerMovement hoặc PlayerMovement không được gắn với GameObject Player.");
        }
    }

    void LateUpdate()
    {
        float dirX = playerMovement.GetDirX(); // Lấy giá trị dirX từ PlayerMovement

        // Điều chỉnh hướng của camera dựa trên giá trị dirX
        if (dirX < 0f)
        {
            // Điều chỉnh hướng camera theo trái
            // Ví dụ:
            virtualCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (dirX > 0f)
        {
            // Điều chỉnh hướng camera theo phải
            // Ví dụ:
            virtualCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}





