using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 3f;
    public float minY = -3f;
    public float maxY = 3f;
    private bool movingUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Khởi tạo có thể thêm code tại đây nếu cần
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= maxY)
                movingUp = false;
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= minY)
                movingUp = true;
        }
    }
}