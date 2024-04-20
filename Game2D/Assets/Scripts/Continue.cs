using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    public GameObject dialogPanel; // Thêm biến này để trỏ tới hộp thoại
    public RectTransform fader;

    private void Start()
    {

        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
            Time.timeScale = 0f;
            dialogPanel.SetActive(true);
        });

    }
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Phương thức này được gọi từ button trong hộp thoại để tiếp tục game
    public void ContinueGame()
    {
        // Ẩn hộp thoại
        dialogPanel.SetActive(false);
        // Khởi động lại thời gian trong game
        Time.timeScale = 1f;
    }

    // Phương thức này được gọi khi người chơi muốn bắt đầu một game mới từ menu
    public void StartNewGame()
    {
        // Tải lại scene Màn 1
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        // Hiển thị hộp thoại sau khi tải lại scene
        dialogPanel.SetActive(false);
        
        fader.gameObject.SetActive(false);
    }

}
