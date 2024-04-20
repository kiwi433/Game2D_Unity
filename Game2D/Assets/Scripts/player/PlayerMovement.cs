using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    private bool grounded;
    private enum MovementState { idle, running, jumping, falling }
    public Transform guntip;
    public GameObject bullet;
    private float firerate = 0.5f;
    private float nextFire = 0;
    private bool facingRight;
    private bool doubleJump;
  [HideInInspector]  public LevelIntroduction1 enemy; // Tham chiếu tới script Enemy
    private SpriteRenderer sprite;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        enemy = FindObjectOfType<LevelIntroduction1>(); // Tìm đối tượng Enemy trong scene
        if (enemy == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Enemy hoặc Enemy không có component Enemy trên đó.");
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public float GetDirX()
    {
        return dirX;
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

    void FlipPlayer()
    {
        // Đảo hướng quay của player
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        // Đảo hướng quay của guntip
        Vector3 guntipScale = guntip.localScale;
        guntipScale.y *= -1;
        guntip.localScale = guntipScale;
    }  
    
    private void FixedUpdate()
    {
        if (grounded && !Input.GetButtonDown("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded || doubleJump)
            {
                grounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }

        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Kiểm tra nút di chuyển sang trái hoặc phải
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.A) == true ||
            Input.GetKeyDown(KeyCode.RightArrow) == true || Input.GetKeyDown(KeyCode.D) == true)
        {
            // Tắt hướng dẫn khi người chơi di chuyển sang trái hoặc phải
            if (enemy != null)
            {
                enemy.HideShootingGuide();
            }
        }

        if (Input.GetKeyDown(KeyCode.K) == true)
        {
            audioManager.PlaySFX(audioManager.ban);
            fireBullet();
        }
        UpdateAnimationState();

    }

    void UpdateAnimationState()
    {
        MovementState state;
        if (dirX < 0f)
        {
            state = MovementState.running;

            if (!facingRight)
            {
                FlipPlayer();
                facingRight = true;
            }
        }
        else if (dirX > 0f)
        {
            state = MovementState.running;

            if (facingRight)
            {
                FlipPlayer();
                facingRight = false;
            }
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 1f && Input.GetButtonDown("Jump"))
        {
            state = MovementState.jumping; audioManager.PlaySFX(audioManager.jump);
        }
        else if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Obstacle" && HeartScript.health == 0)
        {
            GameController.gameController.gameOver();
        }

    }
}