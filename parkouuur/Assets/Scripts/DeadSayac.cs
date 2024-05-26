using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadSayac : MonoBehaviour
{
    private bool isGamePasued = false;
    public int deadsayac=0;
    public TMP_Text deadsayacc;
    void Start()
    {
       deadsayac= PlayerPrefs.GetInt(nameof(deadsayac));
    }

  
    void Update()
    {
        deadsayacc.text = deadsayac.ToString();
    }
    public void DeadSayacArttýr()
    {
        deadsayac++;
        PlayerPrefs.SetInt(nameof(deadsayac), deadsayac);
    }
    private void Resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isGamePasued = false;
        SceneManager.LoadScene("AnimasyonVize");
    }
    public void Play_btn()
    {
        SceneManager.LoadScene("AnimasyonVize");
        Resume();
        DeadSayacArttýr();
    }
}
