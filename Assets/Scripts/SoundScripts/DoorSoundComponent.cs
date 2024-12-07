using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundComponent : MonoBehaviour
{
    [SerializeField]
    private Room thisRoom;
    [SerializeField]
    private Room[] nextRooms;
    [SerializeField]
    private DoorController corridorDoor;
    [SerializeField]
    private DoorController[] nextDoors;
    [SerializeField]
    private StepsController player;
    private StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        Room myRoom = player.room;
        if(myRoom == thisRoom)
        {
            emitter.SetParameter("DoorAperture", 1.0f);
        }
        else if(myRoom == Room.Corridor) 
        {
            emitter.SetParameter("DoorAperture", corridorDoor.getApperture());
        }
        else if(myRoom == nextRooms[0])
        {
            emitter.SetParameter("DoorAperture", nextDoors[0].getApperture());
        }
        else if(nextRooms.Length > 1 && myRoom == nextRooms[1])
        {
            emitter.SetParameter("DoorAperture", nextDoors[0].getApperture());
        }
        else emitter.SetParameter("DoorAperture", 0.0f);

    }
}
