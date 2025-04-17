using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelMenu;         // Panel menu chính
    public GameObject panelLevelSelect;  // Panel chọn level (gán trong Inspector)

    public void PlayGame()
    {
        panelMenu.SetActive(false);

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<Player>().enabled = true;
        }
    }

    public void ShowLevelSelect()
    {
        panelMenu.SetActive(false);            // Ẩn menu chính (nếu cần)
        panelLevelSelect.SetActive(true);      // Hiện panel chọn level
    }
}
