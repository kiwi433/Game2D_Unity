using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    AudioManager audioManager;
    public float playerSpeed;
    private Rigidbody2D rd;
    private Vector2 playerDiretion;
    [SerializeField] private GameObject bullet;
    public Transform guntip;

    private float firerate = 0.5f;
    private float nextFire = 0;
    private bool facingRight;
    public int levelToUnlock;
    int numberOfUnlockLevel;
    [HideInInspector] public enemyGuide enemy; // Tham chiếu tới script Enemy

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        enemy = FindObjectOfType<enemyGuide>(); // Tìm đối tượng Enemy trong scene
        if (enemy == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Enemy hoặc Enemy không có component Enemy trên đó.");
        }
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) == true && Time.time > nextFire)
        {

            fireBullet();
            // Sau khi bắn, gọi phương thức HideShootingGuide() của Enemy để tắt hướng dẫn bắn
            if (enemy != null)
            {
                enemy.HideShootingGuide();
            }

        }

    }
    void fireBullet()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            if (!facingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }

        }
    }
    private void FixedUpdate()
    {
        if (!GameController.gameController.gamePauseUI.activeSelf)
        {
            float directionY = Input.GetAxisRaw("Vertical");
            playerDiretion = new Vector2(0, directionY).normalized;
            rd.velocity = new Vector2(0, playerDiretion.y * playerSpeed);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (collision.tag == "Shootable" && HeartScript.health == 0)
            {
                GameController.gameController.gameOver();
                audioManager.PlaySFX(audioManager.gameOver);
            }
            else if (collision.tag == "Destination")
            {
                StartCoroutine(ShowUIAndWait());
                audioManager.PlaySFX(audioManager.gamewin);
                int totalScore = (int)ScoreManager.Instance.CalculateScore(HeartScript.health, Countdown.countdown.timeRemaining);
                ScoreManager.Instance.AddScore(totalScore);
                numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
                if (numberOfUnlockLevel <= levelToUnlock)
                {
                    PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
                }
                GameController.gameController.gameWin();

            }
        }
    }
    IEnumerator ShowUIAndWait()
    {
        // Hiển thị giao diện người dùng ở đây

        // Chờ 2 giây
        yield return new WaitForSeconds(1f);
    }
}
