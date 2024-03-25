using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public LayerMask obstacleLayer;
    RaycastHit hit;
    public Vector3 offset;
    public GameObject bullet;
    public Transform firePoint;
    private void Update()
    {
        //Look
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,Mathf.Infinity,obstacleLayer))
        {
           transform.LookAt(hit.point);
            transform.rotation*= Quaternion.Euler(offset);
        }
        //Fire
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, firePoint.position, transform.rotation*Quaternion.Euler(-90,0,0));

        }

    }
}
