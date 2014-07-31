using UnityEngine;
using System.Collections;

public class GazeInput : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;
	Vector3 gazePos = Vector3.zero;
	Vector3 rightEyePos = Vector3.zero;
	Vector3 leftEyePos = Vector3.zero;
	
	/// <summary>
	/// Returns Vector3 gaze position.
	/// </summary>
	
	public Vector3 Position() {	
		rightEyePos = gazeModel.posGazeRight;
		leftEyePos = gazeModel.posGazeLeft;
		return gazePos = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
	}
	
	public RaycastHit rayTarget()
	{
		ray = Camera.main.ScreenPointToRay((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
