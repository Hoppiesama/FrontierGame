using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OccupantsController : MonoBehaviour {

    public int maxOccupants = 0;
    List<GameObject> occupants;


    public BuildingPublicness publicness;



    //TODO based on building state enducer, do stuff. E.g. Add to their happiness based on leisure activity.
    public CharacterState buildingStateEnducer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool EnterBuilding(GameObject characterGameObject)
    {
        //If public space, limited capacity
        if (publicness == BuildingPublicness.PUBLIC)
        {
            //If there's space inside
            if (occupants.Count < maxOccupants)
            {
                //Join the fun
                occupants.Add(characterGameObject);
                
                return true;
            }
            //Or there's not enough room at the inn.
            return false;
        }
        else
        {
            //It's a private building, you must own it to go in. (Checked elsewhere).
            occupants.Add(characterGameObject);
            return true;
        }
    }

    public void ExitBuilding(GameObject characterGameObject)
    {
        occupants.Remove(characterGameObject);
    }


    private void disableCharacter(GameObject character)
    {
        character.GetComponent<CharacterController>().enabled = false;
        character.GetComponent<MeshRenderer>().enabled = false;
    }

    private void enableCharacter(GameObject character)
    {
        character.GetComponent<CharacterController>().enabled = true;
        character.GetComponent<MeshRenderer>().enabled = true;
    }
}
