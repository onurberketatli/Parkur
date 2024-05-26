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
    public GameObject dash_effect;
    public GameObject playertransform;
    public AudioClip dash_sound;

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
            coolDown = 1.25f;
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
        GetComponent<AudioSource>().PlayOneShot(dash_sound);    
        GameObject effect = Instantiate(dash_effect,Camera.main.transform.position,dash_effect.transform.rotation);
        effect.transform.parent=Camera.main.transform;
        effect.transform.LookAt(transform);

        isDashing = false;
    }

}
