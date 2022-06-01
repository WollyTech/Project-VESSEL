using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{

    #region Button for Pause Menu

    public static bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                isPaused = false;
            }
            else
            {
                Pause();
                isPaused = true;
            }
        }
    }
    #endregion

    #region Pausing, Resuming and Loading Menu

    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(0);
    }
    #endregion
}