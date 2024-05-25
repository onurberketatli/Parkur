using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    public Transform TargerTransform;
    public Vector3 Offset;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = TargerTransform.position + Offset;
    }
}
