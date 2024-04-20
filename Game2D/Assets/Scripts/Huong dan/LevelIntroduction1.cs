using System.Collections;
using UnityEngine;

public class LevelIntroduction1 : MonoBehaviour
{
    public float shootingRange;
    public GameObject shootingGuide;
    private Transform player;
    private bool guideShown = false;
    public float displayTime;

    private Coroutine hideGuideCoroutine; // Thêm một biến để lưu trữ tham chiếu tới coroutine

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng Player.");
        }
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSecondsRealtime(displayTime);
        HideShootingGuide();
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < shootingRange && !guideShown)
            {
                shootingGuide.SetActive(true);
                guideShown = true;
                hideGuideCoroutine = StartCoroutine(HideAfterDelay()); // Lưu lại tham chiếu tới coroutine
            }
        }
    }

    public void HideShootingGuide()
    {
        Time.timeScale = 1f;
        if (shootingGuide != null)
        {
            shootingGuide.SetActive(false);
        }
        else
        {
            Debug.LogWarning("shootingGuide is null!");
        }
        if (hideGuideCoroutine != null)
        {
            StopCoroutine(hideGuideCoroutine);
        }
    }
    void OnDestroy()
    {
        // Gọi phương thức HideShootingGuide() khi đối tượng bị hủy
        HideShootingGuide();
    }
}
