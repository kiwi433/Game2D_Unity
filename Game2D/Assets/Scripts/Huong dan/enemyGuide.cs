using System.Collections;
using UnityEngine;

public class enemyGuide : MonoBehaviour
{
    public float shootingRange = 20f; // Ngưỡng khoảng cách để hiển thị hướng dẫn bắn
    public GameObject shootingGuide; // Hướng dẫn bắn

    private Transform player; // Tham chiếu tới transform của player
    private bool guideShown = false; // Biến để kiểm tra xem hướng dẫn đã được hiển thị chưa
    public float blinkInterval = 0.5f; // Khoảng thời gian giữa các lần nháy nháy
    public Color blinkColor = Color.red; // Màu sắc khi nháy nháy

    private Color originalColor; // Màu sắc ban đầu của hướng dẫn

    private Coroutine blinkCoroutine; // Coroutine để quản lý việc nhấp nháy

    private void Start()
    {
// Lấy tham chiếu tới transform của player bằng cách tìm GameObject có tag là "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng Player.");
        }
        
    }


    private void Update()
    {
        // Kiểm tra xem biến player đã được thiết lập hay chưa
        if (player != null)
        {
            // Tính toán khoảng cách giữa Enemy và Player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Nếu khoảng cách nhỏ hơn ngưỡng và hướng dẫn chưa được hiển thị
            if (distanceToPlayer < shootingRange && !guideShown)
            {
                
                // Hiển thị hướng dẫn bắn
                shootingGuide.SetActive(true);
                guideShown = true; // Đánh dấu là hướng dẫn đã được hiển thị
            }
        }
    }

    public void HideShootingGuide()
    {
        Time.timeScale = 1f; // Tiếp tục chơi bằng cách khôi phục thời gian thực
        shootingGuide.SetActive(false); // Tắt hướng dẫn bắn
    }
}
