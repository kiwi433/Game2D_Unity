using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maudat : MonoBehaviour
{
    AudioManager audioManager;
    public int levelToUnlock;
    int numberOfUnlockLevel;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (collision.tag == "soilsample")
            {
                audioManager.PlaySFX(audioManager.collect);
                soil.soilNum -= 1;

                int defeatedScore = ScoreManager.Instance.CalculateEnemyDefeatedScore(1);
                ScoreManager.Instance.AddScore(defeatedScore);
                Debug.Log("Thuthapdat" +
                    ": " + soil.soilNum + "số điểm ");
                soil.currentHealth += 20;
                Destroy(collision.gameObject);

            }
            if (soil.soilNum == 0)
            {
                 StartCoroutine(ShowUIAndWait());
            }
        }
    }
    IEnumerator ShowUIAndWait()
    {
        // Hiển thị giao diện người dùng ở đây

        // Chờ 2 giây
        yield return new WaitForSeconds(1f);

        // Tiếp tục với hành động khi đã chờ xong
        int totalScore = (int)ScoreManager.Instance.CalculateScore(HeartScript.health, Countdown.countdown.timeRemaining);
        ScoreManager.Instance.AddScore(totalScore);

        GameController.gameController.gameWin();

        numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
        if (numberOfUnlockLevel <= levelToUnlock)
        {
            PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
        }
    }
}
