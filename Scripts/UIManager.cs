using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused = false;
    bool inventoryOpen = false;
    public GameObject inventoryUI;
    public Texture2D cursorArrow;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }


   void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryOpen)
            {   
               inventoryUI.SetActive(false); 
               inventoryOpen = false;
            }
            else
            {
                inventoryUI.SetActive(true); 
                inventoryOpen = true;
            }

        }
   }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
    
    public void MainMenu(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }

    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
