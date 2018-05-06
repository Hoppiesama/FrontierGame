using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public float regularTime = 1.0f;
    public float fastTime = 2.0f;
    public float superFastTime = 4.0f;


	// Use this for initialization
	void Start () {
        Time.timeScale = regularTime;
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInputs();
	}

    private void ProcessInputs()
    {
        if (Input.GetButton("RegularTime"))
        {
            Time.timeScale = regularTime;
        }
        else if (Input.GetButton("FastTime"))
        {
            Time.timeScale = fastTime;
        }
        else if (Input.GetButton("SuperFastTime"))
        {
            Time.timeScale = superFastTime;
        }
    }
}
