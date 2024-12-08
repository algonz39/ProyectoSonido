using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvenueController : MonoBehaviour
{
    [SerializeField]
    private float roomEntranceX, roomLengthX;
    [SerializeField]
    private Transform playerPos;
    private StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        float value = Mathf.Clamp01(1 - Math.Abs(playerPos.position.x - roomEntranceX) / roomLengthX);
        emitter.SetParameter("CloseToRoad", value);
    }
}
