using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainController : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private Transform playerPos, caveTr;
    private StudioEventEmitter emitter;
    private StudioEventEmitter stepsEmitter;

    private Vector3 cavePos;
    // Start is called before the first frame update
    void Start()
    {
        cavePos = caveTr.position;
        emitter = GetComponent<StudioEventEmitter>();
        stepsEmitter = playerPos.GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("cave", getParameterValue(cavePos));
        stepsEmitter.SetParameter("cave", getParameterValue(cavePos));
    }

    float getParameterValue(Vector3 position)
    {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist / maxDistance);
    }
}
