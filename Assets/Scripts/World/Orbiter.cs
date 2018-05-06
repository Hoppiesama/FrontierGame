using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour {

    public float orbitSpeed = 0.0f;
    private bool triggerLightOnce = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, orbitSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        if (transform.position.y < -60.0f && triggerLightOnce == false)
        {
            GetComponent<Light>().enabled = false;
            triggerLightOnce = true;
        }
        else if (transform.position.y > -60.0f && triggerLightOnce == true)
        {
            GetComponent<Light>().enabled = true;
            triggerLightOnce = false;
        }
	}
}
