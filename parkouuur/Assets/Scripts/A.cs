using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    public float dashSpeed;
    public Camera cam;
    Rigidbody rig;
    bool isDashing;
    float coolDown;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       coolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && coolDown < 0)
        {
            isDashing = true;
            coolDown = 4;
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
