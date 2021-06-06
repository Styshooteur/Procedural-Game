
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField]  GameObject pauseMenu;
    [SerializeField]  GameObject optionMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                optionMenu.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    
    public void Options ()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        optionMenu.SetActive(true);
        
    }
    
    public void Return ()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    
    public void Resume()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
  
}
