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
    private StudioEventEmitter emitter;

    private Vector3 pidgeonPos, fountainPos;
    // Start is called before the first frame update
    void Start()
    {
        pidgeonPos = pidgeonTr.position;
        fountainPos = fountainTr.position;
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("Pigeons", getParameterValue(pidgeonPos));
        emitter.SetParameter("Fountain", getParameterValue(fountainPos));
    }

    float getParameterValue(Vector3 position) {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist/maxDistance);
    }
}
