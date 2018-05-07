using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    CharacterStats stats;

    public float walkSpeed = 1.0f;
    public float runSpeed = 3.0f;

    //TODO - requires access to A* pathfinding



    //TODO remove, testing.
    public CharacterState state = CharacterState.GOING_HOME;

	// Use this for initialization
	void Start () {
        stats = GetComponent<CharacterStats>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (state == CharacterState.GOING_HOME)
        {
            if (stats.home != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, stats.home.transform.position, walkSpeed * Time.deltaTime);
            }
            else
            {
                state = CharacterState.RESTING;
            }
        }
	}

    public void SetState(CharacterState newState)
    {
        state = newState;
    }

    public CharacterState GetState()
    {
        return state;
    }
}

//State machine
public enum CharacterState
{
    WORKING = 0,
    RESTING,
    GOING_HOME,
    GOING_TO_WORK,
    LEISURE_TIME,
};