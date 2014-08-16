using UnityEngine;

public class Gaze
{	
	/// <summary>
	/// Returns Vector3 gaze position.
	/// </summary>
	
	public static Vector3 Position() {	
		Vector3 rightEyePos = gazeModel.posGazeRight;
		Vector3 leftEyePos = gazeModel.posGazeLeft;
		Vector3 gazePos = (leftEyePos + rightEyePos) * 0.5f;
		return gazePos;
	}
	
	public static RaycastHit rayTarget()
	{
		Ray ray = Camera.main.ScreenPointToRay((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
