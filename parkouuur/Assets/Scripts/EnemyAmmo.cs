using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour
{
    public float life = 5;

    void Awake()
    {
        //Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") ) // karakter öldüðünde çýkacak panel ve sonrasýnda levelýn yeniden baþlamasý buranýn altýnda yazacak
        {
            print("öldün");
        }
        //else if (collision.gameObject.CompareTag("enemy"))
        //{
        //    print("özölüm");
        //}

        if (!collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
        
        
       
    }
}