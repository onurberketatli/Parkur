using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAmmo : MonoBehaviour
{
    public float life = 5;
    public GameObject gameover_menu;
    private bool isGamePasued = false;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player")) // karakter öldüðünde çýkacak panel ve sonrasýnda levelýn yeniden baþlamasý buranýn altýnda yazacak
        {
            gameover_menu.SetActive(true);
            Paused();
            print("öldün");
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            print("özölüm");
        }

        if (!collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }



    }
    private void Paused()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isGamePasued = true;
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
    }
}