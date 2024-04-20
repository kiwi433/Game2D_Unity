using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;
    public static float health;
    public const string HEALTH_KEY = "PlayerHealth";
    public const float MAX_HEALTH = 3f; // Số mạng chơi tối đa
    // Start is called before the first frame update
    void Start()
    {  // Load số mạng chơi từ PlayerPrefs khi bắt đầu game
        if (PlayerPrefs.HasKey(HEALTH_KEY))
        {
            health = PlayerPrefs.GetFloat(HEALTH_KEY);
        }
        else
        {
            health = MAX_HEALTH; // Giá trị mặc định nếu chưa có trong PlayerPrefs
        }
        UpdateHearts();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (health > 3)
            health = 3;
        UpdateHearts();
    }
    void UpdateHearts()
    {
       

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                makeDead();
                break;
        }
    }
    public void addDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0; // Đảm bảo rằng health không bao giờ âm
            makeDead();
        }
        UpdateHearts();
        // Lưu số mạng chơi vào PlayerPrefs sau mỗi lần thay đổi
        PlayerPrefs.SetFloat(HEALTH_KEY, health);
        PlayerPrefs.Save();
    }

    void makeDead()
    {
        GameController.gameController.gameOver();
        Destroy(gameObject);

        /* Instantiate(enemyHeathEF,transform.position,transform.rotation);*/
    }    // Phương thức để làm đầy lại mạng chơi
    public void ReplenishHealth()
    {
        health = MAX_HEALTH;
        PlayerPrefs.SetFloat(HEALTH_KEY, health);
        PlayerPrefs.Save();
        UpdateHearts();
    }  // Phương thức để reset số mạng chơi về giá trị ban đầu
    public static void ResetHealth()
    {
        health = MAX_HEALTH;
    }
}
