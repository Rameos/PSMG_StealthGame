using UnityEngine;
using System.Collections;
using iViewX;

public class BarkeeperCamCon : MonoBehaviourWithGazeComponent
{
	public Transform target;
	
	Rect upperArea, lowerArea;
	Vector3 screenPos;
	
	// Use this for initialization
	void Start()
	{
		upperArea = new Rect(0, 0, Screen.width, Screen.height/5);
		lowerArea = new Rect(0, Screen.height - Screen.height / 5, Screen.width, Screen.height / 5);
	}
	
	// Update is called once per frame
	void Update()
	{
		screenPos = camera.WorldToScreenPoint(target.position);
		print("target is " + screenPos.y + " pixels from the left");
		
		MoveCameraWithMouse();
		
		MoveCameraWithEyes();
		
	}
	
	private void MoveCameraWithMouse()
	{
		if (upperArea.Contains(Input.mousePosition))
			moveCameraDown();
		if (lowerArea.Contains(Input.mousePosition))
			moveCameraUp();
	}
	
	
	private void MoveCameraWithEyes()
	{
		if (gazeModel.isEyeTrackerRunning)
		{
			if (upperArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
			{
				moveCameraUp();
			}
			if (lowerArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
			{
				moveCameraDown();
			}
		}
	}
	
	
	private void moveCameraUp()
	{
		if (screenPos.y > -200)
		{
			transform.Translate(Vector3.up * 3 * Time.deltaTime);
		}
	}
	
	private void moveCameraDown()
	{
		if (screenPos.y < 550)
		{
			transform.Translate(Vector3.down * 3 * Time.deltaTime);
		}
	} 
	
	void OnGUI()
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
