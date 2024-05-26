using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public EnemyA1 enemya1;
    float timer = 0;
    float distance;
    GameObject oyuncu;
    public GameObject enemy_deatheffect;
    public AudioClip enemy_explosion;

    void Start()
    {
        Instantiate(enemya1.model, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player");
        distance = Vector3.Distance(transform.position , oyuncu.transform.position);
        GunCoolDown();
    }

    public void GunCoolDown()
    {
        timer += Time.deltaTime;
        if (timer > enemya1.cooldown && distance < 40)
        {
            Debug.Log("Shoot");
            timer = 0;
            Firlat();
        }
    }

    void Firlat()
    {
        // F�rlatma noktas� (Player tag'ine sahip obje)
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Player objesi bulunamazsa i�lemi sonland�r
        if (players.Length == 0)
        {
            Debug.LogWarning("Player objesi bulunamad�!");
            return;
        }

        // F�rlatma noktas�n� belirle
        Transform firlatmaNoktasi = players[0].transform;

        // Yeni bir obje olu�tur
        GameObject yeniObj = Instantiate(enemya1.ammo, transform.position, Quaternion.identity);

        // Olu�turulan objeyi f�rlat
        Rigidbody rb = yeniObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 firlatmaYonu = (firlatmaNoktasi.position - transform.position).normalized;
            rb.AddForce(firlatmaYonu * enemya1.firlatmaGucu, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Firlatilan obje Rigidbody bile�eni i�ermiyor!");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Bullet"))
        {
            GetComponent<AudioSource>().PlayOneShot(enemy_explosion);
            Instantiate(enemy_deatheffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Enemy �ld�");
        }
    }
}
