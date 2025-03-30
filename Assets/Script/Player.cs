using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Cài Đặt Di Chuyển")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Hiệu Ứng Chết")]
    public GameObject dieEffect;
    public AudioClip deathSound;
    public float respawnDelay = 2f;

    private bool isDead = false;

    [Header("Điểm Hồi Sinh")]
    public Transform respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        // Nếu chưa đặt checkpoint, lấy vị trí ban đầu làm respawn
        if (respawnPoint == null)
        {
            respawnPoint = transform;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            rb.linearVelocity = movement.normalized * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("DeadlyObstacle") ||
            collision.gameObject.CompareTag("RotatingObstacle")) // Chết khi chạm vật xoay
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadlyObstacle") || other.CompareTag("RotatingObstacle"))
        {
            Die();
        }
        else if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform; // Cập nhật điểm hồi sinh
        }
        else if (other.CompareTag("WinPoint")) // Điểm chiến thắng
        {
            SceneManager.LoadScene("WinScene"); // Chuyển sang màn Win
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("☠️ Player đã chết!");

        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        if (dieEffect != null)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
        }

        // Xóa toàn bộ kẻ địch cũ
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        gameObject.SetActive(false);

        // Hồi sinh sau 2 giây
        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        isDead = false;
        gameObject.SetActive(true);
        transform.position = respawnPoint.position; // Hồi sinh tại checkpoint
    }

    // Nút chơi lại
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Nút quay lại menu
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}