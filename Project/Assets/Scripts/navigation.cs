using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navigation : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuUI;

    public static bool paused = false;

    void Update(){
        pauseGame();
    }

    public void sceneChange(string level){
        SceneManager.LoadScene(level);
        
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void pauseGame(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }else{
                Pause();
            }
            
        }
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        paused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        paused = true;
    }
    
}
