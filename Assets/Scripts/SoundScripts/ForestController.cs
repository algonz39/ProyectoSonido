using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Vector3 pondPos;
    private StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("CloseToPond", getParameterValue(pondPos));
    }

    float getParameterValue(Vector3 position)
    {
        float dist = (playerPos.position - position).magnitude;
        return Mathf.Clamp01(1.0f - dist / maxDistance);
    }
}
