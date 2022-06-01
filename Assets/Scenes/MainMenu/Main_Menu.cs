using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    #region Clean up Start Menu

    public GameObject mainMenuUI;
    public GameObject settingsMenuUI;
    public GameObject levelSelectMenuUI;
    public GameObject creditsMenuUI;

    void Start()
    {
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        levelSelectMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
    }
    #endregion

    #region LoadLevels

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadFinalLevel()
    {
        SceneManager.LoadScene(7);
    }
    #endregion

    #region Quit Game

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
