using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{
    public float EffectIntensity;
    public float EffectIntensitx;
    public float EffectSpeed;

    private PositionFollower FollowerInstance;
    private Vector3 OriginalOffset;
    private float SinTime;

    void Start()
    {
        FollowerInstance = GetComponent<PositionFollower>();
        OriginalOffset = FollowerInstance.Offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        if (inputVector.magnitude > 0f)
        {
            SinTime += Time.deltaTime * EffectSpeed;
        }
        else
        {
            SinTime = 0f;
        }
        float sinAmounty = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime));
        Vector3 sinAmountX = FollowerInstance.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensitx;

        FollowerInstance.Offset = new Vector3
        {
            x = OriginalOffset.x,
            y = OriginalOffset.y + sinAmounty,
            z = OriginalOffset.z
        };

        FollowerInstance.Offset += sinAmountX;
    }
}