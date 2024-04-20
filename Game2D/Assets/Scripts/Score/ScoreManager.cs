using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText; // Tham chiếu đến văn bản UI để hiển thị điểm
    public Text scoreText1; // Tham chiếu đến văn bản UI để hiển thị điểm
    public int Score = 0; // Biến lưu trữ điểm số

    public float timeRemainingToScoreRatio = 1.0f; // Hệ số chuyển đổi thời gian còn lại thành điểm số
    private int enemiesDefeatedScoreRatio = 10;
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Hàm để thêm điểm vào điểm số
    public void AddScore(int amount)
    {
        Score += amount; // Tăng điểm số
        UpdateScoreText(); // Cập nhật văn bản UI để hiển thị điểm số mới
    }

    // Hàm để cập nhật văn bản UI để hiển thị điểm số
   public  void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString(); // Cập nhật văn bản để hiển thị điểm số
        scoreText1.text = "Score: " + Score.ToString(); // Cập nhật văn bản để hiển thị điểm số
    }

    // Phương thức tính điểm từ mạng còn lại của người chơi và thời gian còn lại
    public float CalculateScore(float remainingHealth, float remainingTime)
    {
        // Tính điểm từ mạng còn lại của người chơi và thời gian còn lại
        float healthScore = Mathf.RoundToInt(remainingHealth * 10f); // Ví dụ: Mỗi 1 điểm mạng sẽ đóng góp 0.5 điểm cho điểm số tổng cộng
        float timeScore = Mathf.RoundToInt(remainingTime * timeRemainingToScoreRatio);

        // Tổng điểm
        float totalScore = healthScore + timeScore;

        return totalScore;
    }
    public int CalculateEnemyDefeatedScore(int enemiesDefeated)
    {
        // Tính điểm từ số quái vật tiêu diệt
        int enemyDefeatedScore = enemiesDefeated * enemiesDefeatedScoreRatio;
        return enemyDefeatedScore;
    }
    public int CalculateSoilScore(int soil)
    {
        // Tính điểm từ số quái vật tiêu diệt
        int SoilScore = soil * 10;
        return SoilScore;
    }
}
