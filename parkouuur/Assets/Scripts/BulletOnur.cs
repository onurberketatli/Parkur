using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnur : MonoBehaviour
{
    public float life = 3;
    public GameObject turret;
    public GameObject enemy_dead_effect;
    public AudioClip enemy_explosion;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            GetComponent<AudioSource>().PlayOneShot(enemy_explosion);
            Instantiate(enemy_dead_effect,turret.transform.position,Quaternion.identity);
            Destroy(collision.gameObject); 
        }
        Destroy(gameObject);
    }
}