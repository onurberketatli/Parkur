using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public EnemyA1 enemya1;
    
    
    void Start()
    {

        Instantiate(enemya1.model, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    private void Update()
    {
        enemya1.GunCoolDown();
        
    }
}
