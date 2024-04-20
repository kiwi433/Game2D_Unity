using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hiendanhsach : MonoBehaviour
{
    public Text collectedPiecesText;
    private List<GameObject> collectedPieces = new List<GameObject>();

    // Gọi hàm này mỗi khi thu thập một mảnh mới
    public void CollectPuzzlePiece(GameObject piece)
    {
        collectedPieces.Add(piece);

        // Cập nhật nội dung của Text UI
        UpdateCollectedPiecesText();
    }

    // Cập nhật nội dung của Text UI để hiển thị danh sách các mảnh đã thu thập
    private void UpdateCollectedPiecesText()
    {
        string textToShow = "Danh sách các mảnh đã thu thập:\n";
        foreach (GameObject piece in collectedPieces)
        {
            textToShow += "- " + piece.name + "\n";
        }
        collectedPiecesText.text = textToShow;
    }
}
