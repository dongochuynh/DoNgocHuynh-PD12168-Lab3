using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lấy input từ bàn phím
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Di chuyển Player dựa trên Rigidbody2D
        rb.linearVelocity = movement * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player đã chạm vào chướng ngại vật!");
            // Làm Player biến mất
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You Win!");
            // Thêm hiệu ứng hoặc chuyển cảnh tại đây
        }
    }
}
