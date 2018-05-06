using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Resource
{
    VEGETABLE = 0,
    MEAT,
    WATER,
    WOOD,
    NAILS,

};

public class Storehouse : MonoBehaviour {



    public int maxVegetables = 10;
    public int maxMeat = 10;
    public int maxWater = 20;
    public int maxWood = 20;
    public int maxNails = 10;

    //Tier 1

        //Sustainance
    public int vegetables = 0;
    public int meat = 0;
    public int water = 0;

        //Building Resources
    public int wood = 0;
    public int nails = 0;
    //TODO complete



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public int AddResourceToStorage(Resource _res, int quantity)
    {
        int remainder = 0;
        switch ( _res)
        {
            case Resource.VEGETABLE:
                {
                    if ((vegetables + quantity) < maxVegetables)
                    {
                        vegetables += quantity;
                        return 0;
                    }
                    else
                    {
                        //TODO loop to add based on quantity, return remainder;
                        return remainder;
                    }
                }
            case Resource.MEAT:
                {
                    return 0;
                }
            case Resource.WATER:
                {
                    return 0;
                }
            case Resource.WOOD:
                {
                    return 0;
                }
            case Resource.NAILS:
                {
                    return 0;
                }
            default:
                {
                    Debug.Log("Unkown Resource, case switch potentially incomplete.");
                    return 0;
                }
        }
    }

}
