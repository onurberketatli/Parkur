using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLast : MonoBehaviour
{
    public int damage;
    public int cooldown;
    public GameObject model;
    public float firlatmaGucu = 20f;
    public GameObject ammo;
    float timer = 0;
    float distance;
    GameObject oyuncu;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player");
        distance = Vector3.Distance(transform.position, oyuncu.transform.position);
        GunCoolDown();
    }
    public void GunCoolDown()
    {
        timer += Time.deltaTime;
        if (timer > cooldown && distance < 40)
        {
            Debug.Log("Shoot");
            timer = 0;
            Firlat();
        }
    }
    void Firlat()
    {
        // Fýrlatma noktasý (Player tag'ine sahip obje)
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Player objesi bulunamazsa iþlemi sonlandýr
        if (players.Length == 0)
        {
            Debug.LogWarning("Player objesi bulunamadý!");
            return;
        }

        // Fýrlatma noktasýný belirle
        Transform firlatmaNoktasi = players[0].transform;

        // Yeni bir obje oluþtur
        GameObject yeniObj = Instantiate(ammo, transform.position, Quaternion.identity);

        // Oluþturulan objeyi fýrlat
        Rigidbody rb = yeniObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 firlatmaYonu = (firlatmaNoktasi.position - transform.position).normalized;
            rb.AddForce(firlatmaYonu * firlatmaGucu, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Firlatilan obje Rigidbody bileþeni içermiyor!");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Bullet"))
        {
           
            Destroy(this.gameObject);
            
            Debug.Log("Enemy öldü");
        }
    }
}
