using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum FloorType
{
    Floor,
    Grass,
    Snow,
    Sand,
    Wet,
}
[Serializable]
public enum Room
{
    Corridor,
    Beach,
    Forest,
    Mountain,
    Plaza,
    Avenue,
    Office
}

public class FloorTypeController : MonoBehaviour
{
    [SerializeField]
    private FloorType floor;
    [SerializeField]
    private Room room;

    public FloorType Floor => floor;
    public Room Room => room;
}
