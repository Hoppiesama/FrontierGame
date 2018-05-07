using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    RaycastHit hit;

    private bool leftClick = false;
    private bool rightClick = false;

    private Vector3 placePos = Vector3.zero;
    private Quaternion placeRot = Quaternion.identity;

    [SerializeField]
    GameObject selected = null;
    [SerializeField]
    GameObject placingObject = null;

    public enum MouseInteractionState
    {
        UNSELECTED = 0,
        SELECTED,
        PLACING
    }

    public MouseInteractionState mouseState;

	// Use this for initialization
	void Start () {
        mouseState = MouseInteractionState.UNSELECTED;
	}
	
	// Update is called once per frame
	void Update () {
        GetInputs();

        ProcessInputs();

    }

    void ProcessInputs()
    {
        if (leftClick && mouseState == MouseInteractionState.UNSELECTED)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                string theTag = hit.transform.gameObject.tag;
                //TODO on hit;
                switch (theTag)
                {
                    case "Floor":
                        {
                            mouseState = MouseInteractionState.UNSELECTED;
                            if (selected != null)
                            {
                                //TODO close UI
                                selected = null;
                            }
                            break;
                        }
                    case "Character":
                        {
                            mouseState = MouseInteractionState.SELECTED;
                            selected = hit.transform.gameObject;
                            //TODO If UI not open, open it here.
                            break;
                        }
                    case "Building":
                        {
                            mouseState = MouseInteractionState.SELECTED;
                            selected = hit.transform.gameObject;
                            //TODO If UI not open, open it here.
                            break;
                        }
                }

            }
        }

        if (leftClick && mouseState == MouseInteractionState.SELECTED)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.tag == "Floor")
                {
                    mouseState = MouseInteractionState.UNSELECTED;
                    selected = null;
                }
            }
        }

        if (mouseState == MouseInteractionState.PLACING)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f, LayerMask.GetMask("Floor"), QueryTriggerInteraction.Ignore))
            {
                placingObject.transform.position = new Vector3(Mathf.Round(hit.point.x), hit.point.y + placingObject.GetComponent<MeshCollider>().bounds.extents.y, Mathf.Round(hit.point.z));
                placePos = placingObject.transform.position;
            }

            if (leftClick)
            {
                mouseState = MouseInteractionState.UNSELECTED;
            }
        }

    }

    void GetInputs()
    {
        leftClick = Input.GetMouseButtonDown(0);
        rightClick = Input.GetMouseButtonDown(1);
    }

    public void SetPlacingObject(GameObject newPlacing)
    {
        placingObject = Instantiate<GameObject>(newPlacing, placePos, Quaternion.identity);
        mouseState = MouseInteractionState.PLACING;
    }

    private void RotatePlacingObjectClockwise()
    {

    }

    private void RotatePlacingObjectAntiClockwise()
    {

    }
}
