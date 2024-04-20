using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectmanh : MonoBehaviour
{
    /* private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {
             Collect();
         }
     }*/

    /*  private void Collect()
      {
          // Gọi hàm xử lý thu thập mảnh ghép từ script Manhghep
          Manhghep manhghepScript = FindObjectOfType<Manhghep>();
          if (manhghepScript != null)
          {
              manhghepScript.CollectPuzzlePiece();
              Destroy(gameObject);
          }

          // Sau khi gọi hàm thu thập, bạn có thể thêm các hành động khác nếu cần
      }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
