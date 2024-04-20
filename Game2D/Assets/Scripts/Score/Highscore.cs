using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highscore : MonoBehaviour
{
    private PlayerMovement player;

    public Text ScoreText;
    public float Score;
    public Text HighScoreText;
    public float HighScore;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighScore = PlayerPrefs.GetFloat("Highscore"); 
        }
        else
        {
            HighScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreUI();
        HighScoreText.text = "High Score: "+ HighScore.ToString();
        if (GameController.gameController.gameWinUI.activeSelf)
        {   HighScore = PlayerPrefs.GetFloat("Highscore");
            SaveHighScore();
        }
    }
    private void UpdateScoreUI()
    {
       // Truy cập thành phần của Instance
            ScoreText.text = "Score: " + ScoreManager.Instance.Score.ToString();
       
    }
    public void SaveHighScore()
    {
        if (ScoreManager.Instance.Score > PlayerPrefs.GetFloat("Highscore")) // Sửa thành "HighScore"
        {
            PlayerPrefs.SetFloat("Highscore", ScoreManager.Instance.Score); // Sửa thành "HighScore"
        }
    }

}
