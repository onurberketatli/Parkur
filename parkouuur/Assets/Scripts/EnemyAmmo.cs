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

        if (collision.gameObject.CompareTag("Player") ) // karakter �ld���nde ��kacak panel ve sonras�nda level�n yeniden ba�lamas� buran�n alt�nda yazacak
        {
            print("�ld�n");
        }
        //else if (collision.gameObject.CompareTag("enemy"))
        //{
        //    print("�z�l�m");
        //}

        if (!collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
        
        
       
    }
}