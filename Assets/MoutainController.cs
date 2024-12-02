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
    [SerializeField]
    private StudioEventEmitter emitter;

    private Vector3 cavePos;
    // Start is called before the first frame update
    void Start()
    {
        cavePos = caveTr.position;
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("cave", getParameterValue(cavePos));
    }

    float getParameterValue(Vector3 position)
    {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist / maxDistance);
    }
}
