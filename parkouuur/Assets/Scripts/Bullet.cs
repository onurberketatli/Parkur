using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifetime = 5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * 1 * Time.deltaTime * speed);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
