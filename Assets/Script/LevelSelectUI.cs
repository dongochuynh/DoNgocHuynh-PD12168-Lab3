using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    public GameObject levelSelectPanel; // Kéo cái panel này vào trong Unity Inspector

    public void ShowLevelPanel()
    {
        levelSelectPanel.SetActive(true); // Hiện Panel khi nhấn nút
    }
}
