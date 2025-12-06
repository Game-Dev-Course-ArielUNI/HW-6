using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Called by Button #1
    public void LoadEnemyChasesPlayer()
    {
        SceneManager.LoadScene("enemy chases player");
    }

    // Called by Button #2
    public void LoadPlayerChasesEnemy()
    {
        SceneManager.LoadScene("player chases enemy");
    }

    // Optional
    public void QuitGame()
    {
        Application.Quit();
    }
}
