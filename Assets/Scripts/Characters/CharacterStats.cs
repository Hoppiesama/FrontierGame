using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public float secondsBetweenStatsUpdates = 15.0f;
    private float timer = 0.0f;

    public int health = 10;
    public int hunger = 10;
    public int thirst = 10;
    public int dollars = 4;

    public GameObject home = null;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        
        if (timer >= secondsBetweenStatsUpdates)
        {
            ProcessNeeds();
        }

	}

    void ProcessNeeds()
    {
        //TODO process needs of the character
    }
}
