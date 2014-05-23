using UnityEngine;
using System.Collections;
using iViewX;

public class zumUnteDeck : MonoBehaviourWithGazeComponent {
    bool buttonPressed = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnGazeEnter(RaycastHit hit)
    {
        Debug.Log(" eye seeeeee");
    }

    public override void OnGazeExit()
    {
        Debug.Log(" eye not seeeing");
    }


    public override void OnGazeStay(RaycastHit hit)
    {
        Debug.Log(" eye seeeeee");

        buttonPressed = Input.GetKeyDown("space");
        if (buttonPressed)
        {
            Debug.Log("space was pressed");
            Application.LoadLevel("UnterDeck");
        }


    }

}
