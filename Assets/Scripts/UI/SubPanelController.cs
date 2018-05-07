using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPanelController : MonoBehaviour {

    private bool open = false;
   

	// Use this for initialization
	void Start () {
        SetPanelVisibility();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePanelOpen()
    {
        open = !open;
        SetPanelVisibility();
    }

    public void ClosePanel()
    {
        open = false;
        SetPanelVisibility();
    }

    private void SetPanelVisibility()
    {
        transform.gameObject.SetActive(open);
    }
}
