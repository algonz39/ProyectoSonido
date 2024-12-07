using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainController : MonoBehaviour
{
    [SerializeField]
    private float caveRadius, fireRange;
    [SerializeField]
    private Transform playerPos, caveTr, fireTr;
    private StudioEventEmitter emitter;
    private StudioEventEmitter stepsEmitter;

    private Vector3 cavePos, firePos;
    // Start is called before the first frame update
    void Start()
    {
        cavePos = caveTr.position;
        firePos = fireTr.position;
        emitter = GetComponent<StudioEventEmitter>();
        stepsEmitter = playerPos.GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        float caveValue = getParameterValue(cavePos, caveRadius);
        emitter.SetParameter("Cave", caveValue);
        stepsEmitter.SetParameter("Cave", caveValue);

        emitter.SetParameter("CloseToBonfire", getParameterValue(firePos, fireRange));
    }

    float getParameterValue(Vector3 position, float radius)
    {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist / radius);
    }
}
