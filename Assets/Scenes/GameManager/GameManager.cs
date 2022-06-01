using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay;
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke(nameof(Restart), restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
