using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunOnur : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    float cooldown;
    public GameObject effect;
    public AudioClip gunshot;
    public AudioSource audioSource;
    public GameObject shot_effect;

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown < 0)
        {
            audioSource.Play();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Instantiate(effect,bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Instantiate(shot_effect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            cooldown = 1;
        }
    }
}
