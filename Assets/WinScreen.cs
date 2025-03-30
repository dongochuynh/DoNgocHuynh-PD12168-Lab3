using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene"); // Thay MainScene bằng tên màn chơi của bạn
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Nếu có màn hình menu
    }
}
