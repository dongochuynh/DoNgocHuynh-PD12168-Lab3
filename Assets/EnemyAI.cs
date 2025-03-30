using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f; // Tốc độ đuổi theo Player
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Di chuyển về phía Player
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("☠️ Player bị kẻ địch tấn công!");
            other.GetComponent<Player>().Die(); // Gọi hàm Die() của Player
        }
    }

}
