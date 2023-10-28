using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
