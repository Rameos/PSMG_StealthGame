using UnityEngine;
using System.Collections;
using iViewX;

public class TransFromPoolToBar : MonoBehaviourWithGazeComponent {
	
	private bool isLooking = false;
	private bool isLookingEye = false; 
	private bool buttonPressed = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		buttonPressed = Input.GetKeyDown("space");
		if (isLooking && buttonPressed) {
			Debug.Log("space was pressed");
			Application.LoadLevel("bar");
		}
		
		
	}
	
	void OnMouseOver()
	{
		Debug.Log("seeeeee");
		isLooking = true;
	}
	
	void OnMouseExit()
	{
		Debug.Log("not seeeing");
		isLooking = false;
	}
	
	public override void OnGazeEnter(RaycastHit hit)
	{
		Debug.Log(" eye seeeeee");
		isLookingEye = true;
	}
	
	//Reset the Element.Transform when the gaze leaves the Collider
	public override void OnGazeExit()
	{
		Debug.Log(" eye not seeeing");
		isLookingEye = false;
	}
	
	
	public override void OnGazeStay(RaycastHit hit)
	{
		Debug.Log(" eye seeeeee");
		isLookingEye = true;
		
		buttonPressed = Input.GetKeyDown("space");
		if (isLookingEye && buttonPressed)
		{
			Debug.Log("space was pressed");
			Application.LoadLevel("bar");
		}
		
		
	}
	
}
