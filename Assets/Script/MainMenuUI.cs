using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelMenu; // Gán Panel chứa menu vào đây

    public void PlayGame()
    {
        panelMenu.SetActive(false); // Ẩn menu UI

        // Nếu muốn chuyển sang level đầu tiên:
        // SceneManager.LoadScene("Scene 1");

        // Hoặc đơn giản là reset lại vị trí player, cho chơi luôn trong scene này
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<Player>().enabled = true; // Bật script Player nếu đang bị tắt
        }
    }

    public void ShowLevelSelect()
    {
        // code hiện panel chọn level nếu cần
    }
}
