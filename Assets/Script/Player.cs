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
            collision.gameObject.CompareTag("RotatingObstacle"))
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
            respawnPoint = other.transform;
        }
        else if (other.CompareTag("WinPoint"))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentIndex < totalScenes - 1)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            Debug.Log("🎉 Đã đến scene cuối cùng!");
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

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        gameObject.SetActive(false);
        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        isDead = false;
        gameObject.SetActive(true);
        transform.position = respawnPoint.position;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
