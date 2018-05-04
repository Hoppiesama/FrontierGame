using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Zoom
    [SerializeField]
    private float targetFOV = 0.0f;
    public float zoomSpeed = 0.0f;
    public float targetOffsetY = 0.0f;

    public float maxDistance = 20.0f;
    public float minDistance = 2.0f;
    public float maxHeight = 15.0f;
    public float minHeight = 4.0f;
    public float distanceUpperLimit = 16.0f;
    public float distanceLowerLimit = 6.0f;
    //TODO find relationship between upper and lower limits with max to calculate without need of the public floats of upper and lower.

    [SerializeField]
    private Vector3 desiredPosition = Vector3.zero;

    //Offsets for camera move
    //Basic
    public float startOffsetDistance = 0.0f;
    public float startOffsetHeight = 0.0f;
[SerializeField]
    private float offsetDistance = 0.0f;
    [SerializeField]
    private float offsetHeight = 0.0f;
    private Vector3 offset;

    //Movement and rotation
    public float moveSpeed = 0.0f;
    public float rotationSpeed = 0.0f;
    private float moveStep = 0.0f;
    private float rotStep = 0.0f;

    //Input variables
    private float inputHorizontal = 0.0f;
    private float inputVertical = 0.0f;
    private bool inputRotateLeft = false;
    private bool inputRotateRight = false;
    private Vector3 inputVector = Vector3.zero;

    //Origin point
    private GameObject camOrigin;
    private GameObject camHolster;


    

    void Start () {
        camOrigin = GameObject.FindGameObjectWithTag("CamOriginPoint");
        camHolster = GameObject.FindGameObjectWithTag("CameraHolster");

        //Set up the offset
        offsetDistance = startOffsetDistance;
        offsetHeight = startOffsetHeight;


        offset = new Vector3(camOrigin.transform.position.x, camOrigin.transform.position.y + offsetHeight, camOrigin.transform.position.z - offsetDistance);

        targetOffsetY = offset.y;
        targetFOV = Camera.main.fieldOfView;

        //Set starting cam pos
        camHolster.transform.position = camOrigin.transform.position + offset;
        desiredPosition = camHolster.transform.position;

        //set up starting rotation
        Quaternion targetRotation = Quaternion.LookRotation(camOrigin.transform.position - transform.position);
        this.transform.localRotation = targetRotation;
    }
	
    //TODO - see below
    //Camera zoom limited distance upper bound and lower bound

	void Update ()
    {


    }

    void LateUpdate()
    {
        moveStep = moveSpeed * Time.deltaTime;
        rotStep = rotationSpeed * Time.deltaTime;

        //Process inputs
        GetInputs();

        //Forward vector relative to the camera along the x-z plane   
        Vector3 camRelativeForward = transform.TransformDirection(Vector3.forward);
        camRelativeForward.y = 0;
        camRelativeForward = camRelativeForward.normalized;

        //Right vector relative to the camera always orthogonal to the forward vector
        Vector3 cam_relative_right = new Vector3(camRelativeForward.z, 0, -camRelativeForward.x);

        inputVector = inputHorizontal * cam_relative_right + inputVertical * camRelativeForward;

        //ProcessZoom
        ProcessZoom();

        //Process movement
        ProcessMove();

        //Process rotation
        ProcessRotation();

        desiredPosition = camHolster.transform.position;
        //Update cams position from holster
        this.transform.position = Vector3.MoveTowards(this.transform.position, desiredPosition, moveSpeed);
        Quaternion targetRotation = Quaternion.LookRotation(camOrigin.transform.position - camHolster.transform.position);
        this.transform.localRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotStep * 4.0f);

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
        offset.y = Mathf.Lerp(offset.y, targetOffsetY, moveStep * 0.5f);
    }

    private void ProcessZoom()
    {
        //   Debug.Log("ScrollValue: " + Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 40)
            {
                targetFOV--;
                if (Camera.main.fieldOfView < 45 || (Camera.main.fieldOfView > 70))
                {
                   targetOffsetY -= 0.25f; 
                }
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView < 75)
            {
                targetFOV++;
                if ((Camera.main.fieldOfView < 45 || Camera.main.fieldOfView > 70))
                {
                    targetOffsetY += 0.25f;
                }
            }
        }

        targetOffsetY = Mathf.Clamp(targetOffsetY, minHeight, maxHeight);

        camHolster.transform.position = camOrigin.transform.position + offset;

    }

    private void ProcessRotation()
    {
        //If both pressed, don't do anything
        if (inputRotateLeft && inputRotateRight)
        {
            return;
        }

        if (inputRotateRight)
        {
            //Rotate Right
            RotateRight();
        }

        if (inputRotateLeft)
        {
            //Rotate Left
            RotateLeft();
        }


    }

    //Movement can make use of camera relative movement from previous project
    private void ProcessMove()
    {
        if (inputVector != Vector3.zero)
        {
            camOrigin.transform.position = Vector3.Lerp(camOrigin.transform.position, camOrigin.transform.position + ( inputVector), moveSpeed * Time.deltaTime) ;
            camHolster.transform.position = camOrigin.transform.position + offset;

            Vector3 testing1 = camHolster.transform.position;
            testing1.y = camOrigin.transform.position.y;

            Debug.Log("Distance: " + Vector3.Distance(testing1, camOrigin.transform.position));
        }
    }

    private void GetInputs()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        inputRotateLeft = Input.GetButton("RotateCamLeft");
        inputRotateRight = Input.GetButton("RotateCamRight");
    }


    private void RotateRight()
    {
        ////move to player location
        camHolster.transform.position = RotatePointAroundPivot(camHolster.transform.position, camOrigin.transform.position, new Vector3(0.0f, (-rotationSpeed * 0.25f), 0.0f));
        Vector3 temp1 = new Vector3(camHolster.transform.position.x, camOrigin.transform.position.y, camHolster.transform.position.z);
        camHolster.transform.rotation = Quaternion.LookRotation(camOrigin.transform.position - temp1);

        offset = camHolster.transform.position - camOrigin.transform.position;
        targetOffsetY = offset.y;
    }

    private void RotateLeft()
    {
        ////move to player location
        camHolster.transform.position = RotatePointAroundPivot(camHolster.transform.position, camOrigin.transform.position, new Vector3(0.0f, (rotationSpeed * 0.25f), 0.0f));
        Vector3 temp1 = new Vector3(camHolster.transform.position.x, camOrigin.transform.position.y, camHolster.transform.position.z);
        camHolster.transform.rotation = Quaternion.LookRotation(camOrigin.transform.position - temp1);

        offset = camHolster.transform.position - camOrigin.transform.position;
        targetOffsetY = offset.y;
    }


    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

}
