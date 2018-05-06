using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentsStats : MonoBehaviour {

    [Range (0.0f, 100.0f)]
    public float lawfulness = 0.5f;

    [Range(0.0f, 100.0f)]
    public float happiness = 0.5f;

    public int availableHomes = 0;
    public int numberOfResidents = 0;

    GameObject[] residents;

    // Use this for initialization
    void Start()
    {
        residents = GameObject.FindGameObjectsWithTag("Resident");
        for (int i = 0; i < residents.Length; i++)
        {
            residents[i] = residents[i].transform.parent.gameObject;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
