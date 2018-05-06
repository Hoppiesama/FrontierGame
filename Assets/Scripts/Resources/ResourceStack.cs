using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStack : MonoBehaviour {

    public Resource resource;
    [SerializeField]
    private int stackQuantity = 0;

    RaycastHit hit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetQuantity(int quantity)
    {
        stackQuantity = quantity;
    }

    public void PickUp(GameObject _parent)
    {
        transform.parent = _parent.transform;
    }

    public void PutDown(Vector3 location, bool placedOnFloor)
    {
        if (placedOnFloor)
        {
            transform.parent = null;
            if (Physics.Raycast(location, Vector3.down, out hit))
            {
                transform.position = hit.point;
            }
        }
    }
}
