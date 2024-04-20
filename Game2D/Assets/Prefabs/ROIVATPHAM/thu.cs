using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class thu : MonoBehaviour
{
    public Text collectedPiecesText;
    public Text puzzletext;
    public int levelToUnlock;
    int numberOfUnlockLevel;

    public GameObject[] puzzlePiecePrefabs;
    public Image[] completedPiecesImages;

    private List<GameObject> puzzlePieces = new List<GameObject>();
    private List<GameObject> collectedPieces = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject prefab in puzzlePiecePrefabs)
        {
            // Khởi tạo Prefab trước khi thêm vào danh sách
            GameObject piece = Instantiate(prefab, transform.position, Quaternion.identity);
            piece.SetActive(false); // Tắt các mảnh ghép ban đầu
            puzzlePieces.Add(piece); // Thêm Prefab vào danh sách
        }

        UpdateCollectedPiecesText();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("manh"))
        {
            CollectPuzzlePiece(other.gameObject);
        }
    }

    private void UpdateCollectedPiecesText()
    {
        string textToShow = "Danh sách các mảnh đã thu thập:\n";
        foreach (GameObject piece in collectedPieces)
        {
            textToShow += "- " + piece.name + "\n";
        }
        collectedPiecesText.text = textToShow;

        string textToShow1 = "Danh sách chứa mảnh ghép:\n";
        foreach (GameObject piece in puzzlePieces)
        {
            if (piece != null)
            {
                int index = puzzlePieces.IndexOf(piece);
                textToShow1 += " [" + index + "]  " + piece.name + "\n";
            }
        }
        puzzletext.text = textToShow1;
    }

    public void CollectPuzzlePiece(GameObject piece)
    {

        if (!collectedPieces.Contains(piece))
        {
            // Nếu chưa, thêm piece vào collectedPieces
            collectedPieces.Add(piece);
            int currentIndex = 0;
            int index = -1;
            Debug.Log("Piece" + piece);

            foreach (GameObject puzzlePiece in puzzlePieces)
            {
                if (puzzlePiece.name == piece.name)
                {
                    Debug.Log("puzzlePiece" + puzzlePiece);
                    index = currentIndex;
                    break;
                }
                currentIndex++;
            }
            if (index != -1)
            {
                completedPiecesImages[index].sprite = piece.GetComponent<SpriteRenderer>().sprite;
                completedPiecesImages[index].gameObject.SetActive(true);
            }
            Debug.Log("Chỉ số: " + index);
/*
            // Kiểm tra xem đã thu thập đủ mảnh ghép chưa
            bool allPiecesCollected = true;
            foreach (GameObject collectedPiece in collectedPieces)
            {
                if (!collectedPiece)
                {
                    allPiecesCollected = false;
                    break;
                }
            }
*/
            if (collectedPieces.Count == puzzlePieces.Count)
            {
                AssemblePuzzle();
            }

            UpdateCollectedPiecesText();
        }
    }

    public void AssemblePuzzle()
    {
       
        GameController.gameController.gameWin();
        int totalScore = (int)ScoreManager.Instance.CalculateScore(HeartScript.health, Countdown.countdown.timeRemaining);
        ScoreManager.Instance.AddScore(totalScore);
        numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
        if (numberOfUnlockLevel <= levelToUnlock)
        {
            PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
        }
        Debug.Log("Bạn đã hoàn thành bức tranh!");
    }
}