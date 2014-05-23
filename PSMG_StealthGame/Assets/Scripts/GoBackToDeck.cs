using UnityEngine;
using System.Collections;
using iViewX;

public class GoBackToDeck : MonoBehaviourWithGazeComponent
{

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override void OnGazeEnter(RaycastHit hit)
    {
        Debug.Log("Hello!");
    }

    //Reset the Element.Transform when the gaze leaves the Collider
    public override void OnGazeExit()
    {
        Debug.Log("Bye!");
    }

    public override void OnGazeStay(RaycastHit hit)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("AnDeck");
        }
    }

}
