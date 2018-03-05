using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour {

    public GameObject credits_panel;

    public void LoadGame()
    {
        Debug.Log("Loading a game... J/K!");
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Menu_Scene");
    }

    public void ExitGame()
    {
        if(Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void ShowCredits()
    {
        credits_panel.SetActive(true);
    }
}