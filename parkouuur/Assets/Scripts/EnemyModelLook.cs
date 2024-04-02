using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyModelLook : MonoBehaviour
{
        GameObject player; 
    public EnemyA1 enemyA1;

    Renderer rend;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        
       
    }

    void Update()
    {
        
        if (player != null)
        {
            
            Vector3 direction = player.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

   
}
