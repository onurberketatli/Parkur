using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Play_btn()
    {
        SceneManager.LoadScene("AnimasyonVize");
    }

    public void Exit_btn()
    {
        Application.Quit();
    }
}
