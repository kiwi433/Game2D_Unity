using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    // Hàm để thoát khỏi trò chơi
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
