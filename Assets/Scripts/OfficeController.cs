using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    [SerializeField, Range(0.0f, 0.75f)]
    private float maxChange;
    [SerializeField, Range(1.0f, 10.0f)]
    private float changeTime;
    private StudioEventEmitter emitter;

    private float business, elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > changeTime)
        {
            elapsedTime -= changeTime;
            float change = Random.Range(-maxChange, maxChange);
            business = Mathf.Clamp01(business = change);
        }
        emitter.SetParameter("Business", business);
    }
}
