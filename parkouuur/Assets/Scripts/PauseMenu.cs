using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePasued = false;

    public GameObject PauseMenu_obj;
    public GameObject music;
 
    
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePasued)
            {
                Paused();
            }
            else
            {
                Resume();
            }
        }
       
    }
    public void Pause_btn()
    {
        if (!isGamePasued)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }
    private void Paused()
    {
        Time.timeScale = 0;
        music.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenu_obj.SetActive(true);
        isGamePasued =true;
    }
    private void Resume()
    {
        Time.timeScale=1;
        music.SetActive(true);  
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu_obj.SetActive(false);     
        isGamePasued =false; 
    }
}
