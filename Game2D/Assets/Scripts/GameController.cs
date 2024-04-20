using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    AudioManager audioManager;
    public static GameController gameController;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject gamePauseUI;
    private HeartScript heartScript; // Thêm trường HeartScript
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        if (gameController == null)
        {
            gameController = this;

        }
        else
        {
            Destroy(gameObject);
        }  // Tìm và lưu tham chiếu đến HeartScript
        heartScript = FindObjectOfType<HeartScript>();
    }

    public void gameOver()
    {
        audioManager.PlaySFX(audioManager.gameOver);
     
        gameOverUI.SetActive(true);
    }
    public void gameWin()
    {
      
        gameWinUI.SetActive(true);
    }
    public void gamePause()
    {
    audioManager.PlaySFX(audioManager.playButton);
        Time.timeScale = 0f;
        gamePauseUI.SetActive(true);

    }
    public void gameResume()
    {
        audioManager.PlaySFX(audioManager.playButton);
        Time.timeScale = 1f;
        gamePauseUI.SetActive(false);

    }
    public void Home(int sceneId)
    {
        audioManager.PlaySFX(audioManager.playButton);

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneId);
    }
    public void Restart()
    {
        audioManager.PlaySFX(audioManager.playButton);
        Time.timeScale = 1f;
        heartScript.ReplenishHealth();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);        

    }
    public void LoadGame()
    {
        audioManager.PlaySFX(audioManager.playButton);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
