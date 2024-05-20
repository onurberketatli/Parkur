using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public AudioSource audio;
    public AudioClip patlamsesi;
    

    void Start()
    {
        // Player tag'ine sahip objeyi bul
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player tag'ine sahip obje bulunamadý!");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Hedefe doðru bak
            Vector3 direction = playerTransform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audio.clip = patlamsesi;
            audio.Play();
            Debug.Log("patladý ses");
        }
    }
}
