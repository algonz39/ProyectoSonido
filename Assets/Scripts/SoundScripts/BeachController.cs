using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachController : MonoBehaviour
{
    [SerializeField]
    private float roomEntranceZ, roomLengthZ, maxDistance;
    [SerializeField]
    private Transform playerPos, seagull;
    private StudioEventEmitter emitter;

    private Vector3 seagullPos;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
        seagullPos = seagull.position;
    }

    // Update is called once per frame
    void Update()
    {
        float seaValue = Mathf.Clamp01(Math.Abs(playerPos.position.z - roomEntranceZ) / roomLengthZ);
        emitter.SetParameter("CloseTo Sea", seaValue);
        emitter.SetParameter("CloseTo Seagull", getParameterValue(seagullPos));
    }

    float getParameterValue(Vector3 position)
    {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist / maxDistance);
    }
}
