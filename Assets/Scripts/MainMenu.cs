using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour // Simply the menu
{
    [SerializeField] GameObject settingsPanel;
    
    public void StartGame()
    { 
        
        //Application.LoadLevel("Level01");
        SceneManager.LoadScene("André");

    }

   public void OpenSettings()
   {
       settingsPanel.SetActive(true);
   }

   public void CloseSettings()
   {
       settingsPanel.SetActive(false);
   }

    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
