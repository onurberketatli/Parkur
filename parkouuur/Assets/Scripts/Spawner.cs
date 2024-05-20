using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private float throwForce = 10.0f;
    [SerializeField] private GameObject effect;
    [SerializeField] private float activationDistance = 10.0f; // Ko�ul i�in mesafe
    public AudioSource audio;
    public AudioClip atesses;

    private Transform playerTransform;

    private void Start()
    {
        // Player tag'ine sahip objeyi bul
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player tag'ine sahip obje bulunamad�!");
        }

        // Her saniye SpawnObject metodunu �a��r
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // Player objesi mevcut ve mesafe ko�ulu sa�lan�yor mu?
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) < activationDistance)
        {
            // Spawn point'te yeni bir obje olu�tur
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            Instantiate(effect, spawnPoint.position, spawnPoint.rotation);

            // Objeye bir Rigidbody bile�eni ekle ve kuvvet uygula
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Rigidbody'ye ileri y�nde kuvvet uygula
                rb.AddForce(spawnPoint.forward * throwForce, ForceMode.Impulse);
            }
            audio.clip = atesses;
            audio.Play();
        }
    }
}
