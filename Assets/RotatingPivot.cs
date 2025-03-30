using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    public float speed = 100f; // Điều chỉnh tốc độ xoay

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime); // Xoay trục Z
    }
}
