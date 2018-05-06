using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingPublicness
{
    PUBLIC = 0,
    PRIVATE,
}

//TODO - update this as development goes on
public enum BuildingType
{
    RESOURCES =0,
    REST,
    LEISURE,
    REST_AND_LEISURE,
    WORK,

    //These ones may not be needed, brainstorming
    GATHERING_PLACE,
    EMERGENCY,
}