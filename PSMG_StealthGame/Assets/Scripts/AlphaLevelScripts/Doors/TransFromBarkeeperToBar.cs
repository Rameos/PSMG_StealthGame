using UnityEngine;
using System.Collections;
using iViewX;

public class TransFromBarkeeperToBar : MonoBehaviourWithGazeComponent {

	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () { 
		if (Input.GetKeyDown("escape")){
			Application.LoadLevel("bar");
		}
		
	} 
	
	void OnMouseEnter()
	{

	}
	
	void OnMouseExit()
	{

	}
	
	public override void OnGazeEnter(RaycastHit hit)
	{

	}
	
	public override void OnGazeExit()
	{

	}
	
	
	public override void OnGazeStay(RaycastHit hit)
	{

		
	}
	
}
