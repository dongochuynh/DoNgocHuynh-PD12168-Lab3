using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của kẻ địch
    public float spawnRate = 0.5f;   // Thời gian tạo mỗi kẻ địch
    public float spawnRadius = 0.5f; // Khoảng cách sinh ra quanh Spawner
    public LayerMask playerLayer;  // Lớp của Player

    private Transform player;
    private bool canSeePlayer = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(CheckForPlayer), 0f, 0.5f); // Kiểm tra mỗi 0.5s
    }

    void CheckForPlayer()
    {
        if (player == null) return;

        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, playerLayer);

        // Nếu tia Raycast trúng Player -> Bắt đầu spawn
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            if (!canSeePlayer)
            {
                canSeePlayer = true;
                InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
            }
        }
        else
        {
            canSeePlayer = false;
            CancelInvoke(nameof(SpawnEnemy)); // Dừng spawn nếu mất tầm nhìn
        }
    }

    void SpawnEnemy()
    {
        if (player == null || !player.gameObject.activeSelf) return; // Nếu Player chết, không sinh địch

        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
