using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Triggered Home");
        if (col.gameObject.tag == "Character")
        {
            if (col.gameObject.GetComponent<CharacterStats>().home == this.gameObject)
            {
                //Resident lives here
                Debug.Log("Resident lives here, going inside");
                GetComponent<OccupantsController>().EnterBuilding(col.gameObject);
            }
        }
    }
}
