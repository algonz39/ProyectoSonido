using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazaController : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private Transform playerPos, pidgeonTr, fountainTr;
    [SerializeField]
    private StudioEventEmitter emitter;

    private Vector3 pidgeonPos, fountainPos;
    // Start is called before the first frame update
    void Start()
    {
        pidgeonPos = pidgeonTr.position;
        fountainPos = fountainTr.position;
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("pidgeon", getParameterValue(pidgeonPos));
        emitter.SetParameter("fountain", getParameterValue(fountainPos));
    }

    float getParameterValue(Vector3 position) {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist/maxDistance);
    }
}
