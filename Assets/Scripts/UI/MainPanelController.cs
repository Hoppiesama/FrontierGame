using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelController : MonoBehaviour {

    private GameObject[] panels;
    public GameObject overviewPanel;
    public GameObject buildPanel;
    public GameObject peoplePanel;
    public GameObject tradePanel;
    public GameObject objectivesPanel;

    public enum PanelID
    {
        OVERVIEW = 0,
        BUILD,
        PEOPLE,
        TRADE,
        OBJECTIVE
    }

	// Use this for initialization
	void Start () {
        panels = new GameObject[5];
        panels[0] = overviewPanel;
        panels[1] = buildPanel;
        panels[2] = peoplePanel;
        panels[3] = tradePanel;
        panels[4] = objectivesPanel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePanel(int panelID)
    {
        switch (panelID)
        {
            case (int)PanelID.OVERVIEW:
                {
                    overviewPanel.GetComponent<SubPanelController>().TogglePanelOpen();
                    CloseAllOtherPanels(overviewPanel);
                    break;
                }
            case (int)PanelID.BUILD:
                {
                    buildPanel.GetComponent<SubPanelController>().TogglePanelOpen();
                    CloseAllOtherPanels(buildPanel);
                    break;
                }
            case (int)PanelID.PEOPLE:
                {
                    peoplePanel.GetComponent<SubPanelController>().TogglePanelOpen();
                    CloseAllOtherPanels(peoplePanel);
                    break;
                }
            case (int)PanelID.TRADE:
                {
                    tradePanel.GetComponent<SubPanelController>().TogglePanelOpen();
                    CloseAllOtherPanels(tradePanel);
                    break;
                }
            case (int)PanelID.OBJECTIVE:
                {
                    objectivesPanel.GetComponent<SubPanelController>().TogglePanelOpen();
                    CloseAllOtherPanels(objectivesPanel);
                    break;
                }
        }
    }

    private void CloseAllOtherPanels(GameObject exception)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != exception)
            {
                panels[i].GetComponent<SubPanelController>().ClosePanel();
            }
        }
    }

}
