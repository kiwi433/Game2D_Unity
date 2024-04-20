using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    public static Countdown countdown;
    public float timeRemaining; // Thời gian đếm ngược ban đầu (ví dụ: 5 phút)
    public Text countdownText; // Text để hiển thị thời gian đếm ngược
    public Color warningColor = Color.red; // Màu sắc cảnh báo khi thời gian gần hết
    private Color originalColor; // Màu sắc ban đầu của văn bản

    void Start()
    {
        countdown = FindObjectOfType<Countdown>();
        // Lưu màu sắc ban đầu của văn bản
        originalColor = countdownText.color;
    }

    void Update()
    {
        if (!GameController.gameController.gamePauseUI.activeSelf && !GameController.gameController.gameWinUI.activeSelf && !GameController.gameController.gameOverUI.activeSelf)
        {
            if (timeRemaining > 0)
            {
                // Giảm thời gian đếm ngược mỗi khung hình
                timeRemaining -= Time.deltaTime;

                // Hiển thị thời gian đếm ngược dưới dạng phút và giây
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);

                // Cập nhật text hiển thị thời gian đếm ngược
                countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                // Kiểm tra nếu thời gian còn lại ít hơn hoặc bằng 10 giây
                if (timeRemaining <= 10f)
                {
                    // Thay đổi màu của văn bản thành màu cảnh báo
                    countdownText.color = warningColor;
                }
            }
            else
            {
                // Xử lý khi thời gian đếm ngược kết thúc (ví dụ: hiển thị thông báo, kết thúc trò chơi)
                countdownText.text = "00:00";
                GameController.gameController.gameOver();
                Debug.Log("Hết thời gian!");
                // Thực hiện các hành động khi thời gian kết thúc
            }
        }

    }
    public void IncreaseTime(float amount)
    {
        timeRemaining += amount;
    }
}
