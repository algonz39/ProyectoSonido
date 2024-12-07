using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsController : MonoBehaviour
{
    public FloorType floor { get; private set; }
    public Room room { get; private set; }
    private StudioEventEmitter emitter;
    private Rigidbody rb;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out FloorTypeController floorType)) 
        {
            floor = floorType.Floor;
            room = floorType.Room;
            emitter.SetParameter("FloorType", ((float)floor));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        floor = FloorType.Floor;
        room = Room.Corridor;
        rb = GetComponent<Rigidbody>();
        emitter = GetComponent<StudioEventEmitter>();
        emitter.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0) 
        {
            if (!emitter.IsPlaying()) {
                emitter.Play();
                emitter.SetParameter("FloorType", ((float)floor));
            }
        } 
        else if(emitter.IsPlaying()) emitter.Stop();
    }
}
