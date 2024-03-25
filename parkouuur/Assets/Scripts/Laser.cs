using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, whatlsPlayer_layer;
    public GameObject death_effect;

    private void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward, out hit, Mathf.Infinity, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0,transform.position);
            GetComponent<LineRenderer>().SetPosition(1,hit.point);
            GetComponent<LineRenderer>().startWidth=0.015f+Mathf.Sin(Time.time)/80;

        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;   

        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, whatlsPlayer_layer))
        {
            Instantiate(death_effect,hit.transform.position,Quaternion.identity);

        }
    }
}
