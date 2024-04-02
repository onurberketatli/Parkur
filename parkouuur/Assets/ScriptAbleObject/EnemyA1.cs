using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "New Enemy", menuName ="Enemy")]
public class EnemyA1 : ScriptableObject
{
    public int damage;
    public int cooldown;
    public GameObject model;
    

    

    float timer = 0;

    public void GunCoolDown()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            Debug.Log("Shoot");
            timer = 0;
        }
    }

   

}
