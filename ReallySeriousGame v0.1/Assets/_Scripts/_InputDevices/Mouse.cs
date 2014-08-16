using UnityEngine;

public class Mouse
{	
	#region mouse clicks
	public static bool leftClicked()
	{
		return Input.GetKey(KeyCode.Mouse0) ? true : false;
	}
	
	public static bool rightClicked()
	{
		return Input.GetKey(KeyCode.Mouse1) ? true : false;
	}
	#endregion
	/// <summary>
	/// Returns Vector3 position.
	/// </summary>
	public static Vector3 Position()
	{
		Vector3 mousePos = Input.mousePosition;
		return mousePos;
	}
	
	public static RaycastHit rayTarget()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
