using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manhghep : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockLevel;
    public GameObject[] puzzlePieces; // Mảng chứa các GameObject của các mảnh ghép
    public Image[] completedPiecesImages; // Mảng chứa các Image của các mảnh ghép đã hoàn thành
    private HashSet<GameObject> collectedPieces = new HashSet<GameObject>(); // Danh sách các mảnh đã thu thập
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("manh") && !collectedPieces.Contains(other.gameObject))
        {
            CollectPuzzlePiece(other.gameObject);
            Destroy(other.gameObject);    
        }
    }
    public void CollectPuzzlePiece(GameObject piece)
    {
        Debug.Log("đã vào");
        collectedPieces.Add(piece); // Đánh dấu mảnh đã được thu thập

        // Hiển thị mảnh ghép đã thu thập lên UI tương ứng
        int index = GetPieceIndex(piece);
        if (index != -1)
        {
            completedPiecesImages[index].sprite = piece.GetComponent<SpriteRenderer>().sprite;
            completedPiecesImages[index].gameObject.SetActive(true);
        }

        // Kiểm tra xem đã thu thập đủ mảnh ghép chưa
        if (collectedPieces.Count == puzzlePieces.Length)
        {
            AssemblePuzzle();
        }
        Debug.Log("manh" + index);
        Debug.Log("manh" + collectedPieces.Count);
    }

    public int GetPieceIndex(GameObject piece)
    {
        // Tìm chỉ số của mảnh ghép trong mảng puzzlePieces
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i] == piece)
            {
                return i;
            }
        }
        return -1;
    }
    public void AssemblePuzzle()
    {
        // Gọi hàm xử lý khi hoàn thành bức tranh (ví dụ: mở cửa ra khỏi phòng)
        ShowGameWinMessage();
    }

    public void ShowGameWinMessage()
    {
        GameController.gameController.gameWin();
        numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
        if (numberOfUnlockLevel <= levelToUnlock)
        {
            PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
        }
        Debug.Log("Bạn đã hoàn thành bức tranh!");
    }

    /*    public int levelToUnlock;
        int numberOfUnlockLevel;
        public Image assembledPuzzleSprite; // Component Image của hình đã ghép
        public Sprite[] puzzlePieceSprites; // Mảng chứa các sprite của các mảnh ghép
        public RectTransform[] piecePositions; // Mảng chứa vị trí của từng mảnh ghép trên hình ghép chính

        private int collectedPieces = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("manh"))
            {
                CollectPuzzlePiece();
            }
        }

        public void CollectPuzzlePiece()
        {
            if (collectedPieces < puzzlePieceSprites.Length)
            {
                // Cập nhật sprite của hình đã ghép bằng mảnh ghép mới thu thập được
                assembledPuzzleSprite.sprite = puzzlePieceSprites[collectedPieces];

                // Đặt mảnh ghép mới vào vị trí tương ứng trên hình ghép chính
                piecePositions[collectedPieces].gameObject.SetActive(true);

                collectedPieces++;

                // Kiểm tra xem đã thu thập đủ mảnh ghép chưa
                if (collectedPieces == puzzlePieceSprites.Length)
                {
                    // Gọi coroutine để hiển thị thông báo "Game Win" sau một khoảng thời gian
                  ShowGameWinMessage(); // Thời gian chờ là 2 giây (có thể thay đổi)
                }
            }
        }

          public void ShowGameWinMessage()
        {

            GameController.gameController.gameWin();
            numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
            if (numberOfUnlockLevel <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
            }
            // Hiển thị thông báo "Game Win" hoặc thực hiện các hành động khi hoàn thành bức tranh
            Debug.Log("Bạn đã hoàn thành bức tranh!");
        }
        *//*private IEnumerator ShowGameWinMessage(float delay)
        {
            // Chờ đợi một khoảng thời gian trước khi hiển thị thông báo
            yield return new WaitForSeconds(delay);
    GameController.gameController.gameWin();
            // Hiển thị thông báo "Game Win" hoặc thực hiện các hành động khi hoàn thành bức tranh
            Debug.Log("Bạn đã hoàn thành bức tranh!");
        }*/
}
