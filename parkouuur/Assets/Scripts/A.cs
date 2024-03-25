using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    public float dashSpeed;
    public Camera cam;
    Rigidbody rig;
    bool isDashing;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dashing();
        }
    }

    private void Dashing()
    {
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0f; 
        rig.AddForce(camForward * dashSpeed, ForceMode.Impulse);
        isDashing = false;
    }

}
