using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform centerPoint;  // Điểm trung tâm xoay quanh
    public float radius = 2f;      // Bán kính của quỹ đạo
    public float speed = 2f;       // Tốc độ quay

    private float angle = 0f;      // Góc quay ban đầu

    void Update()
    {
        // Tính toán vị trí mới dựa trên góc và bán kính
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float y = centerPoint.position.y + Mathf.Sin(angle) * radius;

        // Gán vị trí mới cho GameObject
        transform.position = new Vector3(x, y, 0f);

        // Tăng góc theo thời gian để quay quanh điểm trung tâm
        angle += speed * Time.deltaTime;

        // Đặt lại góc nếu quá 2*PI (1 vòng quay)
        if (angle > 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
}
