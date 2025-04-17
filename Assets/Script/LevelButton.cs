using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string sceneName; // Gán tên Scene trong Inspector (vd: "Scene 2")

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
